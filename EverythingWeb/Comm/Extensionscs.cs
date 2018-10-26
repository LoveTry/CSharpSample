using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingWeb
{
    public static class Extensionscs
    {
        public static string ToStringAndTrim(this object s)
        {
            return s?.ToString().Trim();
        }

        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static string FormatWith(this string s, params object[] args)
        {
            return string.Format(s, args);
        }

        public static bool ToBoolean(this string s)
        {
            if (s.IsEmpty())
                return false;
            return Convert.ToBoolean(s);
        }
    }
}