using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class MentorController : ControllerBase
{
    private MentorServices _mentorServices;
    public MentorController()
    {
        _mentorServices = new MentorServices();
    }

    [HttpGet("ListMentor")]
    public List<MentorDto> ListMentor()
    {
        return _mentorServices.ListMentor();
    }

    [HttpPost("Get By Id")]
    public MentorDto GetMentortById(int Id)
    {
        return _mentorServices.GetMentorById(Id);
    }

    [HttpPost("Insert")]
    public MentorDto AddMentor([FromQuery]MentorDto mentor)
    {
        return _mentorServices.AddMentor(mentor);
    }

    [HttpPost("Update")]
    public MentorDto UpdateMentor([FromQuery]MentorDto mentor)
    {
        return _mentorServices.UpdateMentor(mentor);
    }

    [HttpPost("Delete")]
    public MentorDto DeleteMentor([FromQuery]MentorDto mentor)
    {
        return _mentorServices.DeleteMentor(mentor);
    }

}
