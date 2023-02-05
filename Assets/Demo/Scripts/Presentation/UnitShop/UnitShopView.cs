using System;
using Cysharp.Threading.Tasks;
using Demo.Scripts.Modules.View;
using Demo.Scripts.Presentation.Shared.Binders;
using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;
using UnityEngine.UI;

namespace Demo.Scripts.Presentation.UnitShop
{
    public sealed class UnitShopView : AppView<UnitShopState>
    {
        public Button backButton;
        public TabGroup itemSetTabGroup;

        protected override async UniTask Initialize(UnitShopState state)
        {
            backButton.SetOnClickDestination(state.InvokeBackButtonClicked).AddTo(this);

            itemSetTabGroup.OnTabLoaded
                .Subscribe(x =>
                {
                    var itemSetSheet = (UnitShopItemSetSheet)x.Sheet;

                    switch (x.Index)
                    {
                        case 0:
                            itemSetSheet.Setup(state.RegularItems);
                            break;
                        case 1:
                            itemSetSheet.Setup(state.SpecialItems);
                            break;
                        case 2:
                            itemSetSheet.Setup(state.SaleItems);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                })
                .AddTo(this);

            await itemSetTabGroup.InitializeAsync();
        }
    }
}
