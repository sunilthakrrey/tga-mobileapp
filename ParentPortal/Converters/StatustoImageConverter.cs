using ParentPortal.Enums;
using ParentPortal.Extensions;
using System;
using System.Globalization;
using Xamarin.Forms;
namespace ParentPortal.Converters
{
    public class StatustoImageConverter:IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource retSource = null;
            if (value != null)
            {
                //Enums.TGA_Type status = TGA_Type.None;
                //Enum.TryParse<TGA_Type>(value.ToString(), out status);// (Enums.TGA_Type)value;
                Enums.TGA_Type status = value.ToString().ParseToEnum<Enums.TGA_Type>();
                switch (status)
                {
                    case TGA_Type.Announcement:
                        retSource = ImageSource.FromFile("events_Icon.svg");
                        break;
                    case TGA_Type.DailyChart:
                       // retSource = ImageSource.FromFile("Draft.svg");
                        break;
                    case TGA_Type.Event:
                        retSource = ImageSource.FromFile("events_Icon.svg");
                        break;
                    case TGA_Type.Wellness:
                        retSource = ImageSource.FromFile("sun_icon.svg");
                        break;
                   
                }
            }


            return retSource;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
