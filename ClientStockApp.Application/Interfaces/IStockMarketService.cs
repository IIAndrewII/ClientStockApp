namespace ClientStockApp.Application.Interfaces
{
    public interface IStockMarketService
    {
        Task FetchStockMarketDataAsync();
    }
}
