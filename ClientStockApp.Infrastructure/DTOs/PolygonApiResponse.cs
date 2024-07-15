using System.Text.Json.Serialization;

namespace ClientStockApp.Infrastructure.DTOs
{
    public class PolygonApiResponse
    {
        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }

        public class Result
        {
            [JsonPropertyName("c")]
            public decimal C { get; set; } // Close price
        }
    }
}