using ClientStockApp.Application.Interfaces;
using ClientStockApp.Domain.Models;
using ClientStockApp.Infrastructure.Data;
using ClientStockApp.Infrastructure.DTOs;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ClientStockApp.Infrastructure.Services
{
    public class StockMarketService : IStockMarketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public StockMarketService(ApplicationDbContext context, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task FetchStockMarketDataAsync()
        {
            var apiKey = _configuration["Polygon:ApiKey"];
            var ticker = _configuration["Polygon:Ticker"];
            var httpClient = _httpClientFactory.CreateClient();
            var responseString = await httpClient.GetStringAsync($"https://api.polygon.io/v2/aggs/ticker/{ticker}/prev?apiKey={apiKey}");

            var response = JsonSerializer.Deserialize<PolygonApiResponse>(responseString);

            if (response != null && response.Results.Any())
            {
                var stockData = new StockMarketData
                {
                    Symbol = response.Ticker,
                    Price = response.Results.First().C, // Close price
                    Timestamp = DateTime.UtcNow
                };

                _context.StockMarketData.Add(stockData);
                await _context.SaveChangesAsync();
            }
        }
    }
}