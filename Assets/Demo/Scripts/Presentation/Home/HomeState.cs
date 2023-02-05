using System;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;

namespace Demo.Scripts.Presentation.Home
{
    public sealed class HomeState : AppViewState, IHomeState
    {
        private readonly Subject<Unit> _onBackButtonClickedSubject = new Subject<Unit>();

        public HomeButtonState SettingsButtonState { get; } = new HomeButtonState();
        public HomeButtonState UnitShopButtonState { get; } = new HomeButtonState();
        public HomeButtonState MainQuestButtonState { get; } = new HomeButtonState();
        public HomeButtonState MissionButtonState { get; } = new HomeButtonState();
        public HomeButtonState EventQuestButtonState { get; } = new HomeButtonState();
        public IObservable<Unit> OnBackButtonClicked => _onBackButtonClickedSubject;

        void IHomeState.InvokeBackButtonClicked()
        {
            _onBackButtonClickedSubject.OnNext(Unit.Default);
        }

        protected override void DisposeInternal()
        {
            SettingsButtonState.Dispose();
            UnitShopButtonState.Dispose();
            MainQuestButtonState.Dispose();
            MissionButtonState.Dispose();
            EventQuestButtonState.Dispose();
            _onBackButtonClickedSubject.Dispose();
        }
    }

    internal interface IHomeState
    {
        void InvokeBackButtonClicked();
    }
}
