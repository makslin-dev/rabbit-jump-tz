using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.Runtime.UI
{
    public class DeadViewUI : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private TextMeshProUGUI _scoreText;

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
            _backButton.onClick.AddListener(BackButtonPress);
        }
        private void UnbindButtons()
        {
            _playAgainButton.onClick.RemoveListener(ResumeButtonPress);
            _backButton.onClick.RemoveListener(BackButtonPress);
        }
        private void ResumeButtonPress()
        {
            OnPlayAgainButtonPress?.Invoke();
        }
        private void BackButtonPress()
        {
            OnBackButtonPress?.Invoke();
        }
        public void ChangeScore(int amount)
        {
            _scoreText.text = $"score: {amount}";
        }
    }
}