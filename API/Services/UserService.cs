using Dapper;
using System.Data.SqlClient;
using System.Linq;

public class UserService : IUserService
{
    private readonly string _connectionString;

    public UserService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public UserResponse Register(RegisterUserRequest request)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            
            // Password hashing and other validations must be done before inserting.
            var userId = connection.Query<int>(
                "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @PasswordHash); SELECT CAST(SCOPE_IDENTITY() as int);",
                new { request.Username, PasswordHash = request.Password /* Hashing should be applied here */ }
            ).Single();

            return new UserResponse
            {
                UserId = userId,
                Username = request.Username
            };
        }
    }

    public UserResponse Login(LoginUserRequest request)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var user = connection.Query<UserResponse>(
                "SELECT UserId, Username FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash",
                new { request.Username, PasswordHash = request.Password /* Hashing should be applied here */ }
            ).FirstOrDefault();

            return user;
        }
    }

    public UserResponse GetCurrentUser(int userId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var user = connection.Query<UserResponse>(
                "SELECT UserId, Username FROM Users WHERE UserId = @UserId",
                new { UserId = userId }
            ).FirstOrDefault();

            return user;
        }
    }
}
