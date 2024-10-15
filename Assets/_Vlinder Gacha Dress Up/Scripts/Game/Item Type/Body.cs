using UnityEngine;

public class Body : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Body;
        targetRenderer = Doll.Instance.body;
        base.OnEnable();
        canNullValue = false;
        canChangeRGB = false;
        canChangeBSH = false;
        Choose();
        dollComponentData = ItemBarManager.Instance.dollSaveData.body;
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
