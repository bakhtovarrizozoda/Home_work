using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class AboutStudentController : ControllerBase
{
    private AboutStudentServices _aboutStudentServices;
    public AboutStudentController()
    {
        _aboutStudentServices = new AboutStudentServices();
    }

    [HttpGet("AboutStudent")]
    public List<AboutStudent> AboutStudent()
    {
        return _aboutStudentServices.AboutStudent();
    }

}
