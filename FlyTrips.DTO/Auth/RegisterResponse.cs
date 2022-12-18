using FlyTrips.DTO.Role;

namespace FlyTrips.DTO.Auth
{
    public class RegisterResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public RoleResponseDto Role { get; set; }
    }
}
