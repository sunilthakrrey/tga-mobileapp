using ParentPortal.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;
namespace ParentPortal.Converters
{
    public class StatustoImageConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource retSource = null;
            if (value != null)
            {
                NewsFeedType status = (NewsFeedType)value;
                switch (status)
                {
                    case NewsFeedType.Announcement:
                        //retSource =ImageSource.FromFile("None.svg");
                        break;
                    case NewsFeedType.DailyChart:
                       // retSource = ImageSource.FromFile("Draft.svg");
                        break;
                    case NewsFeedType.Event:
                        retSource = ImageSource.FromFile("events_Icon.svg");
                        break;
                    case NewsFeedType.Wellness:
                        retSource = ImageSource.FromFile("sun_icon.svg");
                        break;
                   
                }
            }


            return retSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
