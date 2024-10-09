using UnityEngine;

public class Body : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Body;
        targetRenderer = Doll.Instance.body;
        base.OnEnable();
        canNullValue = false;
        canMultiValue = false;
        Choose();
    }
}
