using UnityEngine;

public class BehindHair : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Behind_Hair;
        targetRenderer = Doll.Instance.behindHair;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = true;
        canChangeBSH = false;
        dollComponentData = ItemBarManager.Instance.dollSaveData.behindHair;
    }

    public override void WearItem(ItemData itemData)
    {
        base.WearItem(itemData);
        
        if (ItemBarManager.Instance.isApplyColor)
        {
            targetRenderer.color = ItemBarManager.Instance.currentColor;
        }
    }
}
