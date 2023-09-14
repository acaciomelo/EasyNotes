public interface INoteService
{
    NoteResponse Create(NoteRequest request, int userId);
    List<NoteResponse> GetAllByUser(int userId);
    NoteResponse GetById(int noteId, int userId);
    bool Update(int noteId, NoteRequest request, int userId);
    bool Delete(int noteId, int userId);
}
