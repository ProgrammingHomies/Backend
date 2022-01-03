using System.ComponentModel.DataAnnotations;

namespace phra.Dtos.AuthDtos
{
    public class AuthenticateRequest
    {

        [Required] public string Mail { get; set; }
        [Required] public string Password { get; set; }
    }
}
