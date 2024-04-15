using System.Net;
using Domain.DTOs.ChallengeDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.ChallengeServices;

public class ChallengeService(DataContext context) : IChallengeService
{
    public async Task<Response<string>> AddChallengeAsync(AddChallengeDto add)
    {
        try
        {
            var challenge = new Challenge()
            {
            Title = add.Title,
            Description = add.Description
            };
            await context.Challenges.AddAsync(challenge);
            var res = await context.SaveChangesAsync();
            if(res > 0) return new Response<string>("Added Succesfully!");
            return new Response<string>("Failed to Add");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<GetChallengeDto>> GetChallengeByIdAsync(int id)
    {
        try
        {
            var challenge = await context.Challenges.FirstOrDefaultAsync(e=> e.Id == id);
            if(challenge == null) return new Response<GetChallengeDto>(HttpStatusCode.BadRequest,"Not Found!");
            var response = new GetChallengeDto()
            {
                Id = challenge.Id,
                Title = challenge.Title,
                Description = challenge.Description
                
            };
            return new Response<GetChallengeDto>(response);
        }
        catch (System.Exception e)
        {
            return new Response<GetChallengeDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetChallengeDto>>> GetChallengesAsync()
    {
        try
        {
            var challenge = await context.Challenges.Where(e=> e.Id > 0).ToListAsync();

            var list = new List<GetChallengeDto>();
            foreach (var item in challenge)
            {
                
                var newChallenge = new GetChallengeDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description
                };
                list.Add(newChallenge);
            }
            return new Response<List<GetChallengeDto>>(list);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetChallengeDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateChallengeAsync(UpdateChallengeDto update)
    {
        try
        {
            
        var existing = await context.Challenges.FirstOrDefaultAsync(e=> e.Id == update.Id);
        if (existing == null) return new Response<string>(HttpStatusCode.BadRequest,"Not Found!");

        existing.Title = update.Title;
        existing.Description = update.Description;
        var res = await context.SaveChangesAsync();

        if(res > 0) return new Response<string>("Yet Updated ");
        return new Response<string>(HttpStatusCode.BadRequest,"Faild to Updated! ");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteChallengeAsync(int id)
    {
        try
        {
            var deleted = await context.Challenges.FindAsync(id);
            if (deleted == null) return new Response<bool>(HttpStatusCode.NotFound,false);
            context.Challenges.Remove(deleted);
            await context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}
