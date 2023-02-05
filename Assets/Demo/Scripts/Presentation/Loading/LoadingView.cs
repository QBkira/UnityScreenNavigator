using Cysharp.Threading.Tasks;
using Demo.Scripts.Presentation.Shared.Foundation;

namespace Demo.Scripts.Presentation.Loading
{
    public sealed class LoadingView : AppView<LoadingState>
    {
        protected override UniTask Initialize(LoadingState state)
        {
            return UniTask.CompletedTask;
        }
    }
}
