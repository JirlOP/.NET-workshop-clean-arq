using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Entities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ECCI.UCR.IS.ExampleProject.Unity.Presentation.Users
{
    public class UserPresenter : MonoBehaviour
    {
        [SerializeField]
        public TextMeshProUGUI _userLabelTextMeshPro;

        public void OnLoad(User user)
        {
            _userLabelTextMeshPro.text = $"{user.Name.Value} {user.LastName.Value}";
        }
    }
}
