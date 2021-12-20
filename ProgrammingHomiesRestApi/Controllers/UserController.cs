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

        // Post /users
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserAsync(CreateUserDto itemDto)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Biography = itemDto.Biography,
                BirthDate = itemDto.BirthDate,
                Mail = itemDto.Mail,
                Password = itemDto.Password,
                ProfilePhotoUrl = itemDto.ProfilePhotoUrl,
                Username = itemDto.Username,
            };

            await repository.CreateAsync(user);


            return CreatedAtAction(nameof(GetUsersAsync), new { id = user.Id }, user.AsDto());
        }

        //Get /users
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var items = (await repository.GetAllAsync()).Select(item => item.AsDto());

            return items;
        }


        // DELETE /users/{id}
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            await repository.DeleteAsync(id);

            return NoContent();
        }

    }
}
