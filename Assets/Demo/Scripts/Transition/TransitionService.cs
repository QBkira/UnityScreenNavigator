using System;
using Demo.Scripts.Modules.Presentation;
using Demo.Scripts.Presentation.Home;
using Demo.Scripts.Presentation.Loading;
using Demo.Scripts.Presentation.Settings;
using Demo.Scripts.Presentation.Top;
using Demo.Scripts.Presentation.UnitPortraitViewer;
using Demo.Scripts.Presentation.UnitShop;
using Demo.Scripts.Presentation.UnitTypeInformation;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Page;

namespace Demo.Scripts.Transition
{
    public sealed class TransitionService : ITransitionService
    {
        private static PageContainer MainPageContainer => PageContainer.Find("MainPageContainer");
        private static ModalContainer MainModalContainer => ModalContainer.Find("MainModalContainer");

        public void ApplicationStarted()
        {
            MainPageContainer.Push<TopPage>(ResourceKey.Prefabs.TopPage, false,
                onLoad: page =>
                {
                    var presenter = new TopPagePresenter(page, this);

                    OnPagePresenterCreated(presenter, page);
                });
        }

        public void TopPageClicked()
        {
            MainPageContainer.Push<LoadingPage>(ResourceKey.Prefabs.LoadingPage, true,
                onLoad: page =>
                {
                    var presenter = new LoadingPagePresenter(page, this);
                    OnPagePresenterCreated(presenter, page);
                },
                stack: false);
        }

        public void HomeLoadingPageShown()
        {
            MainPageContainer.Push<HomePage>(ResourceKey.Prefabs.HomePage, true,
                onLoad: page =>
                {
                    var presenter = new HomePagePresenter(page, this);
                    OnPagePresenterCreated(presenter, page);
                });
        }

        public void HomePageUnitShopButtonClicked()
        {
            MainPageContainer.Push<UnitShopPage>(ResourceKey.Prefabs.UnitShopPage, true,
                onLoad: page =>
                {
                    var presenter = new UnitShopPagePresenter(page, this);
                    OnPagePresenterCreated(presenter, page);
                });
        }

        public void HomePageSettingsButtonClicked()
        {
            MainModalContainer.Push<SettingsModal>(ResourceKey.Prefabs.SettingsModal, true,
                modal =>
                {
                    var presenter = new SettingsModalPresenter(modal, this);
                    OnModalPresenterCreated(presenter, modal);
                });
        }

        public void UnitShopItemClicked(int unitTypeId)
        {
            MainModalContainer.Push<UnitTypeInformationModal>(ResourceKey.Prefabs.UnitTypeInformationModal, true,
                modal =>
                {
                    var presenter = new UnitTypeInformationModalPresenter(modal, this, unitTypeId);
                    OnModalPresenterCreated(presenter, modal);
                });
        }

        public void UnitTypeInformationExpandButtonClicked(int unitTypeId, int unitRank)
        {
            MainModalContainer.Push<UnitPortraitViewerModal>(ResourceKey.Prefabs.UnitPortraitViewerModal, true,
                modal =>
                {
                    var presenter = new UnitPortraitViewerModalPresenter(modal, this, unitTypeId, unitRank);
                    OnModalPresenterCreated(presenter, modal);
                });
        }

        public void PopCommandExecuted()
        {
            if (MainModalContainer.IsInTransition || MainPageContainer.IsInTransition)
                throw new InvalidOperationException("Cannot pop page or modal while in transition.");

            if (MainModalContainer.Modals.Count >= 1)
                MainModalContainer.Pop(true);
            else if (MainPageContainer.Pages.Count >= 1)
                MainPageContainer.Pop(true);
            else
                throw new InvalidOperationException("Cannot pop page or modal because there is no page or modal.");
        }

        private IPagePresenter OnPagePresenterCreated(IPagePresenter presenter, Page page, bool shouldInitialize = true)
        {
            if (shouldInitialize)
            {
                ((IPresenter)presenter).Initialize();
                presenter.DisposeWith(page);
            }

            return presenter;
        }

        private IModalPresenter OnModalPresenterCreated(IModalPresenter presenter, Modal modal,
            bool shouldInitialize = true)
        {
            if (shouldInitialize)
            {
                ((IPresenter)presenter).Initialize();
                presenter.DisposeWith(modal);
            }

            return presenter;
        }
    }
}
