using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Persistence.Collections;
using MongoDB.Driver;

namespace Bookeasy.Persistence
{
    public class IrisDbContext : IIrisDbContext
    {
        public IUserCollection User { get; }
        public IPostCollection Post { get; }
        public ICommentCollection Comment { get; }

        public IrisDbContext(IMongoClient client)
        {
            var db = client.GetDatabase("Bookeasy");
            User = new UserCollection(db);
            Post = new PostCollection(db);
            Comment = new CommentCollection(db);
        }
    }
}