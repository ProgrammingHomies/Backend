using Microsoft.AspNetCore.Mvc;
using ProgrammingHomiesRestApi.Entities;

namespace ProgrammingHomiesRestApi.Interfaces
{
    public interface ICoreRepostory<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T data);
        Task UpdateAsync(T data);
        Task DeleteAsync(Guid id);
    }
}
