using Npgsql;

namespace GarageApp;

public class DataBaseService
{
    private static NpgsqlConnection? _connection;
    
    private static string GetConnectionString()
    {
        return @"Host=localhost;Port=5432;Database=garage_db;Username=postgres;Password=9056";
    }
    
    public static NpgsqlConnection GetSqlConnection()
    {
        if (_connection is null)
        {
            _connection = new NpgsqlConnection(GetConnectionString()); 
            _connection.Open();
        }
        
        return _connection;
    }
}