using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using GameUI;
using TMPro;
using UnityEngine.UI;
using Enviroment;

namespace Managers
{
    public class LoaderManager : MonoBehaviour
    {
        [SerializeField] private string _nameFileDataObject;
        [SerializeField] private GameObject _scrollViewContent;
        
        private const string RootElementXML = "root";
        private const string ChildElementXML = "object";
        private const string PrefabPoolName = "FigurePool";
        private const string PrefabItemUI = "Item";
        
        // Start is called before the first frame update
        void Start()
        {
            Load();
        }

        private void Load()
        {
            TextAsset txt = Resources.Load<TextAsset>(_nameFileDataObject);
            if (txt == null)
            {
                Debug.Log("Resourse don't find");
            }
            else
            {
                XElement root = XDocument.Parse(txt.text).Element(RootElementXML);
                GenerateObject(root);
            }
        }

        private void GenerateObject(XElement root)
        {
            foreach (XElement element in root.Elements(ChildElementXML))
            {
                GameObject go = (GameObject) Instantiate(Resources.Load(PrefabPoolName));
                FigurePool fp = go.GetComponent<FigurePool>();
                fp.m_prefab = Resources.Load<Figure>("Figure/" + element.Value);
                fp.m_prefab.Score = Int32.Parse(element.Attribute("reward").Value);
                fp.m_size = DataManager.manager.MaxSizePool;
                fp.gameObject.name = fp.gameObject.name + element.Value;
                fp.AwakePool();
                GenerateUI(element, fp);
                DataManager.manager.Pools.Add(fp);
            }
        }

        private void GenerateUI(XElement element, FigurePool fp)
        {
            GameObject item = Instantiate(Resources.Load<GameObject>(PrefabItemUI), _scrollViewContent.transform);
            foreach (Transform child in item.transform)
            {
                if (child.gameObject.GetComponent<TextMeshProUGUI>() != null)
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = element.Attribute("reward").Value;
                }
                if (child.gameObject.GetComponent<Button>() != null)
                {
                    child.gameObject.AddComponent<ButtonSpawn>();
                    child.gameObject.GetComponent<ButtonSpawn>().Fp = fp;
                    child.gameObject.GetComponent<ButtonSpawn>().Spawn += GameManager.Gm.SpawnFigure;
                }
            }
            Instantiate(Resources.Load<GameObject>("FigureUI/" + element.Value), item.transform);
        }
    }
}
