using System;
using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Presentation.Shared.UnitPortrait;
using UniRx;

namespace Demo.Scripts.Presentation.UnitPortraitViewer
{
    public sealed class UnitPortraitViewerState : AppViewState, IUnitPortraitViewerState
    {
        private readonly Subject<Unit> _onCloseButtonClickedSubject = new Subject<Unit>();

        public UnitPortraitState Portrait { get; } = new UnitPortraitState();
        public IObservable<Unit> OnCloseButtonClicked => _onCloseButtonClickedSubject;

        public void InvokeOnCloseButtonClicked()
        {
            _onCloseButtonClickedSubject.OnNext(Unit.Default);
        }

        protected override void DisposeInternal()
        {
            Portrait.Dispose();
            _onCloseButtonClickedSubject.Dispose();
        }
    }

    internal interface IUnitPortraitViewerState
    {
        void InvokeOnCloseButtonClicked();
    }
}
