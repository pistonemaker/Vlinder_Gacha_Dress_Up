public class Hat : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Normal_Hat;
        targetRenderer = Doll.Instance.hat;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = false;
        dollComponentData = ItemBarManager.Instance.dollSaveData.hat;
    }
}
