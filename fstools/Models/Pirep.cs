using System.Diagnostics.CodeAnalysis;

namespace fstools.Models;

[ExcludeFromCodeCoverage]
public class PirepInfo
{
    public PirepData PirepData { get; set; }
}

[ExcludeFromCodeCoverage]
public class PirepData
{
    public List<string> Line_by_line { get; set; }
}