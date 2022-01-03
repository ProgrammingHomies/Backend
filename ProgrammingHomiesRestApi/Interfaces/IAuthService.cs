using ProgrammingHomiesRestApi.Entities;
using ProgrammingHomiesRestApi.Dtos.AuthDtos;

namespace ProgrammingHomiesRestApi.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticateResponseDto> Authenticate(AuthenticateRequestDto model);
        Task<User> GetById(Guid id);
    }
}

    


