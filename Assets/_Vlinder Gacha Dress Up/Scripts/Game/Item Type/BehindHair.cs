using UnityEngine;

public class BehindHair : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Behind_Hair;
        targetRenderer = Doll.Instance.behindHair;
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
