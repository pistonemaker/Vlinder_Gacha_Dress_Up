using System.Collections.Generic;
using Com.TheFallenGames.OSA.CustomAdapters.GridView;
using Com.TheFallenGames.OSA.DataHelpers;
using Com.TheFallenGames.OSA.Demos.Common.SceneEntries;
using UnityEngine;

namespace Com.TheFallenGames.OSA.Demos.SelectAndDelete
{
    public class SceneEntry : BaseSceneEntry<ItemScrollAdapter, MyGridParams, CellGroupViewsHolder<MyCellViewsHolder>>
    {
        public GameData gameData;
        public EItemType eItemType;
        public List<ItemData> allItemsLoaded = new List<ItemData>();

        protected override void InitAdapters()
        {
            base.InitAdapters();

            eItemType = EItemType.Body;
            var adapter = _Adapters[0];
            LoadData(eItemType);
            adapter.LazyData = new LazyDataHelper<ItemData>(adapter, CreateNewModel);
            adapter.Init();
            adapter.LazyData.ResetItems(allItemsLoaded.Count);
        }

        public void LoadData(EItemType eitemType)
        {
            eItemType = eitemType;
            allItemsLoaded.Clear();
            allItemsLoaded.AddRange(gameData.data[eItemType].itemdatas);
        }

        public void LoadDataAccessories()
        {
            allItemsLoaded.Clear();
            allItemsLoaded.AddRange(gameData.data[EItemType.Birthmark].itemdatas);
            allItemsLoaded.AddRange(gameData.data[EItemType.Blush].itemdatas);
            allItemsLoaded.AddRange(gameData.data[EItemType.Nose].itemdatas);
            allItemsLoaded.AddRange(gameData.data[EItemType.Earrings].itemdatas);
            allItemsLoaded.AddRange(gameData.data[EItemType.Glass].itemdatas);
        }

        public void RefreshGrid()
        {
            _Adapters[0].LazyData.ResetItems(allItemsLoaded.Count);
            _Adapters[0].Refresh();
        }

        protected override void InitDrawer()
        {
        }

        #region events from DrawerCommandPanel

        protected override void OnAddItemRequested(ItemScrollAdapter adapter, int index)
        {
            base.OnAddItemRequested(adapter, index);

            adapter.LazyData.List.Insert(index, 1);
        }

        protected override void OnRemoveItemRequested(ItemScrollAdapter adapter, int index)
        {
            base.OnRemoveItemRequested(adapter, index);

            if (adapter.CellsCount == 0)
                return;

            adapter.LazyData.List.Remove(index, 1);
        }

        protected override void OnItemCountChangeRequested(ItemScrollAdapter adapter, int newCount)
        {
            base.OnItemCountChangeRequested(adapter, newCount);
        }

        #endregion

        ItemData CreateNewModel(int index)
        {
            return allItemsLoaded[index];
        }
    }
}