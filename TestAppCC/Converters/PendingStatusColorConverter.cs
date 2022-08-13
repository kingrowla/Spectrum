using System;
using System.Globalization;
using Xamarin.Forms;
namespace TestAppCC.Converters
{
    public class PendingStatusColorConverter : IValueConverter
    {
        public static string PendingColorKey = "PendingTextColor";
        public static string DefaultColorKey = "DefaultTextColor";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var department = string.Empty;
            if (value != null)
            {
                department = (string)value.ToString().ToLower();
            }
            var color = new Color(); 

            switch (department)
            {
                case "services" :
                    color = (Color)Application.Current.Resources[PendingColorKey];
                    break;
                case "marketing" :
                    color = (Color)Application.Current.Resources[PendingColorKey];
                    break;
                default:
                    color = (Color)Application.Current.Resources[DefaultColorKey];
                    break;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
