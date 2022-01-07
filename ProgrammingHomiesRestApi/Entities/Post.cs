using phra.Dtos.UserDtos;

namespace ProgrammingHomiesRestApi.Entities
{
    public record Post:BaseEntity
    {

        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime EndTime { get; set; }
        public PostUserDto PostUser { get; set; }
    }
}
