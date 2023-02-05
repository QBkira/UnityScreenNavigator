using System;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;

namespace Demo.Scripts.Presentation.UnitShop
{
    public sealed class UnitShopState : AppViewState, IUnitShopState
    {
        private readonly Subject<Unit> _onBackButtonClickedSubject = new Subject<Unit>();
        public UnitShopItemSetState RegularItems { get; } = new UnitShopItemSetState();
        public UnitShopItemSetState SpecialItems { get; } = new UnitShopItemSetState();
        public UnitShopItemSetState SaleItems { get; } = new UnitShopItemSetState();

        public IObservable<Unit> OnBackButtonClicked => _onBackButtonClickedSubject;

        public void InvokeBackButtonClicked()
        {
            _onBackButtonClickedSubject.OnNext(Unit.Default);
        }

        protected override void DisposeInternal()
        {
            _onBackButtonClickedSubject.Dispose();
            RegularItems.Dispose();
            SpecialItems.Dispose();
            SaleItems.Dispose();
        }
    }

    internal interface IUnitShopState
    {
        void InvokeBackButtonClicked();
    }
}
