using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Helpers.Strings
{
    public static class OrderHelper
    {
        public static string GetSortString(string sortOrder, bool asc, string defaultSort)
        {
            var sortString = "";

            if (string.IsNullOrEmpty(sortOrder))
                return defaultSort;
            else
                sortString += sortOrder;

            sortString += " " + ConditionHelper.SortExpr(asc);

            return sortString;
        }

        public static string GetSortString(string sortOrder, string defaultSort)
        {
            var sortString = "";

            if (string.IsNullOrEmpty(sortOrder))
                return defaultSort;
            else
                sortString += sortOrder;

            return sortString;
        }
    }
}
