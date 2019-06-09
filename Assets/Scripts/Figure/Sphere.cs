using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enviroment
{   
    public class Sphere : Figure
    {
        [SerializeField]private ParticleSystem _ps;
        
        public override void PlayAnimationDead()
        {
            GetComponent<MeshRenderer>().enabled = false;
            _ps.Play();
            StartCoroutine(PlayingAnimation());
        }

        private IEnumerator PlayingAnimation()
        {
            yield return new WaitForSeconds(_ps.main.duration);
            GetComponent<MeshRenderer>().enabled = true;
            DestroyFigure();
        }
    }
}