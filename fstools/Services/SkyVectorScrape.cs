using fstools.Models;
using HtmlAgilityPack;

namespace fstools.Services
{
    public class SkyVectorScrape
    {
        readonly ChartList charts = new();

        public async Task<ChartList> TestScrape(string ICAO)
        {
            charts.ICAO = new List<Chart>();

            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync($"https://skyvector.com/api/airportSearch?query={ICAO}");
            var aptData = doc.DocumentNode.SelectNodes("//div[@class='aptdata']");
            var l = new List<string>();
            foreach (var apt in aptData)
            {
                if (apt.InnerHtml.Contains("Airport Diagram"))
                {
                    ProcessAirportDiagram(apt);
                }
                else if (apt.InnerHtml.Contains("Approach Procedure (IAP) Charts"))
                {
                    ProcessApproach("Approaches", apt);
                }
                else if (apt.InnerHtml.Contains("Terminal Arrival (STAR) Charts"))
                {
                    ProcessApproach("Arrivals (STAR)", apt);
                }
                else if (apt.InnerHtml.Contains("Procedure (DP) Charts"))
                {
                    ProcessApproach("Departures (SID)", apt);
                }
                else if (apt.InnerHtml.Contains("Weather Minimums"))
                {
                    ProcessApproach("Minimums", apt);
                }

                l.Add(apt.InnerText);
            }

            return charts;
        }

        private void ProcessAirportDiagram(HtmlNode html)
        {
            var title = html.SelectSingleNode(".//div[@class='aptdatatitle']");
            var anchors = html.SelectNodes(".//a");
            var links = anchors.Select(a => a.Attributes["href"].Value).ToList();

            charts.ICAO.Add(new Chart
            {
                Chart_code = "Airport Diagram",
                Chart_name = title.InnerHtml,
                Pdf_path = $"https://skyvector.com/{links[0]}"
            });
        }

        private void ProcessApproach(string Title, HtmlNode html)
        {
            var anchors = html.SelectNodes(".//a");
            foreach (var app in anchors)
            {
                charts.ICAO.Add(new Chart
                {
                    Chart_code = Title,
                    Chart_name = app.InnerText.Trim(),
                    Pdf_path = $"https://skyvector.com/{app.Attributes["href"].Value}"
                });
            }
        }
    }
}