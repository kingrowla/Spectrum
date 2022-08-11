using System;
using System.ComponentModel;
using CoreGraphics;
using TestAppCC.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(TestAppCC.iOS.Effects.CustomShadowEffect), nameof(TestAppCC.iOS.Effects.CustomShadowEffect))]
namespace TestAppCC.iOS.Effects
{
    public class CustomShadowEffect : PlatformEffect
    {
        private UIView GetView()
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
                UpdateRadius();
                UpdateColor();
                UpdateOffset();
                GetView().Layer.ShadowOpacity = 1.0f;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
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
            }
            else if (args.PropertyName == ShadowEffect.ColorProperty.PropertyName)
            {
                UpdateColor();
            }
            else if (args.PropertyName == ShadowEffect.DistanceXProperty.PropertyName ||
                     args.PropertyName == ShadowEffect.DistanceYProperty.PropertyName)
            {
                UpdateOffset();
            }
        }

        void UpdateRadius()
        {

            GetView().Layer.ShadowRadius = (nfloat)ShadowEffect.GetRadius(Element);

        }

        void UpdateColor()
        {
            var color = ShadowEffect.GetColor(Element).ToCGColor();
            GetView().Layer.ShadowColor = color;
        }

        void UpdateOffset()
        {
            GetView().Layer.ShadowOffset = new CGSize(ShadowEffect.GetDistanceX(Element), ShadowEffect.GetDistanceY(Element));
        }
    }
}
