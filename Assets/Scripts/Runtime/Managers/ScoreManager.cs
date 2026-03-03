using System;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        [SerializeField] private Transform _player;

        public float Score { get; private set; } = 0f;
        private float _highestScore;

        public Action<int> OnPlayerScoring;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
            _highestScore = PlayerPrefs.GetInt("BestScore", 0);
        }
        private void OnEnable()
        {
            GameManager.Instance.OnPlayerDead += SaveDailyRecord;
        }
        private void Update()
        {
            HandlePlayerScoring();
        }
        private void OnDisable()
        {
            GameManager.Instance.OnPlayerDead -= SaveDailyRecord;
        }
        private void HandlePlayerScoring()
        {
            if (_player == null) return;

            if (_player.position.y > Score)
            {
                Score = _player.position.y;
                OnPlayerScoring?.Invoke(Mathf.RoundToInt(Score));
            }
            if (Score > _highestScore)
            {
                SaveDailyRecord();
            }
        }

        public void SaveDailyRecord()
        {
            int finalScore = Mathf.RoundToInt(Score);
            if (finalScore > _highestScore)
            {
                _highestScore = finalScore;
                PlayerPrefs.SetInt("BestScore", finalScore);
            }
            string dateKey = "BestScore_" + DateTime.Now.ToString("dd.MM");
            int dailyHighest = PlayerPrefs.GetInt(dateKey, 0);

            if (finalScore > dailyHighest)
            {
                PlayerPrefs.SetInt(dateKey, finalScore);
            }

            PlayerPrefs.Save();
        }

        public int GetScoreByDate(string date)
        {
            return PlayerPrefs.GetInt("BestScore_" + date, 0);
        }

        public int GetBestScore()
        {
            return Mathf.RoundToInt(_highestScore);
        }
    }
}