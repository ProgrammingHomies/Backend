using System.ComponentModel.DataAnnotations;

namespace ProgrammingHomiesRestApi.Dtos.AuthDtos
{
    public class AuthenticateRequestDto
    {

        [Required] public string Mail { get; set; }
        [Required] public string Password { get; set; }
    }
}
