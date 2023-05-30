using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class CoursServices
{
    private DapperContext _context;
    public CoursServices()
    {
        _context = new DapperContext();
    }
    
    // List
    public List<CourseDto> ListCourse()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, coursename as CourseName, coursedescription as Coursedescription, fee as Fee, duration as Duration, startdate as Startdate, enddate as Enddate, studentlimit as Studentlimit from course";
            var result = conn.Query<CourseDto>(sql).ToList();
            return result.ToList();
        }
    }

    // GetById
    public CourseDto GetCourseById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, coursename as CourseName, coursedescription as Coursedescription, fee as Fee, duration as Duration, startdate as Startdate, enddate as Enddate, studentlimit as Studentlimit from course where id = {Id}";
            var result = conn.QuerySingle<CourseDto>(sql);
            return result;
        }
    }  

    // Insert
     public CourseDto AddCourse(CourseDto course)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into course (coursename, coursedescription, fee, duration, startdate, enddate, studentlimit) values (@CourseName, @Coursedescription, @Fee, @Duration, @Startdate, @Enddate, @Studentlimit) returning id";
            var id = conn.ExecuteScalar<int>(sql, course);
            course.Id = id;
            return course;
        }
    } 

    // Update
    public CourseDto UpdateCourse(CourseDto course)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update course set coursename = '{course.CourseName}', coursedescription = '{course.Coursedescription}', fee = '{course.Fee}', duration = '{course.Duration}', startdate = '{course.Startdate}, enddate = '{course.Enddate}', studentlimit = '{course.Studentlimit}' where id = {course.Id}";
            var result = conn.Execute(sql);
            return course;
        }
    }

    // Delete
    public CourseDto DeleteCourse(CourseDto course)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from course where id = {course.Id}";
            var result = conn.Execute(sql);
            return course;
        }
    }
}
