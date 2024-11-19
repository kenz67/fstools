using fstools.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;

namespace fstoolsTests.Services
{
    [TestClass()]
    public class BrowserServiceTests
    {
        [TestMethod()]
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

            Assert.AreEqual(expectedBrowserVersion, svc.Full);
            Assert.AreEqual("Chrome", svc.BrowserName);
            Assert.AreEqual("130.0.0.0", svc.BrowserVersion);
            Assert.AreEqual("130", svc.BrowserMajorVersion);
        }

        [TestMethod()]
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

            Assert.AreEqual(expectedBrowserVersion, svc.Full);
            Assert.AreEqual("Chrome", svc.BrowserName);
            Assert.AreEqual("130.0.0.0", svc.BrowserVersion);
            Assert.IsNull(svc.BrowserMajorVersion);
        }

        [TestMethod]
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

            Assert.AreEqual(expectedBrowserVersion, svc.Full);
            Assert.AreEqual("Chrome", svc.BrowserName);
            Assert.IsNull(svc.BrowserVersion);
            Assert.IsNull(svc.BrowserMajorVersion);
        }

        [TestMethod]
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

            Assert.AreEqual(expectedBrowserVersion, svc.Full);
            Assert.AreEqual(string.Empty, svc.BrowserName);
            Assert.IsNull(svc.BrowserVersion);
            Assert.IsNull(svc.BrowserMajorVersion);
        }

        [TestMethod]
        public void CanDisplayPdfTest()
        {
            var jsRuntimeMock = new Mock<IJSRuntime>();
            var svc = new BrowserService(jsRuntimeMock.Object)
            {
                BrowserName = "Chrome",
                BrowserMajorVersion = "113"
            };
            Assert.IsFalse(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "114";
            Assert.IsTrue(svc.CanDisplayPdf());

            svc.BrowserName = "Edg";
            svc.BrowserMajorVersion = "113";
            Assert.IsFalse(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "114";
            Assert.IsTrue(svc.CanDisplayPdf());

            svc.BrowserName = "Microsoft Internet Explorer";
            svc.BrowserMajorVersion = "113";
            Assert.IsFalse(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "114";
            Assert.IsTrue(svc.CanDisplayPdf());

            svc.BrowserName = "Firefox";
            svc.BrowserMajorVersion = "111";
            Assert.IsFalse(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "112";
            Assert.IsTrue(svc.CanDisplayPdf());

            svc.BrowserName = "Safari";
            svc.BrowserMajorVersion = "14";
            Assert.IsFalse(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "100";
            Assert.IsFalse(svc.CanDisplayPdf());

            svc.BrowserMajorVersion = "99";
            Assert.IsTrue(svc.CanDisplayPdf());

            svc.BrowserName = "unkown";
            Assert.IsFalse(svc.CanDisplayPdf());

            svc.BrowserName = "Chrome";
            svc.BrowserMajorVersion = "x";
            Assert.IsFalse(svc.CanDisplayPdf());
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