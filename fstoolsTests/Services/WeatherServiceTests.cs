using fstools.Services;

namespace fstoolsTests.Services
{
    [TestClass()]
    public class WeatherServiceTests
    {
        [TestMethod()]
        public void TimerSvcValues()
        {
            var svc = new WeatherService();
            Assert.IsNull(svc.ICAO);
            Assert.IsNull(svc.WxInfo);

            svc.ICAO = "KFFL";
            Assert.AreEqual("KFFL", svc.ICAO);
            Assert.IsNull(svc.WxInfo);

            svc.WxInfo = new();
            Assert.AreEqual("KFFL", svc.ICAO);
            Assert.IsNotNull(svc.WxInfo);
        }
    }
}