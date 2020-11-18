using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bookeasy.Domain.Entities
{
    public class Vote : IEntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
    }
}