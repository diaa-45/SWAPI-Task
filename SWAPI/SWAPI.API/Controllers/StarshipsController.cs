using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWAPI.Core.Interfaces;

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
        public async Task<IActionResult> GetAllStarships()
        {
            var starships = await _swapiClient.GetStarshipsPageAsync();
            Console.WriteLine(starships.Items);
            return Ok(starships.Items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStarshipById(int id)
        {
            var starship = await _swapiClient.GetStarshipByIdAsync(id);
            return Ok(starship);
        }

    }
}
