using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.UI
{
    public class RecordsViewUI : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private RecordSingleUI[] _records;

        public Action OnBackButtonPress;
        private void OnEnable()
        {
            BindButtons();
            InitBestScores();
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
            OnBackButtonPress?.Invoke();
        }
        public void InitBestScores()
        {
            int daysToCheck = 4;

            for (int i = 0; i < daysToCheck && i < _records.Length; i++)
            {
                string date = DateTime.Now.AddDays(-i).ToString("dd.MM");
                string fullKey = "BestScore_" + date;

                if (PlayerPrefs.HasKey(fullKey))
                {
                    int score = PlayerPrefs.GetInt(fullKey);
                    _records[i].SetNewBestScoreForDate(date, score);
                }
            }
        }
    }
}