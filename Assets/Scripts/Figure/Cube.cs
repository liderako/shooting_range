using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enviroment
{
    public class Cube : Figure
    {
        private Animator _animator;
        private Vector3 _scaleBeforeAnimation;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public override void PlayAnimationDead()
        {
            _scaleBeforeAnimation = transform.localScale;
            _animator.SetBool("Destroy", true);
        }

        private void EndAnimationDestroy()
        {
            _animator.SetBool("Destroy", false);
            transform.localScale = _scaleBeforeAnimation;
            DestroyFigure();
        }
    }
}
