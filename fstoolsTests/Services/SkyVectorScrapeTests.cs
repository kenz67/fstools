using fstools.Services;
using Xunit;

namespace fstoolsTests.Services
{
    public class SkyVectorScrapeTests
    {
        [Fact]
        public async Task ScrapeTest()
        {
            var svc = new SkyVectorScrape();
            var charts = await svc.Scrape("KJFK");
            Assert.NotEmpty(charts.ICAO);
        }

        [Fact]
        public async Task ScrapeNegativeTest()
        {
            var svc = new SkyVectorScrape();
            var charts = await svc.Scrape("KZZZ");
            Assert.Equal(0, charts.ICAO.Count);
        }
    }
}