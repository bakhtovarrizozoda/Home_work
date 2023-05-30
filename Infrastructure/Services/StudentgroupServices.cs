using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class StudentgroupServices 
{
    private DapperContext _context;
    public StudentgroupServices()
    {
        _context = new DapperContext();      
    }
    
    // List 
    public List<StudentgroupDto> ListStudentgroup()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select studentid as StudentId, groupid as GroupId from studentgroup";
            var result = conn.Query<StudentgroupDto>(sql).ToList();
            return result.ToList();
        }
    }

    // Insert
    public StudentgroupDto AddStudentgroup(StudentgroupDto studentgroup)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Insert into studentgroup (studentid, groupid) values (@StudentId, @GroupId)";
            var result = conn.Execute(sql, studentgroup);
            return studentgroup;    
        }
    }

    // Update
    public StudentgroupDto UpdateStudentgroup(StudentgroupDto studentgroup)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update studentgroup set studentid = {studentgroup.StudentId}, groupid = {studentgroup.GroupId} where groupid = {studentgroup.GroupId}";
            var result = conn.Execute(sql);
            return studentgroup;
        }
    }

    // Delete
    public StudentgroupDto DeleteStudentgroup(StudentgroupDto studentgroup)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from studentgroup where groupid = {studentgroup.GroupId}";
            var result = conn.Execute(sql);
            return studentgroup;
        }
    }
}

