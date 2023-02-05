using System.Collections;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace Demo.Scripts.Modules.Presentation
{
    public abstract class ModalPresenter<TModal> : Presenter<TModal>, IModalPresenter where TModal : Modal
    {
        protected ModalPresenter(TModal view) : base(view)
        {
            View = view;
        }

        private TModal View { get; }

        IEnumerator IModalLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View);
        }

        IEnumerator IModalLifecycleEvent.WillPushEnter()
        {
            return ViewWillPushEnter(View);
        }

        void IModalLifecycleEvent.DidPushEnter()
        {
            ViewDidPushEnter(View);
        }

        IEnumerator IModalLifecycleEvent.WillPushExit()
        {
            return ViewWillPushExit(View);
        }

        void IModalLifecycleEvent.DidPushExit()
        {
            ViewDidPushExit(View);
        }

        IEnumerator IModalLifecycleEvent.WillPopEnter()
        {
            return ViewWillPopEnter(View);
        }

        void IModalLifecycleEvent.DidPopEnter()
        {
            ViewDidPopEnter(View);
        }

        IEnumerator IModalLifecycleEvent.WillPopExit()
        {
            return ViewWillPopExit(View);
        }

        void IModalLifecycleEvent.DidPopExit()
        {
            ViewDidPopExit(View);
        }

        IEnumerator IModalLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View);
        }

        protected virtual IEnumerator ViewDidLoad(TModal view)
        {
            yield break;
        }

        protected virtual IEnumerator ViewWillPushEnter(TModal view)
        {
            yield break;
        }

        protected virtual void ViewDidPushEnter(TModal view)
        {
        }

        protected virtual IEnumerator ViewWillPushExit(TModal view)
        {
            yield break;
        }

        protected virtual void ViewDidPushExit(TModal view)
        {
        }

        protected virtual IEnumerator ViewWillPopEnter(TModal view)
        {
            yield break;
        }

        protected virtual void ViewDidPopEnter(TModal view)
        {
        }

        protected virtual IEnumerator ViewWillPopExit(TModal view)
        {
            yield break;
        }

        protected virtual void ViewDidPopExit(TModal view)
        {
        }

        protected virtual IEnumerator ViewWillDestroy(TModal view)
        {
            yield break;
        }

        protected override void Initialize(TModal view)
        {
            // The lifecycle event of the view will be added with priority 0.
            // Presenters should be processed after the view so set the priority to 1.
            view.AddLifecycleEvent(this, 1);
        }

        protected override void Dispose(TModal view)
        {
            view.RemoveLifecycleEvent(this);
        }
    }

    public abstract class ModalPresenter<TModal, TDataSource> : Presenter<TModal, TDataSource>, IModalPresenter
        where TModal : Modal
    {
        protected ModalPresenter(TModal view, TDataSource dataSource) : base(view, dataSource)
        {
            View = view;
            DataSource = dataSource;
        }

        private TModal View { get; }
        private TDataSource DataSource { get; }

        IEnumerator IModalLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View, DataSource);
        }

        IEnumerator IModalLifecycleEvent.WillPushEnter()
        {
            return ViewWillPushEnter(View, DataSource);
        }

        void IModalLifecycleEvent.DidPushEnter()
        {
            ViewDidPushEnter(View, DataSource);
        }

        IEnumerator IModalLifecycleEvent.WillPushExit()
        {
            return ViewWillPushExit(View, DataSource);
        }

        void IModalLifecycleEvent.DidPushExit()
        {
            ViewDidPushExit(View, DataSource);
        }

        IEnumerator IModalLifecycleEvent.WillPopEnter()
        {
            return ViewWillPopEnter(View, DataSource);
        }

        void IModalLifecycleEvent.DidPopEnter()
        {
            ViewDidPopEnter(View, DataSource);
        }

        IEnumerator IModalLifecycleEvent.WillPopExit()
        {
            return ViewWillPopExit(View, DataSource);
        }

        void IModalLifecycleEvent.DidPopExit()
        {
            ViewDidPopExit(View, DataSource);
        }

        IEnumerator IModalLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View, DataSource);
        }

        protected virtual IEnumerator ViewDidLoad(TModal view, TDataSource dataSource)
        {
            yield break;
        }

        protected virtual IEnumerator ViewWillPushEnter(TModal view, TDataSource dataSource)
        {
            yield break;
        }

        protected virtual void ViewDidPushEnter(TModal view, TDataSource dataSource)
        {
        }

        protected virtual IEnumerator ViewWillPushExit(TModal view, TDataSource dataSource)
        {
            yield break;
        }

        protected virtual void ViewDidPushExit(TModal view, TDataSource dataSource)
        {
        }

        protected virtual IEnumerator ViewWillPopEnter(TModal view, TDataSource dataSource)
        {
            yield break;
        }

        protected virtual void ViewDidPopEnter(TModal view, TDataSource dataSource)
        {
        }

        protected virtual IEnumerator ViewWillPopExit(TModal view, TDataSource dataSource)
        {
            yield break;
        }

        protected virtual void ViewDidPopExit(TModal view, TDataSource dataSource)
        {
        }

        protected virtual IEnumerator ViewWillDestroy(TModal view, TDataSource dataSource)
        {
            yield break;
        }

        protected override void Initialize(TModal view, TDataSource dataStore)
        {
            // The lifecycle event of the view will be added with priority 0.
            // Presenters should be processed after the view so set the priority to 1.
            view.AddLifecycleEvent(this, 1);
        }

        protected override void Dispose(TModal view, TDataSource dataSource)
        {
            view.RemoveLifecycleEvent(this);
        }
    }
}