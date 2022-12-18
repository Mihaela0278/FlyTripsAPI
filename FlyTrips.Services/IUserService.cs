using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public interface IUserService : IBaseService<User>
    {
        bool ExistsByUsername(string username);
    }
}
