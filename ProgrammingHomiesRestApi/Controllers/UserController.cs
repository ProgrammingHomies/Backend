using Microsoft.AspNetCore.Mvc;
using phra.Controllers;
using ProgrammingHomiesRestApi.Dtos.UserDtos;
using ProgrammingHomiesRestApi.Entities;
using ProgrammingHomiesRestApi.Interfaces;

namespace ProgrammingHomiesRestApi.Controllers
{
    [ApiController]
    [Route(ControllerConstants.ItemsRoute)]
    public class UserController : ControllerBase
    {
        private readonly IUserRepostory repository;

        public UserController(IUserRepostory repository)
        {
            this.repository = repository;
        }

        // POST /users
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

        // GET /users
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var items = (await repository.GetAllAsync()).Select(item => item.AsDto());

            return items;
        }

        // DELETE /users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            await repository.DeleteAsync(id);

            return NoContent();
        }

        // GET /users/{id}
        [HttpGet("{id}")]
        public async Task<UserDto> GetUserAsync(Guid id)
        {
            var item = await repository.GetAsync(id);

            return item.AsDto();
        }

        // PUT /users/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUserAsync(Guid id, UserDto user)
        {
            User updatedUser = new User()
            {
                Id = id,
                Biography = user.Biography,
                BirthDate = user.BirthDate,
                Mail = user.Mail,
                Password = user.Password,
                ProfilePhotoUrl = user.ProfilePhotoUrl,
                Username = user.Username,
            };

            await repository.UpdateAsync(updatedUser);

            return CreatedAtAction(nameof(GetUsersAsync), new { id = user.Id }, updatedUser.AsDto());
        }

    }
}
