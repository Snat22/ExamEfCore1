using Domain.DTOs.GroupDtos;
using Domain.Responses;

namespace Infrastructure.Services.GroupServices;

public interface IGroupService
{
    Task<Response<List<GetGroupDto>>> GetGroupsAsync();
    Task<Response<GetGroupDto>> GetGroupByIdAsync(int id);
    Task<Response<string>> AddGroupAsync(AddGroupDto add);
    Task<Response<string>> UpdateGroupAsync(UpdateGroupDto update);
    Task<Response<bool>> DeleteGroupAsync(int id);
}
