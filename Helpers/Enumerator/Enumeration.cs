using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;

namespace  Helpers
{
    public static class Enumeration 
    {
        //public static IEnumerable<System.Web.Mvc.SelectListItem> GetList<T>()
        //{
        //    foreach (var value in Enum.GetValues(typeof(T)))
        //    {
        //            yield return new SelectListItem
        //            {
        //                Text = GetDescription( (System.Enum)value),
        //                Value = Convert.ToInt32((System.Enum)value).ToString(),
        //            };   
        //    }
        //}
        public static Dictionary<int,string> GetList<T>()
        {
            var values = new Dictionary<int, string>();
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                values.Add(Convert.ToInt32((System.Enum)value), GetDescription((System.Enum)value));
                //yield return new 
                //{
                //    Kye = GetDescription((System.Enum)value),
                //    Value = Convert.ToInt32((System.Enum)value).ToString(),
                //};
            }
            return values;
        }

        public static string GetDescription(Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }
        
    }
}