using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

public class NoteService : INoteService
{
    private readonly string _connectionString;

    public NoteService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public NoteResponse Create(NoteRequest request, int userId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var noteId = connection.Query<int>(
                "INSERT INTO Notes (UserID, Title, Content) VALUES (@UserID, @Title, @Content); SELECT CAST(SCOPE_IDENTITY() as int);",
                new { UserID = userId, request.Title, request.Content }
            ).Single();

            return new NoteResponse
            {
                NoteId = noteId,
                Title = request.Title,
                Content = request.Content
            };
        }
    }

    public List<NoteResponse> GetAllByUser(int userId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var notes = connection.Query<NoteResponse>(
                "SELECT NoteID, Title, Content FROM Notes WHERE UserID = @UserId",
                new { UserId = userId }
            ).ToList();

            return notes;
        }
    }

    public NoteResponse GetById(int noteId, int userId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var note = connection.Query<NoteResponse>(
                "SELECT NoteID, Title, Content FROM Notes WHERE NoteID = @NoteId AND UserID = @UserId",
                new { NoteId = noteId, UserId = userId }
            ).FirstOrDefault();

            return note;
        }
    }

    public bool Update(int noteId, NoteRequest request, int userId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            int affectedRows = connection.Execute(
                "UPDATE Notes SET Title = @Title, Content = @Content WHERE NoteID = @NoteId AND UserID = @UserId",
                new { request.Title, request.Content, NoteId = noteId, UserId = userId }
            );

            return affectedRows > 0;
        }
    }

    public bool Delete(int noteId, int userId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            int affectedRows = connection.Execute(
                "DELETE FROM Notes WHERE NoteID = @NoteId AND UserID = @UserId",
                new { NoteId = noteId, UserId = userId }
            );

            return affectedRows > 0;
        }
    }
}
