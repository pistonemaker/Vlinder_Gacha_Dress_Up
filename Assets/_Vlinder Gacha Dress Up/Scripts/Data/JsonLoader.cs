using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class JsonLoader : Singleton<JsonLoader>
{
    [ShowInInspector] public Dictionary<EItemType, ItemTypeDataToJson> jsonData = 
        new Dictionary<EItemType, ItemTypeDataToJson>();
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadJson();
    }

    public void LoadJson()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("GameData");
    
        if (jsonFile == null)
        {
            Debug.LogError("Can not find .json file in Resources folder");
            return;
        }

        string jsonText = jsonFile.text;
        var deserialized = JsonUtility.FromJson<SerializationWrapper<EItemType, ItemTypeDataToJson>>(jsonText);
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
