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
            this.PostEvent(EventID.On_DisSelect_Item, data.id);
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
                    PlayerPrefs.SetInt(Changer.GetDataKey(data.itemtype), -1);
                    return;
                }
                
                select.gameObject.SetActive(false);
                PlayerPrefs.SetInt(Changer.GetDataKey(data.itemtype), -1);
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
                    PlayerPrefs.SetInt(Changer.GetDataKey(EItemType.Birthmark), -1);
                    PlayerPrefs.SetInt(Changer.GetDataKey(EItemType.Blush), -1);
                    PlayerPrefs.SetInt(Changer.GetDataKey(EItemType.Glass), -1);
                    PlayerPrefs.SetInt(Changer.GetDataKey(EItemType.Nose), -1);
                    PlayerPrefs.SetInt(Changer.GetDataKey(EItemType.Earrings), -1);
                    this.PostEvent(EventID.On_DisSelect_All_Accessory);
                    select.gameObject.SetActive(true);
                    return;
                }
                
                select.gameObject.SetActive(false);
                PlayerPrefs.SetInt(Changer.GetDataKey(data.itemtype), -1);
            }
        }
    }

    public void CheckIfSelected(object param)
    {
        var key = Changer.GetDataKey(data.itemtype);
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

    public void OnCheckSelected()
    {
        if (index == 0)
        {
            select.gameObject.SetActive(true);
        }
        else
        {
            select.gameObject.SetActive(false);
        }
    }
}