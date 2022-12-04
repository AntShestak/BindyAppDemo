using UnityEngine;
using UnityEngine.SceneManagement;

namespace BindyAppDemo
{
    public sealed class PageManager : MonoBehaviour
    {
        public static PageManager Instance;

        [SerializeField] private string[] _pageNames;
        [SerializeField] 


        private void Awake()
        {
            #region Singleton
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
            #endregion
        }
        private void OnEnable()
        {
            SceneManager.sceneLoaded += SceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= SceneLoaded;
        }

        private void SceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log(scene.buildIndex);
            CanvasManager.Instance.SetPageName(_pageNames[scene.buildIndex]);
        }

        public void LoadSceneByIndex(int _index)
        {
            
            if (_index >= SceneManager.sceneCountInBuildSettings) return;
            SceneManager.LoadScene(_index);
        }
    }
}