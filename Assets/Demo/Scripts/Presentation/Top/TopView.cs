using Cysharp.Threading.Tasks;
using Demo.Scripts.Presentation.Shared.Binders;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;
using UnityEngine.UI;

namespace Demo.Scripts.Presentation.Top
{
    public sealed class TopView : AppView<TopState>
    {
        public Button button;

        protected override UniTask Initialize(TopState state)
        {
            var internalState = (ITopState)state;
            button.SetOnClickDestination(internalState.InvokeBackButtonClicked).AddTo(this);
            return UniTask.CompletedTask;
        }
    }
}
