using NUnit.Framework;
using Moq;
using YourNamespace.DataLayer.Repositories;
using YourNamespace.DataLayer.Repositories.Interfaces;

[TestFixture]
public class NoteRepositoryTests
{
    private Mock<IDbConnection> _mockDbConnection;
    private NoteRepository _noteRepository;

    [SetUp]
    public void Setup()
    {
        _mockDbConnection = new Mock<IDbConnection>();
        _noteRepository = new NoteRepository(_mockDbConnection.Object);
    }

    [Test]
    public void TestAddNote_ShouldAddNoteSuccessfully()
    {
        // Arrange, Act, Assert...
    }

    // Additional tests for other methods in NoteRepository...
}
