using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DataLoader : Singleton<DataLoader>
{
    public GameData gameData;
    public Dictionary<string, Sprite> spriteDictionary = new Dictionary<string, Sprite>();

    protected override void Awake()
    {
        base.Awake();

        float startTime = Time.realtimeSinceStartup;
        GetSpriteData();
        LoadData();
        float endTime = Time.realtimeSinceStartup;
        float loadingDuration = endTime - startTime;
        Debug.Log($"Time Load Data: {loadingDuration} seconds");
    }

    private void GetSpriteData()
    {
        string folderPath = "Assets/_Vlinder Gacha Dress Up/Sprites Load/Item";
        string[] filePaths = Directory.GetFiles(folderPath, "*.png");

        foreach (string filePath in filePaths)
        {
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(filePath);
            if (sprite != null)
            {
                spriteDictionary[sprite.name] = sprite;
            }
        }

        // Sprite[] loadedSprites = Resources.LoadAll<Sprite>("Item");
        //
        // foreach (Sprite sprite in loadedSprites)
        // {
        //     if (sprite != null)
        //     {
        //         spriteDictionary.Add(sprite.name, sprite);
        //     }
        // }
    }

    private void LoadData()
    {
        if (gameData.data.Count > 0)
        {
            return;
        }

        string[] itemFolders =
        {
            "_Background", "_Behind Hair", "_Body", "_Eyeblow", "_Eyes",
            "_Earrings", "_Birthmark", "_Glass", "_Nose", "_Blush", "_Front Hair", "_Hand Bag",
            "_Hat", "_Insight Shirt", "_Long Dress", "_Mouth", "_Necklace", "_Outsight Shirt",
            "_Shoes", "_Short Dress", "_Socks", "_Trousers", "_Wing"
        };

        string uiThumbPath = "Assets/_Vlinder Gacha Dress Up/Sprites Load/UI Thumb";

        foreach (string folderName in itemFolders)
        {
            string folderPath = uiThumbPath + "/" + folderName;
            string[] filePaths = Directory.GetFiles(folderPath, "*.png");
            int index = 0;

            foreach (string filePath in filePaths)
            {
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(filePath);
                if (sprite != null)
                {
                    ItemData itemData = new ItemData();
                    FindSuitableSpritesInDict(sprite, itemData);
                    EItemType eItemType = GetEItemType(folderName);
                    itemData.itemtype = eItemType;
                    itemData.id = index++;

                    if (!gameData.data.ContainsKey(eItemType))
                    {
                        gameData.data.Add(eItemType, new ItemTypeData());
                        gameData.dataToJson[eItemType] = new ItemTypeDataToJson();
                    }

                    gameData.data[eItemType].itemdatas.Add(itemData);

                    string spritePath = spriteDictionary.ContainsKey(sprite.name) ? 
                        "Assets/_Vlinder Gacha Dress Up/Sprites Load/Item/" + itemData.sprite?.name + ".png" : "";
                    string colorspritePath = spriteDictionary.ContainsKey(sprite.name + "color") ? 
                        "Assets/_Vlinder Gacha Dress Up/Sprites Load/Item/" + itemData.sprite?.name + "color.png" : "";
                    string lightspritePath = spriteDictionary.ContainsKey(sprite.name + "light") ? 
                        "Assets/_Vlinder Gacha Dress Up/Sprites Load/Item/" + itemData.sprite?.name + "light.png" : "";


                    gameData.dataToJson[eItemType].itemdatas.Add(new ItemDataToJson
                    {
                        id = itemData.id,
                        itemtype = itemData.itemtype,
                        isColor = itemData.isColor,
                        isLight = itemData.isLight,
                        sprite = spritePath, 
                        thumbSprite = filePath,
                        colorSprite = colorspritePath,
                        lightSprite = lightspritePath
                    });
                }
            }

            // Sprite[] spritesInFolder = Resources.LoadAll<Sprite>($"UI Thumb/{folderName}");
            // int index = 0;
            //
            // foreach (Sprite sprite in spritesInFolder)
            // {
            //     if (sprite != null)
            //     {
            //         ItemData itemData = new ItemData();
            //         FindSuitableSpritesInDict(sprite, itemData);
            //         EItemType eItemType = GetEItemType(folderName);
            //         itemData.itemtype = eItemType;
            //         itemData.id = index++;
            //
            //         if (!gameData.data.ContainsKey(eItemType))
            //         {
            //             gameData.data.Add(eItemType, new ItemTypeData());
            //         }
            //
            //         gameData.data[eItemType].itemdatas.Add(itemData);
            //     }
            // }
        }

        SaveDataToJson();
    }

    private void FindSuitableSpritesInDict(Sprite sprite, ItemData itemData)
    {
        if (sprite.name == "0None")
        {
            itemData.thumbSprite = sprite;
            itemData.isLight = false;
            itemData.isColor = false;
            return;
        }

        if (sprite.name == "0Noneee")
        {
            itemData.thumbSprite = sprite;
            itemData.isLight = false;
            itemData.isColor = false;
            return;
        }

        if (spriteDictionary.ContainsKey(sprite.name))
        {
            itemData.sprite = spriteDictionary[sprite.name];
            itemData.thumbSprite = sprite;
        }

        if (spriteDictionary.ContainsKey(sprite.name + "light"))
        {
            itemData.isLight = true;
            itemData.lightSprite = spriteDictionary[sprite.name + "light"];
        }

        if (spriteDictionary.ContainsKey(sprite.name + "color"))
        {
            itemData.isColor = true;
            itemData.colorSprite = spriteDictionary[sprite.name + "color"];
        }
    }

    private void SaveDataToJson()
    {
        Dictionary<EItemType, ItemTypeDataToJson> dataToSave = new Dictionary<EItemType, ItemTypeDataToJson>();

        foreach (KeyValuePair<EItemType, ItemTypeDataToJson> entry in gameData.dataToJson)
        {
            ItemTypeDataToJson itemTypeDataToJson = new ItemTypeDataToJson();

            foreach (ItemDataToJson itemData in entry.Value.itemdatas)
            {
                ItemDataToJson itemDataToJson = new ItemDataToJson
                {
                    id = itemData.id,
                    itemtype = itemData.itemtype,
                    isColor = itemData.isColor,
                    isLight = itemData.isLight,
                    sprite = itemData.sprite, 
                    thumbSprite = itemData.thumbSprite.Replace("\\", "/"),
                    colorSprite = itemData.colorSprite.Replace("\\", "/"),
                    lightSprite = itemData.lightSprite.Replace("\\", "/") 
                };

                itemTypeDataToJson.itemdatas.Add(itemDataToJson);
            }

            dataToSave.Add(entry.Key, itemTypeDataToJson);
        }

        string json = JsonUtility.ToJson(new SerializationWrapper<EItemType, ItemTypeDataToJson>(dataToSave), true);
        string filePath = "Assets/_Vlinder Gacha Dress Up/Scripts/Data/GameData.json";
        File.WriteAllText(filePath, json);
    }

    private EItemType GetEItemType(string folderPath)
    {
        string folderName = Path.GetFileName(folderPath);

        switch (folderName)
        {
            case "_Background":
                return EItemType.Background;
            case "_Behind Hair":
                return EItemType.Behind_Hair;
            case "_Body":
                return EItemType.Body;
            case "_Eyeblow":
                return EItemType.Eyeblow;
            case "_Eyes":
                return EItemType.Eyes;
            case "_Earrings":
                return EItemType.Earrings;
            case "_Birthmark":
                return EItemType.Birthmark;
            case "_Glass":
                return EItemType.Glass;
            case "_Nose":
                return EItemType.Nose;
            case "_Blush":
                return EItemType.Blush;
            case "_Front Hair":
                return EItemType.Front_Hair;
            case "_Hand Bag":
                return EItemType.Hand_Bag;
            case "_Hat":
                return EItemType.Normal_Hat;
            case "_Insight Shirt":
                return EItemType.Insight_Shirt;
            case "_Long Dress":
                return EItemType.Long_Dress;
            case "_Mouth":
                return EItemType.Mouth;
            case "_Necklace":
                return EItemType.Necklace;
            case "_Outsight Shirt":
                return EItemType.Outsight_Shirt;
            case "_Shoes":
                return EItemType.Shoes;
            case "_Short Dress":
                return EItemType.Short_Dress;
            case "_Socks":
                return EItemType.Socks;
            case "_Trousers":
                return EItemType.Trouser;
            case "_Wing":
                return EItemType.Wing;
            default:
                return EItemType.None;
        }
    }

    private void Reset()
    {
        GetSpriteData();
        LoadData();
    }

    // Lớp bọc Dictionary để JsonUtility có thể tuần tự hóa được
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