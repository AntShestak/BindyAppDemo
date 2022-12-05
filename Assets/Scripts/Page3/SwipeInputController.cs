using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BindyAppDemo
{
    public class SwipeInputController : MonoBehaviour
    {
        private RadialZoom _radialZoom;

        private Vector2 _mousedDownPos;
        private float _swipeThreshold = 50; //pixels

        private void Awake()
        {
            _radialZoom = this.GetComponentInChildren<RadialZoom>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) _mousedDownPos = (Vector2)Input.mousePosition;

            if (Input.GetMouseButtonUp(0))
            {
                Vector2 pos = (Vector2)Input.mousePosition;
                float delta = _mousedDownPos.x - pos.x;

                if (delta < _swipeThreshold * -1) _radialZoom.MoveRight();

                if (delta > _swipeThreshold) _radialZoom.MoveLeft();

            }
        }
    }
}