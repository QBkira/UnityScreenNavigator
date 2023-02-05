namespace Demo.Scripts.Transition
{
    public interface ITransitionService
    {
        void ApplicationStarted();

        void TopPageClicked();

        void HomeLoadingPageShown();

        void HomePageUnitShopButtonClicked();

        void HomePageSettingsButtonClicked();

        void UnitShopItemClicked(int unitTypeId);

        void UnitTypeInformationExpandButtonClicked(int unitTypeId, int unitRank);

        void PopCommandExecuted();
    }
}
