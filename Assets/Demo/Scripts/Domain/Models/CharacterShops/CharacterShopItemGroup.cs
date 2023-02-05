using System.Collections.Generic;

namespace Demo.Scripts.Domain.Models.CharacterShops
{
    public sealed class CharacterShopItemGroup
    {
        private readonly List<CharacterShopItem> _items = new List<CharacterShopItem>();

        public IList<CharacterShopItem> Items => _items;
    }
}
