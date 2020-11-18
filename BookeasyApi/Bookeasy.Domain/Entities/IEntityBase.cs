using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bookeasy.Domain.Entities
{
    public interface IEntityBase
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}