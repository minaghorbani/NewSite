using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Helpers.Phone
{
    public static class Phone
    {
        public static bool IsValidPhoneM(string phoneM)
        {
            long phoneMLong = 0;

            bool result = Int64.TryParse(phoneM, out phoneMLong);

            if (!result)
                return false;

            var str = phoneMLong.ToString();

            if (str.Length != 10 || str.Substring(0, 1) != "9")
                return false;

            return true;
        }
    }
}
