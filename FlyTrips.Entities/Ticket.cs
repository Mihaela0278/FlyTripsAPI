using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTrips.Entities
{
    public class Ticket : BaseEntity
    {
        public decimal Price { get; set; }

        public string Seat { get; set; }

        public TimeOnly Departure { get; set; }

        public string Destination { get; set; }

        public DateOnly FlightDate { get; set; }

        public TimeOnly FlightTime { get; set; }

    }
}
