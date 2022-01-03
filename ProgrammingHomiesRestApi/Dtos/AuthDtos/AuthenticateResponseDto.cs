using ProgrammingHomiesRestApi.Entities;

namespace ProgrammingHomiesRestApi.Dtos.AuthDtos
{
    public class AuthenticateResponseDto
    {
        public string Token { get; set; }

        public AuthenticateResponseDto(User user, string token)
        {
            Token = token;
        }
    }
}
