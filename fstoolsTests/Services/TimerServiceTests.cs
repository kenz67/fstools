using fstools.Models;
using fstools.Services;
using Xunit;

namespace fstoolsTests.Services;

public class TimerServiceTests
{
    [Fact]
    public void TimerSvcValues()
    {
        var svc = new TimerService();
        Assert.Empty(svc.Info);
        Assert.Empty(svc.Timers);
        Assert.Equal(0, svc.TimerCnt);

        svc.Info.Add(new StopwatchInfo());
        Assert.Single(svc.Info);
        Assert.Empty(svc.Timers);
        Assert.Equal(0, svc.TimerCnt);

        svc.Timers.Add(new FsTimer());
        Assert.Single(svc.Info);
        Assert.Single(svc.Timers);
        Assert.Equal(0, svc.TimerCnt);

        svc.TimerCnt = 10;
        Assert.Single(svc.Info);
        Assert.Single(svc.Timers);
        Assert.Equal(10, svc.TimerCnt);
    }
}