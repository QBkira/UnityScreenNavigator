using Cysharp.Threading.Tasks;
using Demo.Scripts.Presentation.Shared.Binders;
using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Presentation.Shared.UnitThumbnail;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Scripts.Presentation.UnitShop
{
    public sealed class UnitShopItemView : AppView<UnitShopItemState>
    {
        public TMP_Text costText;
        public Image costIconImage;
        public UnitThumbnailView thumbnail;
        public GameObject lockedRoot;
        public GameObject unlockedRoot;

        protected override async UniTask Initialize(UnitShopItemState state)
        {
            lockedRoot.SetActiveSelfSource(state.IsLocked).AddTo(this);
            unlockedRoot.SetActiveSelfSource(state.IsLocked, true).AddTo(this);
            if (!state.IsLocked.Value)
            {
                costText.SetTextSource(state.Cost).AddTo(this);
                costIconImage.SetSpriteSource(state.CostIconImageResourceKey).AddTo(this);
                await thumbnail.InitializeAsync(state.Thumbnail);
            }
        }
    }
}
