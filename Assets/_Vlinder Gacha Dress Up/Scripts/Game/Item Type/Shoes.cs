using UnityEngine;

public class Shoes : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Shoes;
        targetRenderer = Doll.Instance.shoes;
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
        
    protected override void ShowItemGrid()
    {
        ItemBarManager.Instance.LoadOSA(eItemType);
    }
}
