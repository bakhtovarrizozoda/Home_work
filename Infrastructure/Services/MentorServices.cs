using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class MentorServices
{
        private DapperContext _context;
    public MentorServices()
    {
        _context = new DapperContext();
    }

    // List
    public List<MentorDto> ListMentor()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select firstname as FirstName, lastname as LastName, email as Email, phone as Phone, address as Addres, city as City, id as Id from mentor";
            var result=conn.Query<MentorDto>(sql).ToList();
            return result.ToList();
        }
    }

    // GetById
    public MentorDto GetMentorById(int Id)
    {
        using (var conn= _context.CreateConnection())
        {
            var sql = $"select firstname as FirstName, lastname as LastName, email as Email, phone as Phone, address as Addres, city as City, id as Id from mentor where id = {Id}";
            var result = conn.QuerySingle<MentorDto>(sql);
            return result;
        }
    }

    // Insert
    public MentorDto AddMentor(MentorDto mentor)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into mentor (firstname, lastname, email, phone, address, city) values (@FirstName, @LastName, @Email, @Phone, @Addres, @City) returning id";
            var id = conn.ExecuteScalar<int>(sql, mentor);
            mentor.Id = id;
            return mentor;
        }
    }

    // Update
    public MentorDto UpdateMentor(MentorDto mentor)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update mentor set firstname = '{mentor.FirstName}', lastname = '{mentor.LastName}', email = '{mentor.Email}', address = '{mentor.Addres}', city = '{mentor.City}' where id = {mentor.Id}";
            var result = conn.Execute(sql);
            return mentor;
        }
    }

    //Delete
    public MentorDto DeleteMentor(MentorDto mentor)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from mentor where id = {mentor.Id}";
            var result = conn.Execute(sql);
            return mentor;
        }
    }
}
