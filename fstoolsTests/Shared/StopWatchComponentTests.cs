using Bunit;
using fstools.Models;
using fstools.Services;
using fstools.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
using Xunit;

namespace fstoolsTests.Shared;

public class StopWatchComponentTests : TestContext
{
    [Fact]
    public void TestStopWatchComponent()
    {
        var jsruntime = new Mock<IJSRuntime>();
        // This replaces the Bunit version of the JSInterop with the Mock
        Services.AddScoped(_ => jsruntime.Object);

        var CollapseMock = new Mock<BootstrapBlazor.Components.Collapse>();
        Services.AddBootstrapBlazor(); //<BootstrapBlazor.Components.Collapse>();

        var cut = RenderComponent<StopwatchComponent>(
                parameters => parameters
                    .Add(p => p.timerText, "")
                    .Add(p => p.timerNumber, 0)
                    .Add(p => p.infoIn, new List<StopwatchInfo>())
                    .Add(p => p.timersIn, new List<FsTimer>())
                    .Add(p => p.fontSize, "30px")
                    .Add(p => p.showButtons, true)
                );

        var divs = cut.FindAll("div:first-child").Where(d => !d.InnerHtml.Contains("accordion")).ToList();
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<b>Pilot Reports for Area:</b>")));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<li>Line 1</li>")));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<li>Line 2</li>")));
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<li>Line 3</li>")));
    }

    [Fact]
    public void TestPirepNotFound()
    {
        var jsruntime = new Mock<IJSRuntime>();
        // This replaces the Bunit version of the JSInterop with the Mock
        Services.AddScoped(_ => jsruntime.Object);

        var CollapseMock = new Mock<BootstrapBlazor.Components.Collapse>();
        Services.AddBootstrapBlazor(); //<BootstrapBlazor.Components.Collapse>();

        var cut = RenderComponent<PirepComponent>(
                parameters => parameters
                    .Add(p => p.ICAO, "koxc")
                    .Add(p => p.WeatherInfo, null));
        var divs = cut.FindAll("div:first-child").Where(d => !d.InnerHtml.Contains("accordion")).ToList();
        Assert.NotNull(divs.Find(d => d.InnerHtml.Contains("<label>PIREP data not found</label>")));
    }
}
