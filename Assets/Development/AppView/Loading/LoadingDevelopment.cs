using Demo.Scripts.Presentation.Loading;
using Development.AppView.Shared;

namespace Development.AppView.Loading
{
    public sealed class LoadingDevelopment : AppViewDevelopment<LoadingView, LoadingState>
    {
        protected override LoadingState CreateState()
        {
            var state = new LoadingState();
            return state;
        }
    }
}
