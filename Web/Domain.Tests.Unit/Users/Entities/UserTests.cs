using FluentAssertions; // calling the FluentAssertions library

using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;

namespace UCR.ECCI.IS.ExampleProject.Domain.Tests.Unit.Users.Entities;

/*
 * See implementation in:
 * https://xunit.net/docs/shared-context
*/
public class UserTests : IClassFixture<UserValueObjectsFixture>
{
    // dependency injection of the fixture
    private readonly UserValueObjectsFixture _fixture;

    public UserTests(UserValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void UserConstructor_WithValidParameters_ShouldReturnCorrectId()
    {
        // Arrange
        Guid inputUserId = Guid.Empty;
        const bool inputIsActive = false;

        // Act
        var user = new User(
            inputUserId,
            _fixture.Name,
            _fixture.LastName,
            _fixture.Email,
            inputIsActive
        );

        // Assert
        user.UserId.Should().Be(inputUserId,
            because: "The user id should be the same as the one passed as a parameter in the constructor."
        );
    }

}
