using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Transition;
using UniRx;

namespace Demo.Scripts.Presentation.Home
{
    public sealed class HomePagePresenter : PagePresenter<HomePage, HomeView, HomeState>
    {
        public HomePagePresenter(HomePage view, ITransitionService transitionService) : base(view, transitionService)
        {
        }

        protected override HomeState CreateState()
        {
            var state = new HomeState();
            state.UnitShopButtonState
                .OnClicked
                .Subscribe(_ => TransitionService.HomePageUnitShopButtonClicked())
                .AddTo(this);
            state.SettingsButtonState
                .OnClicked
                .Subscribe(_ => TransitionService.HomePageSettingsButtonClicked())
                .AddTo(this);
            state.OnBackButtonClicked
                .Subscribe(_ => TransitionService.PopCommandExecuted())
                .AddTo(this);
            state.MainQuestButtonState.IsLocked.Value = true;
            state.MissionButtonState.IsLocked.Value = true;
            state.EventQuestButtonState.IsLocked.Value = true;

            return state;
        }
    }
}
