using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ParentPortal.Extensions
{
    public static class EnumExtensions
    {
        public static int ToInt(this Enum enum1)
        {
            return Convert.ToInt32(enum1);
        }

        public static string GetValueAsString(this Enum value)
        {
            return value.ToString();
        }


        public static T ParseToEnum<T>(this object val)
        {
            return (T)Enum.Parse(typeof(T), val.ToString(), true);
        }

        public static string GetDescriptionFromEnum(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
              (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes == null && attributes.Length == 0 ? value.ToString() : attributes[0].Description;
        }
        
    }
}
