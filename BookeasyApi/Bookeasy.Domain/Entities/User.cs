using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bookeasy.Domain.Entities
{
    public class User : IEntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Reputation { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime LastAccessDate { get; set; } = DateTime.UtcNow;
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public string ProfileImageUrl { get; set; }
        public string AboutMe { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}