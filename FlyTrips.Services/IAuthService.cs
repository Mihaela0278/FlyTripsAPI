using FlyTrips.DTO.Auth;

namespace FlyTrips.Services
{
    public interface IAuthService
    {
        RegisterResponse Register(RegisterDto registerDto);

        LoginResponseDto Login(LoginDto loginDto);
    }
}
