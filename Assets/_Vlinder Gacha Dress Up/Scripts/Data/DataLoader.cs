using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class DataLoader : Singleton<DataLoader>
{
    public GameData gameData;
    public List<Sprite> sprites;

    protected override void Awake()
    {
        base.Awake();
        //gameData.data.Clear();
        GetSpriteData();
        LoadData();
    }

    private void GetSpriteData()
    {
        if (sprites.Count > 0)
        {
            return;
        }
        
        string folderPath = "Assets/_Vlinder Gacha Dress Up/Sprites/Item";
        string[] filePaths = Directory.GetFiles(folderPath);

        foreach (string filePath in filePaths)
        {
            Sprite texture = AssetDatabase.LoadAssetAtPath<Sprite>(filePath);
            if (texture != null)
            {
                sprites.Add(texture);
            }
        }
    }

    private void LoadData()
    {
        if (gameData.data.Count > 0)
        {
            return;
        }
        
        string folderPath = "Assets/_Vlinder Gacha Dress Up/Sprites/UI Thumb";
        string[] subDirectories = Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories);

        foreach (string subDir in subDirectories)
        {
            string[] spritePaths = Directory.GetFiles(subDir, "*.png", SearchOption.TopDirectoryOnly);

            int index = 0;
            foreach (string spritePath in spritePaths)
            {
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);
                
                if (sprite != null)
                {
                    ItemData itemData = new ItemData();
                    FindSuitableSprites(sprite, itemData);
                    EItemType eItemType = GetEItemType(subDir);
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

    private void FindSuitableSprites(Sprite sprite, ItemData itemData)
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            if (sprites[i].name == sprite.name)
            {
                itemData.sprite = sprites[i];
                itemData.thumbSprite = sprite;
            }
            else if (sprites[i].name == sprite.name + "light")
            {
                itemData.isLight = true;
                itemData.lightSprite = sprites[i];
            }
            else if (sprites[i].name == sprite.name + "color")
            {
                itemData.isColor = true;
                itemData.colorSprite = sprites[i];
            }

            if (sprite.name == "0None")
            {
                itemData.thumbSprite = sprite;
                itemData.isLight = false;
                itemData.isColor = false;
            }

            if (sprite.name == "0Noneee")
            {
                itemData.thumbSprite = sprite;
                itemData.isLight = false;
                itemData.isColor = false;
            }
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
        gameData = GameManager.Instance.gameData;
        GetSpriteData();
    }
}