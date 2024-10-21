public class Trousers : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Trouser;
        targetRenderer = Doll.Instance.trousers;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = true;
        dollComponentData = ItemBarManager.Instance.dollSaveData.trousers;
    }

    public override void SaveData()
    {
        base.SaveData();
        
        if (targetRenderer.sprite != null)
        {
            DataKey.GetConFigShader(targetRenderer.material, ItemBarManager.Instance.dollSaveData.trouserMaterial);
        }
    }
}
