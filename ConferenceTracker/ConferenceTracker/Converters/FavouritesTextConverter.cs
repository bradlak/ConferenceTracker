using System;
using System.Globalization;
using Xamarin.Forms;

namespace ConferenceTracker.Converters
{
    public class FavouritesTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool && (bool)value ? "Remove from favourites" : "Add to favourites";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
