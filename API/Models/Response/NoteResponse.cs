public class NoteResponse
{
    public int NoteId { get; set; }
    public int UserId { get; set; }  // Owner of the note
    public string Title { get; set; }
    public string Content { get; set; }
}
