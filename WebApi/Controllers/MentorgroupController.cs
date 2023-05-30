using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class MentorgroupController : ControllerBase
{
    private MentorgroupServices _mentorgroupServices;
    public MentorgroupController()
    {
        _mentorgroupServices = new MentorgroupServices();
    }

    [HttpGet("ListMentorgroup")]
    public List<MentorgroupDto> ListMentorgroup()
    {
        return _mentorgroupServices.ListMentorgroup();
    }

    [HttpPost("Insert")]
    public MentorgroupDto AddMentorgroup(MentorgroupDto mentorgroup)
    {
        return _mentorgroupServices.AddMentorgroup(mentorgroup);
    }

    [HttpPost("Update")]
    public MentorgroupDto UpdateMentorgroup(MentorgroupDto mentorgroup)
    {
        return _mentorgroupServices.UpdateMentorgroup(mentorgroup);
    }

    [HttpPost("Delete")]
    public MentorgroupDto DeleteMentorgroup(MentorgroupDto mentorgroup)
    {
        return _mentorgroupServices.DeleteMentorgroup(mentorgroup);
    }
}
