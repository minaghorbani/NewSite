using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace  Helpers.Strings
{
    public static class StringHelper
    {
        public static string CommaSeperateValidate(string id_Groups, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            var lst = id_Groups.Split(',');
            foreach (var item in lst)
            {
                int value = 0;
                var valid = int.TryParse(item, out value);
                if (!valid || !(value >= minValue && value <= maxValue))
                {
                    return "";
                }
            }
            return id_Groups;
        }
        public static string CommaSeperateValidate(string id_Groups, long minValue = long.MinValue, long maxValue = long.MaxValue)
        {
            var lst = id_Groups.Split(',');
            foreach (var item in lst)
            {
                long value = 0;
                var valid = long.TryParse(item, out value);
                if (!valid || !(value >= minValue && value <= maxValue))
                {
                    return "";
                }
            }
            return id_Groups;
        }


        public static int[] CommaSeperateToArray(string id_Groups, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            var res = new List<int>();

            var lst = id_Groups.Split(',');
            foreach (var item in lst)
            {
                int value = 0;
                var valid = int.TryParse(item, out value);
                if (!valid || !(value >= minValue && value <= maxValue))
                {
                    return null;
                }
                else
                {
                    res.Add(value);
                }
            }
            return res.ToArray();
        }
        public static long[] CommaSeperateLongValueToArray(string id_Groups, long minValue = long.MinValue, long maxValue = long.MaxValue)
        {
            var res = new List<long>();

            var lst = id_Groups.Split(',');
            foreach (var item in lst)
            {
                long value = 0;
                var valid = long.TryParse(item, out value);
                if (!valid || !(value >= minValue && value <= maxValue))
                {
                    return null;
                }
                else
                {
                    res.Add(value);
                }
            }
            return res.ToArray();
        }
        public static float[] CommaSeperateFloatValueToArray(string id_Groups, float minValue = float.MinValue, float maxValue = float.MaxValue)
        {
            var res = new List<float>();

            var lst = id_Groups.Split(',');
            foreach (var item in lst)
            {
                float value = 0;
                var valid = float.TryParse(item, out value);
                if (!valid || !(value >= minValue && value <= maxValue))
                {
                    return null;
                }
                else
                {
                    res.Add(value);
                }
            }
            return res.ToArray();
        }

        public static string NumberToStrLen(int num, int len = 2)
        {
            string res = num.ToString();
            for (int i = 1; i <= len - num.ToString().Length; i++)
                res = "0" + res;
            return res;
        }
        public static string FillLeftCharachter(string value, int stringLength, string charachter)
        {
            var len = value.Length;

            for (int i = 0; i < stringLength - len; i++)
            {
                value = charachter + value;
            }
            return value;
        }
        public static string SearchConditionInExper(string Exper, char SChar)
        {
            string ss = "";
            string ssDet = "";
            int i = 0;
            while (i <= Exper.Length - 1)
            {
                if (Exper[i] == SChar)
                {
                    ssDet = "";
                    i++;
                    while (Exper[i] >= '0' & Exper[i] <= '9')
                    {
                        ssDet += Exper[i];
                        i++;
                    }
                    ss += "," + ssDet;
                }
                i++;
            }
            return ss;
        }

        public static bool IsValidTextInput(string input)
        {
            //string pattern = "^(?!.*xml)(?!.*html)(?!.*script)(?!.*iframe)[^-<>/\\.‘“()?*].*$";
            string pattern = "^(?!.*xml)(?!.*html)(?!.*script)(?!.*iframe)[^-<>/\\‘“?*].*$";

            var regex = new Regex(pattern);

            return regex.Match(input.ToLower()).Success;
        }
    }
}
