using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "Data/Save Data")]
public class SaveData : ScriptableObject
{
    public bool isEdit;
    public int editID;
    public List<DollSaveData> saveDataList;
}

[Serializable]
public class DollSaveData
{
    public DollComponentData background;
    public DollComponentData behindHair;
    public DollComponentData wing;
    public DollComponentData body;
    public DollComponentData socks;
    public DollComponentData shoes;
    public DollComponentData trousers;
    public DollComponentData shortDress;
    public DollComponentData eyes;
    public DollComponentData eyeblow;
    public DollComponentData mouth;
    public DollComponentData insightShirt;
    public DollComponentData birthmark;
    public DollComponentData earrings;
    public DollComponentData nose;
    public DollComponentData glass;
    public DollComponentData blush;
    public DollComponentData outsightShirt;
    public DollComponentData longDress;
    public DollComponentData frontHair;
    public DollComponentData hat;
    public DollComponentData necklace;
    public DollComponentData handBag;
    public Color hairColor;
}

[Serializable]
public class DollComponentData
{
    public EItemType eItemType;
    public int id;
    public Sprite sprite;
}
