using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentController : ControllerBase
{
    private StudentServices _studentServices;
    public StudentController()
    {
        _studentServices = new StudentServices();
    }

    [HttpGet("ListStudent")]
    public List<StudentDto> ListStudent()
    {
        return _studentServices.ListStudent();
    }

    [HttpPost("Get By Id")]
    public StudentDto GetStudentById(int Id)
    {
        return _studentServices.GetStudentById(Id);
    }

    [HttpPost("Insert")]
    public StudentDto AddStudent([FromQuery]StudentDto student)
    {
        return _studentServices.AddStudent(student);
    }

    [HttpPost("UpdateStudent")]
    public StudentDto UpdateStudent([FromQuery]StudentDto student)
    {
        return _studentServices.UpdateStudent(student);
    }

    [HttpPost("DeleteStudent")]
    public StudentDto DeleteStudent([FromQuery]StudentDto student)
    {
        return _studentServices.DeleteStudent(student);
    }
}
