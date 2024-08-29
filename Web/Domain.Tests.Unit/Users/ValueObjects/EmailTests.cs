using FluentAssertions; // calling the FluentAssertions library
using UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;

namespace UCR.ECCI.IS.ExampleProject.Domain.Tests.Unit.Users.ValueObjects;

public class EmailTests
{
    [Fact] // Fact: allows to test a single test
    public void TryCreate_WithEmptyValue_ShouldFalse()
    {
        // Arrange
        var inputValue = string.Empty;

        // Act
        var result = Email.TryCreate(inputValue, out var email);

        // Assert
        result.Should().BeFalse(
            because: "an empty value is considered invalid");
    }

    [Fact]
    public void TryCreate_WithAtAndDotChars_ReturnsTrue()
    {
        // Arrange
        var inputValue = "@.";

        // Act
        var result = Email.TryCreate(inputValue, out var email);

        // Assert
        result.Should().BeTrue(
            because: "the value {0} contains the '@' and '.' characters", inputValue);
        // email.Should().BeTrue(
        //    because: "the value {0} contains the '@' and '.' characters", email);
        // bad practoce to do two asserts in the same test. SPLIT THE TEST
    }

    [Fact]
    public void TryCreate_WhitAtAndDotChars_ReturnsValidOutput()
    {
        // Arrange
        var inputValue = "@.";

        // Act
        var result = Email.TryCreate(inputValue, out var email);

        // Assert
        email.Value.Should().Be(inputValue,
            because: "the output value should match the the input value.");
    }

    // TODO: add more tests for every functionality
}
