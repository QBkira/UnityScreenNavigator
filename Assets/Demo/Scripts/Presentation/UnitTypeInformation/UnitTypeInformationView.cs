using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using Demo.Scripts.Modules.View;
using Demo.Scripts.Presentation.Shared.Binders;
using Demo.Scripts.Presentation.Shared.Foundation;
using Demo.Scripts.Presentation.Shared.UnitPortrait;
using Demo.Scripts.Presentation.Shared.UnitThumbnail;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Sheet;

namespace Demo.Scripts.Presentation.UnitTypeInformation
{
    public sealed class UnitTypeInformationView : AppView<UnitTypeInformationState>
    {
        public TMP_Text titleText;
        public UnitThumbnailView rank1ThumbnailView;
        public UnitThumbnailView rank2ThumbnailView;
        public UnitThumbnailView rank3ThumbnailView;
        public TabGroup unitPortraitTabGroup;
        public TMP_Text descriptionText;
        public Button closeButton;
        public Button expandButton;

        public RectTransform UnitPortraitRectTransform => (RectTransform)unitPortraitTabGroup.sheetContainer.transform;

        protected override async UniTask Initialize(UnitTypeInformationState state)
        {
            var internalState = (IUnitTypeInformationState)state;

            // Bind state to view.
            titleText.SetTextSource(state.Title).AddTo(this);
            state.TabIndex.Subscribe(x =>
            {
                switch (x)
                {
                    case 0:
                        descriptionText.text = state.Rank1Description.Value;
                        break;
                    case 1:
                        descriptionText.text = state.Rank2Description.Value;
                        break;
                    case 2:
                        descriptionText.text = state.Rank3Description.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }).AddTo(this);
            closeButton.SetOnClickDestination(internalState.InvokeCloseButtonClicked).AddTo(this);
            expandButton.SetOnClickDestination(internalState.InvokeExpandButtonClicked).AddTo(this);

            // Bind state from child views.
            unitPortraitTabGroup.OnTabLoaded
                .Subscribe(x =>
                {
                    IEnumerator WillEnter()
                    {
                        state.TabIndex.Value = x.Index;
                        yield break;
                    }

                    var unitImageSheet = (UnitPortraitSheet)x.Sheet;

                    switch (x.Index)
                    {
                        case 0:
                            unitImageSheet.Setup(state.Rank1Portrait);
                            break;
                        case 1:
                            unitImageSheet.Setup(state.Rank2Portrait);
                            break;
                        case 2:
                            unitImageSheet.Setup(state.Rank3Portrait);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    x.Sheet.AddLifecycleEvent(onWillEnter: WillEnter);
                })
                .AddTo(this);

            await UniTask.WhenAll(
                rank1ThumbnailView.InitializeAsync(state.Rank1Thumbnail),
                rank2ThumbnailView.InitializeAsync(state.Rank2Thumbnail),
                rank3ThumbnailView.InitializeAsync(state.Rank3Thumbnail),
                unitPortraitTabGroup.InitializeAsync()
            );
        }
    }
}
