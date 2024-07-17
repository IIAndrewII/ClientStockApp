using ClientStockApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientStockApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockPriceController : ControllerBase
    {
        private readonly IStockMarketService _stockMarketService;

        public StockPriceController(IStockMarketService stockMarketService)
        {
            _stockMarketService = stockMarketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStockPrices()
        {
            var stockPrices = await _stockMarketService.GetStockPricesAsync();
            return Ok(stockPrices);
        }
    }
}