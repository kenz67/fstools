using System.Diagnostics.CodeAnalysis;

namespace fstools.Models;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
[ExcludeFromCodeCoverage]
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class AirportData
{
	public string city { get; set; }
	public string state_abbr { get; set; }
	public string state_full { get; set; }
	public string country { get; set; }
	public string icao_ident { get; set; }
	public string faa_ident { get; set; }
	public string airport_name { get; set; }
	public bool is_military { get; set; }
}

[ExcludeFromCodeCoverage]
public class SingleChart
{
	public string chart_type { get; set; }
	public string chart_name { get; set; }
	public string chart_sequence { get; set; }
	public string pdf_name { get; set; }
	public string pdf_url { get; set; }
	public bool did_change { get; set; }
}

[ExcludeFromCodeCoverage]
public class FoundCharts
{
	public List<SingleChart> airport_diagram { get; set; }
	public List<SingleChart> general { get; set; }
	public List<SingleChart> departure { get; set; }
	public List<SingleChart> arrival { get; set; }
	public List<SingleChart> approach { get; set; }
}

[ExcludeFromCodeCoverage]
public class General
{
	public string chart_name { get; set; }
	public string chart_sequence { get; set; }
	public string pdf_name { get; set; }
	public string pdf_url { get; set; }
	public bool did_change { get; set; }
}

[ExcludeFromCodeCoverage]
public class ChartRoot
{
	public AirportData airport_data { get; set; }
	public FoundCharts charts { get; set; }
}


//public class Chart
//{
//    public string State { get; set; }
//    public string State_full { get; set; }
//    public string City { get; set; }
//    public string Volume { get; set; }
//    public string Airport_name { get; set; }
//    public string Military { get; set; }
//    public string Faa_ident { get; set; }
//    public string Icao_ident { get; set; }
//    public string Chart_seq { get; set; }
//    public string Chart_code { get; set; }
//    public string Chart_name { get; set; }
//    public string Pdf_name { get; set; }
//    public string Pdf_path { get; set; }
//}

//[ExcludeFromCodeCoverage]
//public class ChartList
//{
//    public List<Chart> ICAO { get; set; }
//}