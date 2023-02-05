using Cysharp.Threading.Tasks;
using Demo.Scripts.Presentation.Shared.Binders;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;
using UnityEngine.UI;

namespace Demo.Scripts.Presentation.Settings
{
    public sealed class SettingsView : AppView<SettingsState>
    {
        public Button closeButton;
        public SoundSettingsView soundSettingsView;

        protected override async UniTask Initialize(SettingsState state)
        {
            var internalState = (ISettingsState)state;
            closeButton.SetOnClickDestination(internalState.InvokeCloseButtonClicked).AddTo(this);
            await soundSettingsView.InitializeAsync(state.SoundSettingsState);
        }
    }
}
