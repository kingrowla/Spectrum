using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(TestAppCC.Droid.Effects.PlainEntryEffect), nameof(TestAppCC.Droid.Effects.PlainEntryEffect))]
namespace TestAppCC.Droid.Effects
{
    public class PlainEntryEffect : PlatformEffect
    {
        private const int _padding = 8;
        protected override void OnAttached()
        {
            try
            {
                Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
                Control?.SetPadding(_padding, _padding, _padding, _padding);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
