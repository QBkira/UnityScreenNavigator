using System.Collections;
using Demo.Scripts.Presentation.Shared.Foundation;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;

namespace Demo.Scripts.Presentation.Home
{
    public sealed class HomePage : Page<HomeView, HomeState>
    {
        public override IEnumerator Initialize()
        {
            //TODO: 移動する
            // Preload the "Shop" page prefab.
            yield return PageContainer.Of(transform).Preload(ResourceKey.Prefabs.UnitShopPage);
            // Simulate loading time.
            yield return new WaitForSeconds(1.0f);
        }

        public override IEnumerator Cleanup()
        {
            //TODO: 移動する
            PageContainer.Of(transform).ReleasePreloaded(ResourceKey.Prefabs.UnitShopPage);
            yield break;
        }
    }
}
