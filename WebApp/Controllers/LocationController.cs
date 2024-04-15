using Domain.DTOs.LocationDtos;
using Domain.Responses;
using Infrastructure.Services.LocationServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class LocationController(ILocationService service) :ControllerBase
{
    
    [HttpGet("Get-Locations")]
    public async Task<Response<List<GetLocationDto>>> GetLocations()
    {
        return await service.GetLocationAsync();
    }

    [HttpGet("LocationId:int")]
    public async Task<Response<GetLocationDto>> GetLocationById(int LocationId)
    {
        return await service.GetLocationByIdAsync(LocationId);
    }
    [HttpPost("Add-Location")]
    public async Task<Response<string>> AddLocation(AddLocationDto add)
    {
        return await service.AddLocationAsync(add);
    }

    [HttpPut("Update-Location")]
    public async Task<Response<string>> UpdateLocation(UpdateLocationDto update)
    {
        return await service.UpdateLocationAsync(update);
    }

    [HttpDelete("LocationId:int")]
    public async Task<Response<bool>> DeleteLocation(int LocationId)
    {
        return await service.DeleteLocationAsync(LocationId);
    }
}
