using System.Collections.Generic;
using System.Threading.Tasks;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Data.Services;
using Bookeasy.Domain.Entities;
using Bookeasy.Persistence.Configurations;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Bookeasy.Persistence.Collections
{
    public class PostCollection : CollectionBase, IPostCollection
    {
        private IMongoCollection<Post> _posts => _database.GetCollection<Post>("posts");

        public PostCollection(IMongoDatabase database) : base(database)
        {
            PostCollectionConfiguration.ConfigureUniqueIndex(_posts);
        }

        public List<Post> Get()
        {
            return _posts.Find(post => true).ToList();
        }

        public async Task<List<Post>> GetAsync()
        {
            var posts = await _posts.FindAsync(post => true);
            return posts.ToList();
        }

        public Post Get(string id)
        {
            return _posts.Find(post => post.Id.ToString() == id).FirstOrDefault();
        }

        public async Task<Post> GetAsync(string id)
        {
            return (await _posts.FindAsync(post => post.Id == ObjectId.Parse(id))).FirstOrDefault();
        }

        public Post Create(Post post)
        {
            _posts.InsertOne(post);
            return post;
        }

        public async Task<Post> CreateAsync(Post post)
        {
            await _posts.InsertOneAsync(post);
            return post;
        }

        public Post Update(string id, Post post)
        {
            var update = Builders<Post>.Update
                .Set(post => post.Body, post.Body)
                .Set(post => post.Title, post.Title);
            var result = _posts.FindOneAndUpdate(post => post.Id == ObjectId.Parse(id), update);
            return result;
        }

        public async Task<Post> UpdateAsync(string id, Post post)
        {
            var update = Builders<Post>.Update
                .Set(post => post.Body, post.Body)
                .Set(post => post.Title, post.Title);
            var result = await _posts.FindOneAndUpdateAsync(post => post.Id == ObjectId.Parse(id), update);
            return result;
        }

        public void Remove(string id)
        {
            _posts.DeleteOne(post => post.Id.ToString() == id);
        }

        public async Task RemoveAsync(string id)
        {
            await _posts.DeleteOneAsync(post => post.Id.ToString() == id);
        }

        public async Task CreateUpVoteAsync(string postId, string userId)
        {
            var updateQuery = Builders<Post>.Update
                .AddToSet(p => p.UsersVotedUp, userId)
                .Pull(p => p.UsersVotedDown, userId);
            await _posts.FindOneAndUpdateAsync(post => post.Id == ObjectId.Parse(postId), updateQuery);
        }

        public async Task CreateDownVoteAsync(string postId, string userId)
        {
            var updateQuery = Builders<Post>.Update
                .AddToSet(p => p.UsersVotedDown, userId)
                .Pull(p => p.UsersVotedUp, userId);
            await _posts.FindOneAndUpdateAsync(post => post.Id == ObjectId.Parse(postId), updateQuery);
        }

        public async Task RemoveVoteAsync(string postId, string userId)
        {
            var updateQuery = Builders<Post>.Update
                .Pull(post => post.UsersVotedUp, userId)
                .Pull(post => post.UsersVotedDown, userId);

            await _posts.FindOneAndUpdateAsync(post => post.Id == ObjectId.Parse(postId), updateQuery);
        }
    }
}