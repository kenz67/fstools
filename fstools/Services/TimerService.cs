using fstools.Models;

namespace fstools.Services;

public class TimerService
{
	public List<StopwatchInfo> Info { get; } = new();
	public List<FsTimer> Timers { get; set; } = new();
	public int TimerCnt { get; set; } = 0;
}