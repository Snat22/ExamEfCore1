using Domain.DTOs.GroupDtos;
using Domain.Responses;
using Infrastructure.Services.GroupServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Group")]
[ApiController]
public class GroupController(IGroupService service) :ControllerBase
{
    [HttpGet("Get-Groups")]
    public async Task<Response<List<GetGroupDto>>> GetGroups()
    {
        return await service.GetGroupsAsync();
    }

    [HttpGet("groupId:int")]
    public async Task<Response<GetGroupDto>> GetGroupById(int groupId)
    {
        return await service.GetGroupByIdAsync(groupId);
    }
    [HttpPost("Add-group")]
    public async Task<Response<string>> AddGroup(AddGroupDto add)
    {
        return await service.AddGroupAsync(add);
    }

    [HttpPut("Update-Group")]
    public async Task<Response<string>> UpdateGroup(UpdateGroupDto update)
    {
        return await service.UpdateGroupAsync(update);
    }

    [HttpDelete("groupId:int")]
    public async Task<Response<bool>> DeleteGroup(int groupId)
    {
        return await service.DeleteGroupAsync(groupId);
    }
}
