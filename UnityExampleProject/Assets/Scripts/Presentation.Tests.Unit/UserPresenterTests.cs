using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Entities;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.ValueObjects;
using ECCI.UCR.IS.ExampleProject.Unity.Presentation.Users;
using FluentAssertions;
using NUnit.Framework;
using System;
using TMPro;
using UnityEngine;

namespace UCR.ECCI.IS.UnityExampleProject.Presentation.Tests.Unit
{
    public class UserPresenterTests
    {
        [Test]
        public void UserPresenter_OnLoad_UpdatesTextToFullName()
        {
            // Arrange
            var gameObjecUnderTest = new GameObject();
            var userPresenter = gameObjecUnderTest.AddComponent<UserPresenter>();
            var textMeshPro = userPresenter.gameObject.AddComponent<TextMeshProUGUI>();
            userPresenter._userLabelTextMeshPro = textMeshPro;

            // Act
            var user = new User(
                Guid.Parse("87c9c211-a48c-4bd2-8c58-1c597c244e3c"),
                Name.Create("First"),
                Name.Create("Last"),
                Email.Create("email@test.com"),
                isActive: true);

            userPresenter.OnLoad(user);

            // Assert
            textMeshPro.text.Should().Be("First Last",
                because: "the UserPresenter should update the text to {FirstName} {LastName} upon loading");
        }
    }
}
