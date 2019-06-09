using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enviroment;
namespace Managers
{
    public class DataManager : MonoBehaviour
    {
        public List<FigurePool> Pools;
        [SerializeField]private int _maxSizePool;
        [SerializeField]private int _score;
        public static DataManager DM;

        void Awake()
        {
            if (DM == null)
            {
                DM = this;
            }
        }

        void Start()
        {
            Pools = new List<FigurePool>();
        }

        public int Score
        {
            get => _score;
            set => _score = value;
        }

        public int MaxSizePool
        {
            get => _maxSizePool;
            set => _maxSizePool = value;
        }
    }
}
