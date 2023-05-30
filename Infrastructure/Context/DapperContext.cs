using System.Data;
using Npgsql;

namespace Infrastructure.Context;

public class DapperContext
{
    string connectionString = "Server=Localhost; port= 5432; database=SoftClub; User Id= postgres; password= 23022002";

    public DapperContext()
    {
        
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
}
