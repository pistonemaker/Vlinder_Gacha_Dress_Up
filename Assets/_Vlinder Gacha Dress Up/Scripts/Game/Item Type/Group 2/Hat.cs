using UnityEngine;

public class Hat : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Normal_Hat;
        targetRenderer = Doll.Instance.hat;
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
