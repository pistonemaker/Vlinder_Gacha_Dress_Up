using UnityEngine;

public class ShortDress : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Short_Dress;
        targetRenderer = Doll.Instance.shortDress;
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
