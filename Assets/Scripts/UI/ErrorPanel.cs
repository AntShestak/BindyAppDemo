using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BindyAppDemo
{
    public class ErrorPanel : MonoBehaviour
    {
        private Image _image;
        private TextMeshProUGUI _message;
        private Button _button;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _message = GetComponentInChildren<TextMeshProUGUI>();
            _button = GetComponentInChildren<Button>();
        }

        private void Start()
        {
            SetActive(false);
        }

        private void OnEnable()
        {
            ApiController.OnErrorReceived += ReceiveError;
        }

        private void OnDisable()
        {
            ApiController.OnErrorReceived -= ReceiveError;
        }

        private void SetActive(bool value)
        {
            _image.enabled = value;
            _message.gameObject.SetActive(value);
            _button.gameObject.SetActive(value);
        }

        private void ReceiveError(string error)
        {
            _message.text = error;
            SetActive(true);
        }

        private void TryAgain()
        {
            SetActive(false);
            DataManager.Instance.Retry();
        }

    }
}