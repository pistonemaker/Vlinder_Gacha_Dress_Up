using System;
using System.Collections.Generic;
using Com.TheFallenGames.OSA.Core;
using Com.TheFallenGames.OSA.CustomAdapters.GridView;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ItemScrollAdapter : GridAdapter<MyGridParams, MyCellViewsHolder>
{
    public List<ItemDataToJson> allItemsLoaded = new List<ItemDataToJson>();
    public EItemType eItemType = EItemType.Body;

    #region GridAdapter implementation

    protected override void Start()
    {
        var cancel = _Params.Animation.Cancel;
        cancel.UserAnimations.OnCountChanges = false;
        cancel.UserAnimations.OnSizeChanges = false;
        Init();
        LoadData(EItemType.Body);
    }

    protected override void Update()
    {
        base.Update();

        if (!IsInitialized)
            return;
    }

    public override void ChangeItemsCount(ItemCountChangeMode changeMode, int cellsCount, int indexIfAppendingOrRemoving = -1, 
        bool contentPanelEndEdgeStationary = false, bool keepVelocity = false)
    {
        base.ChangeItemsCount(changeMode, cellsCount, indexIfAppendingOrRemoving, contentPanelEndEdgeStationary, keepVelocity);
    }

    public override void Refresh(bool contentPanelEndEdgeStationary = false /*ignored*/, bool keepVelocity = false)
    {
        _CellsCount = allItemsLoaded.Count;
    }

    protected override void OnCellViewsHolderCreated(MyCellViewsHolder cellVH, CellGroupViewsHolder<MyCellViewsHolder> cellGroup)
    {
        base.OnCellViewsHolderCreated(cellVH, cellGroup);
    }

    protected override void UpdateCellViewsHolder(MyCellViewsHolder viewsHolder)
    {
        var model = allItemsLoaded[viewsHolder.ItemIndex];
        viewsHolder.UpdateViews(model);
    }

    protected override void OnBeforeRecycleOrDisableCellViewsHolder(MyCellViewsHolder viewsHolder, int newItemIndex)
    {
        viewsHolder.views.localScale = Vector3.one;
    }

    #endregion
    
    public void LoadData(EItemType eitemType)
    {
        eItemType = eitemType;
        allItemsLoaded.Clear();
        allItemsLoaded.AddRange(JsonLoader.Instance.jsonData[eItemType].itemdatas);
        ResetItems(allItemsLoaded.Count);
        Refresh();
    }

    public void LoadDataAccessories()
    {
        allItemsLoaded.Clear();
        allItemsLoaded.AddRange(JsonLoader.Instance.jsonData[EItemType.Birthmark].itemdatas);
        allItemsLoaded.AddRange(JsonLoader.Instance.jsonData[EItemType.Blush].itemdatas);
        allItemsLoaded.AddRange(JsonLoader.Instance.jsonData[EItemType.Nose].itemdatas);
        allItemsLoaded.AddRange(JsonLoader.Instance.jsonData[EItemType.Earrings].itemdatas);
        allItemsLoaded.AddRange(JsonLoader.Instance.jsonData[EItemType.Glass].itemdatas);
        ResetItems(allItemsLoaded.Count);
        Refresh();
    }
}

[Serializable]
public class MyGridParams : GridParams
{
}

/// <summary>All views holders used with GridAdapter should inherit from <see cref="CellViewsHolder"/></summary>
public class MyCellViewsHolder : CellViewsHolder
{
    public ItemButton itemButton;

    public override void CollectViews()
    {
        base.CollectViews();

        itemButton = views.GetComponentInParent<ItemButton>();
        itemButton.thumb = views.Find("Thumb").GetComponent<Image>();
        itemButton.button = views.Find("Button").GetComponent<Button>();
    }

    public void UpdateViews(ItemDataToJson data)
    {
        itemButton.data = data;
        var handle = Addressables.LoadAssetAsync<Sprite>(data.thumbSprite);
        handle.Completed += (AsyncOperationHandle<Sprite> task) =>
        {
            itemButton.thumb.sprite = task.Result;
        };
        
        itemButton.index = ItemIndex;
        itemButton.CheckIfSelected(null);
    }
}