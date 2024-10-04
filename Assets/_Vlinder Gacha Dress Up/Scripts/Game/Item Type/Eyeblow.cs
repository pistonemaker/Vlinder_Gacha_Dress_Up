using UnityEngine;

public class Eyeblow : ItemType
{
    public Sprite chooseItem;

    protected override void OnEnable()
    {
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
