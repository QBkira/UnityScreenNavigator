using System;
using System.Collections;
using System.Collections.Generic;
using Demo.Scripts.Modules.Presentation;
using Demo.Scripts.Transition;
using UniRx;

namespace Demo.Scripts.Presentation.Shared.Foundation
{
    public abstract class PagePresenter<TPage, TRootView, TRootViewState> : PagePresenter<TPage>,
        IDisposableCollectionHolder
        where TPage : Page<TRootView, TRootViewState>
        where TRootView : AppView<TRootViewState>
        where TRootViewState : AppViewState
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        protected PagePresenter(TPage view, ITransitionService transitionService) : base(view)
        {
            TransitionService = transitionService;
        }

        protected ITransitionService TransitionService { get; }

        ICollection<IDisposable> IDisposableCollectionHolder.GetDisposableCollection()
        {
            return _disposables;
        }

        protected abstract TRootViewState CreateState();

        protected override IEnumerator ViewDidLoad(TPage view)
        {
            yield return base.ViewDidLoad(view);

            var state = CreateState();
            state.AddTo(_disposables);
            view.Setup(state);
        }

        protected override IEnumerator ViewWillDestroy(TPage view)
        {
            yield return base.ViewWillDestroy(view);
        }

        protected sealed override void Initialize(TPage view)
        {
            base.Initialize(view);
        }

        protected sealed override void Dispose(TPage view)
        {
            base.Dispose(view);
            _disposables.Dispose();
        }
    }
}
