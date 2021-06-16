using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace ParentPortal.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static T FromJson<T>(this string jsonData)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonData);
        }

    }
}
