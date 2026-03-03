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