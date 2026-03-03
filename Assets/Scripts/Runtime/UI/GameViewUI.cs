using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.UI
{
    public class GameViewUI : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TextMeshProUGUI _scoreText;

        public Action OnPauseButtonPress;
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
            _pauseButton.onClick.AddListener(PauseButtonPress);
        }
        private void UnbindButtons()
        {
            _pauseButton.onClick.RemoveListener(PauseButtonPress);
        }
        private void PauseButtonPress()
        {
            OnPauseButtonPress.Invoke();
        }
    }
}