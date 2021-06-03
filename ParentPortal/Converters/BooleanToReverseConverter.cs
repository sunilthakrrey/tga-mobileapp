using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ParentPortal.Converters
{
  public class BooleanToReverseConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var i = (bool)value;
      return !i;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var i = (bool)value;
      return !i;
    }
  }
}
