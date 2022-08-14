using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Logger.Entities
{
    public class EntityBase : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
