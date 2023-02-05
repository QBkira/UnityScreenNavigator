using Demo.Scripts.Presentation.Shared.Foundation;

namespace Demo.Scripts.Presentation.UnitTypeInformation
{
    public sealed class UnitTypeInformationModal : Modal<UnitTypeInformationView, UnitTypeInformationState>
    {
        protected override ViewInitializationTiming RootInitializationTiming =>
            ViewInitializationTiming.BeforeFirstEnter;
    }
}
