using UnityEngine;

public class Eyes : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Eyes;
        targetRenderer = Doll.Instance.eyes;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = false;
        dollComponentData = ItemBarManager.Instance.dollSaveData.eyes;
    }
}
