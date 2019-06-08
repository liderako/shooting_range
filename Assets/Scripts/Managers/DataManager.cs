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
        public int Score;

        public static DataManager manager;

        void Awake()
        {
            if (manager == null)
            {
                manager = this;
            }
        }

        void Start()
        {
            Pools = new List<FigurePool>();
        }

        public int MaxSizePool
        {
            get => _maxSizePool;
            set => _maxSizePool = value;
        }
    }
}
