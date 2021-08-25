using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Helpers.Strings
{
    public class ConditionHelper
    {
        public static string SortExpr(bool sort)
        {
            if (sort) return " Asc "; else return "Desc";
        }
        public static string ConditionExpr(List<string> condition,string FilterExpr="Where")
        {
            string ssCondition = "";
            if (condition.Any())
                ssCondition = " "+ FilterExpr + " " + condition.Aggregate((i, j) =>
                {
                    if (string.IsNullOrWhiteSpace(i))
                        return j;
                    else
                        return i + " and " + j;
                }
            );
            return ssCondition;
        }
    }
}
