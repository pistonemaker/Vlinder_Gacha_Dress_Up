using System.Collections.Generic;
using System.Linq;
using Com.TheFallenGames.OSA.Demos.SelectAndDelete;
using UnityEngine;

public class ItemBarManager : Singleton<ItemBarManager>
{
    public SpriteRenderer frontHair;
    public SpriteRenderer behindHair;
    public SceneEntry sceneEntry;
    public ChooseBSHPanel chooseBSHPanel;
    public ChooseColorPanel chooseColorPanel;
    public EditColorPopup editColorPopup;
    public ItemTypeButton currentItemTypeButton;
    public ItemTypeButton faceAccessoryButton;
    public ItemTypeButton frontHairButton;
    public ItemTypeButton behindHairButton;
    public List<ItemTypeButton> itemTypeButtons;
    
    public bool isApplyColor;
    public Color currentColor;

    private void OnEnable()
    {
        frontHair = Doll.Instance.frontHair;
        behindHair = Doll.Instance.behindHair;
        itemTypeButtons = GetComponentsInChildren<ItemTypeButton>().ToList();
        this.RegisterListener(EventID.On_Wear_Item, param => WearItem((ItemData)param));

        //chooseBSHPanel.gameObject.SetActive(false);
        chooseColorPanel.gameObject.SetActive(false);
        editColorPopup.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        this.RemoveListener(EventID.On_Wear_Item, param => WearItem((ItemData)param));
    }

    public void ActiveItemButton(ItemTypeButton button)
    {
        for (int i = 0; i < itemTypeButtons.Count; i++)
        {
            if (itemTypeButtons[i] != button)
            {
                itemTypeButtons[i].UnChoose();
            }
        }
    }

    public void LoadOSA(EItemType eItemType)
    {
        sceneEntry.eItemType = eItemType;
        sceneEntry.LoadData(eItemType);
        sceneEntry.RefreshGrid();
    }

    public void LoadOSAFaceAccessories()
    {
        sceneEntry.LoadDataAccessories();
        sceneEntry.RefreshGrid();
    }

    private void WearItem(ItemData data)
    {
        currentItemTypeButton.WearItem(data);

        if (currentItemTypeButton.canChangeRGB)
        {
            chooseColorPanel.gameObject.SetActive(true);
            UIManager.Instance.saveButton.gameObject.SetActive(false);
            UIManager.Instance.takeOffButton.gameObject.SetActive(false);
        }
    }

    public void ApplyColorChange(Color color)
    {
        isApplyColor = true;
        currentColor = color;
        frontHairButton.ApplyColorChange(color);
        behindHairButton.ApplyColorChange(color);
    }

    public void ClearColor()
    {
        isApplyColor = false;
        currentColor = Color.white;
        frontHairButton.ClearColor();
        behindHairButton.ClearColor();
    }
}