using Bunit;
using fstools.Services;
using fstools.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
using Xunit;

namespace fstoolsTests.Shared;

public class MainLayoutTests : TestContext
{
    //    [Fact]
    //    public void Layout_RendersCorrectly()
    //    {
    //        var mockTimerService = new Mock<TimerService>();
    //        var mockJsRuntime = new Mock<IJSRuntime>();
    //        var mockBrowserService = new Mock<BrowserService>(MockBehavior.Default, new object[] { mockJsRuntime.Object });
    //        var mockSettingService = new Mock<SettingsService>();
    //        mockSettingService.Setup(t => t.ShowCl).Returns(false);

    //        Services.AddSingleton(mockTimerService.Object);
    //        Services.AddSingleton(mockBrowserService.Object);
    //        Services.AddSingleton(mockSettingService.Object);

    //        var component = RenderComponent<fstools.Shared.MainLayout>();

    //        component.MarkupMatches(@"
    //        <div class=""page"" >
    //  <div class=""sidebar"" >
    //    <div class=""top-row ps-3 navbar navbar-dark "" >
    //      <div class=""container-fluid"" >
    //        <span class=""fa-solid fa-plane""  style=""color:white;"" aria-hidden=""true"" ></span>
    //        <span class=""navbar-brand""  style=""color:white;"" aria-hidden=""true"" >FS Tools</span>
    //        <button title=""Navigation menu"" class=""navbar-toggler""  >
    //          <span class=""navbar-toggler-icon"" ></span>
    //        </button>
    //      </div>
    //    </div>
    //    <div class=""collapse nav-scrollable""  >
    //      <nav class=""flex-column"" >
    //        <div class=""nav-item px-3"" >
    //          <a href="""" class=""nav-link active"" aria-current=""page"">
    //            <span class=""oi oi-home"" aria-hidden=""true"" ></span>
    //            <label >Home</label>
    //          </a>
    //        </div>
    //        <div class=""nav-item px-3"" >
    //          <a href=""charts"" class=""nav-link"">
    //            <span class=""oi oi-map"" aria-hidden=""true"" ></span>
    //            <label >Charts</label>
    //          </a>
    //        </div>
    //        <div class=""nav-item px-3"" >
    //          <a href=""weather"" class=""nav-link"">
    //            <span class=""oi oi-cloudy"" aria-hidden=""true"" ></span>
    //            <label >Weather</label>
    //          </a>
    //        </div>
    //        <div class=""nav-item px-3"" >
    //          <a href=""timer"" class=""nav-link"">
    //            <span class=""oi oi-timer"" aria-hidden=""true"" ></span>
    //            <label >Timers</label>
    //          </a>
    //        </div>
    //        <div class=""nav-item px-3"" >
    //          <a href=""notes"" class=""nav-link"">
    //            <span class=""oi oi-clipboard"" aria-hidden=""true"" ></span>
    //            <label >Notes</label>
    //          </a>
    //        </div>
    //      </nav>
    //    </div>
    //    <div class=""bottom-row"" >
    //      <div class=""icon-menu-arrow"" >
    //        <span class=""oi oi-arrow-left"" style=""color: white;""  ></span>
    //      </div>
    //    </div>
    //  </div>
    //  <main >
    //    <div class=""top-row px-4"" >
    //      <div class=""col-11"" >
    //        <p style=""font-size: 20px"">Timer 1
    //          <span style=""border: black 2px solid; padding:2px"">00:00:00.0</span>
    //          <button class=""btn btn-sm btn-primary"" >Start</button>
    //          <button class=""btn btn-sm btn-primary"" disabled="""" >Pause</button>
    //          <button class=""btn btn-sm btn-danger"" disabled="""" >Stop</button>
    //        </p>
    //      </div>
    //    </div>
    //    <article class=""content px-4"" ></article>
    //  </main>
    //</div>
    //");
    //    }

    //    [Fact]
    //    public void Layout_RendersWithCLCorrectly()
    //    {
    //        var mockTimerService = new Mock<TimerService>();
    //        var mockJsRuntime = new Mock<IJSRuntime>();
    //        var mockBrowserService = new Mock<BrowserService>(MockBehavior.Default, new object[] { mockJsRuntime.Object });
    //        var mockSettingService = new Mock<SettingsService>();
    //        mockSettingService.Setup(t => t.ShowCl).Returns(true);

    //        Services.AddSingleton(mockTimerService.Object);
    //        Services.AddSingleton(mockBrowserService.Object);
    //        Services.AddSingleton(mockSettingService.Object);

