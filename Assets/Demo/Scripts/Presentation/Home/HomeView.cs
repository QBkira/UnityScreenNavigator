using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Demo.Scripts.Presentation.Shared.Binders;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;
using UnityEngine.UI;

namespace Demo.Scripts.Presentation.Home
{
    public sealed class HomeView : AppView<HomeState>
    {
        public HomeButtonView settingsButton;
        public HomeButtonView unitShopButton;
        public HomeButtonView mainQuestButton;
        public HomeButtonView missionButton;
        public HomeButtonView eventQuestButton;
        public Button backButton;

        protected override async UniTask Initialize(HomeState state)
        {
            var internalState = (IHomeState)state;
            var tasks = new List<UniTask>
            {
                settingsButton.InitializeAsync(state.SettingsButtonState),
                unitShopButton.InitializeAsync(state.UnitShopButtonState),
                mainQuestButton.InitializeAsync(state.MainQuestButtonState),
                missionButton.InitializeAsync(state.MissionButtonState),
                eventQuestButton.InitializeAsync(state.EventQuestButtonState)
            };
            await UniTask.WhenAll(tasks);

            backButton.SetOnClickDestination(internalState.InvokeBackButtonClicked).AddTo(this);
        }
    }
}
