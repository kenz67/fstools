using Microsoft.JSInterop;

namespace fstools.Services;

public class BrowserService(IJSRuntime jsRuntime)
{
    public string BrowserName { get; set; }
    public string BrowserVersion { get; set; }
    public string BrowserMajorVersion { get; set; }

    public string Full { get; set; }

    private readonly IJSRuntime _jsRuntime = jsRuntime;

    public async Task GetData()
    {
        if (string.IsNullOrEmpty(BrowserName))
        {
            var browserData = await _jsRuntime.InvokeAsync<string>("browserVersion");
            var parts = browserData.Split([',']);

            Full = browserData.Trim();
            if (parts.Length > 0) { BrowserName = parts[0]; }
            if (parts.Length > 1) { BrowserVersion = parts[1]; }
            if (parts.Length > 2) { BrowserMajorVersion = parts[2]; }
        }
    }

    public Boolean CanDisplayPdf()
    {
        try
        {
            return BrowserName switch
            {
                "Chrome" or "Edg" or "Microsoft Internet Explorer" => int.Parse(BrowserMajorVersion) >= 114,
                "Firefox" => int.Parse(BrowserMajorVersion) >= 112,
                "Safari" => int.Parse(BrowserMajorVersion) >= 15 && int.Parse(BrowserMajorVersion) < 100,
                _ => false,
            };
        }
        catch { return false; }
    }
}
