using AutoMapper;
using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(FlyTripsDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool ExistsByUsername(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }
    }
}
