using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Runtime.Managers
{
    public class GameEntryPoint : MonoBehaviour
    {
        private static GameEntryPoint _instance;

        [Header("Settings")]
        [SerializeField] private int nextSceneBuildIndex = 1; 
        [SerializeField] private float minLoadingTime = 2f;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private async void Start()
        {
            await LoadGameAsync();
        }

        private async UniTask LoadGameAsync()
        {
            var operation = SceneManager.LoadSceneAsync(nextSceneBuildIndex);
            operation.allowSceneActivation = false;

            float timer = 0f;
            while (operation.progress < 0.9f)
            {
                await UniTask.Yield();
            }
            while (timer < minLoadingTime)
            {
                timer += Time.deltaTime;
                await UniTask.Yield();
            }

            operation.allowSceneActivation = true;
            await operation;
        }
    }
}