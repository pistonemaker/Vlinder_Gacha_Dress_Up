public class Wing : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Wing;
        targetRenderer = Doll.Instance.wing;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = false;
        dollComponentData = ItemBarManager.Instance.dollSaveData.wing;
    }
}
