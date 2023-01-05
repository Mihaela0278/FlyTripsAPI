using AutoMapper;
using FlyTrips.DTO.Auth;
using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(FlyTripsDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public RegisterResponse Create(RegisterDto dto)
        {
            if (ExistsByUsername(dto.Username))
            {
                return null;
            }

            User user = _mapper.Map<User>(dto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            user.Role = _context.Roles.First(r => r.Name == "Admin");

            Create(user);

            return _mapper.Map<RegisterResponse>(user);
        }

        public void Delete(int id)
        {
            User user = base.GetById(id);

            Delete(user);
        }

        public bool ExistsByUsername(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public User GetEntityById(int id)
        {
            return base.GetById(id);
        }

        public new IEnumerable<RegisterResponse> GetAll()
        {
            return base.GetAll().Select(_mapper.Map<RegisterResponse>).ToList();
        }

        public new RegisterResponse GetById(int id)
        {
            return _mapper.Map<RegisterResponse>(base.GetById(id));
        }

        public RegisterResponse Update(int id, RegisterDto dto)
        {
            User user = base.GetById(id);
            if (user == null)
            {
                return null;
            }

            _mapper.Map(dto, user);
            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            Update(user);

            return _mapper.Map<RegisterResponse>(user);
        }
    }
}
