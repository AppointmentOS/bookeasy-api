using Bookeasy.Domain.Entities;
using MongoDB.Driver;

namespace Bookeasy.Persistence.Configurations
{
    public static class PostCollectionConfiguration
    {
        public static void ConfigureUniqueIndex(IMongoCollection<Post> collection)
        {
            var keys = Builders<Post>.IndexKeys
                .Ascending(post => post.Title);

            var indexModel = new CreateIndexModel<Post>(keys, new CreateIndexOptions { Unique = true });
            collection.Indexes.CreateOne(indexModel);
        }
    }
}