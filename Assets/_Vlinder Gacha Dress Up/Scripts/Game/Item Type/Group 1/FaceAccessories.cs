using System;
using UnityEngine;

public class FaceAccessories : ItemTypeButton
{
    protected override void OnEnable()
    {
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = false;
        this.RegisterListener(EventID.On_DisSelect_All_Accessory, DisSelectAll);
    }

    private void OnDisable()
    {
        this.RemoveListener(EventID.On_DisSelect_All_Accessory, DisSelectAll);
    }

    protected override void ShowItemGrid()
    {
        ItemBarManager.Instance.LoadOSAFaceAccessories();
    }

    public override void WearItem(ItemData data)
    {
        WearItemAccessory(data, EItemType.Birthmark, Doll.Instance.birthmark);
        WearItemAccessory(data, EItemType.Earrings, Doll.Instance.earrings);
        WearItemAccessory(data, EItemType.Blush, Doll.Instance.blush);
        WearItemAccessory(data, EItemType.Nose, Doll.Instance.nose);
        WearItemAccessory(data, EItemType.Glass, Doll.Instance.glass);
    }

    private void WearItemAccessory(ItemData data, EItemType eItemTypeCheck, SpriteRenderer targetRender)
    {
        if (data.itemtype == eItemTypeCheck)
        {
            if (targetRender.sprite == data.sprite)
            {
                targetRender.sprite = null;
                this.PostEvent(EventID.On_DisSelect_Accessory, data);
            }
            else
            {
                targetRender.sprite = data.sprite;
                var key = ChangeItemTypeToData(data.itemtype);
                PlayerPrefs.SetInt(key, data.id);
            }
        }
    }

    public void DisSelectAll(object param)
    {
        Doll.Instance.birthmark.sprite = null;
        Doll.Instance.nose.sprite = null;
        Doll.Instance.earrings.sprite = null;
        Doll.Instance.glass.sprite = null;
        Doll.Instance.blush.sprite = null;
    }
}
