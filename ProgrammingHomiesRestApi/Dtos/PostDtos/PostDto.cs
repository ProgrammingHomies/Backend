using phra.Dtos.UserDtos;

namespace phra.Dtos.PostDtos
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime EndTime { get; set; }
        public PostUserDto PostUser { get; set; }
    }
}
