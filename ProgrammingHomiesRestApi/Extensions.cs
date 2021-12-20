using ProgrammingHomiesRestApi.Dtos.UserDtos;
using ProgrammingHomiesRestApi.Entities;

namespace ProgrammingHomiesRestApi
{
    public static class Extensions
    {
        public static UserDto AsDto(this User item)
        {
            return new UserDto
            {
                Id = item.Id,
                Biography = item.Biography,
                BirthDate = item.BirthDate,
                Mail = item.Mail,
                Password = item.Password,
                ProfilePhotoUrl = item.ProfilePhotoUrl,
                Username = item.Username,
            };
        }
    }
}
