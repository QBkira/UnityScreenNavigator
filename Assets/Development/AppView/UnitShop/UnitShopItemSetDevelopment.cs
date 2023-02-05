using Demo.Scripts;
using Demo.Scripts.Presentation.UnitShop;
using Development.AppView.Shared;
using UniRx;
using UnityEngine;

namespace Development.AppView.UnitShop
{
    public sealed class UnitShopItemSetDevelopment : AppViewDevelopment<UnitShopItemSetView, UnitShopItemSetState>
    {
        protected override UnitShopItemSetState CreateState()
        {
            var state = new UnitShopItemSetState();
            state.Item1.IsLocked.Value = false;
            state.Item1.Cost.Value = 5000;
            state.Item1.CostIconImageResourceKey.Value = ResourceKey.Textures.CoinIcon;
            state.Item1.Thumbnail.ImageResourceKey.Value = ResourceKey.Textures.GetUnitThumbnail(3, 1);
            state.Item1.Thumbnail.OnClicked.Subscribe(_ => { Debug.Log("Clicked"); }).AddTo(this);
            state.Item2.IsLocked.Value = true;
            state.Item3.IsLocked.Value = true;
            state.Item4.IsLocked.Value = true;
            state.Item5.IsLocked.Value = true;
            state.Item6.IsLocked.Value = true;
            state.Item7.IsLocked.Value = true;
            state.Item8.IsLocked.Value = true;
            return state;
        }
    }
}