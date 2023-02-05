using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Transition;
using UniRx;

namespace Demo.Scripts.Presentation.UnitPortraitViewer
{
    public sealed class UnitPortraitViewerModalPresenter
        : ModalPresenter<UnitPortraitViewerModal, UnitPortraitViewerView, UnitPortraitViewerState>
    {
        private readonly int _unitTypeId;
        private readonly int _unitRank;

        public UnitPortraitViewerModalPresenter(UnitPortraitViewerModal view, ITransitionService transitionService,
            int unitTypeId, int unitRank) : base(view, transitionService)
        {
            _unitTypeId = unitTypeId;
            _unitRank = unitRank;
        }

        protected override UnitPortraitViewerState CreateState()
        {
            var state = new UnitPortraitViewerState();
            state.Portrait.ImageResourceKey.Value = ResourceKey.Textures.GetUnitPortrait(_unitTypeId, _unitRank);
            state.OnCloseButtonClicked.Subscribe(_ => TransitionService.PopCommandExecuted());
            return state;
        }
    }
}
