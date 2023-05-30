using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentgroupController : ControllerBase
{
    private StudentgroupServices _studentgroupServices;
    public StudentgroupController()
    {
        _studentgroupServices = new StudentgroupServices();
    }

    [HttpGet("ListStudentgroup")]
    public List<StudentgroupDto> ListStudentgroup()
    {
        return _studentgroupServices.ListStudentgroup();
    }

    [HttpPost("Insert")]
    public StudentgroupDto AddStudentgroup(StudentgroupDto studentgroup)
    {
        return _studentgroupServices.AddStudentgroup(studentgroup);
    }

    [HttpPost("Update")]
    public StudentgroupDto UpdateStudentgroup(StudentgroupDto studentgroup)
    {
        return _studentgroupServices.UpdateStudentgroup(studentgroup);
    }

    [HttpPost("Delete")]
    public StudentgroupDto DeleteStudentgroup(StudentgroupDto studentgroup)
    {
        return _studentgroupServices.DeleteStudentgroup(studentgroup);
    }
}
