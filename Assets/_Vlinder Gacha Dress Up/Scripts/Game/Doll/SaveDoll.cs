using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SaveDoll : MonoBehaviour
{
    public DollSaveData dollSaveData;
    public List<Image> images;
    public Image background;
    public Image behindHair;
    public Image wing;
    public Image body;
    public Image socks;
    public Image shoes;
    public Image trousers;
    public Image shortDress;
    public Image eyes;
    public Image eyeblow;
    public Image mouth;
    public Image insightShirt;
    public Image birthmark;
    public Image earrings;
    public Image nose;
    public Image glass;
    public Image blush;
    public Image outsightShirt;
    public Image longDress;
    public Image frontHair;
    public Image hairLight;
    public Image hat;
    public Image necklace;
    public Image handBag;

    public void Init(DollSaveData data)
    {
        dollSaveData = data;
        images = GetComponentsInChildren<Image>().ToList();
        GetSpriteRenderers();
        images.Remove(body);
        images.Remove(background);
        LoadSaveData(data);
    }

    private void GetSpriteRenderers()
    {
        background = images.FirstOrDefault(img => img.name == "BG");
        behindHair = images.FirstOrDefault(img => img.name == "Behind Hair");
        wing = images.FirstOrDefault(img => img.name == "Wing");
        body = images.FirstOrDefault(img => img.name == "Body");
        socks = images.FirstOrDefault(img => img.name == "Socks");
        shoes = images.FirstOrDefault(img => img.name == "Shoes");
        trousers = images.FirstOrDefault(img => img.name == "Trousers");
        shortDress = images.FirstOrDefault(img => img.name == "Short Dress");
        eyes = images.FirstOrDefault(img => img.name == "Eyes");
        eyeblow = images.FirstOrDefault(img => img.name == "Eyeblow");
        mouth = images.FirstOrDefault(img => img.name == "Mouth");
        insightShirt = images.FirstOrDefault(img => img.name == "Insight Shirt");
        birthmark = images.FirstOrDefault(img => img.name == "Birthmark");
        earrings = images.FirstOrDefault(img => img.name == "Earrings");
        nose = images.FirstOrDefault(img => img.name == "Nose");
        glass = images.FirstOrDefault(img => img.name == "Glass");
        blush = images.FirstOrDefault(img => img.name == "Blush");
        outsightShirt = images.FirstOrDefault(img => img.name == "Outsight Shirt");
        longDress = images.FirstOrDefault(img => img.name == "Long Dress");
        frontHair = images.FirstOrDefault(img => img.name == "Front Hair");
        hairLight = images.FirstOrDefault(img => img.name == "Light");
        hat = images.FirstOrDefault(img => img.name == "Hat");
        necklace = images.FirstOrDefault(img => img.name == "Necklace");
        handBag = images.FirstOrDefault(img => img.name == "Hand Bag");
    }

    public void LoadSaveData(DollSaveData data)
    {
        background.sprite = data.background.sprite;
        CheckIfNull(background);
        background.gameObject.SetActive(false);
        behindHair.sprite = data.behindHair.sprite;
        CheckIfNull(behindHair);
        behindHair.color = data.hairColor;
        wing.sprite = data.wing.sprite;
        CheckIfNull(wing);
        body.sprite = data.body.sprite;
        CheckIfNull(body);
        socks.sprite = data.socks.sprite;
        CheckIfNull(socks);
        shoes.sprite = data.shoes.sprite;
        CheckIfNull(shoes);
        trousers.sprite = data.trousers.sprite;
        CheckIfNull(trousers);
        DataKey.ApplyConfig(trousers.material, data.trouserMaterial);
        shortDress.sprite = data.shortDress.sprite;
        CheckIfNull(shortDress);
        DataKey.ApplyConfig(shortDress.material, data.shortDressMaterial);
        eyes.sprite = data.eyes.sprite;
        CheckIfNull(eyes);
        eyeblow.sprite = data.eyeblow.sprite;
        CheckIfNull(eyeblow);
        mouth.sprite = data.mouth.sprite;
        CheckIfNull(mouth);
        insightShirt.sprite = data.insightShirt.sprite;
        CheckIfNull(insightShirt);
        DataKey.ApplyConfig(insightShirt.material, data.insightShirtMaterial);
        birthmark.sprite = data.birthmark.sprite;
        CheckIfNull(birthmark);
        earrings.sprite = data.earrings.sprite;
        CheckIfNull(earrings);
        nose.sprite = data.nose.sprite;
        CheckIfNull(nose);
        glass.sprite = data.glass.sprite;
        CheckIfNull(glass);
        blush.sprite = data.blush.sprite;
        CheckIfNull(blush);
        outsightShirt.sprite = data.outsightShirt.sprite;
        CheckIfNull(outsightShirt);
        DataKey.ApplyConfig(outsightShirt.material, data.outsightShirtMaterial);
        longDress.sprite = data.longDress.sprite;
        CheckIfNull(longDress);
        DataKey.ApplyConfig(longDress.material, data.longDressMaterial);
        frontHair.sprite = data.frontHair.sprite;
        CheckIfNull(frontHair);
        frontHair.color = data.hairColor;
        hat.sprite = data.hat.sprite;
        CheckIfNull(hat);
        necklace.sprite = data.necklace.sprite;
        CheckIfNull(necklace);
        handBag.sprite = data.handBag.sprite;
        CheckIfNull(handBag);
    }

    private void CheckIfNull(Image image)
    {
        if (image.sprite == null)
        {
            image.gameObject.SetActive(false);
        }
        else
        {
            image.gameObject.SetActive(true);
            image.SetNativeSize();
        }
    }
    
    private void Reset()
    {
        images = GetComponentsInChildren<Image>().ToList();
        GetSpriteRenderers();
        images.Remove(body);
        images.Remove(background);
    }

    public void CloneDoll(SaveDoll sample)
    {
        background.sprite = sample.background.sprite;
        CheckIfNull(background);
        background.gameObject.SetActive(false);
        behindHair.sprite = sample.behindHair.sprite;
        CheckIfNull(behindHair);
        behindHair.color = sample.behindHair.color;
        wing.sprite = sample.wing.sprite;
        CheckIfNull(wing);
        body.sprite = sample.body.sprite;
        CheckIfNull(body);
        socks.sprite = sample.socks.sprite;
        CheckIfNull(socks);
        shoes.sprite = sample.shoes.sprite;
        CheckIfNull(shoes);
        trousers.sprite = sample.trousers.sprite;
        CheckIfNull(trousers);
        DataKey.CloneMaterial(trousers.material, sample.trousers.material);
        shortDress.sprite = sample.shortDress.sprite;
        CheckIfNull(shortDress);
        shortDress.material = sample.shortDress.material;
        DataKey.CloneMaterial(shortDress.material, sample.shortDress.material);
        eyes.sprite = sample.eyes.sprite;
        CheckIfNull(eyes);
        eyeblow.sprite = sample.eyeblow.sprite;
        CheckIfNull(eyeblow);
        mouth.sprite = sample.mouth.sprite;
        CheckIfNull(mouth);
        insightShirt.sprite = sample.insightShirt.sprite;
        CheckIfNull(insightShirt);
        DataKey.CloneMaterial(insightShirt.material, sample.insightShirt.material);
        birthmark.sprite = sample.birthmark.sprite;
        CheckIfNull(birthmark);
        earrings.sprite = sample.earrings.sprite;
        CheckIfNull(earrings);
        nose.sprite = sample.nose.sprite;
        CheckIfNull(nose);
        glass.sprite = sample.glass.sprite;
        CheckIfNull(glass);
        blush.sprite = sample.blush.sprite;
        CheckIfNull(blush);
        outsightShirt.sprite = sample.outsightShirt.sprite;
        CheckIfNull(outsightShirt);
        DataKey.CloneMaterial(outsightShirt.material, sample.outsightShirt.material);
        longDress.sprite = sample.longDress.sprite;
        CheckIfNull(longDress);
        DataKey.CloneMaterial(longDress.material, sample.longDress.material);
        frontHair.sprite = sample.frontHair.sprite;
        CheckIfNull(frontHair);
        frontHair.color = sample.frontHair.color;
        hat.sprite = sample.hat.sprite;
        CheckIfNull(hat);
        necklace.sprite = sample.necklace.sprite;
        CheckIfNull(necklace);
        handBag.sprite = sample.handBag.sprite;
        CheckIfNull(handBag);
    }
}
