using FluentAssertions;
using UCR.ECCI.IS.ExampleProject.Infraestructure.Users.Repositories;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure.Tests.Integration.Users.Repositories;

public class SqlUserRepositoryTests : IClassFixture<TestDatabaseFixture>
{
    private readonly TestDatabaseFixture _fixture;

    public SqlUserRepositoryTests(TestDatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetActiveUsersAsync_WhenNoActiveUsers_ReturnEmptyList()
    {
        // Arrange
        var userRepository = new SqlUserRepository(_fixture.ApplicationDBContext);
        await _fixture
            .SeedDatabaseAsync();
        await _fixture
            .SetAllUsersAsInactiveAsync();

        // Act
        var activeUsers = await userRepository
            .GetActiveUsersAsync();

        // Assert
        activeUsers.Should().BeEmpty(
            because: "when there are no active users, the method should return an empty list.");
    }

    [Fact]
    public async Task GetActiveUsersAsync_WhenActiveUsers_ReturnActiveUsersList()
    {
        // Arrange
        var userRepository = new SqlUserRepository(_fixture.ApplicationDBContext);
        await _fixture
            .SeedDatabaseAsync();

        // Act
        var activeUsers = await userRepository.GetActiveUsersAsync();

        // Assert
        activeUsers.Should().NotBeEmpty(
            because: "when there are active users, the method should return a list with active users.");
    }
}
