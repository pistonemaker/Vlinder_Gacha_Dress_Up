public class ShortDress : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Short_Dress;
        targetRenderer = Doll.Instance.shortDress;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = true;
        dollComponentData = ItemBarManager.Instance.dollSaveData.shortDress;
    }
    
    public override void SaveData()
    {
        base.SaveData();
        
        if (targetRenderer.sprite != null)
        {
            DataKey.GetConFigShader(targetRenderer.material, ItemBarManager.Instance.dollSaveData.shortDressMaterial);
        }
    }
}
