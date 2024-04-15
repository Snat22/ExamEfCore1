using Domain.DTOs.ParticipantDtos;
using Domain.Responses;

namespace Infrastructure.Services.ParticipantServices;

public interface IParticipantService
{
    Task<Response<List<GetPartipacipantDto>>> GetParticipantAsync();
    Task<Response<GetPartipacipantDto>> GetParticipantByIdAsync(int id);
    Task<Response<string>> AddParticipantAsync(AddPartipacipantDto add);
    Task<Response<string>> UpdateParticipantAsync(UpdatePartipacipantDto update);
    Task<Response<bool>> DeleteParticipantAsync(int id);
}
