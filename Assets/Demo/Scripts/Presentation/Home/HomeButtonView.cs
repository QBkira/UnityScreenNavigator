using Cysharp.Threading.Tasks;
using Demo.Scripts.Presentation.Shared.Binders;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Scripts.Presentation.Home
{
    public sealed class HomeButtonView : AppView<HomeButtonState>
    {
        public Button button;
        public GameObject lockedRoot;
        public GameObject unlockedRoot;

        protected override UniTask Initialize(HomeButtonState state)
        {
            var internalState = (IHomeButtonState)state;
            lockedRoot.SetActiveSelfSource(state.IsLocked).AddTo(this);
            unlockedRoot.SetActiveSelfSource(state.IsLocked, true).AddTo(this);
            button.SetOnClickDestination(internalState.InvokeClicked).AddTo(this);
            return UniTask.CompletedTask;
        }
    }
}
