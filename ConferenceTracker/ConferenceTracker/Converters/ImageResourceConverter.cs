using System;
using System.Globalization;
using Xamarin.Forms;

namespace ConferenceTracker.Converters
{
    public class ImageResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrWhiteSpace((string)value))
            {
                return new UriImageSource
                {
                    Uri = new Uri((string)value),
                    CachingEnabled = true,
                    CacheValidity = TimeSpan.FromDays(4)
                };
            }
            else throw new ArgumentException("Value cannot be null or empty.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
