using ClientStockApp.Application.Interfaces;
using ClientStockApp.Domain.Models;
using ClientStockApp.Infrastructure.Data;


namespace ClientStockApp.Infrastructure.Services
{
    public class StockMarketService : IStockMarketService
    {
        private readonly ApplicationDbContext _context;
        private readonly System.Net.Http.IHttpClientFactory _httpClientFactory;

        public StockMarketService(ApplicationDbContext context, System.Net.Http.IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public async Task FetchStockMarketDataAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetStringAsync("https://api.polygon.io/v2/aggs/ticker/AAPL/prev?apiKey=YOUR_API_KEY");

            // Parse and save the data to the database
            var stockData = new StockMarketData
            {
                Symbol = "AAPL",
                Price = decimal.Parse(response), // Simplified parsing, adjust as necessary
                Timestamp = DateTime.UtcNow
            };

            _context.StockMarketData.Add(stockData);
            await _context.SaveChangesAsync();
        }
    }
}
