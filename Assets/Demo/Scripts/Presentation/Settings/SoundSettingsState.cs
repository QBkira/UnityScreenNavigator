using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;

namespace Demo.Scripts.Presentation.Settings
{
    public sealed class SoundSettingsState : AppViewState, ISoundSettingsState
    {
        private readonly ReactiveProperty<float> _bgmVolume = new ReactiveProperty<float>();
        private readonly ReactiveProperty<float> _seVolume = new ReactiveProperty<float>();
        private readonly ReactiveProperty<float> _voiceVolume = new ReactiveProperty<float>();

        public IReactiveProperty<float> VoiceVolume => _voiceVolume;
        public IReactiveProperty<float> BgmVolume => _bgmVolume;
        public IReactiveProperty<float> SeVolume => _seVolume;

        protected override void DisposeInternal()
        {
            _voiceVolume.Dispose();
            _bgmVolume.Dispose();
            _seVolume.Dispose();
        }
    }

    internal interface ISoundSettingsState
    {
    }
}
