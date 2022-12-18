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
        private readonly IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RoleCreateUpdateDto dto)
        {
            return Ok(roleService.Create(dto));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(roleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(roleService.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] RoleCreateUpdateDto dto, [FromRoute] int id)
        {
            return Ok(roleService.Update(dto, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            roleService.Delete(id);
            return NoContent();
        }
    }
}
