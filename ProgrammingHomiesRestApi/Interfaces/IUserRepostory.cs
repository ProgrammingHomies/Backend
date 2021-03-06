using Microsoft.AspNetCore.Mvc;
using ProgrammingHomiesRestApi.Entities;

namespace ProgrammingHomiesRestApi.Interfaces
{
    public interface IUserRepostory : ICoreRepostory<User>
    {
        Task<User> SignInUserAsync(string mail, string password);
    }
}
