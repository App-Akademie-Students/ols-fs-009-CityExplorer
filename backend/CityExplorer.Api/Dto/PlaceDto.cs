namespace CityExplorer.Api.Dto;

public class PlaceDto
{
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = [];
    public double Rating { get; set; }
}
