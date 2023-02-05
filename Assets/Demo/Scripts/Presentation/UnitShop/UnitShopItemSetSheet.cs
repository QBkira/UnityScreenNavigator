using Demo.Scripts.Modules.View;
using Demo.Scripts.Presentation.Shared.Foundation;
using UnityScreenNavigator.Runtime.Core.Shared;
using UnityScreenNavigator.Runtime.Core.Sheet;

namespace Demo.Scripts.Presentation.UnitShop
{
    public sealed class UnitShopItemSetSheet : Sheet<UnitShopItemSetView, UnitShopItemSetState>, ITabContent
    {
        protected override ViewInitializationTiming RootInitializationTiming =>
            ViewInitializationTiming.BeforeFirstEnter;

        public int TabIndex { get; private set; }

        void ITabContent.SetTabIndex(int index)
        {
            TabIndex = index;
        }

        private void SetupTransitionAnimations(int index)
        {
            string beforeSheetIdentifierRegex;
            if (index == 0)
                beforeSheetIdentifierRegex = string.Empty;
            else if (index == 1)
                beforeSheetIdentifierRegex = $"{nameof(UnitShopItemSetSheet)}0";
            else
                beforeSheetIdentifierRegex = $"{nameof(UnitShopItemSetSheet)}[0-{index - 1}]";

            var afterSheetIdentifierRegex = $"{nameof(UnitShopItemSetSheet)}[{index + 1}-9]";
            var toLeftExitAnim = SimpleTransitionAnimationObject.CreateInstance(beforeAlignment: SheetAlignment.Center,
                afterAlignment: SheetAlignment.Left, beforeAlpha: 1.0f, afterAlpha: 0.0f);
            var toRightExitAnim = SimpleTransitionAnimationObject.CreateInstance(beforeAlignment: SheetAlignment.Center,
                afterAlignment: SheetAlignment.Right, beforeAlpha: 1.0f, afterAlpha: 0.0f);
            var fromRightEnterAnim = SimpleTransitionAnimationObject.CreateInstance(
                beforeAlignment: SheetAlignment.Right,
                afterAlignment: SheetAlignment.Center, beforeAlpha: 0.0f, afterAlpha: 1.0f);
            var fromLeftEnterAnim = SimpleTransitionAnimationObject.CreateInstance(beforeAlignment: SheetAlignment.Left,
                afterAlignment: SheetAlignment.Center, beforeAlpha: 0.0f, afterAlpha: 1.0f);

            if (!string.IsNullOrEmpty(beforeSheetIdentifierRegex))
            {
                var enterAnimation1 = new SheetTransitionAnimationContainer.TransitionAnimation();
                enterAnimation1.PartnerSheetIdentifierRegex = beforeSheetIdentifierRegex;
                enterAnimation1.AssetType = AnimationAssetType.ScriptableObject;
                enterAnimation1.AnimationObject = fromRightEnterAnim;
                AnimationContainer.EnterAnimations.Add(enterAnimation1);
            }

            var enterAnimation2 = new SheetTransitionAnimationContainer.TransitionAnimation();
            enterAnimation2.PartnerSheetIdentifierRegex = afterSheetIdentifierRegex;
            enterAnimation2.AssetType = AnimationAssetType.ScriptableObject;
            enterAnimation2.AnimationObject = fromLeftEnterAnim;
            AnimationContainer.EnterAnimations.Add(enterAnimation2);

            if (!string.IsNullOrEmpty(beforeSheetIdentifierRegex))
            {
                var exitAnimation1 = new SheetTransitionAnimationContainer.TransitionAnimation();
                exitAnimation1.PartnerSheetIdentifierRegex = beforeSheetIdentifierRegex;
                exitAnimation1.AssetType = AnimationAssetType.ScriptableObject;
                exitAnimation1.AnimationObject = toRightExitAnim;
                AnimationContainer.ExitAnimations.Add(exitAnimation1);
            }

            var exitAnimation2 = new SheetTransitionAnimationContainer.TransitionAnimation();
            exitAnimation2.PartnerSheetIdentifierRegex = afterSheetIdentifierRegex;
            exitAnimation2.AssetType = AnimationAssetType.ScriptableObject;
            exitAnimation2.AnimationObject = toLeftExitAnim;
            AnimationContainer.ExitAnimations.Add(exitAnimation2);
        }
    }
}
