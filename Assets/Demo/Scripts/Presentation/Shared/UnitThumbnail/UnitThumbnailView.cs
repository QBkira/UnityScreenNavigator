using Cysharp.Threading.Tasks;
using Demo.Scripts.Presentation.Shared.Binders;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;
using UnityEngine.UI;

namespace Demo.Scripts.Presentation.Shared.UnitThumbnail
{
    public sealed class UnitThumbnailView : AppView<UnitThumbnailState>
    {
        public Image image;
        public Button button;

        protected override UniTask Initialize(UnitThumbnailState state)
        {
            var stateInternal = (IUnitThumbnailState)state;
            image.SetSpriteSource(state.ImageResourceKey).AddTo(this);
            button.SetOnClickDestination(stateInternal.InvokeClicked).AddTo(this);
            return UniTask.CompletedTask;
        }
    }
}
