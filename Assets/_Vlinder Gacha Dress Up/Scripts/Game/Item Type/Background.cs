using UnityEngine;

public class Background : ItemType
{
    public Sprite chooseItem;

    protected override void OnEnable()
    {
        base.OnEnable();
        canNullValue = false;
        canMultiValue = false;
    }
}
