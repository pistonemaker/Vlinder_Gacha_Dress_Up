using UnityEngine;

public class LongDress : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Long_Dress;
        targetRenderer = Doll.Instance.longDress;
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
        
    protected override void ShowItemGrid()
    {
        ItemBarManager.Instance.LoadOSA(eItemType);
    }
}
