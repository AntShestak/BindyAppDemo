using System;
using System.Collections.Generic;
using UnityEngine;

namespace BindyAppDemo
{
    [RequireComponent(typeof(ApiController))]
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance;
        
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

        private void OnEnable()
        {
            ApiController.OnPhotoDataLoaded += DataReceived;
        }

        private void OnDisable()
        {
            ApiController.OnPhotoDataLoaded -= DataReceived;
        }

        private void Start()
        {
            GetData();
        }

        private void GetData()
        {
            _controller.GetPhotos();
        }

        private void DataReceived(List<PhotoData> photos)
        {
            Debug.Log("Data received: " + photos[0].Title);
        }

        public void Retry()
        {
            GetData();
        }
    }
}