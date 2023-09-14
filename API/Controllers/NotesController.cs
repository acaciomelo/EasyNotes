[ApiController]
[Route("api/notes")]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [Authorize]
    [HttpPost]
    public IActionResult Create([FromBody] NoteRequest request)
    {
        int userId = GetUserIdFromToken();
        var response = _noteService.Create(request, userId);

        if (response == null)
        {
            return BadRequest(new { Message = "Failed to create note." });
        }

        return CreatedAtAction(nameof(GetById), new { id = response.NoteId }, response);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        int userId = GetUserIdFromToken();
        var notes = _noteService.GetAllByUser(userId);

        return Ok(notes);
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        int userId = GetUserIdFromToken();
        var note = _noteService.GetById(id, userId);

        if (note == null)
        {
            return NotFound();
        }

        return Ok(note);
    }

    [Authorize]
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] NoteRequest request)
    {
        int userId = GetUserIdFromToken();
        var success = _noteService.Update(id, request, userId);

        if (!success)
        {
            return BadRequest(new { Message = "Failed to update note." });
        }

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        int userId = GetUserIdFromToken();
        var success = _noteService.Delete(id, userId);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    // Placeholder method to simulate extracting user ID from JWT claims
    private int GetUserIdFromToken()
    {
        // In a real-world scenario, you'd extract the user ID from the token's claims.
        return 1; // Hardcoded for demonstration purposes.
    }
}
