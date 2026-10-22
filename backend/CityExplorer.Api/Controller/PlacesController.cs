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

    // GET /places - all places
    [HttpGet]
    public async Task<List<PlaceDto>> GetAllPlaces()
    {
        var places = await _placeService.GetAllPlacesAsync();
        return places;
    }

    // GET /places/{id} - one place, 404 if the id does not exist
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

    // GET /places/category/{category} - places of one category
    [HttpGet("category/{category}")]   
    public async Task<List<PlaceDto>> GetPlacesByCategory(string category)
    {
        return await _placeService.GetPlacesByCategoryAsync(category);
    }

    // GET /places/nearby?latitude=..&longitude=..&maxDistanceInMeters=.. - places within the radius
    [HttpGet("nearby")]
    public async Task<List<PlaceDto>> GetNearbyPlaces(double latitude, double longitude, double maxDistanceInMeters = 1000)
    {
        return await _placeService.GetNearbyPlacesAsync(latitude, longitude, maxDistanceInMeters);
    }

    // POST /places - creates a place and returns 201 with a link to GET /places/{id}
    [HttpPost]
    public async Task<ActionResult<Place>> CreatePlace(Place place)
    {
        await _placeService.CreatePlaceAsync(place);
        return CreatedAtAction(nameof(GetPlaceById), new { id = place.Id }, place);
    }
}