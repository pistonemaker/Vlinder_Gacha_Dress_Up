using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public ItemData data;
    public Button button;
    public Image thumb;
    public Image select;
    public int index;

    private void OnEnable()
    {
        select = transform.GetChild(0).Find("Select").GetComponent<Image>();
        button = transform.GetChild(0).Find("Button").GetComponent<Button>();
        button.onClick.AddListener(OnClick_WearItem);
        select.gameObject.SetActive(false);
        this.RegisterListener(EventID.On_DisSelect_Item, param => DisSelect((int)param));
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
        this.RemoveListener(EventID.On_DisSelect_Item, param => DisSelect((int)param));
    }

    public void OnClick_WearItem()
    {
        this.PostEvent(EventID.On_Wear_Item, data);
        this.PostEvent(EventID.On_DisSelect_Item, data.id);
        select.gameObject.SetActive(true);
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
                select.gameObject.SetActive(false);
            }
        }
    }

    public void CheckIfSelected()
    {
        EItemType eItemType = data.itemtype;
        string key;

        switch (eItemType)
        {
            case EItemType.Background:
                key = DataKey.ID_Background;
                break;
            case EItemType.Birthmark:
                key = DataKey.ID_Birthmark;
                break;
            case EItemType.Eyeblow:
                key = DataKey.ID_Eyeblow;
                break;
            case EItemType.Body:
                key = DataKey.ID_Body;
                break;
            case EItemType.Earrings:
                key = DataKey.ID_Earrings;
                break;
            case EItemType.Blush:
                key = DataKey.ID_Blush;
                break;
            case EItemType.Eyes:
                key = DataKey.ID_Eyes;
                break;
            case EItemType.Glass:
                key = DataKey.ID_Glass;
                break;
            case EItemType.Mouth:
                key = DataKey.ID_Mouth;
                break;
            case EItemType.Necklace:
                key = DataKey.ID_Neckless;
                break;
            case EItemType.Nose:
                key = DataKey.ID_Nose;
                break;
            case EItemType.Shoes:
                key = DataKey.ID_Shoes;
                break;
            case EItemType.Socks:
                key = DataKey.ID_Socks;
                break;
            case EItemType.Trouser:
                key = DataKey.ID_Trousers;
                break;
            case EItemType.Wing:
                key = DataKey.ID_Wing;
                break;
            case EItemType.Behind_Hair:
                key = DataKey.ID_Behind_Hair;
                break;
            case EItemType.Front_Hair:
                key = DataKey.ID_Front_Hair;
                break;
            case EItemType.Hand_Bag:
                key = DataKey.ID_Hand_Bag;
                break;
            case EItemType.Insight_Shirt:
                key = DataKey.ID_Insight_Shirt;
                break;
            case EItemType.Outsight_Shirt:
                key = DataKey.ID_Outsight_Shirt;
                break;
            case EItemType.Short_Dress:
                key = DataKey.ID_Short_Dress;
                break;
            case EItemType.Long_Dress:
                key = DataKey.ID_Long_Dress;
                break;
            case EItemType.Normal_Hat:
                key = DataKey.ID_Hat;
                break;
            default:
                key = "";
                break;
        }
        
        int idSelected = PlayerPrefs.GetInt(key);
        //Debug.Log("Selected id = " + idSelected + "\t" + data.id);
        
        if (idSelected == data.id)
        {
            select.gameObject.SetActive(true);
        }
        else
        {
            select.gameObject.SetActive(false);
        }
    }
}
