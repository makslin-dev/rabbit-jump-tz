using Assets.Scripts.Core.Enums;
using Assets.Scripts.Runtime.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Runtime.Managers
{
    public class ViewManager : MonoBehaviour
    {
        [SerializeField] private GameViewUI _gameViewUI;
        [SerializeField] private MainMenuViewUI _mainMenuViewUI;
        [SerializeField] private PauseViewUI _pauseViewUI;
        [SerializeField] private DeadViewUI _deadViewUI;
        [SerializeField] private RecordsViewUI _recordsViewUI;
        [SerializeField] private PrivacyPolicyViewUI _privacyPolicyViewUI;

        public static bool ShouldStartGameImmediately;
        private void Start()
        {
            SubscribeToEvents();
            DecideStartingPoint();
        }
        private void OnDisable()
        {
            UnsubscribeFromEvents();
        }   
        private void SubscribeToEvents()
        {
            _gameViewUI.OnPauseButtonPress += HandlePauseButtonPress;
            _mainMenuViewUI.OnPrivacyPolicyButtonPress += HandlePrivacyPolicyButtonPress;
            _mainMenuViewUI.OnRecordsButtonPress += HandleRecordsButtonPress;
            _mainMenuViewUI.OnStartButtonPress += HandleStartButtonPress;
            _pauseViewUI.OnExitButtonPress += HandleExitButtonPress;
            _pauseViewUI.OnResumeButtonPress += HandleResumeButtonPress;
            _deadViewUI.OnPlayAgainButtonPress += HandlePlayAgainButtonPress;
            _deadViewUI.OnBackButtonPress += HandleBackButtonFromDeadPress;
            _recordsViewUI.OnBackButtonPress += HandleBackButtonPress;
            _privacyPolicyViewUI.OnBackButtonPress += HandleBackButtonPress;
            ScoreManager.Instance.OnPlayerScoring += HandlePlayerScore;
            GameManager.Instance.OnPlayerDead += HandlePlayerDead;
        }
        private void UnsubscribeFromEvents()
        {
            _gameViewUI.OnPauseButtonPress -= HandlePauseButtonPress;
            _mainMenuViewUI.OnPrivacyPolicyButtonPress -= HandlePrivacyPolicyButtonPress;
            _mainMenuViewUI.OnRecordsButtonPress -= HandleRecordsButtonPress;
            _mainMenuViewUI.OnStartButtonPress -= HandleStartButtonPress;
            _pauseViewUI.OnExitButtonPress -= HandleExitButtonPress;
            _pauseViewUI.OnResumeButtonPress -= HandleResumeButtonPress;
            _deadViewUI.OnPlayAgainButtonPress -= HandlePlayAgainButtonPress;
            _deadViewUI.OnBackButtonPress -= HandleBackButtonFromDeadPress;
            _recordsViewUI.OnBackButtonPress -= HandleBackButtonPress;
            _privacyPolicyViewUI.OnBackButtonPress -= HandleBackButtonPress;
            ScoreManager.Instance.OnPlayerScoring -= HandlePlayerScore;
            GameManager.Instance.OnPlayerDead -= HandlePlayerDead;
        }
        private void DecideStartingPoint()
        {
            if (ShouldStartGameImmediately)
            {
                ShouldStartGameImmediately = false;
                ChangeView(ScreenView.GameView);
                GameManager.Instance.Unpause();
            }
        }
        private void HandlePlayerDead()
        {
            _deadViewUI.ChangeScore(Mathf.RoundToInt(ScoreManager.Instance.Score));
            ChangeView(ScreenView.DeadView);
        }
        private void HandlePlayerScore(int amount)
        {
            print("updating score");
            _gameViewUI.UpdatePlayerScore(amount);
        }
        private void HandleBackButtonPress()
        {
            print("going here");
            ChangeView(ScreenView.MainMenuView);
        }
        private void HandleBackButtonFromDeadPress()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        private void HandlePlayAgainButtonPress()
        {
            ShouldStartGameImmediately = true;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        private void HandleResumeButtonPress()
        {
            ChangeView(ScreenView.GameView);
        }
        private void HandleExitButtonPress()
        {
            ChangeView(ScreenView.MainMenuView);
        }
        private void HandleStartButtonPress()
        {
            GameManager.Instance.Unpause();
            ChangeView(ScreenView.GameView);
        }
        private void HandleRecordsButtonPress()
        {
            _recordsViewUI.InitBestScores();
            ChangeView(ScreenView.Records);
        }
        private void HandlePauseButtonPress()
        {
            ChangeView(ScreenView.PauseView);
        }
        private void HandlePrivacyPolicyButtonPress()
        {
            ChangeView(ScreenView.PrivacyPolicy);
        }
        private void ChangeView(ScreenView view)
        {
            _gameViewUI.gameObject.SetActive(false);
            _mainMenuViewUI.gameObject.SetActive(false);
            _pauseViewUI.gameObject.SetActive(false);
            _deadViewUI.gameObject.SetActive(false);
            _recordsViewUI.gameObject.SetActive(false);
            _privacyPolicyViewUI.gameObject.SetActive(false);
            switch (view)
            {
                case ScreenView.Records:
                    _recordsViewUI.gameObject.SetActive(true);
                    break;
                case ScreenView.PrivacyPolicy:
                    _privacyPolicyViewUI.gameObject.SetActive(true);
                    break;
                case ScreenView.GameView:
                    _gameViewUI.gameObject.SetActive(true);
                    break;
                case ScreenView.PauseView:
                    _pauseViewUI.gameObject.SetActive(true);
                    break;
                case ScreenView.MainMenuView:
                    _mainMenuViewUI.gameObject.SetActive(true);
                    break;
                case ScreenView.DeadView:
                    _deadViewUI.gameObject.SetActive(true);
                    break;
            }
        }
    }
}