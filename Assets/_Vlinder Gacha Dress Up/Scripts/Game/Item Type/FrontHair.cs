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
        dollComponentData = ItemBarManager.Instance.dollSaveData.frontHair;
    }

    public override void WearItem(ItemData itemData)
    {
        base.WearItem(itemData);
        
        if (ItemBarManager.Instance.isApplyColor)
        {
            targetRenderer.color = ItemBarManager.Instance.currentColor;
        }
    }

    public override void SaveData()
    {
        base.SaveData();
        
        if (targetRenderer.sprite != null)
        {
            ItemBarManager.Instance.dollSaveData.hairColor = targetRenderer.color;
        }
    }
}
