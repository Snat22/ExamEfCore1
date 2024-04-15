using Domain.DTOs.ParticipantDtos;
using Domain.Responses;
using Infrastructure.Services.ParticipantServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ParticipantController(IParticipantService service):ControllerBase
{
    
    [HttpGet("Get-Participants")]
    public async Task<Response<List<GetPartipacipantDto>>> GetParticipants()
    {
        return await service.GetParticipantAsync();
    }

    [HttpGet("ParticipantId:int")]
    public async Task<Response<GetPartipacipantDto>> GetParticipantById(int ParticipantId)
    {
        return await service.GetParticipantByIdAsync(ParticipantId);
    }
    [HttpPost("Add-Participant")]
    public async Task<Response<string>> AddParticipant(AddPartipacipantDto add)
    {
        return await service.AddParticipantAsync(add);
    }

    [HttpPut("Update-Participant")]
    public async Task<Response<string>> UpdateParticipant(UpdatePartipacipantDto update)
    {
        return await service.UpdateParticipantAsync(update);
    }

    [HttpDelete("ParticipantId:int")]
    public async Task<Response<bool>> DeleteParticipant(int ParticipantId)
    {
        return await service.DeleteParticipantAsync(ParticipantId);
    }
}
