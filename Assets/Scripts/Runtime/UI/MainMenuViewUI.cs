using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.UI
{
    public class MainMenuViewUI : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _recordsButton;
        [SerializeField] private Button _privacyPolicyButton;

        public Action OnStartButtonPress;
        public Action OnRecordsButtonPress;
        public Action OnPrivacyPolicyButtonPress;
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
            _startButton.onClick.AddListener(StartButtonPress);
            _recordsButton.onClick.AddListener(RecordsButtonPress);
            _privacyPolicyButton.onClick.AddListener(PrivacyPolicyButtonPress);
        }
        private void UnbindButtons()
        {
            _startButton.onClick.RemoveListener(StartButtonPress);
            _recordsButton.onClick.RemoveListener(RecordsButtonPress);
            _privacyPolicyButton.onClick.RemoveListener(PrivacyPolicyButtonPress);
        }
        private void StartButtonPress()
        {
            OnStartButtonPress?.Invoke();
        }
        private void RecordsButtonPress()
        {
            OnRecordsButtonPress?.Invoke();
        }
        private void PrivacyPolicyButtonPress()
        {
            OnPrivacyPolicyButtonPress?.Invoke();
        }
    }
}