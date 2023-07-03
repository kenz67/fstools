namespace fstools.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Chart
    {
        public string State { get; set; }
        public string State_full { get; set; }
        public string City { get; set; }
        public string Volume { get; set; }
        public string Airport_name { get; set; }
        public string Military { get; set; }
        public string Faa_ident { get; set; }
        public string Icao_ident { get; set; }
        public string Chart_seq { get; set; }
        public string Chart_code { get; set; }
        public string Chart_name { get; set; }
        public string Pdf_name { get; set; }
        public string Pdf_path { get; set; }
    }

    public class ChartList
    {
        public List<Chart> ICAO { get; set; }
    }
}
