using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Doll : Singleton<Doll>
{
    public List<SpriteRenderer> spriteRenderers;
    public SpriteRenderer background;
    public SpriteRenderer behindHair;
    public SpriteRenderer wing;
    public SpriteRenderer body;
    public SpriteRenderer socks;
    public SpriteRenderer shoes;
    public SpriteRenderer trousers;
    public SpriteRenderer shortDress;
    public SpriteRenderer eyes;
    public SpriteRenderer eyeblow;
    public SpriteRenderer mouth;
    public SpriteRenderer insightShirt;
    public SpriteRenderer birthmark;
    public SpriteRenderer earrings;
    public SpriteRenderer nose;
    public SpriteRenderer glass;
    public SpriteRenderer blush;
    public SpriteRenderer outsightShirt;
    public SpriteRenderer longDress;
    public SpriteRenderer frontHair;
    public SpriteRenderer hairLight;
    public SpriteRenderer hat;
    public SpriteRenderer necklace;
    public SpriteRenderer handBag;
    
    private void OnEnable()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>().ToList();
        GetSpriteRenderers();
        spriteRenderers.Remove(body);
        LoadSaveItems();
    }

    private void GetSpriteRenderers()
    {
        background = spriteRenderers.FirstOrDefault(sr => sr.name == "BG");
        behindHair = spriteRenderers.FirstOrDefault(sr => sr.name == "Behind Hair");
        wing = spriteRenderers.FirstOrDefault(sr => sr.name == "Wing");
        body = spriteRenderers.FirstOrDefault(sr => sr.name == "Body");
        socks = spriteRenderers.FirstOrDefault(sr => sr.name == "Socks");
        shoes = spriteRenderers.FirstOrDefault(sr => sr.name == "Shoes");
        trousers = spriteRenderers.FirstOrDefault(sr => sr.name == "Trousers");
        shortDress = spriteRenderers.FirstOrDefault(sr => sr.name == "Short Dress");
        eyes = spriteRenderers.FirstOrDefault(sr => sr.name == "Eyes");
        eyeblow = spriteRenderers.FirstOrDefault(sr => sr.name == "Eyeblow");
        mouth = spriteRenderers.FirstOrDefault(sr => sr.name == "Mouth");
        insightShirt = spriteRenderers.FirstOrDefault(sr => sr.name == "Insight Shirt");
        birthmark = spriteRenderers.FirstOrDefault(sr => sr.name == "Birthmark");
        earrings = spriteRenderers.FirstOrDefault(sr => sr.name == "Earrings");
        nose = spriteRenderers.FirstOrDefault(sr => sr.name == "Nose");
        glass = spriteRenderers.FirstOrDefault(sr => sr.name == "Glass");
        blush = spriteRenderers.FirstOrDefault(sr => sr.name == "Blush");
        outsightShirt = spriteRenderers.FirstOrDefault(sr => sr.name == "Outsight Shirt");
        longDress = spriteRenderers.FirstOrDefault(sr => sr.name == "Long Dress");
        frontHair = spriteRenderers.FirstOrDefault(sr => sr.name == "Front Hair");
        hairLight = spriteRenderers.FirstOrDefault(sr => sr.name == "Light");
        hat = spriteRenderers.FirstOrDefault(sr => sr.name == "Hat");
        necklace = spriteRenderers.FirstOrDefault(sr => sr.name == "Necklace");
        handBag = spriteRenderers.FirstOrDefault(sr => sr.name == "Hand Bag");
    }

    public void TakeOffDoll()
    {
        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            spriteRenderers[i].sprite = null;
        }
    }
    
    private void Reset()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>().ToList();
        GetSpriteRenderers();
        spriteRenderers.Remove(body);
    }

    private void WearSaveItem(EItemType eItemType, int itemIndex)
    {
        if (itemIndex == -1)
        {
            return;
        }
        
        var sr = FindSuitableRenderer(eItemType);

        if (sr != null)
        {
            sr.sprite = GameManager.Instance.gameData.data[eItemType].itemdatas[itemIndex].sprite;
        }
    }

    private void LoadSaveItems()
    {
        WearSaveItem(EItemType.Body, PlayerPrefs.GetInt(DataKey.ID_Body));
        WearSaveItem(EItemType.Background, PlayerPrefs.GetInt(DataKey.ID_Background));
        WearSaveItem(EItemType.Birthmark, PlayerPrefs.GetInt(DataKey.ID_Birthmark));
        WearSaveItem(EItemType.Eyeblow, PlayerPrefs.GetInt(DataKey.ID_Eyeblow));
        WearSaveItem(EItemType.Eyes, PlayerPrefs.GetInt(DataKey.ID_Eyes));
        WearSaveItem(EItemType.Earrings, PlayerPrefs.GetInt(DataKey.ID_Earrings));
        WearSaveItem(EItemType.Blush, PlayerPrefs.GetInt(DataKey.ID_Blush));
        WearSaveItem(EItemType.Glass, PlayerPrefs.GetInt(DataKey.ID_Glass));
        WearSaveItem(EItemType.Mouth, PlayerPrefs.GetInt(DataKey.ID_Mouth));
        WearSaveItem(EItemType.Necklace, PlayerPrefs.GetInt(DataKey.ID_Neckless));
        WearSaveItem(EItemType.Shoes, PlayerPrefs.GetInt(DataKey.ID_Shoes));
        WearSaveItem(EItemType.Socks, PlayerPrefs.GetInt(DataKey.ID_Socks));
        WearSaveItem(EItemType.Trouser, PlayerPrefs.GetInt(DataKey.ID_Trousers));
        WearSaveItem(EItemType.Wing, PlayerPrefs.GetInt(DataKey.ID_Wing));
        WearSaveItem(EItemType.Behind_Hair, PlayerPrefs.GetInt(DataKey.ID_Behind_Hair));
        WearSaveItem(EItemType.Front_Hair, PlayerPrefs.GetInt(DataKey.ID_Front_Hair));
        WearSaveItem(EItemType.Short_Dress, PlayerPrefs.GetInt(DataKey.ID_Short_Dress));
        WearSaveItem(EItemType.Long_Dress, PlayerPrefs.GetInt(DataKey.ID_Long_Dress));
        WearSaveItem(EItemType.Normal_Hat, PlayerPrefs.GetInt(DataKey.ID_Hat));
        WearSaveItem(EItemType.Nose, PlayerPrefs.GetInt(DataKey.ID_Nose));
        WearSaveItem(EItemType.Hand_Bag, PlayerPrefs.GetInt(DataKey.ID_Hand_Bag));
        WearSaveItem(EItemType.Insight_Shirt, PlayerPrefs.GetInt(DataKey.ID_Insight_Shirt));
        WearSaveItem(EItemType.Outsight_Shirt, PlayerPrefs.GetInt(DataKey.ID_Outsight_Shirt));
    }

    private SpriteRenderer FindSuitableRenderer(EItemType eItemType)
    {
        switch (eItemType)
        {
            case EItemType.Background:
                return background;
            case EItemType.Birthmark:
                return birthmark;
            case EItemType.Eyeblow:
                return eyeblow;
            case EItemType.Body:
                return body;
            case EItemType.Earrings:
                return earrings;
            case EItemType.Blush:
                return blush;
            case EItemType.Eyes:
                return eyes;
            case EItemType.Glass:
                return glass;
            case EItemType.Mouth:
                return mouth;
            case EItemType.Necklace:
                return necklace;
            case EItemType.Nose:
                return nose;
            case EItemType.Shoes:
                return shoes;
            case EItemType.Socks:
                return socks;
            case EItemType.Trouser:
                return trousers;
            case EItemType.Wing:
                return wing;
            case EItemType.Behind_Hair:
                return behindHair;
            case EItemType.Front_Hair:
                return frontHair;
            case EItemType.Hand_Bag:
                return handBag;
            case EItemType.Insight_Shirt:
                return insightShirt;
            case EItemType.Outsight_Shirt:
                return outsightShirt;
            case EItemType.Short_Dress:
                return shortDress;
            case EItemType.Long_Dress:
                return longDress;
            case EItemType.Normal_Hat:
                return hat;
            default:
                return null;
        }
    }
}
