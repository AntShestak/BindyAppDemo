using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BindyAppDemo
{
    [RequireComponent(typeof(TextureLoader))]
    public class RadialEntry : MonoBehaviour
    {
        [SerializeField] RawImage _image;


        private RectTransform _trans;
        private TextureLoader _textureLoader;
        private IEnumerator _currentCoroutine;

        private void Awake()
        {
            _textureLoader = GetComponent<TextureLoader>();
            _trans = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _textureLoader.OnTextureLoaded += TextureLoaded;
        }

        private void OnDisable()
        {
            _textureLoader.OnTextureLoaded -= TextureLoaded;
        }

        public void SetActive(bool value)
        {
            _image.enabled = value;
        }

        public void SetPosition(Vector2 pos)
        {
            _trans.anchoredPosition = pos;
        }

        public void MovePositionAndSize(Vector2 pos, Vector2 size)
        {
            if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);

            _currentCoroutine = MovePositionCoroutine(pos,size);
            StartCoroutine(_currentCoroutine);
        }

        public void SetSize(Vector2 size)
        {
            _trans.sizeDelta = size;
        }

        public void LoadTexture(string url)
        {
            _textureLoader.LoadPNGTexture(url);
        }
        

        private void TextureLoaded(Texture tex)
        {
            _image.texture = tex;
        }

        private IEnumerator MovePositionCoroutine(Vector2 pos, Vector2 size)
        {
            

            float speed = 1f; //this value should be in RadialZoom.cs
            float i = 0; //interpolator

            Vector2 startPos = _trans.anchoredPosition;
            Vector2 startSize = _trans.sizeDelta;

            SetActive(true); //only some entries won't be active at this stage

            do
            {
                i += speed * Time.deltaTime;
                SetPosition(Vector2.Lerp(startPos, pos, Mathf.Clamp01(i)));
                SetSize(Vector2.Lerp(startSize, size, Mathf.Clamp01(i)));

                yield return null;
            }
            while (i <= 1);

            //deactivate image if we are in invisible position
            if (_trans.sizeDelta == Vector2.zero) SetActive(false);
        }

        
    }
}