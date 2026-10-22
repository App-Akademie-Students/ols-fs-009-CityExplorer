using CityExplorer.Api.Service;
using Microsoft.Extensions.FileProviders;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();


// Register services
builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddSingleton<PlaceService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allow the static frontend (other origin) to call the API
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors();

// Serve the static frontend (../../frontend) from the same server
var frontendProvider = new PhysicalFileProvider(
    Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", "..", "frontend")));
app.UseDefaultFiles(new DefaultFilesOptions { FileProvider = frontendProvider });
app.UseStaticFiles(new StaticFileOptions { FileProvider = frontendProvider });

// move this to a separate controller or minimal API endpoint if needed
app.MapControllers();

// app.MapGet("/places", async (PlaceService placeService) =>
// {
//     return await placeService.GetAllPlacesAsync();
// });


app.Run();

