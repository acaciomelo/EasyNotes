public interface IUserService
{
    UserResponse Register(RegisterUserRequest request);
    UserResponse Login(LoginUserRequest request);
    UserResponse GetCurrentUser(int userId);
}