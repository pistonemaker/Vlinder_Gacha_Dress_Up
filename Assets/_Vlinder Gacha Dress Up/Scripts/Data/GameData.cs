using System;
using System.Collections.Generic;
using UnityEngine;

public class GameData : ScriptableObject
{
    public List<ItemTypeData> data;
}

[Serializable]
public class ItemTypeData
{
    public EItemType itemType;
    public List<ItemData> itemdatas;
}

[Serializable]
public class ItemData
{
    public Sprite sprite;
    public Sprite thumbSprite;
}

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