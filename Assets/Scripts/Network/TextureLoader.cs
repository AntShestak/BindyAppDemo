using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace BindyAppDemo
{
    public class TextureLoader : MonoBehaviour
    {
        public event Action OnLoading;
        public event Action<Texture> OnTextureLoaded;
        public event Action<string> OnError;

        public void LoadPNGTexture(string url)
        {
            string fullURL = url + ".png";
            IEnumerator req = GetTextueRequest(fullURL);
            StartCoroutine(req);
        }

        IEnumerator GetTextueRequest(string url)
        {
           
            using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url + ".png"))
            {
                OnLoading?.Invoke();
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                    OnError?.Invoke(webRequest.error);
                else
                {
                    var texture = DownloadHandlerTexture.GetContent(webRequest);

                    OnTextureLoaded?.Invoke(texture);
                }
            }

        }
    }
}