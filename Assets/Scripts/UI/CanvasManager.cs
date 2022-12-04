using UnityEngine;
using TMPro;


namespace BindyAppDemo
{
    public sealed class CanvasManager : MonoBehaviour
    {
        public static CanvasManager Instance { get; private set; }

        [SerializeField] TextMeshProUGUI _pageNameText;

        [SerializeField] ScrollEntry _entry;
        [SerializeField] ScrollEntry _entry2;

        private void Awake()
        {
            #region Singleton

            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;

            #endregion
        }

        public void SetPageName(string name)
        {
            _pageNameText.text = name;
        }

        public void PopulateScroll()
        {
            
        }

    }
}

