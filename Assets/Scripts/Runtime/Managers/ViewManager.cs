using Assets.Scripts.Runtime.UI;
using UnityEngine;

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

        private void OnEnable()
        {
            SubscribeToEvents();
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
            _recordsViewUI.OnBackButtonPress += HandleBackButtonPress;
            _privacyPolicyViewUI.OnBackButtonPress += HandleBackButtonPress;
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
            _recordsViewUI.OnBackButtonPress -= HandleBackButtonPress;
            _privacyPolicyViewUI.OnBackButtonPress -= HandleBackButtonPress;

        }
        private void HandleBackButtonPress()
        {
            ChangeView(ScreenView.MainMenuView);
        }
        private void HandlePlayAgainButtonPress()
        {
            //Restart?
            ChangeView(ScreenView.GameView);
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
            ChangeView(ScreenView.GameView);
        }
        private void HandleRecordsButtonPress()
        {
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