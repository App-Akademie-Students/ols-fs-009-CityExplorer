using MongoDB.Bson.Serialization.Attributes;

namespace CityExplorer.Model;

public class Address
{
    [BsonElement("district")]
    public string District { get; set; } = string.Empty;

    [BsonElement("city")]
    public string City { get; set; } = string.Empty;
}
