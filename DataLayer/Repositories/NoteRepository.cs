using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

public class NoteRepository : INoteRepository
{
    private readonly IDbConnection _connection;

    public NoteRepository(DatabaseConnection dbConnection)
    {
        _connection = dbConnection.CreateConnection();
    }

    public async Task<int> AddNote(Note note)
    {
        var sql = "INSERT INTO Notes (UserID, Title, Content) VALUES (@UserID, @Title, @Content); SELECT CAST(SCOPE_IDENTITY() as int)";
        var noteId = await _connection.QuerySingleAsync<int>(sql, note);
        return noteId;
    }

    public async Task<IEnumerable<Note>> GetNotesByUserId(int userId)
    {
        var sql = "SELECT * FROM Notes WHERE UserID = @UserId";
        var notes = await _connection.QueryAsync<Note>(sql, new { UserId = userId });
        return notes;
    }
    
    // More methods implementing the INoteRepository interface...
}
