using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.ValueObjects;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace UCR.ECCI.IS.UnityExampleProject.Domain.Tests.Unit
{
    public class EmailTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TryCreate_WithAtAndDotCharacter_ReturnsTrue()
        {
            // Arrange
            var inputValue = "@.";

            // Act
            var result = Email.TryCreate(inputValue, out var email);

            // Assert
            result.Should().BeTrue(
                because: "the value {0} contains both '@' and '.' characters", inputValue);
        }

        [Test]
        public void TryCreate_WithAtAndDotCharacter_ReturnsCorresctOutputVariable()
        {
            // Arrange
            var inputValue = "@.";

            // Act
            var result = Email.TryCreate(inputValue, out var email);

            // Assert
            email.Value.Should().Be(inputValue,
                because: "the out variable should match the input given");
        }
    }
}
