using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProgrammingHomiesRestApi.Entities;
using ProgrammingHomiesRestApi.Dtos;
using phra.Helpers;
using phra.Dtos.AuthDtos;

namespace phra.Services
{

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
    }

    public class UserService : IUserService
    {
        private List<User> _users = new List<User>()
        {
            new User {
                Id = Guid.NewGuid(),
                Username = "K4T3",
                Biography = "8v v<1v <0K 9v<Lv",
                BirthDate = new DateTime(1992,6,10),
                FacebookAccountUrl = new Uri(""),
                LinkedInAccountUrl = new Uri(""),
                ProfilePhotoUrl = new Uri(""),
                TwitterAccountUrl = new Uri(""),
                Mail = "mfkuct@hotmail.com",
                Password = "K4P4NW1Y0RDv9M313R"}
        };

        private readonly AppSettings _appSettings = new AppSettings();

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);

            if (user == null) return null;

            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
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

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
    }

    


