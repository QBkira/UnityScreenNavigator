using Demo.Scripts;
using Demo.Scripts.Presentation.UnitTypeInformation;
using Development.AppView.Shared;
using UniRx;
using UnityEngine;

namespace Development.AppView.UnitTypeInformation
{
    public sealed class UnitTypeInformationDevelopment
        : AppViewDevelopment<UnitTypeInformationView, UnitTypeInformationState>
    {
        protected override UnitTypeInformationState CreateState()
        {
            var state = new UnitTypeInformationState();
            state.Title.Value = "Test Unit Name";
            state.Rank1Thumbnail.ImageResourceKey.Value = ResourceKey.Textures.GetUnitThumbnail(3, 1);
            state.Rank2Thumbnail.ImageResourceKey.Value = ResourceKey.Textures.GetUnitThumbnail(3, 2);
            state.Rank3Thumbnail.ImageResourceKey.Value = ResourceKey.Textures.GetUnitThumbnail(3, 3);
            state.Rank1Description.Value =
                "Rank 1 Description. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi utz";
            state.Rank2Description.Value =
                "Rank 2 Description. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut";
            state.Rank3Description.Value =
                "Rank 3 Description. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut";

            state.Rank1Portrait.ImageResourceKey.Value = ResourceKey.Textures.GetUnitPortrait(3, 1);
            state.Rank2Portrait.ImageResourceKey.Value = ResourceKey.Textures.GetUnitPortrait(3, 2);
            state.Rank3Portrait.ImageResourceKey.Value = ResourceKey.Textures.GetUnitPortrait(3, 3);

            state.OnCloseButtonClicked.Subscribe(_ => Debug.Log("Close Button Clicked")).AddTo(this);
            state.OnExpandButtonClicked.Subscribe(_ => Debug.Log("Expand Button Clicked")).AddTo(this);
            return state;
        }
    }
}
