using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWAPI.Core.Interfaces;
using SWAPI.Core.Services.Currency;

namespace SWAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarshipsController : ControllerBase
    {
        private readonly ISwapiClient _swapiClient;

        public StarshipsController(ISwapiClient swapiClient)
        {
            _swapiClient = swapiClient;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStarships([FromQuery] string currency = "GC")
        {
            var starships = await _swapiClient.GetStarshipsPageAsync();
            var convertedStarships = new List<object>();
            foreach (var ship in starships.ValidShips)
            {
                
                ICurrencyConversionStrategy strategy = currency.ToUpper() switch
                {
                    "USD" => new UsdConversionStrategy(),
                    "EUR" => new EurConversionStrategy(),
                    _ => new GalacticCreditsStrategy()
                };

                
                var converter = new CurrencyConverter(strategy);
                decimal cost = 0;

                if (!string.IsNullOrWhiteSpace(ship.cost_in_credits) && decimal.TryParse(ship.cost_in_credits, out var parsedCost))
                {
                    cost = parsedCost;
                }

                var convertedCost = converter.Convert(cost);
                ship.cost_in_credits = convertedCost.ToString();
                ship.Currency = converter.Symbol;
                convertedStarships.Add(ship);
            }
            return Ok(convertedStarships);
            //return Ok(starships.FailedShips);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStarshipById(int id)
        {
            var starship = await _swapiClient.GetStarshipByIdAsync(id);
            return Ok(starship);
        }

    }
}
