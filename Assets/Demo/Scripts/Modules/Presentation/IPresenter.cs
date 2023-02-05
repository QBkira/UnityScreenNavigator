using System;

namespace Demo.Scripts.Modules.Presentation
{
    public interface IPresenter : IDisposable
    {
        bool IsDisposed { get; }
        bool IsInitialized { get; }
        void Initialize();
    }
}