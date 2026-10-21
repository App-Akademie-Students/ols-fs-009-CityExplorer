
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CityExplorer.Api.Service;


public class MongoDbService
{
    public IMongoDatabase Database { get; }

    public MongoDbService(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
        Database = client.GetDatabase(configuration["MongoDB:Database"]);
    }

    // see PlacesService for usage of GetCollection method
   // public IMongoCollection<T> GetCollection<T>(string name) => _database.GetCollection<T>(name);

   

}
