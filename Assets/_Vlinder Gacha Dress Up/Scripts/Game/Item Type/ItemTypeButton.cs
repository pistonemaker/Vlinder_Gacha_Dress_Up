using UnityEngine;
using UnityEngine.UI;

public class ItemTypeButton : MonoBehaviour
{
    [SerializeField] protected EItemType eItemType;
    [SerializeField] protected Sprite chooseItemSprite;
    [SerializeField] protected SpriteRenderer targetRenderer;
    public ItemData curItemData;
    public bool canNullValue;
    public bool canChangeRGB;
    public bool canChangeBSH;
    public Sprite sprite;
    public Sprite chooseSprite;
    protected Button button;
    protected DollComponentData dollComponentData;

    protected virtual void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnChoose);
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }

    protected void OnChoose()
    {
        SetUpItemType();
        ShowItemGrid();
    }

    protected void SetUpItemType()
    {
        Choose();
        ItemBarManager.Instance.ActiveItemButton(this);
    }

    protected void Choose()
    {
        button.image.sprite = chooseSprite;
        ItemBarManager.Instance.currentItemTypeButton = this;
        ItemBarManager.Instance.chooseColorPanel.gameObject.SetActive(false);
        UIManager.Instance.saveButton.gameObject.SetActive(true);
        UIManager.Instance.takeOffButton.gameObject.SetActive(true);

        if (canChangeBSH)
        {
            //ItemBarManager.Instance.chooseBSHPanel.gameObject.SetActive(true);
        }
        else
        {
            //ItemBarManager.Instance.chooseBSHPanel.gameObject.SetActive(false);
        }
    }

    public void UnChoose()
    {
        button.image.sprite = sprite;
    }

    protected virtual void ShowItemGrid()
    {
        ItemBarManager.Instance.LoadOSA(eItemType);
    }

    public SpriteRenderer GetRenderer()
    {
        return targetRenderer;
    }

    public virtual void WearItem(ItemData itemData)
    {
        curItemData = itemData;
        
        if (itemData.itemtype == eItemType)
        {
            if (targetRenderer.sprite == itemData.sprite && canNullValue)
            {
                targetRenderer.sprite = null;
                Doll.Instance.hairLight.sprite = null;
                this.PostEvent(EventID.On_DisSelect_Item, curItemData.id);
            }
            else if (targetRenderer.sprite == itemData.colorSprite && itemData.colorSprite != null)
            {
                targetRenderer.sprite = null;
                Doll.Instance.hairLight.sprite = null;
                this.PostEvent(EventID.On_DisSelect_Item, curItemData.id);
            }
            else
            {
                if (itemData.isColor)
                {
                    targetRenderer.sprite = chooseItemSprite = itemData.colorSprite;
                    Doll.Instance.hairLight.sprite = null;
                    
                    if (ItemBarManager.Instance.isApplyColor)
                    {
                        targetRenderer.sprite = chooseItemSprite = itemData.sprite;
                    }
                }
                else
                {
                    targetRenderer.sprite = chooseItemSprite = itemData.sprite;
                    if (itemData.isLight)
                    {
                        Doll.Instance.hairLight.sprite = itemData.lightSprite;
                    }
                    else
                    {
                        Doll.Instance.hairLight.sprite = null;
                    }
                }

                StartCoroutine(StarSpawner.Instance.SpawnStar());
                var key = ChangeItemTypeToData(eItemType);
                PlayerPrefs.SetInt(key, itemData.id);
            }
        }
    }

    public SpriteRenderer GetCurSpriteRenderer()
    {
        return targetRenderer;
    }

    public void ApplyColorChange(Color color)
    {
        if (targetRenderer.sprite != null)
        {
            if (targetRenderer.sprite == curItemData.sprite)
            {
                targetRenderer.color = color;
            }
            else
            {
                targetRenderer.sprite = curItemData.sprite;
                targetRenderer.color = color;
            }
        }
    }

    public void ClearColor()
    {
        if (curItemData.isColor)
        {
            targetRenderer.sprite = curItemData.colorSprite;
            targetRenderer.color = Color.white;
        }
        else
        {
            targetRenderer.color = Color.white;
        }
    }

    public virtual void SaveData()
    {
        dollComponentData.id = curItemData.id;
        dollComponentData.eItemType = eItemType;
        dollComponentData.sprite = targetRenderer.sprite;
    }

    protected string ChangeItemTypeToData(EItemType itemType)
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
                return DataKey.ID_Necklace;
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