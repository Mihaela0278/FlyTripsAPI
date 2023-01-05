using FlyTrips.DTO.Ticket;
using FlyTrips.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlyTripsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] TicketCreateUpdateDto dto)
        {
            return Ok(_ticketService.Create(dto));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ticketService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_ticketService.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TicketCreateUpdateDto dto)
        {
            return Ok(_ticketService.Update(id, dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) 
        {
            _ticketService.Delete(id);
            return NoContent();
        }
    }
}
