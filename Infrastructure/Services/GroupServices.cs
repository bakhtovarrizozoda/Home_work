using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class GroupServices
{
    private DapperContext _context;
    public GroupServices()
    {
        _context = new DapperContext();
    }

    // List 
    public List<GroupsDto> ListGroup()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select groupname as GroupName, groupdescription as Groupdescription, courseid as Courseid, id as Id from groups";
            var result = conn.Query<GroupsDto>(sql).ToList();
            return result.ToList();
        }
    }

    // Get By Id
    public GroupsDto GetGroupsById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select groupname as GroupName, groupdescription as Groupdescription, courseid as Courseid, id as Id from groups where id = {Id}";
            var result = conn.QuerySingle<GroupsDto>(sql);
            return result;
        }
    }

    // insert 
    public GroupsDto AddGroups(GroupsDto groups)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into groups (groupname, groupdescription, courseid) values (@GroupName, @Groupdescription, @Courseid) returning id";
            var id = conn.ExecuteScalar<int>(sql, groups);
            groups.Id = id;
            return groups;
        }
    }

    // Update
    public GroupsDto UpdateGroup(GroupsDto groups)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update groups set groupname = '{groups.GroupName}', groupdescription = '{groups.Groupdescription}', courseid = '{groups.Courseid}' where id = {groups.Id}";
            var result = conn.Execute(sql);
            return groups;
        }
    }

    // Delete
    public GroupsDto DeleteGroup(GroupsDto groups)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from groups where id = {groups.Id}";
            var result = conn.Execute(sql);
            return groups;
        }
    }
}
