using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BindyAppDemo
{
    public class ScrollEntry : MonoBehaviour
    {

        [SerializeField] private RectTransform _imageHolder;
        [SerializeField] private RectTransform _textHolder;

        [SerializeField] private RawImage _rawImage;
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private TextMeshProUGUI _loadingText;
       

        private TextureLoader _textureLoader;

        private void Awake()
        {
            _textureLoader = GetComponent<TextureLoader>();
        }

        private void Start()
        {
            _loadingText.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _textureLoader.OnLoading += TextureLoading;
            _textureLoader.OnTextureLoaded += TextureLoaded;
            _textureLoader.OnError += TextureLoadingError;
        }

        private void OnDisable()
        {
            _textureLoader.OnLoading -= TextureLoading;
            _textureLoader.OnTextureLoaded -= TextureLoaded;
            _textureLoader.OnError -= TextureLoadingError;
        }

        public void SwitchElementPosition()
        {
            //even elements swap
            Vector2 rightPivot = _imageHolder.pivot;
            Vector2 rightAnchorMin = _imageHolder.anchorMin;
            Vector2 rightAnchorMax = _imageHolder.anchorMax;

            _imageHolder.pivot = _textHolder.pivot;
            _imageHolder.anchorMax = _textHolder.anchorMax;
            _imageHolder.anchorMin = _textHolder.anchorMin;

            _textHolder.pivot = rightPivot;
            _textHolder.anchorMin = rightAnchorMin;
            _textHolder.anchorMax = rightAnchorMax;
        }

        public void SetText(string text)
        {
            _text.text = text;
        }

        public void LoadTexture(string url)
        {
            _textureLoader.LoadPNGTexture(url);
        }

        private void TextureLoading()
        {
            _loadingText.gameObject.SetActive(true);
            _loadingText.text = "Loading...";
        }

        private void TextureLoaded(Texture texture)
        {
            _loadingText.gameObject.SetActive(false);
            
            _rawImage.texture = texture;
            _rawImage.color = Color.white;
        }

        private void TextureLoadingError(string error)
        {
            _loadingText.gameObject.SetActive(true);
            _loadingText.text = "ERR, error";
        }

    }
}