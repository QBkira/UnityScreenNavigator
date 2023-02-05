using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Scripts.Presentation.Shared.Binders
{
    public static class ImageExtensions
    {
        public static IDisposable SetSpriteSource(this Image self, IObservable<string> spriteResourceKey)
        {
            return spriteResourceKey
                .Subscribe(x =>
                {
                    if (string.IsNullOrEmpty(x))
                        self.sprite = null;

                    self.sprite = Resources.Load<Sprite>(x);
                })
                .AddTo(self);
        }
    }
}