using FlyTrips.DTO.Role;
using FlyTrips.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlyTripsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RoleCreateUpdateDto dto)
        {
            return Ok(_roleService.Create(dto));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_roleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_roleService.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] RoleCreateUpdateDto dto, [FromRoute] int id)
        {
            return Ok(_roleService.Update(dto, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _roleService.Delete(id);
            return NoContent();
        }
    }
}
