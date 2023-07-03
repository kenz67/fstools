namespace fstools.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Chart
    {
        public string state { get; set; }
        public string state_full { get; set; }
        public string city { get; set; }
        public string volume { get; set; }
        public string airport_name { get; set; }
        public string military { get; set; }
        public string faa_ident { get; set; }
        public string icao_ident { get; set; }
        public string chart_seq { get; set; }
        public string chart_code { get; set; }
        public string chart_name { get; set; }
        public string pdf_name { get; set; }
        public string pdf_path { get; set; }
    }

    public class ChartList
    {
        public List<Chart> ICAO { get; set; }
    }
}
