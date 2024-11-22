using fstools.Models;

namespace fstools.Services;

public class TimerService
{
    public List<StopwatchInfo> Info { get; } = [];
    public List<FsTimer> Timers { get; } = [];
    public int TimerCnt { get; set; }
}