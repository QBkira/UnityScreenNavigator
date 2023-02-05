using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Transition;
using UniRx;

namespace Demo.Scripts.Presentation.UnitTypeInformation
{
    public sealed class UnitTypeInformationModalPresenter
        : ModalPresenter<UnitTypeInformationModal, UnitTypeInformationView, UnitTypeInformationState>
    {
        private readonly int _unitTypeId;

        public UnitTypeInformationModalPresenter(UnitTypeInformationModal view, ITransitionService transitionService,
            int unitTypeId) : base(view, transitionService)
        {
            _unitTypeId = unitTypeId;
        }

        protected override UnitTypeInformationState CreateState()
        {
            var state = new UnitTypeInformationState();
            state.Title.Value = "Test Unit Name";
            state.Rank1Thumbnail.ImageResourceKey.Value = ResourceKey.Textures.GetUnitThumbnail(_unitTypeId, 1);
            state.Rank2Thumbnail.ImageResourceKey.Value = ResourceKey.Textures.GetUnitThumbnail(_unitTypeId, 2);
            state.Rank3Thumbnail.ImageResourceKey.Value = ResourceKey.Textures.GetUnitThumbnail(_unitTypeId, 3);
            state.Rank1Description.Value =
                "Rank 1 Description. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi utz";
            state.Rank2Description.Value =
                "Rank 2 Description. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut";
            state.Rank3Description.Value =
                "Rank 3 Description. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut";

            state.Rank1Portrait.ImageResourceKey.Value = ResourceKey.Textures.GetUnitPortrait(_unitTypeId, 1);
            state.Rank2Portrait.ImageResourceKey.Value = ResourceKey.Textures.GetUnitPortrait(_unitTypeId, 2);
            state.Rank3Portrait.ImageResourceKey.Value = ResourceKey.Textures.GetUnitPortrait(_unitTypeId, 3);

            state.OnCloseButtonClicked
                .Subscribe(_ => TransitionService.PopCommandExecuted())
                .AddTo(this);
            state.OnExpandButtonClicked
                .Subscribe(_ =>
                {
                    var unitRank = state.TabIndex.Value + 1;
                    TransitionService.UnitTypeInformationExpandButtonClicked(_unitTypeId, unitRank);
                })
                .AddTo(this);
            return state;
        }
    }
}
