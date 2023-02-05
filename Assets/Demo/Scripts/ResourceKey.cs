namespace Demo.Scripts
{
    public static class ResourceKey
    {
        public static class Prefabs
        {
            private const string Prefix = "prefab_";
            private const string RootFolder = "Prefabs";
            private const string TopFolder = RootFolder + "/Top";
            private const string HomeFolder = RootFolder + "/Home";
            private const string LoadingFolder = RootFolder + "/Loading";
            private const string SettingsFolder = RootFolder + "/Settings";
            private const string UnitShopFolder = RootFolder + "/UnitShop";
            private const string UnitTypeInformationFolder = RootFolder + "/UnitTypeInformation";
            private const string UnitPortraitViewerFolder = RootFolder + "/UnitPortraitViewer";

            public const string TopPage = TopFolder + "/" + Prefix + "top_page";
            public const string HomePage = HomeFolder + "/" + Prefix + "home_page";
            public const string LoadingPage = LoadingFolder + "/" + Prefix + "loading_page";
            public const string SettingsModal = SettingsFolder + "/" + Prefix + "settings_modal";

            public const string UnitShopPage =
                UnitShopFolder + "/" + Prefix + "unit_shop_page";

            public const string UnitShopItemSetSheet =
                UnitShopFolder + "/" + Prefix + "unit_shop_item_set_sheet";

            public const string UnitTypeInformationModal =
                UnitTypeInformationFolder + "/" + Prefix + "unit_type_information_modal";

            public const string UnitPortraitViewerModal =
                UnitPortraitViewerFolder + "/" + Prefix + "unit_portrait_viewer_modal";
        }

        public static class Textures
        {
            private const string Prefix = "tex_";
            private const string RootFolder = "Textures";

            public const string CoinIcon = RootFolder + "/" + Prefix + "icon_coin";

            private const string UnitPortraitFormat
                = RootFolder + "/" + Prefix + "unit_portrait_{0:D3}_{1}";

            private const string UnitThumbnailFormat
                = RootFolder + "/" + Prefix + "unit_thumb_{0:D3}_{1}";

            public static string GetUnitPortrait(int unitTypeId, int rank)
            {
                return string.Format(UnitPortraitFormat, unitTypeId, rank);
            }

            public static string GetUnitThumbnail(int unitTypeId, int rank)
            {
                return string.Format(UnitThumbnailFormat, unitTypeId, rank);
            }
        }
    }
}
