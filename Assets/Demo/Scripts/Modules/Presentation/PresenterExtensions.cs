using System.Collections;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Sheet;

namespace Demo.Scripts.Modules.Presentation
{
    public static class PresenterExtensions
    {
        public static void DisposeWith(this IPagePresenter self, Page page)
        {
            IEnumerator DisposeRoutine()
            {
                self.Dispose();
                yield break;
            }

            page.AddLifecycleEvent(onCleanup: DisposeRoutine, priority: int.MaxValue);
        }

        public static void DisposeWith(this IModalPresenter self, Modal modal)
        {
            IEnumerator DisposeRoutine()
            {
                self.Dispose();
                yield break;
            }

            modal.AddLifecycleEvent(onCleanup: DisposeRoutine, priority: int.MaxValue);
        }

        public static void DisposeWith(this ISheetPresenter self, Sheet sheet)
        {
            IEnumerator DisposeRoutine()
            {
                self.Dispose();
                yield break;
            }

            sheet.AddLifecycleEvent(onCleanup: DisposeRoutine, priority: int.MaxValue);
        }
    }
}
