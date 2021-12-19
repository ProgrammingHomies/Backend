using Microsoft.AspNetCore.Mvc;
using ProgrammingHomiesRestApi.Dtos.UserDtos;
using ProgrammingHomiesRestApi.Entities;
using ProgrammingHomiesRestApi.Interfaces;

namespace ProgrammingHomiesRestApi.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepostory repository;

        public UserController(IUserRepostory repository)
        {
            this.repository = repository;
        }


        // Post /items
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateItemAsync(CreateUserDto itemDto)
        {
            User item = new User()
            {
                Id = Guid.NewGuid(),
                Biography = itemDto.Biography,
                BirthDate = itemDto.BirthDate, 
                Mail = itemDto.Mail,
                Password= itemDto.Password,
                ProfilePhotoUrl = itemDto.ProfilePhotoUrl,
                Username = itemDto.Username,
            };

            await repository.CreateAsync(item);

            //CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
            return Ok(item);
        }
    }
}
