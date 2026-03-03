using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.UI
{
    public class PauseViewUI : MonoBehaviour
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _exitButton;

        public Action OnResumeButtonPress;
        public Action OnExitButtonPress;
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
            _resumeButton.onClick.AddListener(ResumeButtonPress);
            _exitButton.onClick.AddListener(ExitButtonPress);
        }
        private void UnbindButtons()
        {
            _resumeButton.onClick.RemoveListener(ResumeButtonPress);
            _exitButton.onClick.AddListener(ExitButtonPress);
        }
        private void ResumeButtonPress()
        {
            OnResumeButtonPress.Invoke();
         
        }
        private void ExitButtonPress()
        {
            OnExitButtonPress.Invoke();
        }
    }
}
