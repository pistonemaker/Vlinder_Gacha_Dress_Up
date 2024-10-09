using UnityEngine;

public class Wing : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Wing;
        targetRenderer = Doll.Instance.wing;
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
