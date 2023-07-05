namespace fstools.Models;

public class WeatherInfo
{
    public string ICAO { get; set; }
    public MetarInfo Metar { get; set; }
    public TafInfo Taf { get; set; }
}