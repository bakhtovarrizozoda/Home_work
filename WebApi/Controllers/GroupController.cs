using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class GroupController
{
    private GroupServices _groupServices;
    public GroupController()
    {
        _groupServices = new GroupServices();
    }

    [HttpGet("ListGroup")]
    public List<GroupsDto> ListGroup()
    {
        return _groupServices.ListGroup();
    }
    
    [HttpPost("Get By Id")]
    public GroupsDto GetGroupsById(int Id)
    {
        return _groupServices.GetGroupsById(Id);
    }

    [HttpPost("Insert")]
    public GroupsDto AddGroups(GroupsDto groups)
    {
        return _groupServices.AddGroups(groups);
    }

    [HttpPost("Update")]
    public GroupsDto UpdateGroup(GroupsDto groups)
    {
        return _groupServices.UpdateGroup(groups);
    }

    [HttpPost("Delete")]
    public GroupsDto DeleteGroup(GroupsDto groups)
    {
        return _groupServices.DeleteGroup(groups);
    }
}
