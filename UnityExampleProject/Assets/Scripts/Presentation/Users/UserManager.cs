using ECCI.UCR.IS.ExampleProject.Unity.Domain.Assets.Scripts.Domain.Users.Events;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Core.EventSystem;
using UCR.ECCI.IS.ExampleProject.Unity.Application.Users;
using UnityEngine;
using Zenject;

namespace ECCI.UCR.IS.ExampleProject.Unity.Presentaion.Users

{
    public class UserManager : MonoBehaviour
    {
        [Inject] // Inject the IUserService. This is from Zenject.
        private IUserService _userService;

        [Inject] // This services are already binded in the installer.
        private IEventChannel _eventChannel;

        public AwaitableCompletionSource GetActiveUsersAwaitableCompletionSource {  get; private set; }

        private async Awaitable GetActiveUsersAsync()
        {
            // Fetch data from API.
            var users = await _userService.GetActiveUsersAsync();

            // Create and fire event, to notify observers about the active users.
            var @event = new UsersFetchedEvent(users);
            _eventChannel.Fire(@event);

            // Complete the AwaitableCompletionSource.
            GetActiveUsersAwaitableCompletionSource.SetResult();
        }

        // Start is called before the first frame update
        // Only the event handlers van be async void
        async void Start()
        {
            GetActiveUsersAwaitableCompletionSource = new AwaitableCompletionSource();
            await GetActiveUsersAsync();
        }
    }
}
