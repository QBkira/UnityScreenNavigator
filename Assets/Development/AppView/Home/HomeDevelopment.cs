using Demo.Scripts.Presentation.Home;
using Development.AppView.Shared;
using UniRx;
using UnityEngine;

namespace Development.AppView.Home
{
    public sealed class HomeDevelopment : AppViewDevelopment<HomeView, HomeState>
    {
        protected override HomeState CreateState()
        {
            var state = new HomeState();
            state.SettingsButtonState.IsLocked.Value = false;
            state.SettingsButtonState.OnClicked.Subscribe(_ => Debug.Log("Settings Button Clicked")).AddTo(this);
            state.UnitShopButtonState.IsLocked.Value = false;
            state.UnitShopButtonState.OnClicked.Subscribe(_ => Debug.Log("Unit Shop Button Clicked")).AddTo(this);
            state.MainQuestButtonState.IsLocked.Value = true;
            state.MissionButtonState.IsLocked.Value = true;
            state.EventQuestButtonState.IsLocked.Value = true;
            state.OnBackButtonClicked.Subscribe(_ => Debug.Log("Back Button Clicked")).AddTo(this);
            return state;
        }
    }
}