using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Transition;
using UniRx;

namespace Demo.Scripts.Presentation.Top
{
    public sealed class TopPagePresenter : PagePresenter<TopPage, TopView, TopState>
    {
        public TopPagePresenter(TopPage view, ITransitionService transitionService) : base(view, transitionService)
        {
        }

        protected override TopState CreateState()
        {
            var state = new TopState();
            state.OnClicked.Subscribe(_ => TransitionService.TopPageClicked()).AddTo(this);
            return state;
        }
    }
}
