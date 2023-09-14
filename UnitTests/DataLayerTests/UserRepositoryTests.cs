using NUnit.Framework;
using Moq;
using YourNamespace.DataLayer.Repositories;
using YourNamespace.DataLayer.Repositories.Interfaces;

[TestFixture]
public class UserRepositoryTests
{
    private Mock<IDbConnection> _mockDbConnection;
    private UserRepository _userRepository;

    [SetUp]
    public void Setup()
    {
        _mockDbConnection = new Mock<IDbConnection>();
        _userRepository = new UserRepository(_mockDbConnection.Object);
    }

    [Test]
    public void TestAddUser_ShouldAddUserSuccessfully()
    {
        // Arrange: Set up the expected behavior and data...

        // Act: Call the method you want to test...

        // Assert: Verify the outcome...
    }

    // Additional tests for other methods in UserRepository...
}
