using fstools.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
using Xunit;

namespace fstoolsTests.Services
{
    public class BrowserServiceTests
    {
        [Fact]
        public async Task GetDataTestFull()
        {
            const string expectedBrowserVersion = "Chrome,130.0.0.0,130,Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/130.0.0.0 Safari/537.36,";

            var jsRuntimeMock = new Mock<IJSRuntime>();
            var provider = AddServices(jsRuntimeMock);
            var svc = provider.GetRequiredService<BrowserService>();

            jsRuntimeMock
                .Setup(j => j.InvokeAsync<string>("browserVersion", It.IsAny<object[]>()))
                .ReturnsAsync(expectedBrowserVersion);
            await svc.GetData();

            Assert.Equal(expectedBrowserVersion, svc.Full);
            Assert.Equal("Chrome", svc.BrowserName);
            Assert.Equal("130.0.0.0", svc.BrowserVersion);
            Assert.Equal("130", svc.BrowserMajorVersion);
        }

        [Fact]
        public async Task GetDataTest2()
        {
            const string expectedBrowserVersion = "Chrome,130.0.0.0";

            var jsRuntimeMock = new Mock<IJSRuntime>();
            var provider = AddServices(jsRuntimeMock);
            var svc = provider.GetRequiredService<BrowserService>();

            jsRuntimeMock
                .Setup(j => j.InvokeAsync<string>("browserVersion", It.IsAny<object[]>()))
                .ReturnsAsync(expectedBrowserVersion);
            await svc.GetData();

            Assert.Equal(expectedBrowserVersion, svc.Full);
            Assert.Equal("Chrome", svc.BrowserName);
            Assert.Equal("130.0.0.0", svc.BrowserVersion);
            Assert.Null(svc.BrowserMajorVersion);
        }

        [Fact]
        public async Task GetDataTest1()
        {
            const string expectedBrowserVersion = "Chrome";

            var jsRuntimeMock = new Mock<IJSRuntime>();
            var provider = AddServices(jsRuntimeMock);
            var svc = provider.GetRequiredService<BrowserService>();

            jsRuntimeMock
                .Setup(j => j.InvokeAsync<string>("browserVersion", It.IsAny<object[]>()))
                .ReturnsAsync(expectedBrowserVersion);
            await svc.GetData();

            Assert.Equal(expectedBrowserVersion, svc.Full);
            Assert.Equal("Chrome", svc.BrowserName);
            Assert.Null(svc.BrowserVersion);
            Assert.Null(svc.BrowserMajorVersion);
        }

        [Fact]
        public async Task GetDataTest0()
        {
            const string expectedBrowserVersion = "";

            var jsRuntimeMock = new Mock<IJSRuntime>();
            var provider = AddServices(jsRuntimeMock);
            var svc = provider.GetRequiredService<BrowserService>();

            jsRuntimeMock
                .Setup(j => j.InvokeAsync<string>("browserVersion", It.IsAny<object[]>()))
                .ReturnsAsync(expectedBrowserVersion);
            await svc.GetData();

            Assert.Equal(expectedBrowserVersion, svc.Full);
            Assert.Equal(string.Empty, svc.BrowserName);
            Assert.Null(svc.BrowserVersion);
            Assert.Null(svc.BrowserMajorVersion);
        }

        [Fact]
        public void CanDisplayPdfTest()
        {
            var jsRuntimeMock = new Mock<IJSRuntime>();
            var svc = new BrowserService(jsRuntimeMock.Object)
            {
                BrowserName = "Chrome",
                BrowserMajorVersion = "113"
            };
            Assert.False(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "114";
            Assert.True(svc.CanDisplayPdf());

            svc.BrowserName = "Edg";
            svc.BrowserMajorVersion = "113";
            Assert.False(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "114";
            Assert.True(svc.CanDisplayPdf());

            svc.BrowserName = "Microsoft Internet Explorer";
            svc.BrowserMajorVersion = "113";
            Assert.False(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "114";
            Assert.True(svc.CanDisplayPdf());

            svc.BrowserName = "Firefox";
            svc.BrowserMajorVersion = "111";
            Assert.False(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "112";
            Assert.True(svc.CanDisplayPdf());

            svc.BrowserName = "Safari";
            svc.BrowserMajorVersion = "14";
            Assert.False(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "100";
            Assert.False(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "99";
            Assert.True(svc.CanDisplayPdf());

            svc.BrowserName = "unkown";
            Assert.False(svc.CanDisplayPdf());

            svc.BrowserName = "Chrome";
            svc.BrowserMajorVersion = "x";
            Assert.False(svc.CanDisplayPdf());
        }

        private static ServiceProvider AddServices(Mock<IJSRuntime> mock)
        {
            var services = new ServiceCollection();
            services.AddScoped<BrowserService>();
            services.AddSingleton(mock.Object);

            var provider = services.BuildServiceProvider();

            return provider;
        }
    }
}