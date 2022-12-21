using System.ComponentModel.DataAnnotations;

namespace FlyTrips.DTO.Airline
{
    public class AirlineCreateUpdateDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long!")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Country must be at least 3 characters long!")]
        public string Country { get; set; }

    }
}
