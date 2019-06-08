using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Enviroment.Interface;

namespace Enviroment
{
    public abstract class Figure : MonoBehaviour, IFigure
    {
        private int _score;

        public delegate void MethodContainer(Figure f);
        public event MethodContainer Dead;
        
        public void GetHit()
        {
            DataManager.manager.Score += _score;
            if (Dead != null)
            {
                Dead(this);
            }
        }

        public int Score
        {
            get => _score;
            set => _score = value;
        }

        public abstract void PlayAnimationDead();
    }
}
