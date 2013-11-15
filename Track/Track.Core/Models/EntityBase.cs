using MongoDB.Bson.Serialization.Attributes;

namespace Track.Core.Models
{
    /// <summary>
    /// A non-instantiable base entity which defines 
    /// members available across all entities.
    /// </summary>
    public abstract class EntityBase
    {
        [BsonId]
        public string Id { get; set; }
    }
}