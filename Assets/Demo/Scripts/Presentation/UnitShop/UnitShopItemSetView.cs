using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Demo.Scripts.Presentation.Shared.Foundation;

namespace Demo.Scripts.Presentation.UnitShop
{
    public sealed class UnitShopItemSetView : AppView<UnitShopItemSetState>
    {
        public UnitShopItemView item1;
        public UnitShopItemView item2;
        public UnitShopItemView item3;
        public UnitShopItemView item4;
        public UnitShopItemView item5;
        public UnitShopItemView item6;
        public UnitShopItemView item7;
        public UnitShopItemView item8;

        protected override async UniTask Initialize(UnitShopItemSetState state)
        {
            var tasks = new List<UniTask>
            {
                item1.InitializeAsync(state.Item1),
                item2.InitializeAsync(state.Item2),
                item3.InitializeAsync(state.Item3),
                item4.InitializeAsync(state.Item4),
                item5.InitializeAsync(state.Item5),
                item6.InitializeAsync(state.Item6),
                item7.InitializeAsync(state.Item7),
                item8.InitializeAsync(state.Item8)
            };
            await UniTask.WhenAll(tasks);
        }
    }
}
