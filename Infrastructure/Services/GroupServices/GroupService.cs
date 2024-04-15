using System.Net;
using Domain.DTOs.GroupDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.GroupServices;

public class GroupService(DataContext context) : IGroupService
{
    public async Task<Response<string>> AddGroupAsync(AddGroupDto add)
    {
        try
        {
            var group = new Group()
            {
                GroupNick = add.GroupNick,
                ChallengeId = add.ChallengeId,
                NeedMember = add.NeedMember,
                TeamSlogan = add.TeamSlogan,
                CreatedAt = add.CreatedAt
            };
            await context.Groups.AddAsync(group);
            var res = await context.SaveChangesAsync();
            if(res> 0) return new Response<string>("Added Succesfully!");
            return new Response<string>(HttpStatusCode.BadRequest,"Failed to add");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    

    public async Task<Response<GetGroupDto>> GetGroupByIdAsync(int id)
    {
        try
        {
            var group = await context.Groups.FirstOrDefaultAsync(g => g.Id==id);
            if(group==null) return new Response<GetGroupDto>(HttpStatusCode.BadRequest,"Not Found!");
            
            var response = new GetGroupDto()
            {
                Id = group.Id,
                GroupNick = group.GroupNick,
                ChallengeId = group.ChallengeId,
                NeedMember = group.NeedMember,
                TeamSlogan = group.TeamSlogan,
                CreatedAt = group.CreatedAt
            };
            return new Response<GetGroupDto>(response);
        }
        catch (System.Exception e)
        {
            return new Response<GetGroupDto>(HttpStatusCode.InternalServerError,e.Message);            
        }
    }

    public async Task<Response<List<GetGroupDto>>> GetGroupsAsync()
    {
        try
        {
            var groups = await context.Groups.Where(e=> e.Id > 0).ToListAsync();

        var list = new List<GetGroupDto>();

        foreach (var item in groups)
        {
            
            var newGroup = new GetGroupDto()
            {
                Id = item.Id,
                GroupNick = item.GroupNick,
                ChallengeId = item.ChallengeId,
                NeedMember = item.NeedMember,
                TeamSlogan = item.TeamSlogan,
                CreatedAt = item.CreatedAt
            };
            list.Add(newGroup);
        }
        return new Response<List<GetGroupDto>>(list);
    
        }
        catch (System.Exception e)
        {
        return new Response<List<GetGroupDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateGroupAsync(UpdateGroupDto update)
    {
        try
        {
            var existing = await context.Groups.FirstOrDefaultAsync(e=> e.Id==update.Id);
            if (existing == null) return new Response<string>(HttpStatusCode.BadRequest,"Not Found!");

            existing.GroupNick = update.GroupNick;
            existing.ChallengeId = update.ChallengeId;
            existing.NeedMember = update.NeedMember;
            existing.TeamSlogan = update.TeamSlogan;
            existing.CreatedAt = update.CreatedAt;

            var res = await context.SaveChangesAsync();

            if(res > 0) return new Response<string>(HttpStatusCode.OK,"Yet Updated!");
            return new Response<string>(HttpStatusCode.BadRequest,"Failed to Updated");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<bool>> DeleteGroupAsync(int id)
    {
        try
        {
            var deleted = await context.Groups.FindAsync(id);
            if (deleted == null) return new Response<bool>(HttpStatusCode.BadRequest,"Not found");
            context.Groups.Remove(deleted);
            var res = await context.SaveChangesAsync();
            return new Response<bool>(HttpStatusCode.OK,true);
        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}
