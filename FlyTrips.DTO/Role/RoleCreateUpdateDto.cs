using System.ComponentModel.DataAnnotations;

namespace FlyTrips.DTO.Role
{
    public class RoleCreateUpdateDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Role name must be at least 3 characters")]
        public string Name { get; set; }
    }
}