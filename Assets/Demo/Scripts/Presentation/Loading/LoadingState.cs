using Demo.Scripts.Presentation.Shared.Foundation;

namespace Demo.Scripts.Presentation.Loading
{
    public sealed class LoadingState : AppViewState, ILoadingState
    {
        protected override void DisposeInternal()
        {
        }
    }

    internal interface ILoadingState
    {
    }
}
