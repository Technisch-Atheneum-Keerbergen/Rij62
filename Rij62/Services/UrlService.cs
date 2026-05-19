
namespace Rij62.Services;

public class UrlService
{

    public string Origin { get; private set; }
    public string FrontendOrigin { get; private set; }

    public UrlService(IConfiguration configuration)
    {
        var origin = configuration.GetValue<string>("Origin");
        if (origin == null)
        {
            throw new Exception("Origin config value is required.");
        }
        Origin = origin.TrimEnd('/');

        var frontendOrigin = configuration.GetValue<string>("FrontendOrigin");
        if (frontendOrigin == null)
        {
            throw new Exception("FrontendOrigin config value is required.");
        }
        FrontendOrigin = frontendOrigin.TrimEnd('/');
    }


    public string MakeAbsolute(string url)
    {
        if (url.StartsWith("https://"))
        {
            return url;
        }
        else
        {
            return Origin + "/" + url;
        }
    }
    public string TryMakeRelative(string url)
    {
        if (url.StartsWith(Origin))
        {
            return url.Substring(Origin.Length + 1);
        }
        return url;
    }
}
