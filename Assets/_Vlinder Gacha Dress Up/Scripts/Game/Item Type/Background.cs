public class Background : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Background;
        targetRenderer = Doll.Instance.background;
        base.OnEnable();
        canNullValue = false;
        canChangeRGB = false;
        canChangeBSH = false;
        dollComponentData = ItemBarManager.Instance.dollSaveData.background;
    }
    
    public override void SaveData()
    {
        base.SaveData();
        if (chooseItemSprite == null)
        {
            dollComponentData.sprite = GameManager.Instance.gameData.data[eItemType].itemdatas[0].sprite;
        }
    }
}
