namespace ProgrammingHomiesRestApi.Dtos.UserDtos
{
    public record UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; init; }
        public string Password { get; init; }
        public Uri ProfilePhotoUrl { get; init; }
        public DateTime BirthDate { get; init; }
        public string Mail { get; init; }
        public string Biography { get; init; }
        public Uri GitHubAccountUrl { get; set; }
        public Uri LinkedInAccountUrl { get; set; }
        public List<string> Interests { get; init; }

    }
}
