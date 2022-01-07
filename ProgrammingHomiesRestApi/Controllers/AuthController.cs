using Microsoft.AspNetCore.Mvc;
using ProgrammingHomiesRestApi.Dtos.AuthDtos;
using ProgrammingHomiesRestApi.Dtos.UserDtos;
using ProgrammingHomiesRestApi.Entities;
using ProgrammingHomiesRestApi.Interfaces;

namespace ProgrammingHomiesRestApi.Controllers
{
    [ApiController]
    [Route(ControllerConstants.ItemsRoute)]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepostory repository;
        private readonly IAuthService authService;

        public AuthController(IAuthService authService, IUserRepostory userRepostory)
        {
            this.authService = authService;
            this.repository = userRepostory;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticateResponseDto>> SignInAsync(AuthenticateRequestDto requestDto)
        {
            var result = await authService.Authenticate(requestDto);

            return CreatedAtAction("SignIn", result);
        }


        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateNewUserAsync(CreateUserDto itemDto)
        {
            User user = new User()
            {
                Password = itemDto.Password.ToHash(),
                Username = itemDto.Username,
                Id = Guid.NewGuid(),
                Biography = itemDto.Biography,
                BirthDate = itemDto.BirthDate,
                Mail = itemDto.Mail,
                ProfilePhotoUrl = itemDto.ProfilePhotoUrl,
                GitHubAccountUrl = itemDto.GitHubAccountUrl,
                LinkedInAccountUrl = itemDto.LinkedInAccountUrl,
                Interests = itemDto.Interests,
            };

            await repository.CreateAsync(user);

            return CreatedAtAction(nameof(GetUsersAsync), new { id = user.Id }, user.AsDto());
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var items = (await repository.GetAllAsync()).Select(item => item.AsDto());

            return items;
        }
    }
}
