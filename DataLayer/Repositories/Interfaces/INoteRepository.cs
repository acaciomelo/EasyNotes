using System.Collections.Generic;
using System.Threading.Tasks;

public interface INoteRepository
{
    Task<int> AddNote(Note note);
    Task<IEnumerable<Note>> GetNotesByUserId(int userId);
    // More methods related to note operations...
}
