using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

public class Item
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid ItemId { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("price")]
    public float Price { get; set; }

    [BsonElement("createdDate")]
    public DateTime CreatedDate { get; set; }
}
