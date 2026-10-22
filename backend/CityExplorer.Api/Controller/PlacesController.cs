namespace CityExplorer.Api.Controller;
using CityExplorer.Api.Service;
using Microsoft.AspNetCore.Mvc;
using CityExplorer.Api.Model;
using CityExplorer.Api.Dto;

[ApiController]
[Route("places")]
public class PlacesController : ControllerBase
{
    private readonly PlaceService _placeService;

    public PlacesController(PlaceService placeService)
    {
        _placeService = placeService;
    }

    [HttpGet]
    public async Task<List<PlaceDto>> GetAllPlaces()
    {
        var places = await _placeService.GetAllPlacesAsync();
        return places;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlaceDto>> GetPlaceById(string id)
    {
        var place = await _placeService.GetPlaceByIdAsync(id);
        if (place == null)
        {
            return NotFound();
        }
        return place;
    }

    [HttpGet("category/{category}")]   
    public async Task<List<PlaceDto>> GetPlacesByCategory(string category)
    {
        return await _placeService.GetPlacesByCategoryAsync(category);
    }

    [HttpGet("nearby")]
    public async Task<List<PlaceDto>> GetNearbyPlaces(double latitude, double longitude, double maxDistanceInMeters = 1000)
    {
        return await _placeService.GetNearbyPlacesAsync(latitude, longitude, maxDistanceInMeters);
    }

    [HttpPost]
    public async Task<ActionResult<Place>> CreatePlace(Place place)
    {
        await _placeService.CreatePlaceAsync(place);
        return CreatedAtAction(nameof(GetPlaceById), new { id = place.Id }, place);
    }
}