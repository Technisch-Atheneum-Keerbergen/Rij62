
using System.Net;
using Rij62.Models.Bancontact;

namespace Rij62.Services;

public class PaymentService
{

    private readonly HttpClient _httpClient;
    private readonly string _origin;
    private readonly string _frontendOrigin;

    public PaymentService(HttpClient httpClient, IConfiguration config)
    {
        var origin = config.GetValue<string>("Origin");
        if (origin == null)
        {
            throw new Exception("'Origin' option was null. Set this to the domain name and protocol where the app will run");
        }
        _origin = origin;
        var frontendOrigin = config.GetValue<string>("FrontendOrigin");
        if (frontendOrigin == null)
        {
            throw new Exception("'FrontendOrigin' option was null. Set this to the domain name and protocol where the app will run");
        }
        _frontendOrigin = frontendOrigin;

        httpClient.BaseAddress = config.GetValue<Uri>("Bancontact:BaseUrl");
        httpClient.DefaultRequestHeaders.Add("Authorization", config.GetValue<string>("Bancontact:ApiKey"));
        _httpClient = httpClient;
    }


    public async Task<CreatePaymentResponse> CreatePayment(decimal amount)
    {
        var resp = await _httpClient.PostAsJsonAsync("/v3/payments", new CreatePaymentRequest
        {
            Reference = "19848995",
            BulkId = "Bulk-1-200",
            Amount = amount.ToString(),
            Currency = "EUR",
            Description = "string",
            IdentifyCallbackUrl = "/payment/callback",
            CallbackUrl = _origin + "/payment/callback",
            ReturnUrl = _frontendOrigin + "/checkoutComplete",
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
