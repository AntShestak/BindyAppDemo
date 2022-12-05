using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BindyAppDemo
{
    public class ScrollPopulator : MonoBehaviour
    {
        [SerializeField] private GameObject _contentPrefab;
        [SerializeField] private RectTransform _contentHolder;
        [SerializeField] private Scrollbar _scrollbar;

        private int _entriesToPopulate = 20;
        private int _nextEntryId = 0;
        private bool _isExpansionAllowed = true; //this block multiple calls for populating when scrollbar value reachses bottom

        private void Start()
        {
            _scrollbar.onValueChanged.AddListener(CheckScrollValue);
            DataManager.Instance.RequestData();
        }

        private void OnEnable()
        {
            ApiController.OnPhotoDataLoaded += DataReceived;
        }

        private void OnDisable()
        {
            ApiController.OnPhotoDataLoaded -= DataReceived;
        }

        public void Populate(List<PhotoData> data)
        {
            for (int i = 0; i < _entriesToPopulate; i++)
            {
                if (data.Count <= _nextEntryId) break; //run out of entries

                GameObject go = Instantiate(_contentPrefab, _contentHolder);
                ScrollEntry entry = go.GetComponent<ScrollEntry>();
                entry.LoadTexture(data[_nextEntryId].Url);
                entry.SetText(data[_nextEntryId].Title);
                if (_nextEntryId % 2 != 0)
                    entry.SwitchElementPosition();

                _nextEntryId++;
            }

            _isExpansionAllowed= true;
        }

        private void CheckScrollValue(float value)
        {
            if (value <= 0 && _isExpansionAllowed)
            {
                _isExpansionAllowed = false;
                DataManager.Instance.RequestData();
            }
        }

        private void DataReceived(List<PhotoData> data)
        {
            Populate(data);
        }
    }
}