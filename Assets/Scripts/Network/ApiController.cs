using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

namespace BindyAppDemo
{
    /// <summary>
    /// Model for photos endpoint deserialisation
    /// </summary>
    public class PhotoData
    {
        [JsonProperty("albumId")]
        public int AlbumId;

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl;
    }

    public class ApiController : MonoBehaviour
    {
        public static event Action<List<PhotoData>> OnPhotoDataLoaded;
        public static event Action<string> OnErrorReceived;

        private string url ="https://jsonplaceholder.typicode.com/photos";

        public void GetPhotos()
        {
            StartCoroutine("GetPhotosRequest");
        }

        IEnumerator GetPhotosRequest()
        {

            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                        OnErrorReceived?.Invoke(webRequest.error);
                        break;
                    case UnityWebRequest.Result.DataProcessingError:
                        OnErrorReceived?.Invoke(webRequest.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        OnErrorReceived?.Invoke(webRequest.error);
                        break;
                    case UnityWebRequest.Result.Success:
                       
                        string text = webRequest.downloadHandler.text;

                        var photos = JsonConvert.DeserializeObject<List<PhotoData>>(text);

                        OnPhotoDataLoaded?.Invoke(photos);
                        

                        break;
                }
            }

        }
    }
}