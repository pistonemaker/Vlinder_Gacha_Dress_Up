using System.Collections.Generic;
using System.Linq;
using Com.TheFallenGames.OSA.Demos.SelectAndDelete;

public class ItemBarManager : Singleton<ItemBarManager>
{
    public SceneEntry sceneEntry;
    public ItemTypeButton currentItemTypeButton;
    public ItemTypeButton faceAccessoryButton;
    public List<ItemTypeButton> itemTypeButtons;

    private void OnEnable()
    {
        itemTypeButtons = GetComponentsInChildren<ItemTypeButton>().ToList();
        this.RegisterListener(EventID.On_Wear_Item, param => WearItem((ItemData)param));
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
        if (currentItemTypeButton != faceAccessoryButton)
        {
            currentItemTypeButton.WearItem(data);
        }
        else
        {
            faceAccessoryButton.WearItem(data);
        }
    }
}
