using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class AboutStudentServices
{
    private DapperContext _context;
    public AboutStudentServices()
    {
        _context = new DapperContext();
    }

    // Join
    public List<AboutStudent> AboutStudent()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select concat(s.firstname,' ',s.lastname) as Student, s.city as City, g.groupname as Group, concat(m.firstname,' ',m.lastname) as Mentor, c.coursename as CourseName"+ 
            " from studentgroup sg"+
            " join student s on sg.studentid = s.id"+
            " join groups g on g.id = sg.groupid"+
            " join mentorgroup mg on mg.groupid = sg.groupid"+
            " join mentor m on mg.mentorid = m.id"+
            " join course c on c.id = g.courseid";
            var result = conn.Query<AboutStudent>(sql).ToList();
            return result.ToList();
        }
    }
}
