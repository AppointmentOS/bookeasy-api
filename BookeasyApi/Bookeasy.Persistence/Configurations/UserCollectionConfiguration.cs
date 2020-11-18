using Bookeasy.Domain.Entities;
using MongoDB.Driver;

namespace Bookeasy.Persistence.Configurations
{
    public static class UserCollectionConfiguration
    {
        public static void ConfigureUniqueIndex(IMongoCollection<User> collection)
        {
            var keys = Builders<User>.IndexKeys
                .Ascending(user => user.Email);

            var indexModel = new CreateIndexModel<User>(keys, new CreateIndexOptions { Unique = true });
            collection.Indexes.CreateOne(indexModel);
        }
    }
}
