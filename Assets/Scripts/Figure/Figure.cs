using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Enviroment.Interface;

namespace Enviroment
{
    public abstract class Figure : MonoBehaviour, IFigure
    {
        [SerializeField, HideInInspector]private  int _score;
        private  bool _isHit;
        [SerializeField] public AudioSource _sound;
        
        public delegate void MethodContainer(Figure f);
        public event MethodContainer Dead;

        public void GetHit()
        {
            if (!_isHit)
            {
                _isHit = true;
                _sound.Play();
                Debug.Log(_score);
                GameManager.Gm.AddScore(_score);
                PlayAnimationDead();
            }
        }

        public int Score
        {
            set { _score = value; }
        }

        public void DestroyFigure()
        {
            if (Dead != null)
            {
                Dead(this);
            }
            _isHit = false;
        }

        public abstract void PlayAnimationDead();
    }
}
