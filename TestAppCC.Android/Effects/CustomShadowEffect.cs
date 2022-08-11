
using System;
using System.ComponentModel;
using AndroidX.CardView.Widget;
using TestAppCC.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(TestAppCC.Droid.Effects.CustomShadowEffect), nameof(TestAppCC.Droid.Effects.CustomShadowEffect))]
namespace TestAppCC.Droid.Effects
{
    public class CustomShadowEffect : PlatformEffect
    {
        CardView? _control;

        // not using these properties for this implementation
        Android.Graphics.Color _color;
        float _radius, _distanceX, _distanceY;

        private Android.Views.View GetView()
        {
            if (Control != null)
            {
                return Control;
            }
            else if (Container != null)
            {
                return Container;
            }

            return null;
        }

        protected override void OnAttached()
        {
            try
            {
                _control = Control as CardView;
                UpdateRadius();
                UpdateColor();
                UpdateOffset();
                UpdateControl();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot set property on attached control. Error: {ex.Message}");
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == ShadowEffect.RadiusProperty.PropertyName)
            {
                UpdateRadius();
                UpdateControl();
            }
            else if (args.PropertyName == ShadowEffect.ColorProperty.PropertyName)
            {
                UpdateColor();
                UpdateControl();
            }
            else if (args.PropertyName == ShadowEffect.DistanceXProperty.PropertyName ||
                     args.PropertyName == ShadowEffect.DistanceYProperty.PropertyName)
            {
                UpdateOffset();
                UpdateControl();
            }
        }

        void UpdateControl()
        {
            if (GetView() != null)
            {
                _control.Elevation = 8;
            }
        }

        void UpdateRadius()
        {
            _radius = (float)ShadowEffect.GetRadius(Element);
        }

        void UpdateColor()
        {
            _color = ShadowEffect.GetColor(Element).ToAndroid();
        }

        void UpdateOffset()
        {
            _distanceX = (float)ShadowEffect.GetDistanceX(Element);
            _distanceY = (float)ShadowEffect.GetDistanceY(Element);
        }
    }
}

