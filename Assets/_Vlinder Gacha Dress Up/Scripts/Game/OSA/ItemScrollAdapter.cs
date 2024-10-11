using System;
using Com.TheFallenGames.OSA.Core;
using Com.TheFallenGames.OSA.CustomAdapters.GridView;
using Com.TheFallenGames.OSA.DataHelpers;
using UnityEngine;
using UnityEngine.UI;

public class ItemScrollAdapter : GridAdapter<MyGridParams, MyCellViewsHolder>
{
    public LazyDataHelper<ItemData> LazyData { get; set; }

    #region GridAdapter implementation

    protected override void Start()
    {
        var cancel = _Params.Animation.Cancel;
        cancel.UserAnimations.OnCountChanges = false;
        cancel.UserAnimations.OnSizeChanges = false;
    }

    protected override void Update()
    {
        base.Update();

        if (!IsInitialized)
            return;
    }

    public override void ChangeItemsCount(ItemCountChangeMode changeMode, int cellsCount, int indexIfAppendingOrRemoving = -1, bool contentPanelEndEdgeStationary = false,
        bool keepVelocity = false)
    {
        base.ChangeItemsCount(changeMode, cellsCount, indexIfAppendingOrRemoving, contentPanelEndEdgeStationary, keepVelocity);
    }

    public override void Refresh(bool contentPanelEndEdgeStationary = false /*ignored*/, bool keepVelocity = false)
    {
        _CellsCount = LazyData.Count;
    }

    protected override void OnCellViewsHolderCreated(MyCellViewsHolder cellVH, CellGroupViewsHolder<MyCellViewsHolder> cellGroup)
    {
        base.OnCellViewsHolderCreated(cellVH, cellGroup);
    }

    protected override void UpdateCellViewsHolder(MyCellViewsHolder viewsHolder)
    {
        var model = LazyData.GetOrCreate(viewsHolder.ItemIndex);
        viewsHolder.UpdateViews(model);
    }

    protected override void OnBeforeRecycleOrDisableCellViewsHolder(MyCellViewsHolder viewsHolder, int newItemIndex)
    {
        viewsHolder.views.localScale = Vector3.one;
    }

    #endregion
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

    public void UpdateViews(ItemData data)
    {
        itemButton.data = data;
        itemButton.thumb.sprite = data.thumbSprite;
        itemButton.index = ItemIndex;
        itemButton.CheckIfSelected(null);
    }
}