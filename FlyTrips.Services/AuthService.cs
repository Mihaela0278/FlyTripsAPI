using AutoMapper;
using FlyTrips.DTO.Auth;
using FlyTrips.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlyTrips.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly FlyTripsDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(IMapper mapper, 
                           IUserService userService, 
                           FlyTripsDbContext context, 
                           IConfiguration configuration)
        {
            _mapper = mapper;
            _userService = userService;
            _context = context;
            _configuration = configuration;
        }

        public LoginResponseDto Login(LoginDto loginDto)
        {
            if (!_userService.ExistsByUsername(loginDto.Username))
            {
                return null;
            }

            User user = _context.Users.First(u => u.Username == loginDto.Username);

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return null;
            }

            string jwt = CreateJwtToken(user);

            return new LoginResponseDto(jwt);
        }

        public RegisterResponse Register(RegisterDto registerDto)
        {
            if (_userService.ExistsByUsername(registerDto.Username))
            {
                return null;
            }

            User user = _mapper.Map<User>(registerDto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            user.Role = _context.Roles.First(r => r.Name == "User");

            _userService.Create(user);

            return _mapper.Map<RegisterResponse>(user);
        }

        private string CreateJwtToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Secret").Value
                    )
                );

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddHours(1)
                );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

    }
}
