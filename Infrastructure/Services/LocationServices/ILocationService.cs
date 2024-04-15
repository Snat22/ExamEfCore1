using Domain.DTOs.LocationDtos;
using Domain.Responses;

namespace Infrastructure.Services.LocationServices;

public interface ILocationService
{
    Task<Response<List<GetLocationDto>>> GetLocationAsync();
    Task<Response<GetLocationDto>> GetLocationByIdAsync(int id);
    Task<Response<string>> AddLocationAsync(AddLocationDto add);
    Task<Response<string>> UpdateLocationAsync(UpdateLocationDto update);
    Task<Response<bool>> DeleteLocationAsync(int id);
}
