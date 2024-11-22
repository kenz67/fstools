using System.Diagnostics.CodeAnalysis;

namespace fstools.Models;

[ExcludeFromCodeCoverage]
public class StopwatchInfo
{
    public String ElaspedTime { get; set; } = "00:00:00.0";
    public String StartText { get; set; } = "Start";
    public String PauseResumeText { get; set; } = "Pause";
}