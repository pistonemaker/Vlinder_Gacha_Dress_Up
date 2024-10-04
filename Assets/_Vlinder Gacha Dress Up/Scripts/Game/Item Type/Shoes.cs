using UnityEngine;

public class Shoes : ItemType
{
    public Sprite chooseItem;

    protected override void OnEnable()
    {
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
