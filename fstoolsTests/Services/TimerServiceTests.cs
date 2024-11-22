using fstools.Models;
using fstools.Services;
using Xunit;

namespace fstoolsTests.Services
{
    public class TimerServiceTests
    {
        [Fact]
        public void TimerSvcValues()
        {
            var svc = new TimerService();
            Assert.Equal(0, svc.Info.Count);
            Assert.Equal(0, svc.Timers.Count);
            Assert.Equal(0, svc.TimerCnt);

            svc.Info.Add(new StopwatchInfo());
            Assert.Equal(1, svc.Info.Count);
            Assert.Equal(0, svc.Timers.Count);
            Assert.Equal(0, svc.TimerCnt);

            svc.Timers.Add(new FsTimer());
            Assert.Equal(1, svc.Info.Count);
            Assert.Equal(1, svc.Timers.Count);
            Assert.Equal(0, svc.TimerCnt);

            svc.TimerCnt = 10;
            Assert.Equal(1, svc.Info.Count);
            Assert.Equal(1, svc.Timers.Count);
            Assert.Equal(10, svc.TimerCnt);
        }
    }
}