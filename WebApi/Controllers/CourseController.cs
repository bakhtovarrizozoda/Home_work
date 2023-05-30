using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CourseController : ControllerBase
{
    private CoursServices _courseServices;
    public CourseController()
    {
        _courseServices = new CoursServices();
    }

    [HttpGet("ListCourse")]
    public List<CourseDto> ListCourse()
    {
        return _courseServices.ListCourse();
    }

    [HttpPost("Get By Id")]
   public CourseDto GetCourseById(int Id)
   {
        return _courseServices.GetCourseById(Id);
   }

    [HttpPost("Insert")]
    public CourseDto AddCourse(CourseDto course)
    {
        return _courseServices.AddCourse(course);
    }

    [HttpPost("Update")]
    public CourseDto UpdateCourse(CourseDto course)
    {
        return _courseServices.UpdateCourse(course);
    }

    [HttpPost("Delete")]
    public CourseDto DeleteCourse(CourseDto course)
    {
        return _courseServices.DeleteCourse(course);
    }

}
