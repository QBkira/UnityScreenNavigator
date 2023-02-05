using Demo.Scripts;
using Demo.Scripts.Presentation.UnitShop;
using Development.AppView.Shared;
using UniRx;
using UnityEngine;

namespace Development.AppView.UnitShop
{
    public sealed class UnitShopDevelopment : AppViewDevelopment<UnitShopView, UnitShopState>
    {
        protected override UnitShopState CreateState()
        {
            var state = new UnitShopState();
            SetupItemSet(state.RegularItems, 5000, 3, 1);
            SetupItemSet(state.SpecialItems, 10000, 4, 1);
            SetupItemSet(state.SaleItems, 800, 5, 1);
            state.OnBackButtonClicked.Subscribe(_ => Debug.Log("OnBackButtonClicked")).AddTo(this);
            return state;
        }

        private void SetupItemSet(UnitShopItemSetState state, int cost, int unitId, int unitRank)
        {
            state.Item1.IsLocked.Value = false;
            state.Item1.Cost.Value = cost;
            state.Item1.CostIconImageResourceKey.Value = ResourceKey.Textures.CoinIcon;
            state.Item1.Thumbnail.ImageResourceKey.Value = ResourceKey.Textures.GetUnitThumbnail(unitId, unitRank);
            state.Item1.Thumbnail.OnClicked.Subscribe(_ => { Debug.Log("Clicked"); }).AddTo(this);
            state.Item2.IsLocked.Value = true;
            state.Item3.IsLocked.Value = true;
            state.Item4.IsLocked.Value = true;
            state.Item5.IsLocked.Value = true;
            state.Item6.IsLocked.Value = true;
            state.Item7.IsLocked.Value = true;
            state.Item8.IsLocked.Value = true;
        }
    }
}
