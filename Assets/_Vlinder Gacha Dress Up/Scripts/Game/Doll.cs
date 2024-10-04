using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Doll : Singleton<Doll>
{
    public List<SpriteRenderer> spriteRenderers;
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
    public SpriteRenderer hat;
    public SpriteRenderer necklace;
    public SpriteRenderer handBag;
    
    private void OnEnable()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>().ToList();
        GetSpriteRenderers();
        spriteRenderers.Remove(body);
    }

    private void GetSpriteRenderers()
    {
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
}
