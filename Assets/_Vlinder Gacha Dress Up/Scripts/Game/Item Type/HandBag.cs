using UnityEngine;

public class HandBag : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Hand_Bag;
        targetRenderer = Doll.Instance.handBag;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = false;
        dollComponentData = ItemBarManager.Instance.dollSaveData.handBag;
    }
}
