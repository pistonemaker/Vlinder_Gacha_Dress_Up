using UnityEngine;
using UnityEngine.UI;

public class ItemTypeButton : MonoBehaviour
{
    [SerializeField] protected EItemType eItemType;
    [SerializeField] protected Sprite chooseItemSprite;
    [SerializeField] protected SpriteRenderer targetRenderer;
    public bool canNullValue;
    public bool canMultiValue;
    public Sprite sprite;
    public Sprite chooseSprite;
    protected Button button;

    protected virtual void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnChoose);
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
    }

    public void UnChoose()
    {
        button.image.sprite = sprite;
    }

    protected virtual void ShowItemGrid()
    {
        ItemBarManager.Instance.LoadOSA(eItemType);
    }

    public virtual void WearItem(ItemData itemData)
    {
        if (itemData.itemtype == eItemType)
        {
            if (targetRenderer.sprite == itemData.sprite && canNullValue)
            {
                targetRenderer.sprite = null;
                Doll.Instance.hairLight.sprite = null;
            }
            else if (targetRenderer.sprite == itemData.colorSprite && itemData.colorSprite != null)
            {
                targetRenderer.sprite = null;
                Doll.Instance.hairLight.sprite = null;
            }
            else
            {
                if (itemData.isColor)
                {
                    targetRenderer.sprite = chooseItemSprite = itemData.colorSprite;
                    Doll.Instance.hairLight.sprite = null;
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

                PlayerPrefs.SetInt(DataKey.ID_Body, itemData.id);
            }
        }
    }
}