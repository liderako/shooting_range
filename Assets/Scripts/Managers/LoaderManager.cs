using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace Managers
{
    public class LoaderManager : MonoBehaviour
    {
        [SerializeField] private string _nameFileDataObject;

        private const string _rootElement = "root";
        private const string _childElement = "object";

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
                XElement root = XDocument.Parse(txt.text).Element(_rootElement);
                GenerateObject(root);
            }
        }

        private void GenerateObject(XElement root)
        {
            foreach (XElement element in root.Elements(_childElement))
            {
                GameObject go = (GameObject) Instantiate(Resources.Load("FigurePool"));
                FigurePool fp = go.GetComponent<FigurePool>();
                fp.m_prefab = Resources.Load<Figure>("Figure/" + element.Value);
                fp.m_prefab.Score = Int32.Parse(element.Attribute("reward").Value);
                fp.m_size = DataManager.manager.MaxSizePool;
                fp.gameObject.name = fp.gameObject.name + element.Value;
                fp.AwakePool();
                DataManager.manager.Pools.Add(fp);
            }
        }
    }
}
