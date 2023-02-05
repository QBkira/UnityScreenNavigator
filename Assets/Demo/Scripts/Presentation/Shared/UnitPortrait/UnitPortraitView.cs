using Cysharp.Threading.Tasks;
using Demo.Scripts.Presentation.Shared.Binders;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;
using UnityEngine.UI;

namespace Demo.Scripts.Presentation.Shared.UnitPortrait
{
    public sealed class UnitPortraitView : AppView<UnitPortraitState>
    {
        public Image image;

        protected override UniTask Initialize(UnitPortraitState state)
        {
            image.SetSpriteSource(state.ImageResourceKey).AddTo(this);
            return UniTask.CompletedTask;
        }
    }
}
