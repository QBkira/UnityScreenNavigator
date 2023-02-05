using System;
using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Presentation.Shared.UnitPortrait;
using Demo.Scripts.Presentation.Shared.UnitThumbnail;
using UniRx;

namespace Demo.Scripts.Presentation.UnitTypeInformation
{
    public sealed class UnitTypeInformationState : AppViewState, IUnitTypeInformationState
    {
        private readonly Subject<Unit> _onCloseButtonClickedSubject = new Subject<Unit>();
        private readonly Subject<Unit> _onExpandButtonClickedSubject = new Subject<Unit>();
        private readonly ReactiveProperty<string> _rank1Description = new ReactiveProperty<string>();
        private readonly ReactiveProperty<string> _rank2Description = new ReactiveProperty<string>();
        private readonly ReactiveProperty<string> _rank3Description = new ReactiveProperty<string>();
        private readonly ReactiveProperty<int> _tabIndex = new ReactiveProperty<int>();
        private readonly ReactiveProperty<string> _title = new ReactiveProperty<string>();

        public IReactiveProperty<string> Title => _title;
        public IReactiveProperty<int> TabIndex => _tabIndex;
        public IReactiveProperty<string> Rank1Description => _rank1Description;
        public IReactiveProperty<string> Rank2Description => _rank2Description;
        public IReactiveProperty<string> Rank3Description => _rank3Description;
        public UnitThumbnailState Rank1Thumbnail { get; } = new UnitThumbnailState();
        public UnitThumbnailState Rank2Thumbnail { get; } = new UnitThumbnailState();
        public UnitThumbnailState Rank3Thumbnail { get; } = new UnitThumbnailState();
        public UnitPortraitState Rank1Portrait { get; } = new UnitPortraitState();
        public UnitPortraitState Rank2Portrait { get; } = new UnitPortraitState();
        public UnitPortraitState Rank3Portrait { get; } = new UnitPortraitState();
        public IObservable<Unit> OnCloseButtonClicked => _onCloseButtonClickedSubject;
        public IObservable<Unit> OnExpandButtonClicked => _onExpandButtonClickedSubject;

        void IUnitTypeInformationState.InvokeCloseButtonClicked()
        {
            _onCloseButtonClickedSubject.OnNext(Unit.Default);
        }

        void IUnitTypeInformationState.InvokeExpandButtonClicked()
        {
            _onExpandButtonClickedSubject.OnNext(Unit.Default);
        }

        protected override void DisposeInternal()
        {
            _title.Dispose();
            _tabIndex.Dispose();
            _rank1Description.Dispose();
            _rank2Description.Dispose();
            _rank3Description.Dispose();
            Rank1Thumbnail.Dispose();
            Rank2Thumbnail.Dispose();
            Rank3Thumbnail.Dispose();
            Rank1Portrait.Dispose();
            Rank2Portrait.Dispose();
            Rank3Portrait.Dispose();
            _onCloseButtonClickedSubject.Dispose();
            _onExpandButtonClickedSubject.Dispose();
        }
    }

    internal interface IUnitTypeInformationState
    {
        void InvokeCloseButtonClicked();
        void InvokeExpandButtonClicked();
    }
}
