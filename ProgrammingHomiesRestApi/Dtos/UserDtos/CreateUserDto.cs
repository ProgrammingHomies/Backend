using System.ComponentModel.DataAnnotations;

namespace ProgrammingHomiesRestApi.Dtos.UserDtos
{
    public class CreateUserDto
    {
        public string Username { get; init; }
        [Required]
        public string Password { get; init; }
        public Uri ProfilePhotoUrl { get; init; }
        public DateTime BirthDate { get; init; }
        [Required]
        public string Mail { get; init; }
        public string Biography { get; init; }
        public Uri GitHubAccountUrl { get; init; }
        public Uri LinkedInAccountUrl { get; init; }
        public List<string> Interests { get; init; }
    }
}
