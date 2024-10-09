using UnityEngine;

public class Background : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Background;
        targetRenderer = Doll.Instance.background;
        base.OnEnable();
        canNullValue = false;
        canMultiValue = false;
    }
}
