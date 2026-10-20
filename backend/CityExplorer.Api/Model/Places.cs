using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace CityExplorer.Model;

public class Place
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }   // ein String oder null

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("category")]
    public string Category { get; set; } = string.Empty;

    // GeoJSON-Point [Längengrad, Breitengrad] – Grundlage für 2dsphere-Abfragen
    [BsonElement("location")]
    public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; } = null!;

    [BsonElement("address")]
    public Address Address { get; set; } = new();

    [BsonElement("tags")]
    public List<string> Tags { get; set; } = [];

    [BsonElement("rating")]
    public double Rating { get; set; }

    // // Zusätzliche, frei wählbare Eigenschaften (z. B. openingHours, website)
    // [BsonElement("properties")]
    // [BsonIgnoreIfNull]
    // public Dictionary<string, object>? Properties { get; set; }
}
