using Demo.Scripts.Presentation.Shared.Foundation;

namespace Demo.Scripts.Presentation.UnitShop
{
    public sealed class UnitShopItemSetState : AppViewState, IUnitShopItemSetState
    {
        public UnitShopItemState Item1 { get; } = new UnitShopItemState();
        public UnitShopItemState Item2 { get; } = new UnitShopItemState();
        public UnitShopItemState Item3 { get; } = new UnitShopItemState();
        public UnitShopItemState Item4 { get; } = new UnitShopItemState();
        public UnitShopItemState Item5 { get; } = new UnitShopItemState();
        public UnitShopItemState Item6 { get; } = new UnitShopItemState();
        public UnitShopItemState Item7 { get; } = new UnitShopItemState();
        public UnitShopItemState Item8 { get; } = new UnitShopItemState();

        protected override void DisposeInternal()
        {
            Item1.Dispose();
            Item2.Dispose();
            Item3.Dispose();
            Item4.Dispose();
            Item5.Dispose();
            Item6.Dispose();
            Item7.Dispose();
            Item8.Dispose();
        }
    }

    internal interface IUnitShopItemSetState
    {
    }
}
