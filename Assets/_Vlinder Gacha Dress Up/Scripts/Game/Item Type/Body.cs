using UnityEngine;

public class Body : ItemType
{
    public Sprite chooseItem;

    protected override void OnEnable()
    {
        base.OnEnable();
        canNullValue = false;
        canMultiValue = false;
    }
}
