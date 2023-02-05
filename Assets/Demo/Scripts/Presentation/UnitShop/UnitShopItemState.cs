using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Presentation.Shared.UnitThumbnail;
using UniRx;

namespace Demo.Scripts.Presentation.UnitShop
{
    public sealed class UnitShopItemState : AppViewState, IUnitShopItemState
    {
        private readonly ReactiveProperty<int> _cost = new ReactiveProperty<int>();
        private readonly ReactiveProperty<string> _costIconImageResourceKey = new ReactiveProperty<string>();
        private readonly ReactiveProperty<bool> _isLocked = new ReactiveProperty<bool>();
        public UnitThumbnailState Thumbnail { get; } = new UnitThumbnailState();

        public IReactiveProperty<int> Cost => _cost;
        public IReactiveProperty<string> CostIconImageResourceKey => _costIconImageResourceKey;
        public IReactiveProperty<bool> IsLocked => _isLocked;

        protected override void DisposeInternal()
        {
            Thumbnail.Dispose();
            _cost.Dispose();
            _costIconImageResourceKey.Dispose();
            _isLocked.Dispose();
        }
    }

    internal interface IUnitShopItemState
    {
    }
}
