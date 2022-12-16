namespace FlyTrips.Entities
{
    public class Airline : BaseEntity
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
