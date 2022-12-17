namespace FlyTrips.Entities
{
    public class Ticket : BaseEntity
    {
        public decimal Price { get; set; }

        public string Seat { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }

        public DateTime FlightDateTime { get; set; }

        public User User { get; set; }

        public ICollection<Airline> Airlines { get; set; }

    }
}
