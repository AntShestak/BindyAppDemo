using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BindyAppDemo
{
    public class LookAtCamera : MonoBehaviour
    {
        private Transform _cam;
        // Start is called before the first frame update
        void Start()
        {
            _cam = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - _cam.position);
        }
    }
}