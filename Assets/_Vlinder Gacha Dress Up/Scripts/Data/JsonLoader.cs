using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector;
using UnityEngine;

public class JsonLoader : Singleton<JsonLoader>
{
    public string jsonFilePath;
    [ShowInInspector] public Dictionary<EItemType, ItemTypeDataToJson> jsonData = new Dictionary<EItemType, ItemTypeDataToJson>();
    
    protected override void Awake()
    {
        base.Awake();
        jsonFilePath = "Assets/_Vlinder Gacha Dress Up/Scripts/Data/GameData.json";
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadJson();
    }

    public void LoadJson()
    {
        if (!File.Exists(jsonFilePath))
        {
            Debug.LogError("Can not find .json file with path: " + jsonFilePath);
            return;
        }

        string jsonText = File.ReadAllText(jsonFilePath);
        var deserialized = 
            JsonUtility.FromJson<SerializationWrapper<EItemType, ItemTypeDataToJson>>(jsonText);
        jsonData.Clear();

        for (int i = 0; i < deserialized.keys.Count; i++)
        {
            jsonData[deserialized.keys[i]] = deserialized.values[i];
        }
    }
    
    [System.Serializable]
    public class SerializationWrapper<TKey, TValue>
    {
        public List<TKey> keys = new List<TKey>();
        public List<TValue> values = new List<TValue>();

        public SerializationWrapper(Dictionary<TKey, TValue> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                keys.Add(kvp.Key);
                values.Add(kvp.Value);
            }
        }
    }
}
