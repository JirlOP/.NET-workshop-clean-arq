using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;
using UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;
using UCR.ECCI.IS.ExampleProject.Infraestructure.Users.Repositories;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure.Tests.Unit.Users.Repositories;

public class SqlUserRepositoryTests
{
    [Fact]
    public async Task GetActiveUsersAsync_WhenNoActiveUsers_ReturnEmptyList()
    {
        // Arrange
        User[] users = [
            new User(
                userId: Guid.Parse("9d190ba3-1ec6-4091-9781-d7f71a15b76a"),
                name: Name.Create("First"),
                lastName: Name.Create("Last"),
                email: Email.Create("first.last@email.com"),
                isActive: false),
            new User(
                userId: Guid.Parse("e18cd860-e44e-461d-a0b4-127696944ade"),
                name: Name.Create("First2"),
                lastName: Name.Create("Last2"),
                email: Email.Create("first.last2@email.com"),
                isActive: false)
            ];

        var usersDbSetMock = users.BuildMock().BuildMockDbSet();

        var dbContextMock = new Mock<ApplicationDBContext>();
        dbContextMock
            .Setup(dbContext => dbContext.Users)
            .Returns(usersDbSetMock.Object);

        var userRepository = new SqlUserRepository(dbContextMock.Object);

        // Act
        var activeUsers = await userRepository.GetActiveUsersAsync();

        // Assert
        activeUsers.Should().BeEmpty(
            because: "when there are no active users, the method should return an empty list.");
    }

    [Fact]
    public async Task GetActiveUsersAsync_WhenActiveUsers_ReturnActiveUsersList()
    {
        // Arrange
        User activeUser = new User(
            userId: Guid.Parse("01093f29-8abf-4224-b84f-5d927e1baabd"),
            name: Name.Create("First3"),
            lastName: Name.Create("Last3"),
            email: Email.Create("first.last3@email.com"),
            isActive: true);
        User[] users = [
            new User(
                userId: Guid.Parse("9d190ba3-1ec6-4091-9781-d7f71a15b76a"),
                name: Name.Create("First"),
                lastName: Name.Create("Last"),
                email: Email.Create("first.last@email.com"),
                isActive: false),
            new User(
                userId: Guid.Parse("e18cd860-e44e-461d-a0b4-127696944ade"),
                name: Name.Create("First2"),
                lastName: Name.Create("Last2"),
                email: Email.Create("first.last2@email.com"),
                isActive: false),
            activeUser
            ];

        var usersDbSetMock = users.BuildMock().BuildMockDbSet();

        var dbContextMock = new Mock<ApplicationDBContext>();
        dbContextMock
            .Setup(dbContext => dbContext.Users)
            .Returns(usersDbSetMock.Object);

        var userRepository = new SqlUserRepository(dbContextMock.Object);

        // Act
        var activeUsers = await userRepository.GetActiveUsersAsync();

        // Assert
        activeUsers.Should().BeEquivalentTo([activeUser],
            because: "when there are active users, the method should return a list with the active users.");
    }
}

// "Homework": Do infrastructure layer tests.
// https://github.com/MichalJankowskii/Moq.EntityFrameworkCore