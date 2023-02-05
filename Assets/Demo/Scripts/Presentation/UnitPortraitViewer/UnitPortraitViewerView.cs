using Cysharp.Threading.Tasks;
using Demo.Scripts.Presentation.Shared.Binders;
using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Presentation.Shared.UnitPortrait;
using UniRx;
using UnityEngine.UI;

namespace Demo.Scripts.Presentation.UnitPortraitViewer
{
    public sealed class UnitPortraitViewerView : AppView<UnitPortraitViewerState>
    {
        public UnitPortraitView portraitView;
        public Button closeButton;

        protected override async UniTask Initialize(UnitPortraitViewerState state)
        {
            var internalState = (IUnitPortraitViewerState)state;
            closeButton.SetOnClickDestination(internalState.InvokeOnCloseButtonClicked).AddTo(this);

            await portraitView.InitializeAsync(state.Portrait);
        }
    }
}
