using fstools.Models;

namespace fstools.Services;

public class TimerService
{
    public List<StopwatchInfo> Info { get; set; } = [];
    public List<FsTimer> Timers { get; set; } = [];
    public int TimerCnt { get; set; }
}