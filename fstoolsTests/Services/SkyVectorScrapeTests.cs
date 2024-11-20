using fstools.Services;

namespace fstoolsTests.Services
{
    [TestClass()]
    public class SkyVectorScrapeTests
    {
        [TestMethod()]
        public async Task ScrapeTest()
        {
            var svc = new SkyVectorScrape();
            var charts = await svc.Scrape("KJFK");
            Assert.AreNotEqual(0, charts.ICAO.Count);
        }

        [TestMethod()]
        public async Task ScrapeNegativeTest()
        {
            var svc = new SkyVectorScrape();
            var charts = await svc.Scrape("KZZZ");
            Assert.AreEqual(0, charts.ICAO.Count);
        }
    }
}