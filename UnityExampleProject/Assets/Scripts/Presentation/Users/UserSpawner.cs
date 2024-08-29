using System.Collections.Generic;
using UnityEngine;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Entities;
using TMPro;
using ECCI.UCR.IS.ExampleProject.Unity.Presentation.Users;
using Zenject;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Core.EventSystem;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Assets.Scripts.Domain.Users.Events;

namespace ECCI.UCR.IS.ExampleProject.Unity.Presentaion.Users
{
    public class UserSpawner : MonoBehaviour
    {
        // Serialized fields are exposed in the Unity Editor
        [SerializeField]
        private GameObject _userPrefab;

        [SerializeField]
        private float _offset;

        [Inject]
        private IEventChannel _eventChannel;

        // Start is called before the first frame update
        void Start()
        {
            _eventChannel.Subscribe<UsersFetchedEvent>(OnUsersFetched);
        }

        void OnDestroy()
        {
            _eventChannel.Unsubscribe<UsersFetchedEvent>(OnUsersFetched);
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// It activates when a Suscribed event is fired.
        /// </summary>
        /// <param name="event"></param>
        private void OnUsersFetched(UsersFetchedEvent @event)
        { 
            float currentOffset = 0;
            foreach (var user in @event.Users)
            {
                var userPosition = transform.position + new Vector3(currentOffset, 0);
                var userGameObject = Instantiate(_userPrefab, userPosition, transform.rotation);

                userGameObject.GetComponent<UserPresenter>().OnLoad(user);
                                
                currentOffset += _offset;
            }
        }

    }
}
