using System.Threading.Tasks;
using YourNamespace.Models.Response;

public interface IUserLogic
{
    Task<UserResponse> RegisterUser(string username, string password);
    Task<UserResponse> LoginUser(string username, string password);
    // More methods related to user operations...
}
