using UnityEngine;

public class OutsightShirt : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Outsight_Shirt;
        targetRenderer = Doll.Instance.outsightShirt;
        base.OnEnable();
        canNullValue = true;
        canChangeRGB = false;
        canChangeBSH = true;
        dollComponentData = ItemBarManager.Instance.dollSaveData.outsightShirt;
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

    public override void WearItem(ItemDataToJson itemData)
    {
        base.WearItem(itemData);

        if (ItemBarManager.Instance.longDressButton.GetCurSpriteRenderer().sprite != null)
        {
            ItemBarManager.Instance.longDressButton.GetCurSpriteRenderer().sprite = null;
            PlayerPrefs.SetInt(DataKey.ID_Long_Dress, 0);
        }
    }
    
    public override void SaveData()
    {
        base.SaveData();
        
        if (targetRenderer.sprite != null)
        {
            DataKey.GetConFigShader(targetRenderer.material, ItemBarManager.Instance.dollSaveData.outsightShirtMaterial);
        }
    }
}
