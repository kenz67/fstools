namespace fstools.Models;

public class WeatherData
{
    public string Station_id { get; set; }
    public string Raw { get; set; }
    public string Temp { get; set; }
    public string Dewpoint { get; set; }
    public string Wind { get; set; }
    public string Wind_vel { get; set; }
    public string Visibility { get; set; }
    public string Alt_hg { get; set; }
    public string Alt_mb { get; set; }
    public object Wx { get; set; }
    public string Auto_report { get; set; }
    public List<SkyCondition> Sky_conditions { get; set; }
    public string Category { get; set; }
    public string Report_type { get; set; }
    public DateTime Time_of_obs { get; set; }
}

public class MetarInfo
{
    public WeatherData WeatherData { get; set; }
}

public class SkyCondition
{
    public string Coverage { get; set; }
    public object Base_agl { get; set; }
}