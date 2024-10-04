using UnityEngine;

public class Socks : ItemType
{
    public Sprite chooseItem;

    protected override void OnEnable()
    {
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
