using MongoDB.Driver;
using CityExplorer.Api.Service;
using CityExplorer.Api.Model;
using CityExplorer.Api.Dto;

namespace CityExplorer.Api.Service;

public class PlaceService
{

    private readonly IMongoCollection<Place> _places;

    public PlaceService(MongoDbService mongoDbService)
    {
        _places = mongoDbService.Database.GetCollection<Place>("places");
    }

    //public IMongoCollection<T> GetCollection<T>(string name) => _mongoDbService.Database.GetCollection<T>(name);

    public async Task<List<PlaceDto>> GetAllPlacesAsync()
    {
        var places = await _places.Find(_ => true).ToListAsync();
        return places.Select(ToDto).ToList();
    }

    private static PlaceDto ToDto(Place place)
    {
        return new PlaceDto
        {
            Id = place.Id,
            Name = place.Name,
            Category = place.Category,
            Latitude = place.Location.Coordinates.Latitude,
            Longitude = place.Location.Coordinates.Longitude,
            District = place.Address.District,
            City = place.Address.City,
            Tags = place.Tags,
            Rating = place.Rating
        };
    }

    public async Task<PlaceDto?> GetPlaceByIdAsync(string id)
    {
        var place = await _places.Find(p => p.Id == id).FirstOrDefaultAsync();
        return place == null ? null : ToDto(place);
    }

    public async Task<List<PlaceDto>> GetPlacesByCategoryAsync(string category)
    {
        var places = await _places.Find(p => p.Category == category).ToListAsync();
        return places.Select(ToDto).ToList();
    }

    public async Task<List<PlaceDto>> GetNearbyPlacesAsync(double latitude, double longitude, double maxDistanceInMeters)
    {
        var filter = Builders<Place>.Filter.NearSphere(p => p.Location, longitude, latitude, maxDistanceInMeters);
        var places = await _places.Find(filter).ToListAsync();
        return places.Select(ToDto).ToList();
    }

    public async Task CreatePlaceAsync(Place place)
    {
        await _places.InsertOneAsync(place);
    }


    public async Task<List<PlaceDto>> GetNearbyPlacesAsync(Place place, double maxDistanceInMeters)
    {
        var filter = Builders<Place>.Filter.NearSphere(p => p.Location, place.Location.Coordinates.Longitude, place.Location.Coordinates.Latitude, maxDistanceInMeters);
        var places = await _places.Find(filter).ToListAsync();
        return places.Select(ToDto).ToList();
    }
}