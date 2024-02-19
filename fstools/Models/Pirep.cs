namespace fstools.Models;

public class PirepInfo
{
    public PirepData PirepData { get; set; }
}

public class PirepData
{
    public List<string> Line_by_line { get; set; }
}