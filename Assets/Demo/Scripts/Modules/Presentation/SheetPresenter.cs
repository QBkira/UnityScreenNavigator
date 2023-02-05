using System.Collections;
using UnityScreenNavigator.Runtime.Core.Sheet;

namespace Demo.Scripts.Modules.Presentation
{
    public abstract class SheetPresenter<TSheet> : Presenter<TSheet>, ISheetPresenter
        where TSheet : Sheet
    {
        protected SheetPresenter(TSheet view) : base(view)
        {
            View = view;
        }

        private TSheet View { get; }

        IEnumerator ISheetLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View);
        }

        IEnumerator ISheetLifecycleEvent.WillEnter()
        {
            return ViewWillEnter(View);
        }

        void ISheetLifecycleEvent.DidEnter()
        {
            ViewDidEnter(View);
        }

        IEnumerator ISheetLifecycleEvent.WillExit()
        {
            return ViewWillExit(View);
        }

        void ISheetLifecycleEvent.DidExit()
        {
            ViewDidExit(View);
        }

        IEnumerator ISheetLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View);
        }

        protected virtual IEnumerator ViewDidLoad(TSheet view)
        {
            yield break;
        }

        protected virtual IEnumerator ViewWillEnter(TSheet view)
        {
            yield break;
        }

        protected virtual void ViewDidEnter(TSheet view)
        {
        }

        protected virtual IEnumerator ViewWillExit(TSheet view)
        {
            yield break;
        }

        protected virtual void ViewDidExit(TSheet view)
        {
        }

        protected virtual IEnumerator ViewWillDestroy(TSheet view)
        {
            yield break;
        }

        protected override void Initialize(TSheet view)
        {
            // The lifecycle event of the view will be added with priority 0.
            // Presenters should be processed after the view so set the priority to 1.
            view.AddLifecycleEvent(this, 1);
        }

        protected override void Dispose(TSheet view)
        {
            view.RemoveLifecycleEvent(this);
        }
    }

    public abstract class SheetPresenter<TSheet, TDataSource> : Presenter<TSheet, TDataSource>, ISheetPresenter
        where TSheet : Sheet
    {
        protected SheetPresenter(TSheet view, TDataSource dataSource) : base(view, dataSource)
        {
            View = view;
            DataSource = dataSource;
        }

        private TSheet View { get; }
        private TDataSource DataSource { get; }

        IEnumerator ISheetLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View, DataSource);
        }

        IEnumerator ISheetLifecycleEvent.WillEnter()
        {
            return ViewWillEnter(View, DataSource);
        }

        void ISheetLifecycleEvent.DidEnter()
        {
            ViewDidEnter(View, DataSource);
        }

        IEnumerator ISheetLifecycleEvent.WillExit()
        {
            return ViewWillExit(View, DataSource);
        }

        void ISheetLifecycleEvent.DidExit()
        {
            ViewDidExit(View, DataSource);
        }

        IEnumerator ISheetLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View, DataSource);
        }

        protected virtual IEnumerator ViewDidLoad(TSheet view, TDataSource dataSource)
        {
            yield break;
        }

        protected virtual IEnumerator ViewWillEnter(TSheet view, TDataSource dataSource)
        {
            yield break;
        }

        protected virtual void ViewDidEnter(TSheet view, TDataSource dataSource)
        {
        }

        protected virtual IEnumerator ViewWillExit(TSheet view, TDataSource dataSource)
        {
            yield break;
        }

        protected virtual void ViewDidExit(TSheet view, TDataSource dataSource)
        {
        }

        protected virtual IEnumerator ViewWillDestroy(TSheet view, TDataSource dataSource)
        {
            yield break;
        }

        protected override void Initialize(TSheet view, TDataSource dataStore)
        {
            // The lifecycle event of the view will be added with priority 0.
            // Presenters should be processed after the view so set the priority to 1.
            view.AddLifecycleEvent(this, 1);
        }

        protected override void Dispose(TSheet view, TDataSource dataSource)
        {
            view.RemoveLifecycleEvent(this);
        }
    }
}