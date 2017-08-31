using System;
using System.Globalization;
using Xamarin.Forms;

namespace WeatherApp.Converters
{
    public class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var condition = value.ToString();

            if (condition.Contains("cloud"))
                return "Images/clouds-background.jpg";
            else if (condition.Contains("rain"))
                return "Images/rain-background.jpg";
            else if (condition.Contains("sun") || (condition.Contains("clear sky")))
                return "Images/sun-background.jpg";
            else
                return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}