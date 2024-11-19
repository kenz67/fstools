using fstools.Services;

namespace fstoolsTests.Services
{
    [TestClass()]
    public class IcaoServiceTests
    {
        [TestMethod()]
        public void IcaotSvcValues()
        {
            var svc = new IcaoService();
            Assert.IsNull(svc.IcaoList);

            svc.IcaoList = [];
            Assert.AreEqual(0, svc.IcaoList.Count);

            svc.IcaoList.Add("KOXC");
            svc.IcaoList.Add("N87");

            Assert.AreEqual(2, svc.IcaoList.Count);
        }
    }
}