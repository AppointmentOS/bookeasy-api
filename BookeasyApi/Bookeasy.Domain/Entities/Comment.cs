using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Bookeasy.Domain.Entities
{
    public class Comment : IEntityBase
    {
        [BsonId] public ObjectId Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string OwnerUserId { get; set; }
        public string Body { get; set; }
        public HashSet<string> UserVotedUp { get; set; } = new HashSet<string>();
        public HashSet<string> UserVotedDown { get; set; } = new HashSet<string>();
    }
}