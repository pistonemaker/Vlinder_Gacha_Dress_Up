using UnityEngine;

public class Eyeblow : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Eyeblow;
        targetRenderer = Doll.Instance.eyeblow;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = false;
        dollComponentData = ItemBarManager.Instance.dollSaveData.eyeblow;
    }
}
