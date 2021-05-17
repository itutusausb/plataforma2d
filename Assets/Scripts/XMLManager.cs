using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XMLManager : MonoBehaviour{

    public static XMLManager XML;

    private void Awake()
    {
        XML = this;
    }

    public FruitManager fruitManager;

    public void Save()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(FruitManager));
        FileStream stream = new FileStream(Application.dataPath + "/Users/lopob/Documents/GitHub/Platfor2/Assets/Scripts/frutas.xml", FileMode.Create);
        serializer.Serialize(stream, fruitManager);
        stream.Close();
    }

    public void Load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(FruitManager));
        FileStream stream = new FileStream(Application.dataPath + "/Users/lopob/Documents/GitHub/Platfor2/Assets/Scripts/frutas.xml", FileMode.Open);
        serializer.Deserialize(stream) as FruitManager);
        stream.Close();
    }

    [System.Serializable]
    public class FruitManager
    {
        

    }


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
