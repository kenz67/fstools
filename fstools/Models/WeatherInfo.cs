using System.Diagnostics.CodeAnalysis;

namespace fstools.Models;

[ExcludeFromCodeCoverage]
public class WeatherInfo
{
    public string ICAO { get; set; }
    public MetarInfo Metar { get; set; }
    public TafInfo Taf { get; set; }
    public PirepInfo Pirep { get; set; }
}