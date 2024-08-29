using ECCI.UCR.IS.ExampleProject.Unity.Domain.Core.EventSystem;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Entities;
using System.Collections.Generic;

namespace ECCI.UCR.IS.ExampleProject.Unity.Domain.Assets.Scripts.Domain.Users.Events
{
    public readonly struct UsersFetchedEvent : IEvent
    {
        public IEnumerable<User> Users { get; }

        public UsersFetchedEvent(IEnumerable<User> users)
        {
            Users = users;
        }
    }
}
