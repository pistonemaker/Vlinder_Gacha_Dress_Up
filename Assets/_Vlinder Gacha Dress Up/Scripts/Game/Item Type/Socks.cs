using UnityEngine;

public class Socks : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Socks;
        targetRenderer = Doll.Instance.socks;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = false;
        dollComponentData = ItemBarManager.Instance.dollSaveData.socks;
    }
}
