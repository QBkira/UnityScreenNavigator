using System;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;

namespace Demo.Scripts.Presentation.Home
{
    public sealed class HomeButtonState : AppViewState, IHomeButtonState
    {
        private readonly ReactiveProperty<bool> _isLocked = new ReactiveProperty<bool>();
        private readonly Subject<Unit> _onClickedSubject = new Subject<Unit>();

        public IReactiveProperty<bool> IsLocked => _isLocked;
        public IObservable<Unit> OnClicked => _onClickedSubject;

        void IHomeButtonState.InvokeClicked()
        {
            _onClickedSubject.OnNext(Unit.Default);
        }

        protected override void DisposeInternal()
        {
            _onClickedSubject.Dispose();
        }
    }

    internal interface IHomeButtonState
    {
        void InvokeClicked();
    }
}
