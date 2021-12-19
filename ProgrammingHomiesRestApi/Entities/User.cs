using System.ComponentModel.DataAnnotations;

namespace ProgrammingHomiesRestApi.Entities
{
    public record User
    {
        public Guid Id { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public Uri ProfilePhotoUrl { get; init; }
        public DateTime BirthDate { get; init; }
        public string Mail { get; init; }
        public string Biography { get; init; }
    }
}
