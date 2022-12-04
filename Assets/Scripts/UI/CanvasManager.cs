using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace BindyAppDemo
{
    public sealed class CanvasManager : MonoBehaviour
    {
        public static CanvasManager Instance { get; private set; }

        [SerializeField] TextMeshProUGUI _pageNameText;

        private ScrollPopulator _scrollPopulator;

        private void Awake()
        {
            #region Singleton

            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;

            #endregion

            _scrollPopulator = GetComponent<ScrollPopulator>();
        }

        public void SetPageName(string name)
        {
            _pageNameText.text = name;
        }

        public void PopulateScroll(List<PhotoData> data)
        {
            _scrollPopulator.Populate(data);
        }

    }
}

