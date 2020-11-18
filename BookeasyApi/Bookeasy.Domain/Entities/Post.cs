using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;

namespace Bookeasy.Domain.Entities
{
    public class Post : IEntityBase
    {
        [BsonId] public ObjectId Id { get; set; }
        [BsonRepresentation(BsonType.String)] public PostType PostType { get; set; }
        public HashSet<string> UsersVotedUp { get; set; } = new HashSet<string>();
        public HashSet<string> UsersVotedDown { get; set; } = new HashSet<string>();
        public int Score { get; set; }
        public int ViewCount { get; set; }
        public string Body { get; set; }
        public string OwnerId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? DeletionDate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public DateTime LastActivityDate { get; set; } = DateTime.Now;
        public DateTime? ClosedDate { get; set; }
        public GeoJson2DGeographicCoordinates GeoLocation { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
