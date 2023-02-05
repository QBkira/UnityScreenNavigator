namespace Demo.Scripts.Domain.Models.CharacterShops
{
    public sealed class CharacterShop
    {
        public CharacterShopItemGroup RegularItemGroup { get; } = new CharacterShopItemGroup();
        public CharacterShopItemGroup SpecialItemGroup { get; } = new CharacterShopItemGroup();
        public CharacterShopItemGroup SaleItemGroup { get; } = new CharacterShopItemGroup();
    }
}
