using System;
using System.Globalization;
using Xamarin.Forms;

namespace ConferenceTracker.Converters
{
    public class FavouriteIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool && (bool)value) ? "favourite.png" : "nofavourite.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
