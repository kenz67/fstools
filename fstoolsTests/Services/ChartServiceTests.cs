using fstools.Services;

namespace fstoolsTests.Services
{
    [TestClass()]
    public class ChartServiceTests
    {
        [TestMethod()]
        public void ChartSvcValues()
        {
            var svc = new ChartService();

            Assert.IsNull(svc.CurrentIcao);
            Assert.IsNull(svc.Pdf);
            Assert.IsFalse(svc.ShowPdf);

            svc.CurrentIcao = "KFFA";
            Assert.AreEqual("KFFA", svc.CurrentIcao);
            Assert.IsNull(svc.Pdf);
            Assert.IsFalse(svc.ShowPdf);

            svc.Pdf = "pdf path";
            Assert.AreEqual("KFFA", svc.CurrentIcao);
            Assert.AreEqual("pdf path", svc.Pdf);
            Assert.IsFalse(svc.ShowPdf);

            svc.ShowPdf = true;
            Assert.AreEqual("KFFA", svc.CurrentIcao);
            Assert.AreEqual("pdf path", svc.Pdf);
            Assert.IsTrue(svc.ShowPdf);
        }
    }
}