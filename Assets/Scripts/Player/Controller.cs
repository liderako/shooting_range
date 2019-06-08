using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enviroment.Interface;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnTouch();
            }
        }

        public void OnTouch()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
//                Debug.DrawRay(ray.origin, ray.direction);
                if (hit.transform.gameObject.GetComponent<IFigure>() != null)
                {
                    hit.transform.gameObject.GetComponent<IFigure>().GetHit();
                }
            }
        }
    }
}
