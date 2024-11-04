using Com.TheFallenGames.OSA.CustomAdapters.GridView;
using Com.TheFallenGames.OSA.Demos.Common.SceneEntries;

namespace Com.TheFallenGames.OSA.Demos.SelectAndDelete
{
    public class SceneEntry : BaseSceneEntry<ItemScrollAdapter, MyGridParams, CellGroupViewsHolder<MyCellViewsHolder>>
    {
        protected override void InitAdapters()
        {
            base.InitAdapters();
            var adapter = _Adapters[0];
        }

        protected override void InitDrawer()
        {
        }

        #region events from DrawerCommandPanel

        protected override void OnRemoveItemRequested(ItemScrollAdapter adapter, int index)
        {
            base.OnRemoveItemRequested(adapter, index);

            if (adapter.CellsCount == 0)
                return;
        }

        protected override void OnItemCountChangeRequested(ItemScrollAdapter adapter, int newCount)
        {
            base.OnItemCountChangeRequested(adapter, newCount);
        }

        #endregion
    }
}