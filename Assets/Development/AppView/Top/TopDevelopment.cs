using Demo.Scripts.Presentation.Top;
using Development.AppView.Shared;
using UniRx;
using UnityEngine;

namespace Development.AppView.Top
{
    public sealed class TopDevelopment : AppViewDevelopment<TopView, TopState>
    {
        protected override TopState CreateState()
        {
            var state = new TopState();
            state.OnClicked.Subscribe(_ => Debug.Log("Clicked"));
            return state;
        }
    }
}
