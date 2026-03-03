using UnityEngine;
using System;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.UI
{
    public class DeadViewUI : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _playAgainButton;

        public Action OnPlayAgainButtonPress;
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
            _playAgainButton.onClick.AddListener(ResumeButtonPress);
        }
        private void UnbindButtons()
        {
            _playAgainButton.onClick.RemoveListener(ResumeButtonPress);
        }
        private void ResumeButtonPress()
        {
            OnPlayAgainButtonPress.Invoke();
        }

    }
}