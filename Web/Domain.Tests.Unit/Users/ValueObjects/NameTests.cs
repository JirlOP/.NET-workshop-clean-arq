using FluentAssertions; // calling the FluentAssertions library
using UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;

namespace UCR.ECCI.IS.ExampleProject.Domain.Tests.Unit.Users.ValueObjects;

public class NameTests
{
    [Fact] // Fact: allows to test a single test
    public void TryCreate_WithEmptyValue_ShouldFalse()
    {
        // Arrange: prepare the test
        var inputValue = string.Empty;

        // Act: execute the test
        var result = Name.TryCreate(inputValue, out var name);

        // Assert: verify the result
        //Assert.False(result); // default assertion
        result.Should().BeFalse(
            because: "an empty value is considered invalid"); // FluentAssertions
    }

    [Theory] // Theory: allows to test the same test with different data
    [InlineData(null)] //
    [InlineData("@")] // InlineData: allows to pass data to the
    [InlineData(" ")] // same test with different values
    public void TryCreate_WithInvalidValue_ReturnsFalse(string inputValue)
    {
        // Arrange
        // Act
        var result = Name.TryCreate(inputValue, out var name);
        // Assert
        result.Should().BeFalse(
            because: "the value {0} is considered invalid", inputValue);
    }

    // TODO: add more tests for every functionality
}
