using ConferenceTracker.Data;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace ConferenceTracker.Converters
{
    public class SponsorLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SponsorLevel)
            {
                SponsorLevel level = (SponsorLevel)value;
                return String.Format("{0} Sponsor", Enum.GetName(typeof(SponsorLevel), level));
                
            }
            else throw new ArgumentException("Value must be sponsorLevel type.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
