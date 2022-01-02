using phra.Dtos.UserDtos;

namespace phra.Dtos.PostDtos
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime EndTime { get; set; }
    }
}
