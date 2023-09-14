using NUnit.Framework;
using Moq;
using YourNamespace.Api.Controllers;
using YourNamespace.BusinessLogicLayer.Interfaces;

[TestFixture]
public class UsersControllerTests
{
    private Mock<IUserLogic> _mockUserLogic;
    private UsersController _usersController;

    [SetUp]
    public void Setup()
    {
        _mockUserLogic = new Mock<IUserLogic>();
        _usersController = new UsersController(_mockUserLogic.Object);
    }

    [Test]
    public void TestRegister_ShouldRegisterUserSuccessfully()
    {
        // Arrange, Act, Assert...
    }

    // Additional tests for other actions in UsersController...
}
