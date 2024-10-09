using UnityEngine;

public class FaceAccessories : ItemTypeButton
{
    protected override void OnEnable()
    {
        base.OnEnable();
        canNullValue = true;
        canMultiValue = true;
    }
        
    protected override void ShowItemGrid()
    {
        ItemBarManager.Instance.LoadOSAFaceAccessories();
    }

    public override void WearItem(ItemData data)
    {
        var eItemType = data.itemtype;
        WearItemAccessory(data, eItemType, EItemType.Birthmark, Doll.Instance.birthmark);
        WearItemAccessory(data, eItemType, EItemType.Earrings, Doll.Instance.earrings);
        WearItemAccessory(data, eItemType, EItemType.Blush, Doll.Instance.blush);
        WearItemAccessory(data, eItemType, EItemType.Nose, Doll.Instance.nose);
        WearItemAccessory(data, eItemType, EItemType.Glass, Doll.Instance.glass);
    }

    private void WearItemAccessory(ItemData data, EItemType itemType, EItemType eItemTypeCheck, SpriteRenderer targetRender)
    {
        if (itemType == eItemTypeCheck)
        {
            if (targetRender.sprite == data.sprite)
            {
                targetRender.sprite = null;
            }
            else
            {
                targetRender.sprite = data.sprite;
            }
        }
    }
}
