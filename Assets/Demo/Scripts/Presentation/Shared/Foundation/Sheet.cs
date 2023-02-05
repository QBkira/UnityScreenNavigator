using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;
using UnityScreenNavigator.Runtime.Core.Sheet;

namespace Demo.Scripts.Presentation.Shared.Foundation
{
    public abstract class Sheet<TRootView, TViewState> : Sheet
        where TRootView : AppView<TViewState>
        where TViewState : AppViewState
    {
        public TRootView root;
        private bool _isInitialized;
        private TViewState _state;

        protected virtual ViewInitializationTiming RootInitializationTiming =>
            ViewInitializationTiming.BeforeFirstEnter;

        public void Setup(TViewState state)
        {
            _state = state;
        }

        public override IEnumerator Initialize()
        {
            Assert.IsNotNull(root);

            yield return base.Initialize();
            if (RootInitializationTiming == ViewInitializationTiming.Initialize && !_isInitialized)
            {
                yield return root.InitializeAsync(_state).ToCoroutine();
                _isInitialized = true;
            }
        }

        public override IEnumerator WillEnter()
        {
            Assert.IsNotNull(root);

            if (RootInitializationTiming == ViewInitializationTiming.BeforeFirstEnter && !_isInitialized)
            {
                yield return root.InitializeAsync(_state).ToCoroutine();
                _isInitialized = true;
            }
        }
    }
}
