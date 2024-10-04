using UnityEngine;
using UnityEngine.UI;

public class ItemType : MonoBehaviour
{
    public bool canNullValue;
    public bool canMultiValue;
    public Sprite sprite;
    public Sprite chooseSprite;
    public Button button;

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
        if (button.image.sprite == chooseSprite)
        {
            button.image.sprite = sprite;
        }
        else
        {
            button.image.sprite = chooseSprite;
        }
    }

    protected virtual void ShowItemGrid()
    {
        
    }
}
