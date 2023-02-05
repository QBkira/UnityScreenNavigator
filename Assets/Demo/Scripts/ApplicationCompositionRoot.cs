using Demo.Scripts.Domain.Models.CharacterShops;
using Demo.Scripts.Transition;
using UnityEngine;

namespace Demo.Scripts
{
    public sealed class ApplicationCompositionRoot : MonoBehaviour
    {
        private CharacterShopDataStore _characterShopDataStore;

        private void Start()
        {
            Application.targetFrameRate = 60;

            // Setup dummy data.
            _characterShopDataStore = new CharacterShopDataStore();
            _characterShopDataStore.CharacterShop.RegularItemGroup.Items.Add(new CharacterShopItem { Id = 3 });
            _characterShopDataStore.CharacterShop.SpecialItemGroup.Items.Add(new CharacterShopItem { Id = 4 });
            _characterShopDataStore.CharacterShop.SaleItemGroup.Items.Add(new CharacterShopItem { Id = 5 });

            var transitionService = new TransitionService();

            transitionService.ApplicationStarted();
        }
    }
}
