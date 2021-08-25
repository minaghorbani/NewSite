using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace  Helpers.QueryHelper
{
    public static class QrHelper
    {
        public static string DeleteSqlChar(String cmd)
        {
            cmd = Regex.Replace(cmd, "Delete", "", RegexOptions.IgnoreCase);
            cmd = Regex.Replace(cmd, "Update", "", RegexOptions.IgnoreCase);
            cmd = Regex.Replace(cmd, "Truncate", "", RegexOptions.IgnoreCase);
            cmd = Regex.Replace(cmd, "Insert", "", RegexOptions.IgnoreCase);
            cmd = Regex.Replace(cmd, "Table", "", RegexOptions.IgnoreCase);
            cmd = Regex.Replace(cmd, "Function", "", RegexOptions.IgnoreCase);
            cmd = Regex.Replace(cmd, ";", ",", RegexOptions.IgnoreCase);
            cmd = Regex.Replace(cmd, "GO", "", RegexOptions.IgnoreCase);
            cmd = Regex.Replace(cmd, "ALTER", "", RegexOptions.IgnoreCase);
            cmd = Regex.Replace(cmd, "Create", "", RegexOptions.IgnoreCase);
            cmd = Regex.Replace(cmd, "--", "", RegexOptions.IgnoreCase);
            cmd = Regex.Replace(cmd, "Select", "", RegexOptions.IgnoreCase);

            return cmd;
        }
    }
}
