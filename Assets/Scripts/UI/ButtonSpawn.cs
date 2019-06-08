using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enviroment;

namespace GameUI
{
    public class ButtonSpawn : MonoBehaviour
    {
        public FigurePool Fp { get; set; }
        
        private Button _button;
        
        public delegate void MethodContainer(FigurePool fp);
        public event MethodContainer Spawn;
        
        private void Start() {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => { OnClick(); });
        }
        
        private void OnClick()
        {
            if (Spawn != null)
            {
                Spawn(Fp);
            }
        }
    }
}
