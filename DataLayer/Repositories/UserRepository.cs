using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _connection;

    public UserRepository(DatabaseConnection dbConnection)
    {
        _connection = dbConnection.CreateConnection();
    }

    public async Task<int> AddUser(string username, string passwordHash)
    {
        var sql = "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @PasswordHash); SELECT CAST(SCOPE_IDENTITY() as int)";
        var userId = await _connection.QuerySingleAsync<int>(sql, new { Username = username, PasswordHash = passwordHash });
        return userId;
    }

    public async Task<User> GetUserByUsername(string username)
    {
        var sql = "SELECT * FROM Users WHERE Username = @Username";
        var user = (await _connection.QueryAsync<User>(sql, new { Username = username })).FirstOrDefault();
        return user;
    }
    
    // More methods implementing the IUserRepository interface...
}
