using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using GameUI;
using TMPro;
using UnityEngine.UI;
using System.IO;
using Enviroment;

namespace Managers
{
    public class LoaderManager : MonoBehaviour
    {
        [SerializeField] private string _nameFileDataObject;
        [SerializeField] private GameObject _scrollViewContent;
        private string _pathData;
        
        private const string RootElementXML = "root";
        private const string ChildElementXML = "object";
        private const string PrefabPoolName = "FigurePool";
        private const string PrefabItemUI = "Item";

        public static LoaderManager Lm;

        void Awake()
        {
            if (Lm == null)
            {
                Lm = this;
            }
        }
        
        // Start is called before the first frame update
        void Start()
        {
            _pathData = Application.persistentDataPath + "/data.xml";
            LoadMain();
        }
        
        public void Save()
        {
            XElement root = new XElement(RootElementXML);
            
            root.AddFirst(new XElement("score", DataManager.DM.Score));
            XDocument saveDoc = new XDocument(root);
            File.WriteAllText(_pathData, saveDoc.ToString());
        }
        
        private void LoadMain()
        {
            LoadData();
            LoadObject();
        }

        private void LoadObject()
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

        private void LoadData()
        {
            if (File.Exists(_pathData))
            {
                XElement root = XDocument.Parse(File.ReadAllText(_pathData)).Element(RootElementXML);
                XElement element = root.Element("score");
                DataManager.DM.Score = Int32.Parse(element.Value);
            }
            else
            {
                Save();
            }
        }

        private void GenerateObject(XElement root)
        {
            foreach (XElement element in root.Elements(ChildElementXML))
            {
                GameObject go = (GameObject) Instantiate(Resources.Load(PrefabPoolName));
                FigurePool fp = go.GetComponent<FigurePool>();
                fp.m_prefab = (Resources.Load<Figure>("Figure/" + element.Value));
                fp.m_prefab.Score = Int32.Parse(element.Attribute("reward").Value);
                fp.m_size = DataManager.DM.MaxSizePool;
                fp.gameObject.name = fp.gameObject.name + element.Value;
                fp.AwakePool();
                GenerateUI(element, fp);
                DataManager.DM.Pools.Add(fp);
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
