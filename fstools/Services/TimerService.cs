using fstools.Models;

namespace fstools.Services
{
    public class TimerService
    {
        public List<StopwatchInfo> Info { get; set; } = new List<StopwatchInfo>();
        public List<FsTimer> Timers { get; set; } = new List<FsTimer>();
        public int TimerCnt { get; set; }
    }
}
