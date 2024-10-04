using UnityEngine;

public class OutsightShirt : ItemType
{
    public Sprite chooseItem;

    protected override void OnEnable()
    {
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
