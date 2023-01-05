using FlyTrips.DTO.Airline;
using FlyTrips.DTO.Auth;

namespace FlyTrips.DTO.Ticket
{
    public class TicketResponseDto
    {
        public decimal Price { get; set; }

        public string Seat { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }

        public DateTime FlightDateTime { get; set; }

        public RegisterResponse User { get; set; }

        public ICollection<AirlineResponseDto> Airlines { get; set; }

    }
}
