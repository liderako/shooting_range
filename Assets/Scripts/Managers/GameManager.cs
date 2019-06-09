using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enviroment;
using TMPro;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Gm;
        [SerializeField]private Vector3 _spawnPosition;
        [SerializeField] private TextMeshProUGUI _textScore;
        
        public void Awake()
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
            figure.Dead += fp.ReturnObject;
            Debug.Log("Spawn:" + fp.gameObject.name);
        }

        private void Update()
        {
            _textScore.text = DataManager.DM.Score.ToString();
        }

        public void AddScore(int score)
        {
            Debug.Log(score);
            DataManager.DM.Score += score;
            LoaderManager.Lm.Save();
            _textScore.text = DataManager.DM.Score.ToString();
        }
    }
}