using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
    [ShowInInspector] public Dictionary<EItemType, ItemTypeData> data = new Dictionary<EItemType, ItemTypeData>();
    [ShowInInspector] public Dictionary<EItemType, ItemTypeDataToJson> dataToJson = new Dictionary<EItemType, ItemTypeDataToJson>();
}

// List ảnh của loại đồ
[Serializable]
public class ItemTypeData
{
    public List<ItemData> itemdatas = new List<ItemData>();
}


[Serializable]
public class ItemTypeDataToJson
{
    public List<ItemDataToJson> itemdatas = new List<ItemDataToJson>();
}

// Data ảnh của đồ
[Serializable]
public class ItemData
{
    public int id;
    public EItemType itemtype;
    public bool isColor;
    public bool isLight;
    public Sprite sprite;
    public Sprite thumbSprite;

    [ShowIf("@isColor == true")] public Sprite colorSprite;

    [ShowIf("@isLight == true")] public Sprite lightSprite;
}

[Serializable]
public class ItemDataToJson
{
    public int id;
    public EItemType itemtype;
    public bool isColor;
    public bool isLight;
    public string sprite;
    public string thumbSprite;

    [ShowIf("@isColor == true")] public string colorSprite;

    [ShowIf("@isLight == true")] public string lightSprite;
}

// Loại đồ
public enum EItemType
{
    None,
    Body,
    Front_Hair,
    Behind_Hair,
    Eyes,
    Eyeblow,
    Mouth,
    Insight_Shirt,
    Outsight_Shirt,
    Trouser,
    Short_Dress,
    Long_Dress,
    Socks,
    Shoes,
    Birthmark,
    Blush,
    Earrings,
    Glass,
    Nose,
    Normal_Hat,
    Special_Hat,
    Necklace,
    Hand_Bag,
    Wing,
    Background,
}