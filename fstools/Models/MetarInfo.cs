using System.Diagnostics.CodeAnalysis;

namespace fstools.Models;

[ExcludeFromCodeCoverage]
public class WeatherData
{
    public string IcaoId { get; set; }
    public string RawOb { get; set; }
    public string Temp { get; set; }
    public string Dewp { get; set; }
    public string Wdir { get; set; }
    public string Wspd { get; set; }
    public string Visib { get; set; }
    public double Altim { get; set; }
    //   public object Wx { get; set; }
    //  public string Auto_report { get; set; }
    public List<SkyCondition> Clouds { get; set; }
    //  public string Category { get; set; }
    public string MetarType { get; set; }
    public DateTime ReportTime { get; set; }
}

[ExcludeFromCodeCoverage]
public class MetarInfo
{
    public WeatherData WeatherData { get; set; }
}

[ExcludeFromCodeCoverage]
public class SkyCondition
{
    public string Cover { get; set; }
    public int? Base { get; set; }
}