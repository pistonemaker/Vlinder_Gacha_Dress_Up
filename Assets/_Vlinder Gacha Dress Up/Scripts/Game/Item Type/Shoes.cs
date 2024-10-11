using UnityEngine;

public class Shoes : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Shoes;
        targetRenderer = Doll.Instance.shoes;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = false;
    }
        
    protected override void ShowItemGrid()
    {
        ItemBarManager.Instance.LoadOSA(eItemType);
    }
}
