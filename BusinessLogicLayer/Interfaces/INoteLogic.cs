using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.Models.Response;

public interface INoteLogic
{
    Task<NoteResponse> CreateNote(NoteRequest note);
    Task<IEnumerable<NoteResponse>> GetUserNotes(int userId);
    // More methods related to note operations...
}
