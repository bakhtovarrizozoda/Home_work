using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class StudentServices
{
    private DapperContext _context;
    public StudentServices()
    {
        _context = new DapperContext();
    }

    // List
    public List<StudentDto> ListStudent()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select firstname as FirstName, lastname as LastName, email as Email, phone as Phone, address as Addres, city as City, id as Id from student";
            var result=conn.Query<StudentDto>(sql).ToList();
            return result.ToList();
        }
    }

    // GetById
    public StudentDto GetStudentById(int Id)
    {
        using (var conn= _context.CreateConnection())
        {
            var sql = $"select firstname as FirstName, lastname as LastName, email as Email, phone as Phone, address as Addres, city as City, id as Id from student where id = {Id}";
            var result = conn.QuerySingle<StudentDto>(sql);
            return result;
        }
    }

    // Insert
    public StudentDto AddStudent(StudentDto student)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into student (firstname, lastname, email, phone, address, city) values (@FirstName, @LastName, @Email, @Phone, @Addres, @City) returning id";
            var id = conn.ExecuteScalar<int>(sql, student);
            student.Id = id;
            return student;
        }
    }

    // Update
    public StudentDto UpdateStudent(StudentDto student)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update student set firstname = '{student.FirstName}', lastname = '{student.LastName}', email = '{student.Email}', address = '{student.Addres}', city = '{student.City}' where id = {student.Id}";
            var result = conn.Execute(sql);
            return student;
        }
    }

    //Delete
    public StudentDto DeleteStudent(StudentDto student)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from student where id = {student.Id}";
            var result = conn.Execute(sql);
            return student;

        }
    }


}
