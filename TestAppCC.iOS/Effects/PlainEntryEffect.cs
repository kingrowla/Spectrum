
using System;
using TestAppCC.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(PlainEntryEffect), nameof(PlainEntryEffect))]
namespace TestAppCC.iOS.Effects
{
    public class PlainEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                if (!(Control is UITextField field))
                    return;

                field.BorderStyle = UITextBorderStyle.None;
                field.AutocapitalizationType = UITextAutocapitalizationType.None;
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
