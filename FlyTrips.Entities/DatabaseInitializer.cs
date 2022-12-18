namespace FlyTrips.Entities
{
    public static class DatabaseInitializer
    {
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
        }
    }
}
