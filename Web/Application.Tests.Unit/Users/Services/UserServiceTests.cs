using FluentAssertions;
using Moq;
using UCR.ECCI.IS.ExampleProject.Application.Users.Services;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Repositories;

namespace UCR.ECCI.IS.ExampleProject.Application.Tests.Unit.Users.Services;

public class UserServiceTests : IClassFixture<UsersListFixture>
{

    private readonly UsersListFixture _fixture;
    public UserServiceTests(UsersListFixture fixture)
    {
        _fixture = fixture;
    }

    // TODO: add tests for every functionality
    [Fact]
    public async Task GetActiveUserAsync_WhenGivenNonEmptyList_ShouldReturnCorrectUsers()
    {
        // Arrange
        // We configure the mock in fixture class to return the list of active users
        // The fixture creates a list of users and a list of active users
        // To represent the repository, we use a mock object
        var userRepoMock = new Mock<IUserRepository>();
        userRepoMock
            .Setup(repo => repo.GetActiveUsersAsync())
            .ReturnsAsync(_fixture.ActiveUsersList);
        var userService = new UserService(userRepoMock.Object);

        // Act
        var results = await userService.GetActiveUsersAsync();

        // Assert
        results.Should().BeEquivalentTo(_fixture.ActiveUsersList,
            because: "the list of active users should be the same as the one returned by the repository");
    }
}
