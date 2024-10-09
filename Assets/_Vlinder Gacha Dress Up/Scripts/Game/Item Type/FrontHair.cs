using UnityEngine;

public class FrontHair : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Front_Hair;
        targetRenderer = Doll.Instance.frontHair;
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
