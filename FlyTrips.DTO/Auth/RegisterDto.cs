using System.ComponentModel.DataAnnotations;

namespace FlyTrips.DTO.Auth
{
    public class RegisterDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters long!")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Last name must be at least 3 characters long!")]
        public string LastName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters long!")]
        public string Username { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long!")]
        public string Password { get; set; }
    }
}
