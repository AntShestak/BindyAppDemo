using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BindyAppDemo
{
    public class RadialZoom : MonoBehaviour
    {

        [SerializeField] RectTransform[] _placeholders;
        [SerializeField] RectTransform _holder;
        [SerializeField] GameObject _prefab;
        
        [Header("Buttons for easy debug")]
        [SerializeField] Button _buttonRight;
        [SerializeField] Button _buttonLeft;

        private List<RadialEntry> _entries;
        private int _numberOfEntries = 20;
        private int _entryIndexAtFirstPosition = 0;
        private bool _isPopulated = false;

        void Start()
        {
            _entries = new List<RadialEntry>();
            DataManager.Instance.RequestData();

            _buttonLeft.onClick.AddListener(MoveLeft);
            _buttonRight.onClick.AddListener(MoveRight);
        }

        private void OnEnable()
        {
            ApiController.OnPhotoDataLoaded += PopulateZoom;
        }

        private void OnDisable()
        {
            ApiController.OnPhotoDataLoaded -= PopulateZoom;
        }

        private void MoveRight()
        {
            //to move right index at first position should decrease
            _entryIndexAtFirstPosition -= 1;
            if (_entryIndexAtFirstPosition < 0) _entryIndexAtFirstPosition = _entries.Count - 1;


            //first entry should be dealt with separetely because it will take the invisible position
            _entries[_entryIndexAtFirstPosition].SetPosition(_placeholders[0].anchoredPosition);
            _entries[_entryIndexAtFirstPosition].SetSize(_placeholders[0].sizeDelta);

            for (int i = 1; i < _placeholders.Length; i++)
            {
                int entryIndex = _entryIndexAtFirstPosition + i;
                //overlap
                entryIndex = (entryIndex >= _entries.Count) ? entryIndex - _entries.Count : entryIndex;

                _entries[entryIndex].MovePositionAndSize(_placeholders[i].anchoredPosition, _placeholders[i].sizeDelta);

            }
        }

        private void MoveLeft()
        {
            //to move left increase the index at first position
            _entryIndexAtFirstPosition += 1;
            //take are of overlapping
            _entryIndexAtFirstPosition = (_entryIndexAtFirstPosition >= _entries.Count) ? _entryIndexAtFirstPosition - _entries.Count : _entryIndexAtFirstPosition;

            for (int i = 1; i < _placeholders.Length; i++)
            {
                int entryIndex = _entryIndexAtFirstPosition + i;
                //overlap
                if (_entryIndexAtFirstPosition < 0) _entryIndexAtFirstPosition = _entries.Count - i;

                
                if (i == _placeholders.Length - 1)
                {
                    //last entry dealing with separetely
                    _entries[_entryIndexAtFirstPosition].SetPosition(_placeholders[i].anchoredPosition);
                    _entries[_entryIndexAtFirstPosition].SetSize(_placeholders[i].sizeDelta);
                }
                else
                    _entries[entryIndex].MovePositionAndSize(_placeholders[i].anchoredPosition, _placeholders[i].sizeDelta);


            }

            

            
        }

        
        

        private void StartRadialZoom()
        {
            for (int i = 0; i < _placeholders.Length; i++)
            {
                RadialEntry entry = _entries[i];
                entry.SetPosition(_placeholders[i].anchoredPosition);
                entry.SetSize(_placeholders[i].sizeDelta);
                entry.SetActive(true);
            }
        }

        private void PopulateZoom(List<PhotoData> data)
        {
            if (_isPopulated) return;

            for (int i = 0; i < _numberOfEntries; i++)
            {
                GameObject go = Instantiate(_prefab, _holder);
                RadialEntry newEntry = go.GetComponent<RadialEntry>();
                newEntry.LoadTexture(data[i].Url);

                _entries.Add(newEntry);
                newEntry.SetActive(false);
            }

            StartRadialZoom();
        }
    }
}