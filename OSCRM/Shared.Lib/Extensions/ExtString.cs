
using System.Globalization;
using System.Text;

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

        public static string ReverseString(this string input)
        {
            if (input is null || input.Trim() == string.Empty) return string.Empty;

            char[] chars = input.ToCharArray();
            StringBuilder reverse_input = new StringBuilder();
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                reverse_input.Append(chars[i]);
            }

            return reverse_input.ToString();
        }
    }
}
