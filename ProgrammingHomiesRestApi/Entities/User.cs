using System.ComponentModel.DataAnnotations;

namespace ProgrammingHomiesRestApi.Entities
{
    public record User:BaseEntity
    {
        public string Username { get; init; }
        public string Password { get; init; }
        public Uri ProfilePhotoUrl { get; init; }
        public DateTime BirthDate { get; init; }
        public string Mail { get; init; }
        public string Biography { get; init; }
        public Uri LinkedInAccountUrl { get; set; }
        public Uri GitHubAccountUrl { get; set; }
        public List<string> Interests { get; init; }

    }
}
