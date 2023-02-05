using System;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;

namespace Demo.Scripts.Presentation.Settings
{
    public sealed class SettingsState : AppViewState, ISettingsState
    {
        private readonly Subject<Unit> _onCloseButtonClickedSubject = new Subject<Unit>();

        public SoundSettingsState SoundSettingsState { get; } = new SoundSettingsState();
        public IObservable<Unit> CloseButtonClicked => _onCloseButtonClickedSubject;

        void ISettingsState.InvokeCloseButtonClicked()
        {
            _onCloseButtonClickedSubject.OnNext(Unit.Default);
        }

        protected override void DisposeInternal()
        {
            SoundSettingsState.Dispose();
            _onCloseButtonClickedSubject.Dispose();
        }
    }

    internal interface ISettingsState
    {
        void InvokeCloseButtonClicked();
    }
}
