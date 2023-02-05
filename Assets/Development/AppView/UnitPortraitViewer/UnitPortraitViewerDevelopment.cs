using Demo.Scripts;
using Demo.Scripts.Presentation.UnitPortraitViewer;
using Development.AppView.Shared;
using UniRx;
using UnityEngine;

namespace Development.AppView.UnitPortraitViewer
{
    public sealed class UnitPortraitViewerDevelopment
        : AppViewDevelopment<UnitPortraitViewerView, UnitPortraitViewerState>
    {
        protected override UnitPortraitViewerState CreateState()
        {
            var state = new UnitPortraitViewerState();
            state.Portrait.ImageResourceKey.Value = ResourceKey.Textures.GetUnitThumbnail(3, 1);
            state.OnCloseButtonClicked.Subscribe(_ => Debug.Log("OnCloseButtonClicked")).AddTo(this);
            return state;
        }
    }
}
