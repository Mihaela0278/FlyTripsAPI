using FlyTrips.DTO.Airline;
using FlyTrips.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlyTripsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        private readonly IAirlineService _airlineService;

        public AirlinesController(IAirlineService airlineService)
        {
            _airlineService = airlineService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] AirlineCreateUpdateDto dto)
        {
            return Ok(_airlineService.Create(dto));
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            return Ok(_airlineService.GetAll());
        }

        [HttpGet("getByName")]
        [Authorize]
        public IActionResult GetByName([FromQuery] string name)
        {
            return Ok(_airlineService.GetAirlinesByName(name));
        }

        [HttpGet("getByCountry")]
        [Authorize]
        public IActionResult GetByCountry([FromHeader] string countryName)
        {
            return Ok(_airlineService.GetAirlinesByCountryName(countryName));
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_airlineService.GetById(id));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromRoute] int id, [FromBody] AirlineCreateUpdateDto dto)
        {
            return Ok(_airlineService.Update(id, dto));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            _airlineService.Delete(id);
            return NoContent();
        }
    }
}
