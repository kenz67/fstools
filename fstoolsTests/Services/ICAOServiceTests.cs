using fstools.Services;
using Xunit;

namespace fstoolsTests.Services
{
    public class IcaoServiceTests
    {
        [Fact]
        public void IcaotSvcValues()
        {
            var svc = new IcaoService();
            Assert.Null(svc.IcaoList);

            svc.IcaoList = [];
            Assert.Empty(svc.IcaoList);

            svc.IcaoList.Add("KOXC");
            svc.IcaoList.Add("N87");

            Assert.Equal(2, svc.IcaoList.Count);
        }
    }
}