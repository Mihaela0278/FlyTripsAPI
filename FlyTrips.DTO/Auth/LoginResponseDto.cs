namespace FlyTrips.DTO.Auth
{
    public class LoginResponseDto
    {
        public string Jwt { get; }

        public LoginResponseDto(string jwt) 
        { 
            Jwt = jwt;
        }
    }
}
