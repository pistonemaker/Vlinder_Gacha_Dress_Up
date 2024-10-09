using UnityEngine;

public class OutsightShirt : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Outsight_Shirt;
        targetRenderer = Doll.Instance.outsightShirt;
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
