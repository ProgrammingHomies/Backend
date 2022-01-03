using ProgrammingHomiesRestApi.Entities;

namespace phra.Dtos.AuthDtos
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Token = token;
        }
    }
}
