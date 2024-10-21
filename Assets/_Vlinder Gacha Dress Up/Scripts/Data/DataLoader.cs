using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLoader : Singleton<DataLoader>
{
    public GameData gameData;
    public List<Sprite> sprites;
    public Dictionary<string, Sprite> spriteDictionary = new Dictionary<string, Sprite>();

    protected override void Awake()
    {
        base.Awake();

        GetSpriteData();

        float startTime = Time.realtimeSinceStartup;
        LoadData();
        float endTime = Time.realtimeSinceStartup;
        float loadingDuration = endTime - startTime;
        Debug.Log($"Time Load Data: {loadingDuration} seconds");
    }

    private void GetSpriteData()
    {
        if (sprites.Count > 0)
        {
            return;
        }

        Sprite[] loadedSprites = Resources.LoadAll<Sprite>("Item");

        foreach (Sprite sprite in loadedSprites)
        {
            if (sprite != null)
            {
                sprites.Add(sprite);
                spriteDictionary.Add(sprite.name, sprite);
            }
        }
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

        foreach (string folderName in itemFolders)
        {
            Sprite[] spritesInFolder = Resources.LoadAll<Sprite>($"UI Thumb/{folderName}");

            int index = 0;
            foreach (Sprite sprite in spritesInFolder)
            {
                if (sprite != null)
                {
                    ItemData itemData = new ItemData();
                    //FindSuitableSprites(sprite, itemData, index);
                    FindSuitableSpritesInDict(sprite, itemData);

                    EItemType eItemType = GetEItemType(folderName);

                    itemData.itemtype = eItemType;
                    itemData.id = index++;

                    if (!gameData.data.ContainsKey(eItemType))
                    {
                        gameData.data.Add(eItemType, new ItemTypeData());
                    }

                    gameData.data[eItemType].itemdatas.Add(itemData);
                }
            }
        }
    }

    private void FindSuitableSprites(Sprite sprite, ItemData itemData, int index)
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

        for (int i = index; i < sprites.Count; i++)
        {
            if (sprites[i].name == sprite.name)
            {
                itemData.sprite = sprites[i];
                itemData.thumbSprite = sprite;
            }

            if (sprites[i].name == sprite.name + "light")
            {
                itemData.isLight = true;
                itemData.lightSprite = sprites[i];
            }

            if (sprites[i].name == sprite.name + "color")
            {
                itemData.isColor = true;
                itemData.colorSprite = sprites[i];
                return;
            }
        }
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
        LoadData();
        GetSpriteData();
    }
}