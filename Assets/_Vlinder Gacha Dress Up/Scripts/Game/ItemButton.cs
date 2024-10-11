using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public ItemData data;
    public Button button;
    public Image thumb;
    public Image select;
    public int index;

    private System.Action<object> onDisSelectItemDelegate;
    private System.Action<object> onDisSelectAccessoryDelegate;

    private void OnEnable()
    {
        select = transform.GetChild(0).Find("Select").GetComponent<Image>();
        button = transform.GetChild(0).Find("Button").GetComponent<Button>();
        select.gameObject.SetActive(false);

        button.onClick.AddListener(OnClick_WearItem);
        onDisSelectItemDelegate = param => DisSelect((int)param);
        onDisSelectAccessoryDelegate = param => DisSelectAccessory((ItemData)param);
        this.RegisterListener(EventID.On_DisSelect_Item, onDisSelectItemDelegate);
        this.RegisterListener(EventID.On_DisSelect_Accessory, onDisSelectAccessoryDelegate);
        this.RegisterListener(EventID.On_DisSelect_All_Accessory, CheckIfSelected);
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
        this.RemoveListener(EventID.On_DisSelect_Item, onDisSelectItemDelegate);
        this.RemoveListener(EventID.On_DisSelect_Accessory, onDisSelectAccessoryDelegate);
        this.RemoveListener(EventID.On_DisSelect_All_Accessory, CheckIfSelected);
    }


    public void OnClick_WearItem()
    {
        CheckPostEvent();
        select.gameObject.SetActive(true);
        this.PostEvent(EventID.On_Wear_Item, data);
    }

    private void CheckPostEvent()
    {
        if (data.itemtype == EItemType.Birthmark || data.itemtype == EItemType.Blush ||
            data.itemtype == EItemType.Glass || data.itemtype == EItemType.Earrings || data.itemtype == EItemType.Nose)
        {
            this.PostEvent(EventID.On_DisSelect_Accessory, data);
        }
        else
        {
            this.PostEvent(EventID.On_DisSelect_Item, data.itemtype);
        }
    }

    private void DisSelect(int id)
    {
        if (id != data.id)
        {
            select.gameObject.SetActive(false);
        }
        else
        {
            // Nếu loại item hiện tại có thể không mặc cũng được 
            if (ItemBarManager.Instance.currentItemTypeButton.canNullValue)
            {
                if (data.thumbSprite.name == "0None")
                {
                    select.gameObject.SetActive(true);
                    PlayerPrefs.SetInt(GetDataKey(data.itemtype), -1);
                    return;
                }
                select.gameObject.SetActive(false);
                PlayerPrefs.SetInt(GetDataKey(data.itemtype), -1);
            }
        }
    }

    private void DisSelectAccessory(ItemData itemData)
    {
        if (data.itemtype == itemData.itemtype)
        {
            if (data.id != itemData.id)
            {
                select.gameObject.SetActive(false);
            }
            else
            {
                if (data.thumbSprite.name == "0Noneee")
                {
                    PlayerPrefs.SetInt(GetDataKey(EItemType.Birthmark), -1);
                    PlayerPrefs.SetInt(GetDataKey(EItemType.Blush), -1);
                    PlayerPrefs.SetInt(GetDataKey(EItemType.Glass), -1);
                    PlayerPrefs.SetInt(GetDataKey(EItemType.Nose), -1);
                    PlayerPrefs.SetInt(GetDataKey(EItemType.Earrings), -1);
                    this.PostEvent(EventID.On_DisSelect_All_Accessory);
                    select.gameObject.SetActive(true);
                    return;
                }
                
                select.gameObject.SetActive(false);
                PlayerPrefs.SetInt(GetDataKey(data.itemtype), -1);
            }
        }
    }

    public void CheckIfSelected(object param)
    {
        var key = GetDataKey(data.itemtype);
        int idSelected = PlayerPrefs.GetInt(key);

        if (idSelected == data.id)
        {
            select.gameObject.SetActive(true);
        }
        else
        {
            select.gameObject.SetActive(false);
        }
    }

    private string GetDataKey(EItemType itemType)
    {
        switch (itemType)
        {
            case EItemType.Background:
                return DataKey.ID_Background;
            case EItemType.Birthmark:
                return DataKey.ID_Birthmark;
            case EItemType.Eyeblow:
                return DataKey.ID_Eyeblow;
            case EItemType.Body:
                return DataKey.ID_Body;
            case EItemType.Earrings:
                return DataKey.ID_Earrings;
            case EItemType.Blush:
                return DataKey.ID_Blush;
            case EItemType.Eyes:
                return DataKey.ID_Eyes;
            case EItemType.Glass:
                return DataKey.ID_Glass;
            case EItemType.Mouth:
                return DataKey.ID_Mouth;
            case EItemType.Necklace:
                return DataKey.ID_Neckless;
            case EItemType.Nose:
                return DataKey.ID_Nose;
            case EItemType.Shoes:
                return DataKey.ID_Shoes;
            case EItemType.Socks:
                return DataKey.ID_Socks;
            case EItemType.Trouser:
                return DataKey.ID_Trousers;
            case EItemType.Wing:
                return DataKey.ID_Wing;
            case EItemType.Behind_Hair:
                return DataKey.ID_Behind_Hair;
            case EItemType.Front_Hair:
                return DataKey.ID_Front_Hair;
            case EItemType.Hand_Bag:
                return DataKey.ID_Hand_Bag;
            case EItemType.Insight_Shirt:
                return DataKey.ID_Insight_Shirt;
            case EItemType.Outsight_Shirt:
                return DataKey.ID_Outsight_Shirt;
            case EItemType.Short_Dress:
                return DataKey.ID_Short_Dress;
            case EItemType.Long_Dress:
                return DataKey.ID_Long_Dress;
            case EItemType.Normal_Hat:
                return DataKey.ID_Hat;
            default:
                return "";
        }
    }
}