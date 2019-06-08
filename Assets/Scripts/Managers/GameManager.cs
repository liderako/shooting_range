using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enviroment;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Gm;
        [SerializeField]private Vector3 _spawnPosition;
        private void Awake()
        {
            if (Gm == null)
            {
                Gm = this;
            }
        }

        public void SpawnFigure(FigurePool fp)
        {
            Figure figure = fp.Get();
            figure.gameObject.SetActive(true);
            figure.gameObject.transform.position = _spawnPosition;
            Debug.Log("Spawn:" + fp.gameObject.name);
        }
    }
}