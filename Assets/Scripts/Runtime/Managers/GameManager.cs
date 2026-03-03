using System;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        [SerializeField] private Transform _player;
        public Action OnPlayerDead;
        public bool PlayerIsDead { get; private set; }
        private int _playerDeathOffset = 12;
        private void Awake()
        {
            InitSingleton();
            Pause();
        }
        private void Update()
        {
            CheckIfPlayerAlive();
        }
        private void CheckIfPlayerAlive()
        {
            if (_player.position.y < ScoreManager.Instance.Score - _playerDeathOffset
                && PlayerIsDead == false)
            {
                OnPlayerDead?.Invoke();
                PlayerIsDead = true;
            }
        }
        private void InitSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void Pause()
        {
            Time.timeScale = 0f;
        }
        public void Unpause()
        {
            Time.timeScale = 1f;
        }
    }
}