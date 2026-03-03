using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Runtime.UI
{
    public class RecordSingleUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dateText;
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void SetNewBestScoreForDate(string date, int score)
        {
            _dateText.text = date;
            _scoreText.text = $"{score}m";
        }
    }
}