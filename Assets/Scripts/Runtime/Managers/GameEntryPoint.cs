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
            while (!operation.isDone)
            {
                timer += Time.deltaTime;


                if (operation.progress >= 0.9f && timer >= minLoadingTime)
                {
                    operation.allowSceneActivation = true;
                }

                await UniTask.Yield();
            }
        }
    }
}