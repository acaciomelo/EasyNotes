using System.Threading.Tasks;

public interface IUserRepository
{
    Task<int> AddUser(string username, string passwordHash);
    Task<User> GetUserByUsername(string username);
    // More methods related to user operations...
}
