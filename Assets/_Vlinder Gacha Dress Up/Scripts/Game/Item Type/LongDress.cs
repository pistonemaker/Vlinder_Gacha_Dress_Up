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

    protected override void Choose()
    {
        base.Choose();

        var brightness = targetRenderer.material.GetFloat(DataKey.OutlineAlpha);
        var saturation = targetRenderer.material.GetFloat(DataKey.GreyscaleBlend);
        var hue = targetRenderer.material.GetFloat(DataKey.HsvShift);

        if (brightness != 0f || saturation != 0f || hue != 0f)
        {
            ItemBarManager.Instance.chooseBSHPanel.LoadValue(brightness, saturation, hue);
        }
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
    
    public override void SaveData()
    {
        base.SaveData();
        
        if (targetRenderer.sprite != null)
        {
            DataKey.GetConFigShader(targetRenderer.material, ItemBarManager.Instance.dollSaveData.longDressMaterial);
        }
    }
}
