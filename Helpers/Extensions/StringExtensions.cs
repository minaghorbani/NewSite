using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string input)
    {
        return (string.IsNullOrEmpty(input));
    }
    public static string ReplaceYeKe(this string input)
    {
        return input.Replace("ي", "ی").Replace("ك", "ک");
    }
}