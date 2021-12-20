using ProgrammingHomiesRestApi.Entities;
using ProgrammingHomiesRestApi.Interfaces;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ProgrammingHomiesRestApi.Repositories
{
    public class MongoDbPostRepository : IPostRepository
    {
        private readonly IMongoCollection<Post> postsCollection;
        private readonly FilterDefinitionBuilder<Post> filterBuilder = Builders<Post>.Filter;

        public MongoDbPostRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(RepositoryConstant.DatabaseName);
            postsCollection = database.GetCollection<Post>(RepositoryConstant.PostCollectionName);
        }
        public Task CreateAsync(Post data)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Post data)
        {
            throw new NotImplementedException();
        }
    }
}
