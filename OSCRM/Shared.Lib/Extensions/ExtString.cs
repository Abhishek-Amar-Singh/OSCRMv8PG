
using System.Globalization;

namespace Shared.Lib.Extensions
{
    public static class ExtString
    {
        public static string ToLowerCase(this string input) =>
            new CultureInfo("en-US", false).TextInfo.ToLower(input);
        public static string ToTitleCase(this string input) =>
            char.ToUpper(input[0]) + input.Substring(1).ToLower();
        public static string ToUpperCase(this string input) =>
            new CultureInfo("en-US", false).TextInfo.ToUpper(input);
    }
}
