using FlyTrips.DTO.Auth;
using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public interface IUserService : IBaseService<User>
    {
        bool ExistsByUsername(string username);

        RegisterResponse Create(RegisterDto dto);

        new RegisterResponse GetById(int id);

        new IEnumerable<RegisterResponse> GetAll();

        RegisterResponse Update(int id, RegisterDto dto);

        void Delete(int id);

        User GetEntityById(int id);
    }
}
