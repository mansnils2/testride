﻿using System.Globalization;

namespace Testdrive.Extensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string title, string culture = "sv-SE")
        {
            var textinfo = new CultureInfo(culture).TextInfo;
            return textinfo.ToTitleCase(title.ToLower());
        }
    }
}
