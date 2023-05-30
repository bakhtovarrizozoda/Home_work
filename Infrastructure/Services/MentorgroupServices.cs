using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class MentorgroupServices 
{
    private DapperContext _context;
    public MentorgroupServices()
    {
        _context = new DapperContext();      
    }
    
    // List 
    public List<MentorgroupDto> ListMentorgroup()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select mentorid as MentorId, groupid as GroupId from mentorgroup";
            var result = conn.Query<MentorgroupDto>(sql).ToList();
            return result.ToList();
        }
    }

    // Insert
    public MentorgroupDto AddMentorgroup(MentorgroupDto mentorgroup)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Insert into mentorgroup (mentorid, groupid) values (@MentorId, @GroupId)";
            var result = conn.Execute(sql, mentorgroup);
            return mentorgroup;    
        }
    }

    // Update
    public MentorgroupDto UpdateMentorgroup(MentorgroupDto mentorgroup)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update mentorgroup set mentorid = {mentorgroup.MentorId}, groupid = {mentorgroup.GroupId} where groupid = {mentorgroup.GroupId}";
            var result = conn.Execute(sql);
            return mentorgroup;
        }
    }

    // Delete
    public MentorgroupDto DeleteMentorgroup(MentorgroupDto mentorgroup)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from mentorgroup where groupid = {mentorgroup.GroupId}";
            var result = conn.Execute(sql);
            return mentorgroup;
        }
    }
}
