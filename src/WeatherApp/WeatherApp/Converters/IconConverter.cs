using System;
using System.Globalization;
using Xamarin.Forms;

namespace WeatherApp.Converters
{
    public class IconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var iconType = value.ToString();

            switch(iconType)
            {
                case "01n":
                    return "Images/moon.png";
                case "01d":
                    return "Images/sun.png";
                case "02n":
                case "02D":
                case "04d":
                    return "Images/cloud.png";
                case "10d":
                    return "Images/rain.png";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}