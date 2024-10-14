using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Doll : Singleton<Doll>
{
    public DollSave saveDoll;
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
        spriteRenderers.Remove(background);
        LoadSaveItems();
        TakeOffDoll();
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
        // Debug.Log(eItemType + "\t" + itemIndex);
        PlayerPrefs.SetInt(Changer.GetDataKey(eItemType), itemIndex);
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
        WearSaveItem(EItemType.Birthmark, -1);
        WearSaveItem(EItemType.Earrings, -1);
        WearSaveItem(EItemType.Blush, -1);
        WearSaveItem(EItemType.Glass, -1);
        WearSaveItem(EItemType.Nose, -1);
        WearSaveItem(EItemType.Background, 0);
        WearSaveItem(EItemType.Body, 0);
        WearSaveItem(EItemType.Eyeblow, 0);
        WearSaveItem(EItemType.Eyes, 0);
        WearSaveItem(EItemType.Mouth, 0);
        WearSaveItem(EItemType.Necklace, 0);
        WearSaveItem(EItemType.Shoes, 0);
        WearSaveItem(EItemType.Socks, 0);
        WearSaveItem(EItemType.Trouser, 0);
        WearSaveItem(EItemType.Wing, 0);
        WearSaveItem(EItemType.Behind_Hair, 0);
        WearSaveItem(EItemType.Front_Hair, 0);
        WearSaveItem(EItemType.Short_Dress, 0);
        WearSaveItem(EItemType.Long_Dress, 0);
        WearSaveItem(EItemType.Normal_Hat, 0);
        WearSaveItem(EItemType.Hand_Bag, 0);
        WearSaveItem(EItemType.Insight_Shirt, 0);
        WearSaveItem(EItemType.Outsight_Shirt, 0);
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

    public void SaveDoll()
    {
        saveDoll.background.sprite = background.sprite;
        saveDoll.behindHair.sprite = behindHair.sprite;
        saveDoll.wing.sprite = wing.sprite;
        saveDoll.body.sprite = body.sprite;
        saveDoll.socks.sprite = socks.sprite;
        saveDoll.shoes.sprite = shoes.sprite;
        saveDoll.trousers.sprite = trousers.sprite;
        saveDoll.shortDress.sprite = shortDress.sprite;
        saveDoll.eyes.sprite = eyes.sprite;
        saveDoll.eyeblow.sprite = eyeblow.sprite;
        saveDoll.mouth.sprite = mouth.sprite;
        saveDoll.insightShirt.sprite = insightShirt.sprite;
        saveDoll.birthmark.sprite = birthmark.sprite;
        saveDoll.earrings.sprite = earrings.sprite;
        saveDoll.nose.sprite = nose.sprite;
        saveDoll.glass.sprite = glass.sprite;
        saveDoll.blush.sprite = blush.sprite;
        saveDoll.outsightShirt.sprite = outsightShirt.sprite;
        saveDoll.longDress.sprite = longDress.sprite;
        saveDoll.frontHair.sprite = frontHair.sprite;
        saveDoll.hairLight.sprite = hairLight.sprite;
        saveDoll.hat.sprite = hat.sprite;
        saveDoll.necklace.sprite = necklace.sprite;
        saveDoll.handBag.sprite = handBag.sprite;
    }
}
