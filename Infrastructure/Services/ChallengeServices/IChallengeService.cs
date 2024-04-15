using Domain.DTOs.ChallengeDtos;
using Domain.Responses;

namespace Infrastructure.Services.ChallengeServices;

public interface IChallengeService
{
    Task<Response<List<GetChallengeDto>>> GetChallengesAsync();
    Task<Response<GetChallengeDto>> GetChallengeByIdAsync(int id);
    Task<Response<string>> AddChallengeAsync(AddChallengeDto add);
    Task<Response<string>> UpdateChallengeAsync(UpdateChallengeDto update);
    Task<Response<bool>> DeleteChallengeAsync(int id);

}
