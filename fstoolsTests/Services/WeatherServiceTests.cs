using fstools.Services;
using Xunit;

namespace fstoolsTests.Services
{
    public class WeatherServiceTests
    {
        [Fact]
        public void TimerSvcValues()
        {
            var svc = new WeatherService();
            Assert.Null(svc.ICAO);
            Assert.Null(svc.WxInfo);

            svc.ICAO = "KFFL";
            Assert.Equal("KFFL", svc.ICAO);
            Assert.Null(svc.WxInfo);

            svc.WxInfo = new();
            Assert.Equal("KFFL", svc.ICAO);
            Assert.NotNull(svc.WxInfo);
        }
    }
}