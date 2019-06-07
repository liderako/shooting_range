using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class DataManager : MonoBehaviour
    {
        private List<FigurePool> _pools;
        private int _maxSizePool;

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
            _maxSizePool = 10;
        }

        public List<FigurePool> Pools
        {
            get => _pools;
            set => _pools = value;
        }

        public int MaxSizePool
        {
            get => _maxSizePool;
            set => _maxSizePool = value;
        }
    }
}
