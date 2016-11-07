using ConferenceTracker.Constants;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace ConferenceTracker.Converters
{
    public class SelectedToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool)value ? Colors.LigthGray : Color.White;
            }
            else throw new ArgumentException("The value for converting should be boolean.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