    //        var component = RenderComponent<fstools.Shared.MainLayout>();

    //        component.MarkupMatches(@"
    //  <div class=""page"" >
    //  <div class=""sidebar"" >
    //    <div class=""top-row ps-3 navbar navbar-dark "" >
    //      <div class=""container-fluid"" >
    //        <span class=""fa-solid fa-plane""  style=""color:white;"" aria-hidden=""true"" ></span>
    //        <span class=""navbar-brand""  style=""color:white;"" aria-hidden=""true"" >FS Tools</span>
    //        <button title=""Navigation menu"" class=""navbar-toggler""  >
    //          <span class=""navbar-toggler-icon"" ></span>
    //        </button>
    //      </div>
    //    </div>
    //    <div class=""collapse nav-scrollable""  >
    //      <nav class=""flex-column"" >
    //        <div class=""nav-item px-3"" >
    //          <a href="""" class=""nav-link active"" aria-current=""page"">
    //            <span class=""oi oi-home"" aria-hidden=""true"" ></span>
    //            <label >Home</label>
    //          </a>
    //        </div>
    //        <div class=""nav-item px-3"" >
    //          <a href=""charts"" class=""nav-link"">
    //            <span class=""oi oi-map"" aria-hidden=""true"" ></span>
    //            <label >Charts</label>
    //          </a>
    //        </div>
    //        <div class=""nav-item px-3"" >
    //          <a href=""weather"" class=""nav-link"">
    //            <span class=""oi oi-cloudy"" aria-hidden=""true"" ></span>
    //            <label >Weather</label>
    //          </a>
    //        </div>
    //        <div class=""nav-item px-3"" >
    //          <a href=""timer"" class=""nav-link"">
    //            <span class=""oi oi-timer"" aria-hidden=""true"" ></span>
    //            <label >Timers</label>
    //          </a>
    //        </div>
    //        <div class=""nav-item px-3"" >
    //          <a href=""notes"" class=""nav-link"">
    //            <span class=""oi oi-clipboard"" aria-hidden=""true"" ></span>
    //            <label >Notes</label>
    //          </a>
    //        </div>
    //        <div class=""nav-item px-3"" >
    //          <a href=""checklists"" class=""nav-link"">
    //            <span class=""oi oi-circle-check"" aria-hidden=""true"" ></span>
    //            <label >Check List</label>
    //          </a>
    //        </div>
    //      </nav>
    //    </div>
    //    <div class=""bottom-row"" >
    //      <div class=""icon-menu-arrow"" >
    //        <span class=""oi oi-arrow-left"" style=""color: white;""  ></span>
    //      </div>
    //    </div>
    //  </div>
    //  <main >
    //    <div class=""top-row px-4"" >
    //      <div class=""col-11"" >
    //        <p style=""font-size: 20px"">Timer 1
    //          <span style=""border: black 2px solid; padding:2px"">00:00:00.0</span>
    //          <button class=""btn btn-sm btn-primary"" >Start</button>
    //          <button class=""btn btn-sm btn-primary"" disabled="""" >Pause</button>
    //          <button class=""btn btn-sm btn-danger"" disabled="""" >Stop</button>
    //        </p>
    //      </div>
    //    </div>
    //    <article class=""content px-4"" ></article>
    //  </main>
    //</div>
    //");
    //    }

    [Fact]
    public void ToggleIconMenu_UpdatesCssClassCorrectly()
    {
        var mockMainLayout = new Mock<MainLayout>() { CallBase = true };

        var mockTimerService = new Mock<TimerService>();
        var mockJsRuntime = new Mock<IJSRuntime>();
        var mockBrowserService = new Mock<BrowserService>(MockBehavior.Default, new object[] { mockJsRuntime.Object });
        var mockSettingService = new Mock<SettingsService>();

        mockSettingService.Setup(t => t.ShowCl).Returns(true);

        ComponentFactories
            .Add(mockMainLayout.Object);

        Services
            .AddSingleton(mockTimerService.Object)
            .AddSingleton(mockBrowserService.Object)
            .AddSingleton(mockSettingService.Object);

        var cut = RenderComponent<MainLayout>();
        var nav = cut.FindComponent<NavMenu>();
        var buttonElement = nav.Find("#ToggleMenu");

        buttonElement.Click();

        mockMainLayout.Verify(v => v.ToggleIconMenu(It.IsAny<bool>()));
    }
}