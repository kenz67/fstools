using fstools.Services;
using Xunit;

namespace fstoolsTests.Services
{
    public class SettingsServiceTests
    {
        [Fact]
        public void SettingSvcValues()
        {
            var svc = new SettingsService();
            Assert.False(svc.ShowCl);

            svc.ShowCl = true;
            Assert.True(svc.ShowCl);
        }
    }
}