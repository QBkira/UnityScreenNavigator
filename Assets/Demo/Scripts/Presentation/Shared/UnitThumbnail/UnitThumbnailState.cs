using System;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;

namespace Demo.Scripts.Presentation.Shared.UnitThumbnail
{
    public sealed class UnitThumbnailState : AppViewState, IUnitThumbnailState
    {
        private readonly ReactiveProperty<string> _imageResourceKey = new ReactiveProperty<string>();
        private readonly Subject<Unit> _onClickedSubject = new Subject<Unit>();

        public IReactiveProperty<string> ImageResourceKey => _imageResourceKey;
        public IObservable<Unit> OnClicked => _onClickedSubject;

        void IUnitThumbnailState.InvokeClicked()
        {
            _onClickedSubject.OnNext(Unit.Default);
        }

        protected override void DisposeInternal()
        {
            _imageResourceKey.Dispose();
            _onClickedSubject.Dispose();
        }
    }

    internal interface IUnitThumbnailState
    {
        void InvokeClicked();
    }
}
