using UnityEngine;

public class Necklace : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Necklace;
        targetRenderer = Doll.Instance.necklace;
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
