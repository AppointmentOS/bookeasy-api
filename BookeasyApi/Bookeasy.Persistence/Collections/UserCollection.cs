using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Data.Services;
using Bookeasy.Domain.Entities;
using Bookeasy.Persistence.Configurations;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookeasy.Persistence.Collections
{
    public class UserCollection : CollectionBase<User>, IUserCollection
    {
        private readonly IMongoCollection<User> _users;

        public UserCollection(IMongoCollection<User> collection) : base(collection)
        {
            _users = collection;
            UserCollectionConfiguration.ConfigureUniqueIndex(_users);
        }

        public List<User> Get()
        {
            var users = _users.Find(user => true).ToList();
            return users;
        }

        public User Get(string id)
        {
            var user = _users.Find(user => user.Id.ToString() == id).FirstOrDefault();
            return user;
        }

        public async Task<User> GetAsync(string id)
        {
            var user = (await _users.FindAsync(user => user.Id.ToString() == id)).FirstOrDefault();
            return user;
        }

        public User GetByEmail(string email)
        {
            var user = _users.Find(user => user.Email == email).FirstOrDefault();
            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = (await _users.FindAsync(user => user.Email == email)).FirstOrDefault();
            return user;
        }

        public User Create(User newUser)
        {
            _users.InsertOne(newUser);
            return newUser;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public User Update(string id, User updatedUser)
        {
            var updated = _users.ReplaceOne(user => user.Id.ToString() == id, updatedUser);
            return updatedUser;
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.Id == ObjectId.Parse(id));
        }

        public async Task RemoveAsync(string id)
        {
            await _users.DeleteOneAsync(user => user.Id == ObjectId.Parse(id));
        }
    }
}
