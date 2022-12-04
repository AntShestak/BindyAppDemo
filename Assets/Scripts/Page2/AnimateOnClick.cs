using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BindyAppDemo
{
    public class AnimateOnClick : MonoBehaviour
    {
        private Animator _anim;

        private void Awake()
        {
            _anim = GetComponentInChildren<Animator>();
        }

        private void OnMouseDown()
        {
            _anim.SetTrigger("Click");
        }


    }
}