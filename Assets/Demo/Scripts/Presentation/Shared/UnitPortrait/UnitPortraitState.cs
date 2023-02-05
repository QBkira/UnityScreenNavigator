using Demo.Scripts.Presentation.Shared.Foundation;
using UniRx;

namespace Demo.Scripts.Presentation.Shared.UnitPortrait
{
    public sealed class UnitPortraitState : AppViewState, IUnitPortraitState
    {
        private readonly ReactiveProperty<string> _imageResourceKey = new ReactiveProperty<string>();

        public IReactiveProperty<string> ImageResourceKey => _imageResourceKey;

        protected override void DisposeInternal()
        {
            _imageResourceKey.Dispose();
        }
    }

    internal interface IUnitPortraitState
    {
    }
}
