using ProgrammingHomiesRestApi.Entities;
using ProgrammingHomiesRestApi.Interfaces;

namespace ProgrammingHomiesRestApi.Repositories
{
    public class MongoDbUserRepostory : IUserRepostory
    {
        public Task CreateAsync(User data)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User data)
        {
            throw new NotImplementedException();
        }
    }
}
