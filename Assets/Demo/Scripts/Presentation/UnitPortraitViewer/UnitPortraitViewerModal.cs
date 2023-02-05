using Demo.Scripts.Presentation.Shared.Foundation;

namespace Demo.Scripts.Presentation.UnitPortraitViewer
{
    public sealed class UnitPortraitViewerModal : Modal<UnitPortraitViewerView, UnitPortraitViewerState>
    {
        protected override ViewInitializationTiming RootInitializationTiming =>
            ViewInitializationTiming.BeforeFirstEnter;
    }
}
