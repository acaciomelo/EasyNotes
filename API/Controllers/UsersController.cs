[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterUserRequest request)
    {
        var response = _userService.Register(request);

        if (response == null)
        {
            return BadRequest(new { Message = "Failed to register user." });
        }

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUserRequest request)
    {
        var response = _userService.Login(request);

        if (response == null)
        {
            return Unauthorized(new { Message = "Invalid username or password." });
        }

        // Assuming you have a method to generate JWT tokens.
        var token = GenerateJwtToken(response.UserId);
        
        return Ok(new { response.UserId, response.Username, Token = token });
    }

    [Authorize]  // Ensure this method can only be accessed with a valid JWT
    [HttpGet("me")]
    public IActionResult GetCurrentUser()
    {
        // In a real-world scenario, you'd extract the user ID from the token's claims.
        int userId = GetUserIdFromToken();

        var response = _userService.GetCurrentUser(userId);
        
        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}

