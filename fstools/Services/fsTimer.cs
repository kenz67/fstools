using System.Diagnostics;

namespace fstools.Services;

public class FsTimer
{
    private TimeSpan _elaspsedTime;
    private DateTime _startTime;
    private Timer _timer;
    private Func<TimeSpan, Task> _callback;
    private Stopwatch _stopwatch;

    public void StartTimer(Func<TimeSpan, Task> callback)
    {
        SetCallback(callback);
        _startTime = DateTime.Now;
        _stopwatch = Stopwatch.StartNew();
        _timer = new Timer(async _ =>
        {
            _elaspsedTime = DateTime.Now - _startTime;
            await _callback(_elaspsedTime);
        }, null, 0, 100);
    }

    public void PauseTimer()
    {
        _stopwatch.Stop();
    }

    public void ResumeTimer()
    {
        _stopwatch.Start();
    }

    public void StopTimer()
    {
        _stopwatch?.Reset();
        _timer?.Dispose();
    }

    public TimeSpan SetCallback(Func<TimeSpan, Task> callback)
    {
        _callback -= callback;
        _callback += callback;
        return _stopwatch?.Elapsed ?? new TimeSpan();
    }

    public String FormattedTime()
    {
        return _stopwatch?.Elapsed.ToString(@"hh\:mm\:ss\.f") ?? "00:00:00.0";
    }
}