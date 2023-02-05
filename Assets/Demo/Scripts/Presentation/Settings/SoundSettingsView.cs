using Cysharp.Threading.Tasks;
using Demo.Scripts.Presentation.Shared.Binders;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;
using UnityEngine.UI;

namespace Demo.Scripts.Presentation.Settings
{
    public sealed class SoundSettingsView : AppView<SoundSettingsState>
    {
        public Slider voiceSlider;
        public Slider bgmSlider;
        public Slider seSlider;

        protected override UniTask Initialize(SoundSettingsState state)
        {
            voiceSlider.SetOnValueChangedDestination(x => state.VoiceVolume.Value = x).AddTo(this);
            bgmSlider.SetOnValueChangedDestination(x => state.BgmVolume.Value = x).AddTo(this);
            seSlider.SetOnValueChangedDestination(x => state.SeVolume.Value = x).AddTo(this);
            return UniTask.CompletedTask;
        }
    }
}
