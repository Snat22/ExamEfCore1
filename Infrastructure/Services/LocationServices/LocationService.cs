using System.Net;
using Domain.DTOs.LocationDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.LocationServices;

public class LocationService(DataContext context) : ILocationService
{
    public async Task<Response<string>> AddLocationAsync(AddLocationDto add)
    {
        try
        {
            var location = new Location()
            {
                Name = add.Name,
                Description = add.Description

            };
            await context.Locations.AddAsync(location);
            var res = await context.SaveChangesAsync();
            if(res>0) return new Response<string>("Successfully added");
                return new Response<string>("Failed to add");
    
    }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    public async Task<Response<List<GetLocationDto>>> GetLocationAsync()
    {
        try
        {
            
        var location = await context.Locations.Where(e=> e.Id > 0).ToListAsync();

        var list = new List<GetLocationDto>();

        foreach (var item in location)
        {
            
            var newLocation = new GetLocationDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };
            list.Add(newLocation);
        }
        return new Response<List<GetLocationDto>>(list);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetLocationDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<GetLocationDto>> GetLocationByIdAsync(int id)
    {
        try
        {
            var location = await context.Locations.FirstOrDefaultAsync(e=>e.Id == id);
            if (location == null) return new Response<GetLocationDto>(HttpStatusCode.BadRequest,"Not Found! ");
            var response = new GetLocationDto()
            {
                Id = location.Id,
                Name = location.Name,
                Description = location.Description
            };
            return new Response<GetLocationDto>(response);
        }
        catch (System.Exception e)
        {
            return new Response<GetLocationDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateLocationAsync(UpdateLocationDto update)
    {
        try
        {
            var existing = await context.Locations.FirstOrDefaultAsync(e=> e.Id==update.Id);
            if (existing == null) return new Response<string>(HttpStatusCode.BadRequest,"Not Found!");

            existing.Name = update.Name;
            existing.Description = update.Description;

            var res = await context.SaveChangesAsync();

            if(res > 0) return new Response<string>(HttpStatusCode.OK,"Yet Updated!");
            return new Response<string>(HttpStatusCode.BadRequest,"Failed to Updated!");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    public async Task<Response<bool>> DeleteLocationAsync(int id)
    {
        try
        {
            var deleted = await context.Locations.FindAsync(id);
            if (deleted == null) return new Response<bool>(HttpStatusCode.NotFound,false );

            context.Locations.Remove(deleted);
            await context.SaveChangesAsync();
            return new Response<bool>(HttpStatusCode.OK,true);

        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}
