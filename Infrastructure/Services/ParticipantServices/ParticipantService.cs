using System.Net;
using Domain.DTOs.ParticipantDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.ParticipantServices;

public class ParticipantService(DataContext context) : IParticipantService
{
    public async Task<Response<string>> AddParticipantAsync(AddPartipacipantDto add)
    {
        try
        {
        var newParticipant = new Participant()
        {
            FullName = add.FullName,
            Email = add.Email,
            Phone = add.Phone,
            Password = add.Password,
            CreatedAt = add.CreatedAt,
            GroupId = add.GroupId,
            LocationId = add.LocationId
        };
        await context.Participants.AddAsync(newParticipant);
        var res = await context.SaveChangesAsync();
        if(res > 0) return new Response<string>("Added Succesfully!");
        return new Response<string>(HttpStatusCode.BadRequest,"Failed to Add");
    
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    public async Task<Response<List<GetPartipacipantDto>>> GetParticipantAsync()
    {
        try
        {
            var par = await context.Participants.Where(e=> e.Id>0).ToListAsync();

            var list = new List<GetPartipacipantDto>();

            foreach (var item in par)
            {
                var newParticipant = new GetPartipacipantDto()
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Email = item.Email,
                    Phone = item.Phone,
                    Password = item.Password,
                    CreatedAt = item.CreatedAt,
                    GroupId = item.GroupId,
                    LocationId = item.LocationId
                };
                list.Add(newParticipant);
            }
            return new Response<List<GetPartipacipantDto>>(list);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetPartipacipantDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<GetPartipacipantDto>> GetParticipantByIdAsync(int id)
    {
        try
        {
            var par = await context.Participants.FirstOrDefaultAsync(e=> e.Id == id);
            if (par == null) return new Response<GetPartipacipantDto>(HttpStatusCode.BadRequest,"Not Found!");
            var response = new GetPartipacipantDto()
            {
                Id = par.Id,
                FullName = par.FullName,
                Email = par.Email,
                Phone = par.Phone,
                Password = par.Password,
                CreatedAt = par.CreatedAt,
                GroupId = par.GroupId,
                LocationId = par.LocationId
            };
            return new Response<GetPartipacipantDto>(response);
        }
        catch (System.Exception e)
        {
            return new Response<GetPartipacipantDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateParticipantAsync(UpdatePartipacipantDto update)
    {
        try
        {
            var existing = await context.Participants.FirstOrDefaultAsync(e=>e.Id==update.Id);
            if (existing == null) return new Response<string>(HttpStatusCode.BadRequest,"Not Found");

            existing.FullName = update.FullName;
            existing.Email = update.Email;
            existing.Phone = update.Phone;
            existing.Password = update.Password;
            existing.CreatedAt = update.CreatedAt;
            existing.GroupId = update.GroupId;
            existing.LocationId = update.LocationId;

            var res = await context.SaveChangesAsync();
            if(res > 0) return new Response<string>(HttpStatusCode.Accepted,"Yet Updated");
            return new Response<string>(HttpStatusCode.BadRequest,"Failed to Updated");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

        public async Task<Response<bool>> DeleteParticipantAsync(int id)
    {
        try
        {
            var existing = await context.Participants.FindAsync(id);
            if (existing == null) return new Response<bool>(HttpStatusCode.BadRequest,"Not Found",false);
            context.Participants.Remove(existing);
            await context.SaveChangesAsync();
            return new Response<bool>(HttpStatusCode.OK,true);
        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


}
