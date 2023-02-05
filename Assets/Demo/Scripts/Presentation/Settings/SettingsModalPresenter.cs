using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Transition;
using UniRx;

namespace Demo.Scripts.Presentation.Settings
{
    public sealed class SettingsModalPresenter : ModalPresenter<SettingsModal, SettingsView, SettingsState>
    {
        public SettingsModalPresenter(SettingsModal view, ITransitionService transitionService)
            : base(view, transitionService)
        {
        }

        protected override SettingsState CreateState()
        {
            var state = new SettingsState();
            state.CloseButtonClicked
                .Subscribe(_ => TransitionService.PopCommandExecuted())
                .AddTo(this);
            return state;
        }
    }
}
