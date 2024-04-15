using Domain.DTOs.ChallengeDtos;
using Domain.Responses;
using Infrastructure.Services.ChallengeServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ChallengeController(IChallengeService service):ControllerBase
{
    
    [HttpGet("Get-Challenges")]
    public async Task<Response<List<GetChallengeDto>>> GetChallenges()
    {
        return await service.GetChallengesAsync();
    }

    [HttpGet("ChallengeId:int")]
    public async Task<Response<GetChallengeDto>> GetChallengeById(int ChallengeId)
    {
        return await service.GetChallengeByIdAsync(ChallengeId);
    }
    [HttpPost("Add-Challenge")]
    public async Task<Response<string>> AddChallenge(AddChallengeDto add)
    {
        return await service.AddChallengeAsync(add);
    }

    [HttpPut("Update-Challenge")]
    public async Task<Response<string>> UpdateChallenge(UpdateChallengeDto update)
    {
        return await service.UpdateChallengeAsync(update);
    }

    [HttpDelete("ChallengeId:int")]
    public async Task<Response<bool>> DeleteChallenge(int ChallengeId)
    {
        return await service.DeleteChallengeAsync(ChallengeId);
    }
}
