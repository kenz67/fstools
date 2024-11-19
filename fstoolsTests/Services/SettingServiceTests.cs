using fstools.Services;

namespace fstoolsTests.Services
{
    [TestClass()]
    public class SettingsServiceTests
    {
        [TestMethod()]
        public void SettingSvcValues()
        {
            var svc = new SettingsService();
            Assert.IsFalse(svc.ShowCl);

            svc.ShowCl = true;
            Assert.IsTrue(svc.ShowCl);
        }
    }
}