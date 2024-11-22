using fstools.Services;
using Xunit;

namespace fstoolsTests.Services
{
    public class ChartServiceTests
    {
        [Fact]
        public void ChartSvcValues()
        {
            var svc = new ChartService();

            Assert.Null(svc.CurrentIcao);
            Assert.Null(svc.Pdf);
            Assert.False(svc.ShowPdf);

            svc.CurrentIcao = "KFFA";
            Assert.Equal("KFFA", svc.CurrentIcao);
            Assert.Null(svc.Pdf);
            Assert.False(svc.ShowPdf);

            svc.Pdf = "pdf path";
            Assert.Equal("KFFA", svc.CurrentIcao);
            Assert.Equal("pdf path", svc.Pdf);
            Assert.False(svc.ShowPdf);

            svc.ShowPdf = true;
            Assert.Equal("KFFA", svc.CurrentIcao);
            Assert.Equal("pdf path", svc.Pdf);
            Assert.True(svc.ShowPdf);
        }
    }
}