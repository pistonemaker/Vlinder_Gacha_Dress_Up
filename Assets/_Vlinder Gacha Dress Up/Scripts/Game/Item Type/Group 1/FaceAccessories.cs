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
                StartCoroutine(StarSpawner.Instance.SpawnStar());
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

    public override void SaveData()
    {
        var dollSaveData = ItemBarManager.Instance.dollSaveData;
        var component = ItemBarManager.Instance.dollSaveData.birthmark;
        component.sprite = Doll.Instance.birthmark.sprite;
        component.eItemType = EItemType.Birthmark;
        component.id = PlayerPrefs.GetInt(DataKey.ID_Birthmark);
        dollSaveData.birthmark = component;
        
        component = ItemBarManager.Instance.dollSaveData.nose;
        component.sprite = Doll.Instance.nose.sprite;
        component.eItemType = EItemType.Nose;
        component.id = PlayerPrefs.GetInt(DataKey.ID_Nose);
        dollSaveData.nose = component;
        
        component = ItemBarManager.Instance.dollSaveData.earrings;
        component.sprite = Doll.Instance.earrings.sprite;
        component.eItemType = EItemType.Earrings;
        component.id = PlayerPrefs.GetInt(DataKey.ID_Earrings);
        dollSaveData.earrings = component;
        
        component = ItemBarManager.Instance.dollSaveData.glass;
        component.sprite = Doll.Instance.glass.sprite;
        component.eItemType = EItemType.Glass;
        component.id = PlayerPrefs.GetInt(DataKey.ID_Glass);
        dollSaveData.glass = component;
        
        component = ItemBarManager.Instance.dollSaveData.blush;
        component.sprite = Doll.Instance.blush.sprite;
        component.eItemType = EItemType.Blush;
        component.id = PlayerPrefs.GetInt(DataKey.ID_Blush);
        dollSaveData.blush = component;
    }
}
