using System;
using System.Globalization;
using Xamarin.Forms;

namespace PFRCenterGlobal.Converters
{
    public class StringToUpperConverter:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string s)
            {
                return s.ToUpper();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
