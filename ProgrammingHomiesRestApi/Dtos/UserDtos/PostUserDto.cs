namespace phra.Dtos.UserDtos
{
    public record PostUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; init; }
        public Uri ProfilePhotoUrl { get; init; }
        public string Mail { get; init; }
        public string Biography { get; init; }
        public Uri LinkedInAccountUrl { get; init; }
        public Uri GitHubAccountUrl { get; init; }
    }
}
