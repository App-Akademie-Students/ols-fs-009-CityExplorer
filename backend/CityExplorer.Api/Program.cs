using CityExplorer.Api.Service;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();




// Register services
builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddSingleton<PlaceService>();


builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.MapOpenApi();
  
}

//app.UseHttpsRedirection();

// move this to a separate controller or minimal API endpoint if needed

app.MapGet("/places", async (PlaceService placeService) =>
{
    return await placeService.GetAllPlacesAsync();
});


app.Run();

