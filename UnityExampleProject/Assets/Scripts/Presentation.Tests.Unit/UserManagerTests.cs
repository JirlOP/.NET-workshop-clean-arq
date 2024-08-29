using System.Collections;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Assets.Scripts.Domain.Users.Events;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Core.EventSystem;
using ECCI.UCR.IS.ExampleProject.Unity.Presentaion.Users;
using Moq;
using UCR.ECCI.IS.ExampleProject.Unity.Application.Users;
using UnityEngine.TestTools;
using Zenject;

namespace UCR.ECCI.IS.UnityExampleProject.Presentation.Tests.Unit
{
    public class UserManagerTests : ZenjectIntegrationTestFixture
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator UserManager_WhenStarting_LoadsUsers()
        {
            // Arrange
            Mock<IUserService> userServiceMock = new(behavior: MockBehavior.Loose);
            Mock<IEventChannel> eventChannelMock = new(behavior: MockBehavior.Loose);

            // Set up dependency injection for the test.
            PreInstall();

            Container
                .Bind<IUserService>()
                .FromInstance(userServiceMock.Object);

            Container
                .Bind<IEventChannel>()
                .FromInstance(eventChannelMock.Object);

            Container
                .Bind<UserManager>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();

            PostInstall();

            var userManager = Container.Resolve<UserManager>();
            
            // Skip one fram to allow Start method to run.
            yield return null;

            // Wait as many frames until the Awaitable complets.
            yield return userManager.GetActiveUsersAwaitableCompletionSource.Awaitable;

            userServiceMock
                .Verify(userManager => userManager.GetActiveUsersAsync(),
                    Times.Once,
                    failMessage: "UserManager should load all the users upon starting");
        }

        [UnityTest]
        public IEnumerator UserManager_UponLoadingUsers_FiresEvent()
        {
            // Arrange
            Mock<IUserService> userServiceMock = new(behavior: MockBehavior.Loose);
            Mock<IEventChannel> eventChannelMock = new(behavior: MockBehavior.Loose);

            // Set up dependency injection for the test.
            PreInstall();

            Container
                .Bind<IUserService>()
                .FromInstance(userServiceMock.Object);

            Container
                .Bind<IEventChannel>()
                .FromInstance(eventChannelMock.Object);

            Container
                .Bind<UserManager>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();

            PostInstall();

            var userManager = Container.Resolve<UserManager>();

            // Skip one fram to allow Start method to run.
            yield return null;

            // Wait as many frames until the Awaitable complets.
            yield return userManager.GetActiveUsersAwaitableCompletionSource.Awaitable;

            eventChannelMock
                .Verify(eventChannel => eventChannel.Fire(It.IsAny<UsersFetchedEvent>()),
                    Times.Once,
                    failMessage: "UserManager should fire event upon loading users");
        }
    }
}
