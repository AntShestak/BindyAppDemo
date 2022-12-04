using System;
using System.Collections.Generic;
using UnityEngine;

namespace BindyAppDemo
{
    [RequireComponent(typeof(ApiController))]
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance;

        public static event Action<List<PhotoData>> OnDataReceived;
        
        private ApiController _controller;

        private void Awake()
        {
            #region Singleton
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
            #endregion
            _controller = GetComponent<ApiController>();
        }

       

        private void GetData()
        {
            _controller.GetPhotoData();
        }

       

        public void RequestData()
        {
            GetData();
        }
    }
}