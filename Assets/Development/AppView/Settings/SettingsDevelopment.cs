using Demo.Scripts.Presentation.Settings;
using Development.AppView.Shared;
using UniRx;
using UnityEngine;

namespace Development.AppView.Settings
{
    public sealed class SettingsDevelopment : AppViewDevelopment<SettingsView, SettingsState>
    {
        protected override SettingsState CreateState()
        {
            var state = new SettingsState();
            state.SoundSettingsState.VoiceVolume.Value = 0.5f;
            state.SoundSettingsState
                .VoiceVolume
                .Subscribe(volume => Debug.Log($"Voice volume: {volume}"))
                .AddTo(this);
            state.CloseButtonClicked
                .Subscribe(_ => Debug.Log("Close button clicked"))
                .AddTo(this);
            return state;
        }
    }
}
