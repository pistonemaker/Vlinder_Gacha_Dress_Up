using UnityEngine;

public class Mouth : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Mouth;
        targetRenderer = Doll.Instance.mouth;
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
