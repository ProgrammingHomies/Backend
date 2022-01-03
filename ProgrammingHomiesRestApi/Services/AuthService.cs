using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProgrammingHomiesRestApi.Entities;
using ProgrammingHomiesRestApi.Helpers;
using ProgrammingHomiesRestApi.Dtos.AuthDtos;
using ProgrammingHomiesRestApi.Interfaces;

namespace ProgrammingHomiesRestApi.Services
{

    public class AuthService : IAuthService
    {
        private readonly IUserRepostory repository;


        private readonly AppSettings _appSettings = new AppSettings();

        public AuthService(IUserRepostory userRepostory, IOptions<AppSettings> appSettings)
        {
            this.repository = userRepostory;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponseDto> Authenticate(AuthenticateRequestDto model)
        {
            var user =await repository.SignInUserAsync(model.Mail, model.Password.ToHash());

            if (user == null) return null;

            var token = generateJwtToken(user);

            return new AuthenticateResponseDto(user, token);
        }

        public async Task<User> GetById(Guid id)
        {
            return await repository.GetAsync(id);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

    


