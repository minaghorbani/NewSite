using System;
using System.Text.RegularExpressions;

namespace  Helpers.Strings
{
    public static class PersianText
    {
        public static string GetPersianNumber(string data)
        {
            for (var i = 48; i < 58; i++)
            {
                data = data.Replace(Convert.ToChar(i), Convert.ToChar(1728 + i));
            }
            return data;
        }
        public static string GetEnglishNumber(string data)
        {
            string englishNumber = "";
            foreach (char ch in data)
            {
                if ((ch >= '۰' && ch <= '۹')||(ch >= '٠' && ch <= '٩'))
                    englishNumber += char.GetNumericValue(ch);
                else
                    englishNumber += ch;
            }
            return englishNumber;
        }

        public static bool IsPersianString(string input)
        {
            //Remove Number
            var output = Regex.Replace(input, @"[\d-]", string.Empty);

            //Check Is UTF
            Regex regex = new Regex("[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc]");
            var isUTF = regex.IsMatch(output);

            return isUTF;
        }

    }
}