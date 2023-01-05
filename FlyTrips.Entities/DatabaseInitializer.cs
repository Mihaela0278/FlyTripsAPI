using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;

namespace FlyTrips.Entities
{
    public static class DatabaseInitializer
    {
        public static void SeedAirlines(FlyTripsDbContext context)
        {
            if (context.Airlines.Any())
            {
                return;
            }

            using var reader = new StreamReader("airlines.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                string airlineName = csv.GetField("Name");
                if (string.IsNullOrWhiteSpace(airlineName) || context.Airlines.Any(a => a.Name == airlineName))
                {
                    continue;
                }

                string country = csv.GetField("Country");
                Airline airline = new Airline
                {
                    Name = airlineName,
                    Country = string.IsNullOrWhiteSpace(country) ? "SomeCountry" : country
                };

                context.Airlines.Add(airline);
                context.SaveChanges();
                
            }

        }
        public static void SeedRolesInDb(FlyTripsDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            context.Roles.AddRange(
                new Role
                {
                    Name = "Admin",
                },
                new Role
                {
                    Name = "User"
                });
            context.SaveChanges();
        }

        public static void SeedAdminInDb(FlyTripsDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            context.Users.Add(new User
            {
                FirstName = "Admin",
                LastName = "Adminov",
                Username = "DemoAdmin",
                Role = context.Roles.First(r => r.Name == "Admin"),
                Password = BCrypt.Net.BCrypt.HashPassword("Admin123")
            });
            context.SaveChanges();
        }
    }
}
