using System;
using UniRx;
using UnityEngine;

namespace Demo.Scripts.Presentation.Shared.Binders
{
    public static class GamObjectExtensions
    {
        public static IDisposable SetActiveSelfSource(this GameObject self, IObservable<bool> source,
            bool invert = false)
        {
            return source
                .Subscribe(x =>
                {
                    x = invert ? !x : x;
                    self.SetActive(x);
                })
                .AddTo(self);
        }
    }
}
