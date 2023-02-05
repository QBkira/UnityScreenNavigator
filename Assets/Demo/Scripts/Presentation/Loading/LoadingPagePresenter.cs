using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Transition;

namespace Demo.Scripts.Presentation.Loading
{
    public sealed class LoadingPagePresenter : PagePresenter<LoadingPage, LoadingView, LoadingState>
    {
        public LoadingPagePresenter(LoadingPage view, ITransitionService transitionService)
            : base(view, transitionService)
        {
        }

        protected override void ViewDidPushEnter(LoadingPage view)
        {
            base.ViewDidPushEnter(view);

            TransitionService.HomeLoadingPageShown();
        }

        protected override LoadingState CreateState()
        {
            return new LoadingState();
        }
    }
}
