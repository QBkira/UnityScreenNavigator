using System;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;

namespace Demo.Scripts.Presentation.Top
{
    public sealed class TopState : AppViewState, ITopState
    {
        private readonly Subject<Unit> _onClickedSubject = new Subject<Unit>();

        public IObservable<Unit> OnClicked => _onClickedSubject;

        void ITopState.InvokeBackButtonClicked()
        {
            _onClickedSubject.OnNext(Unit.Default);
        }

        protected override void DisposeInternal()
        {
            _onClickedSubject.Dispose();
        }
    }

    internal interface ITopState
    {
        void InvokeBackButtonClicked();
    }
}
