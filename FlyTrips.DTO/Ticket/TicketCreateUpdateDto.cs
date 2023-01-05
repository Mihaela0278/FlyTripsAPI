using System.ComponentModel.DataAnnotations;

namespace FlyTrips.DTO.Ticket
{
    public class TicketCreateUpdateDto
    {
        [Required]
        [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000!")]
        public decimal Price { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Seat must be at least 3 characters long!")]
        public string Seat { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Departure must be at least 2 characters long!")]
        public string Departure { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Destination must be at least 2 characters long!")]
        public string Destination { get; set; }

        [Required]
        public DateTime FlightDateTime { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public ISet<int> AirlineIds { get; set; }
    }
}
