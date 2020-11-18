using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Domain.Entities;
using Bookeasy.Persistence.Collections;
using MongoDB.Driver;

namespace Bookeasy.Persistence
{
    public class IrisDbContext : IIrisDbContext
    {
        public IUserCollection User { get; }
        public IPostCollection Post { get; }
        public ICommentCollection Comment { get; }

        public IrisDbContext(IMongoDbDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.Database);
            User = new UserCollection(db.GetCollection<User>(settings.UserCollection));
            Post = new PostCollection(db.GetCollection<Post>(settings.UserCollection));
            Comment = new CommentCollection(db.GetCollection<Post>(settings.UserCollection));
        }
    }
}
