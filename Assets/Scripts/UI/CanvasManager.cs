using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace BindyAppDemo
{
    public sealed class CanvasManager : MonoBehaviour
    {
        public static CanvasManager Instance { get; private set; }

        [SerializeField] TextMeshProUGUI _pageNameText;

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

        

    }
}

