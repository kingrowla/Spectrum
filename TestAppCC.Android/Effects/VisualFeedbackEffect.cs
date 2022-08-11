﻿
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AColor = Android.Graphics.Color;
using AView = Android.Views.View;

[assembly: ExportEffect(typeof(TestAppCC.Droid.Effects.VisualFeedbackEffect), nameof(TestAppCC.Droid.Effects.VisualFeedbackEffect))]
namespace TestAppCC.Droid.Effects
{
    [Preserve(AllMembers = true)]
    public class VisualFeedbackEffect : PlatformEffect
    {
        AView _view;
        RippleDrawable _ripple;
        Drawable _orgDrawable;
        FrameLayout _rippleOverlay;
        FastRendererOnLayoutChangeListener _fastListener;

        bool IsClickable => !(Element is Layout || Element is BoxView);

        protected override void OnAttached()
        {
            _view = Control ?? Container;

            SetUpRipple();

            if (IsClickable)
                _view.Touch += OnViewTouch;

            UpdateEffectColor();
        }

        protected override void OnDetached()
        {
            if (!IsClickable)
            {
                _view.Touch -= OnOverlayTouch;
                _view.RemoveOnLayoutChangeListener(_fastListener);

                _fastListener.Dispose();
                _fastListener = null;
                _rippleOverlay.Dispose();
                _rippleOverlay = null;
            }
            else
            {
                _view.Touch -= OnViewTouch;
                _view.Background = _orgDrawable;
                _orgDrawable = null;
            }

            _ripple?.Dispose();
            _ripple = null;

            _view = null;
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == TestAppCC.Effects.VisualFeedbackEffect.FeedbackColorProperty.PropertyName)
            {
                UpdateEffectColor();
            }
        }

        void UpdateEffectColor()
        {
            var color = TestAppCC.Effects.VisualFeedbackEffect.GetFeedbackColor(Element);

            var nativeColor = color.ToAndroid();
            nativeColor.A = 150;

            _ripple?.SetColor(GetPressedColorSelector(nativeColor));
        }

        void SetUpRipple()
        {
            _ripple = CreateRipple(AColor.Transparent);

            if (!IsClickable)
            {
                _rippleOverlay = new FrameLayout(_view.Context)
                {
                    Clickable = true,
                    LongClickable = true,
                    Foreground = _ripple
                };
                _fastListener = new FastRendererOnLayoutChangeListener(this);
                _view.AddOnLayoutChangeListener(_fastListener);
                _view.RequestLayout();
            }
            else
            {
                _orgDrawable = _view.Background;
                _view.Background = _ripple;
            }
        }

        void SetUpOverlay()
        {
            var parent = _view.Parent as ViewGroup;

            parent.AddView(_rippleOverlay);

            _rippleOverlay.BringToFront();
            _rippleOverlay.Touch += OnOverlayTouch;
        }

        void OnViewTouch(object sender, AView.TouchEventArgs e) => e.Handled = false;

        void OnOverlayTouch(object sender, AView.TouchEventArgs e)
        {
            _view?.DispatchTouchEvent(e.Event);

            e.Handled = false;
        }

        RippleDrawable CreateRipple(AColor color)
        {
            if (!IsClickable)
            {
                var mask = new ColorDrawable(AColor.White);
                return new RippleDrawable(GetPressedColorSelector(color), null, mask);
            }

            var back = _view.Background;

            if (back == null)
            {
                var mask = new ColorDrawable(AColor.White);
                return new RippleDrawable(GetPressedColorSelector(color), null, mask);
            }
            else
                return new RippleDrawable(GetPressedColorSelector(color), back, null);
        }

        ColorStateList GetPressedColorSelector(int pressedColor) => new ColorStateList(
                new int[][]
                {
                    new int[] { }
                },
                new int[]
                {
                    pressedColor
                });

        internal class FastRendererOnLayoutChangeListener : Java.Lang.Object, AView.IOnLayoutChangeListener
        {
            private bool _hasParent = false;
            private VisualFeedbackEffect _effect;

            public FastRendererOnLayoutChangeListener(VisualFeedbackEffect effect)
            {
                _effect = effect;
            }

            public void OnLayoutChange(AView v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
            {
                _effect._rippleOverlay.Layout(v.Left, v.Top, v.Right, v.Bottom);

                if (_hasParent)
                {
                    return;
                }

                _hasParent = true;
                _effect.SetUpOverlay();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                    _effect = null;

                base.Dispose(disposing);
            }
        }
    }
}