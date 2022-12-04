using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BindyAppDemo
{
    [RequireComponent(typeof(Button))]
    public class NavButton : MonoBehaviour
    {
        [SerializeField] private int _id; //used with scene loader

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(RequestScene);
        }

        private void RequestScene()
        {
            PageManager.Instance.LoadSceneByIndex(_id);
        }
    }
}