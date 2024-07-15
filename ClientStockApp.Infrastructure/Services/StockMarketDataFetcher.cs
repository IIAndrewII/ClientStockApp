using ClientStockApp.Application.Interfaces;
using ClientStockApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClientStockApp.Infrastructure.Services
{
    public class StockMarketDataFetcher : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public StockMarketDataFetcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(6));
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var stockMarketService = scope.ServiceProvider.GetRequiredService<IStockMarketService>();
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                await stockMarketService.FetchStockMarketDataAsync();

                var clients = await context.Clients.ToListAsync();
                var stockData = await context.StockMarketData.OrderByDescending(s => s.Timestamp).FirstOrDefaultAsync();

                foreach (var client in clients)
                {
                    var body = $"Hello {client.FirstName},\n\nThe latest stock price for AAPL is {stockData.Price} as of {stockData.Timestamp}.\n\nBest regards,\nStock Market App";
                    await emailService.SendEmailAsync(client.Email, "Stock Market Update", body);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
