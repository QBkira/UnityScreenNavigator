using System.Collections;
using UnityScreenNavigator.Runtime.Core.Page;

namespace Demo.Scripts.Modules.Presentation
{
    public abstract class PagePresenter<TPage> : Presenter<TPage>, IPagePresenter where TPage : Page
    {
        protected PagePresenter(TPage view) : base(view)
        {
            View = view;
        }

        private TPage View { get; }

        IEnumerator IPageLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View);
        }

        IEnumerator IPageLifecycleEvent.WillPushEnter()
        {
            return ViewWillPushEnter(View);
        }

        void IPageLifecycleEvent.DidPushEnter()
        {
            ViewDidPushEnter(View);
        }

        IEnumerator IPageLifecycleEvent.WillPushExit()
        {
            return ViewWillPushExit(View);
        }

        void IPageLifecycleEvent.DidPushExit()
        {
            ViewDidPushExit(View);
        }

        IEnumerator IPageLifecycleEvent.WillPopEnter()
        {
            return ViewWillPopEnter(View);
        }

        void IPageLifecycleEvent.DidPopEnter()
        {
            ViewDidPopEnter(View);
        }

        IEnumerator IPageLifecycleEvent.WillPopExit()
        {
            return ViewWillPopExit(View);
        }

        void IPageLifecycleEvent.DidPopExit()
        {
            ViewDidPopExit(View);
        }

        IEnumerator IPageLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View);
        }

        protected virtual IEnumerator ViewDidLoad(TPage view)
        {
            yield break;
        }

        protected virtual IEnumerator ViewWillPushEnter(TPage view)
        {
            yield break;
        }

        protected virtual void ViewDidPushEnter(TPage view)
        {
        }

        protected virtual IEnumerator ViewWillPushExit(TPage view)
        {
            yield break;
        }

        protected virtual void ViewDidPushExit(TPage view)
        {
        }

        protected virtual IEnumerator ViewWillPopEnter(TPage view)
        {
            yield break;
        }

        protected virtual void ViewDidPopEnter(TPage view)
        {
        }

        protected virtual IEnumerator ViewWillPopExit(TPage view)
        {
            yield break;
        }

        protected virtual void ViewDidPopExit(TPage view)
        {
        }

        protected virtual IEnumerator ViewWillDestroy(TPage view)
        {
            yield break;
        }

        protected override void Initialize(TPage view)
        {
            // The lifecycle event of the view will be added with priority 0.
            // Presenters should be processed after the view so set the priority to 1.
            view.AddLifecycleEvent(this, 1);
        }

        protected override void Dispose(TPage view)
        {
            view.RemoveLifecycleEvent(this);
        }
    }
}
