using MongoDB.Driver;
using CityExplorer.Api.Service;
using CityExplorer.Api.Model;

namespace CityExplorer.Api.Service;

public class PlaceService
{

    private readonly IMongoCollection<Place> _places;

    public PlaceService(MongoDbService mongoDbService)
    {
        _places = mongoDbService.Database.GetCollection<Place>("places");
    }

    //public IMongoCollection<T> GetCollection<T>(string name) => _mongoDbService.Database.GetCollection<T>(name);

    public async Task<List<Place>> GetAllPlacesAsync()
    {
        return await _places.Find(_ => true).ToListAsync();
    }

}