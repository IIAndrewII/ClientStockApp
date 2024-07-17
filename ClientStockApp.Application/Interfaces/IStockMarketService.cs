using ClientStockApp.Domain.Models;

namespace ClientStockApp.Application.Interfaces
{
    public interface IStockMarketService
    {
        Task FetchStockMarketDataAsync();
        Task<IEnumerable<StockMarketData>> GetStockPricesAsync();

    }
}
