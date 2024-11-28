using Bunit;
using fstools.Models;
using fstools.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
using Xunit;

namespace fstoolsTests.Shared;

public class MetarComponentTests : TestContext
{
    [Fact]
    public void TestMetarComponent()
    {
        var WeatherInfo = new MetarInfo
        {
            WeatherData = new WeatherData
            {
                RawOb = "KOXC 231856Z 30012G22KT 10SM OVC030 07/02 A2946 RMK AO2 PK WND 32026/1840 SLP991 T00720017",
                ReportTime = new DateTime(2024, 11, 23, 19, 0, 0),
                Temp = "7.2",
                Dewp = "1.7",
                Wdir = "300",
                Wspd = "12",
                Visib = "10+",
                Altim = 997.7,
                Clouds =
                [
                    new SkyCondition { Base = 3000, Cover = "OVC" }
                ]
            }
        };

        var jsruntime = new Mock<IJSRuntime>();
        // This replaces the Bunit version of the JSInterop with the Mock
        Services.AddScoped(_ => jsruntime.Object);

        var CollapseMock = new Mock<BootstrapBlazor.Components.Collapse>();
        Services.AddBootstrapBlazor(); //<BootstrapBlazor.Components.Collapse>();

        var cut = RenderComponent<MetarComponent>(
                parameters => parameters
                    .Add(p => p.ICAO, "koxc")
                    .Add(p => p.WeatherInfo, WeatherInfo));
        var divs = cut.FindAll("div:first-child").Where(d => !d.InnerHtml.Contains("accordion")).ToList();
        var d = divs.Find(d => d.InnerHtml.Contains("<b>Raw METAR:</b> KOXC 231856Z 30012G22KT 10SM OVC030 07/02 A2946 RMK AO2 PK WND 32026/1840 SLP991 T00720017"));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<b>Raw METAR:</b> KOXC 231856Z 30012G22KT 10SM OVC030 07/02 A2946 RMK AO2 PK WND 32026/1840 SLP991 T00720017")));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<b>Report Time:</b> 11/23/2024 7:00:00 PM")));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<b>Temperature/Dewpoint:</b> 7.2°C / 1.7°C")));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<b>Wind:</b> 300 degrees at 12 knots")));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<b>Visibility:</b> 10+ statute miles")));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<b>Altimeter:</b> 29.46 Hg / 997.7 mb")));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<b>Sky Conditions:</b>")));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<ul><li>OVC at 3000' AGL</li></ul>")));
    }

    [Fact]
    public void TestMetarCloudsClearWindCalm()
    {
        var WeatherInfo = new MetarInfo
        {
            WeatherData = new WeatherData
            {
                RawOb = "KOXC 231856Z 30012G22KT 10SM OVC030 07/02 A2946 RMK AO2 PK WND 32026/1840 SLP991 T00720017",
                ReportTime = new DateTime(2024, 11, 23, 19, 0, 0),
                Temp = "7.2",
                Dewp = "1.7",
                Wdir = "0",
                Wspd = "0",
                Visib = "10+",
                Altim = 997.7,
                Clouds =
                [
                    new SkyCondition { Base = 3000, Cover = "CLR" }
                ]
            }
        };

        var jsruntime = new Mock<IJSRuntime>();
        // This replaces the Bunit version of the JSInterop with the Mock
        Services.AddScoped(_ => jsruntime.Object);

        var CollapseMock = new Mock<BootstrapBlazor.Components.Collapse>();
        Services.AddBootstrapBlazor(); //<BootstrapBlazor.Components.Collapse>();

        var cut = RenderComponent<MetarComponent>(
                parameters => parameters
                    .Add(p => p.ICAO, "koxc")
                    .Add(p => p.WeatherInfo, WeatherInfo));
        var divs = cut.FindAll("div:first-child").Where(d => !d.InnerHtml.Contains("accordion")).ToList();
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<ul><li>Clear</li></ul>")));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<b>Wind:</b> Calm")));
    }

    [Fact]
    public void TestMetarCloudsMulti()
    {
        var WeatherInfo = new MetarInfo
        {
            WeatherData = new WeatherData
            {
                RawOb = "KOXC 231856Z 30012G22KT 10SM OVC030 07/02 A2946 RMK AO2 PK WND 32026/1840 SLP991 T00720017",
                ReportTime = new DateTime(2024, 11, 23, 19, 0, 0),
                Temp = "7.2",
                Dewp = "1.7",
                Wdir = "300",
                Wspd = "12",
                Visib = "10+",
                Altim = 997.7,
                Clouds =
                [
                    new SkyCondition { Base = 3000, Cover = "SKT" },
                    new SkyCondition { Base = 9000, Cover = "OVR" }
                ]
            }
        };

        var jsruntime = new Mock<IJSRuntime>();
        // This replaces the Bunit version of the JSInterop with the Mock
        Services.AddScoped(_ => jsruntime.Object);

        var CollapseMock = new Mock<BootstrapBlazor.Components.Collapse>();
        Services.AddBootstrapBlazor(); //<BootstrapBlazor.Components.Collapse>();

        var cut = RenderComponent<MetarComponent>(
                parameters => parameters
                    .Add(p => p.ICAO, "koxc")
                    .Add(p => p.WeatherInfo, WeatherInfo));
        var divs = cut.FindAll("div:first-child").Where(d => !d.InnerHtml.Contains("accordion")).ToList();
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<ul><li>SKT at 3000' AGL</li><li>OVR at 9000' AGL</li></ul>")));
    }

    [Fact]
    public void TestMetarComponentNull()
    {
        var jsruntime = new Mock<IJSRuntime>();
        // This replaces the Bunit version of the JSInterop with the Mock
        Services.AddScoped(_ => jsruntime.Object);

        var CollapseMock = new Mock<BootstrapBlazor.Components.Collapse>();
        Services.AddBootstrapBlazor(); //<BootstrapBlazor.Components.Collapse>();

        var cut = RenderComponent<MetarComponent>(
                parameters => parameters
                    .Add(p => p.ICAO, "koxc")
                    .Add(p => p.WeatherInfo, null));
        var divs = cut.FindAll("label:first-child").ToList();
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("METAR data not found")));
    }
}
