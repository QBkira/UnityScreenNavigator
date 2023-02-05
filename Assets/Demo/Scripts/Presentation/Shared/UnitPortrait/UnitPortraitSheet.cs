using Demo.Scripts.Presentation.Shared.Foundation;

namespace Demo.Scripts.Presentation.Shared.UnitPortrait
{
    public sealed class UnitPortraitSheet : Sheet<UnitPortraitView, UnitPortraitState>
    {
        protected override ViewInitializationTiming RootInitializationTiming =>
            ViewInitializationTiming.BeforeFirstEnter;
    }
}
