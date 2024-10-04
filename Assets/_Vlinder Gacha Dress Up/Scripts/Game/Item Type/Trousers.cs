using UnityEngine;

public class Trousers : ItemType
{
    public Sprite chooseItem;

    protected override void OnEnable()
    {
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
