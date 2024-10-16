using UnityEngine;

public class LongDress : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Long_Dress;
        targetRenderer = Doll.Instance.longDress;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = true;
        dollComponentData = ItemBarManager.Instance.dollSaveData.longDress;
    }
        
    protected override void ShowItemGrid()
    {
        ItemBarManager.Instance.LoadOSA(eItemType);
    }

    public override void WearItem(ItemData itemData)
    {
        base.WearItem(itemData);

        if (ItemBarManager.Instance.outsightShirtButton.GetCurSpriteRenderer().sprite != null)
        {
            ItemBarManager.Instance.outsightShirtButton.GetCurSpriteRenderer().sprite = null;
            PlayerPrefs.SetInt(DataKey.ID_Outsight_Shirt, 0);
        }
    }
}
