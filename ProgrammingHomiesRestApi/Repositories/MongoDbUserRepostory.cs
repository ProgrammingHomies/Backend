using ProgrammingHomiesRestApi.Entities;
using ProgrammingHomiesRestApi.Interfaces;
using MongoDB.Driver;

namespace ProgrammingHomiesRestApi.Repositories
{
    public class MongoDbUserRepostory : IUserRepostory
    {
        private readonly IMongoCollection<User> usersCollection;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;
        public MongoDbUserRepostory(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(RepositoryConstant.DatabaseName);
            usersCollection = database.GetCollection<User>(RepositoryConstant.UserCollectionName);
        }
        public async Task CreateAsync(User data)
        {
            await usersCollection.InsertOneAsync(data);
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id == id);
            await usersCollection.DeleteOneAsync(filter);
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
