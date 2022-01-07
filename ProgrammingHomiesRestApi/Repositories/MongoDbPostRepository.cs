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
        public async Task CreateAsync(Post data)
        {
            await postsCollection.InsertOneAsync(data);
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            await postsCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await postsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Post> GetAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await postsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Post data)
        {
            var filter = filterBuilder.Eq(item => item.Id, data.Id);
            var result = await postsCollection.ReplaceOneAsync(filter, data);
        }
    }
}
