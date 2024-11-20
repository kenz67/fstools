using fstools.Models;
using fstools.Services;

namespace fstoolsTests.Services
{
    [TestClass()]
    public class TimerServiceTests
    {
        [TestMethod()]
        public void TimerSvcValues()
        {
            var svc = new TimerService();
            Assert.AreEqual(0, svc.Info.Count);
            Assert.AreEqual(0, svc.Timers.Count);
            Assert.AreEqual(0, svc.TimerCnt);

            svc.Info.Add(new StopwatchInfo());
            Assert.AreEqual(1, svc.Info.Count);
            Assert.AreEqual(0, svc.Timers.Count);
            Assert.AreEqual(0, svc.TimerCnt);

            svc.Timers.Add(new FsTimer());
            Assert.AreEqual(1, svc.Info.Count);
            Assert.AreEqual(1, svc.Timers.Count);
            Assert.AreEqual(0, svc.TimerCnt);

            svc.TimerCnt = 10;
            Assert.AreEqual(1, svc.Info.Count);
            Assert.AreEqual(1, svc.Timers.Count);
            Assert.AreEqual(10, svc.TimerCnt);

        }
    }
}