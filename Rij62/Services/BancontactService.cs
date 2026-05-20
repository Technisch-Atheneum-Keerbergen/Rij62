
using System.Buffers;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Jose;
using Microsoft.IdentityModel.Tokens;
using Rij62.Models.Bancontact;

namespace Rij62.Services;


public class BancontactService
{
     private readonly HttpClient _httpClient;
    private readonly UrlService _urlService;

    private readonly string _certUrl;
    private JwkSet? _cachedKeys = null;

    public BancontactService(HttpClient httpClient, IConfiguration config, UrlService urlService)
    {
        _urlService = urlService;

        var certUrl = config.GetValue<string>("Bancontact:CertUrl");
        if (certUrl == null)
        {
            throw new Exception("Bancontact:CertUrl is required");
        }
        _certUrl = certUrl;

        httpClient.BaseAddress = config.GetValue<Uri>("Bancontact:BaseUrl");
        httpClient.DefaultRequestHeaders.Add("Authorization", config.GetValue<string>("Bancontact:ApiKey"));
        _httpClient = httpClient;
    }

    private async Task<JwkSet> RefetchKeys()
    {
        var keys = await _httpClient.GetStringAsync(_certUrl);
        var jwks = JwkSet.FromJson(keys, JWT.DefaultSettings.JsonMapper);
        _cachedKeys = jwks;
        return jwks;
    }

    private async Task<Jwk> GetBancontactPubKey(string kid, bool allowRefetchKeys=true)
    {
        JwkSet jwks = _cachedKeys ?? await RefetchKeys();
        // 3. Find the matching public key
        var pubKey = jwks.Keys.FirstOrDefault(k => k.KeyId == kid);
        if (pubKey == null)
        {
            if (!allowRefetchKeys)
            {
                throw new Exception($"KeyId '{kid}' was not found in the bancontact public keys.");
            }
            _cachedKeys = null;
            return await GetBancontactPubKey(kid, allowRefetchKeys=false);
        }
        return pubKey;
    }

    public async Task ValidateCallbackSignature(string signature, ReadOnlySequence<byte> body)
    {

        // 2. Extract kid from the detached JWS header (before verifying)
        var headers = JWT.Headers(signature);  // parses just the header
        var kid = (string)headers["kid"];

        var parts = signature.Split('.');
        var bodyBase64 = Base64Url.Encode(body.ToArray());

        var pubKey = await GetBancontactPubKey(kid);

        // 4. Verify the detached JWS by re-attaching the body as the payload
        // jose-jwt handles detached content: insert the base64url(body) back into the middle slot
        var reattached = $"{parts[0]}.{bodyBase64}.{parts[2]}";

        var _ = JWT.Verify(reattached, pubKey);
    }

    public async Task<PaymentCallbackRequest> GetPaymentInfo(string paymentId)
    {
        var resp = await _httpClient.GetAsync("/v3/payments/"+paymentId);
        if (resp.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Payments API returned status code " + resp.StatusCode);
        }
        var response = await resp.Content.ReadFromJsonAsync<PaymentCallbackRequest>();
        if (response == null)
        {
            throw new NullReferenceException("Json response returned by the Payments API is null");
        }
        return response;
    }


    public async Task<CreatePaymentResponse> CreatePayment(decimal amount)
    {
        var resp = await _httpClient.PostAsJsonAsync("/v3/payments", new CreatePaymentRequest
        {
            Reference = "19848995",
            BulkId = "Bulk-1-200",
            Amount = amount.ToString(),
            Currency = "EUR",
            Description = "",
            IdentifyCallbackUrl = "/payment/callback",
            CallbackUrl = _urlService.Origin + "/payment/callback",
            ReturnUrl = _urlService.FrontendOrigin + "/checkoutComplete",
        });

        if (resp.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Payments API returned status code " + resp.StatusCode);
        }
        var response = await resp.Content.ReadFromJsonAsync<CreatePaymentResponse>();
        if (response == null)
        {
            throw new NullReferenceException("Json response returned by the Payments API is null");
        }
        return response;
    }


}