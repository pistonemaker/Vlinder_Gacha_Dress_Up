using UnityEngine;

public class FrontHair : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Front_Hair;
        targetRenderer = Doll.Instance.frontHair;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = true;
        canChangeBSH = false;
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
