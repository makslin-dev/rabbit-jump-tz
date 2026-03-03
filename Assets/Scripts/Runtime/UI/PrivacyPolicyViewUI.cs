using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.UI
{
    public class PrivacyPolicyViewUI : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        public Action OnBackButtonPress;
        private void OnEnable()
        {
            BindButtons();
        }
        private void OnDisable()
        {
            UnbindButtons();
        }
        private void BindButtons()
        {
            _backButton.onClick.AddListener(BackButtonPress);
        }
        private void UnbindButtons()
        {
            _backButton.onClick.RemoveListener(BackButtonPress);
        }
        private void BackButtonPress()
        {
            OnBackButtonPress.Invoke();
        }
    }
}