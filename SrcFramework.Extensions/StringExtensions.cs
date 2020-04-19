using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
// ReSharper disable CheckNamespace

namespace System
{
    public static class StringExtensions
    {
        public static List<int> ToIntList(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            string[] textList = text.Split(',');
            List<int> list = new List<int>();
            for (int i = 0; i < textList.Length; i++)
            {
                list.Add(Convert.ToInt32(textList[i]));
            }

            return list;
        }

        public static string ToUpperTurkish(this string text)
        {
            if (text == null)
            {
                return null;
            }

            return text.ToUpper(new CultureInfo("tr-tr"));
        }

        public static DateTime ToDateFromTurkishString(this string text)
        {
            return Convert.ToDateTime(text, new CultureInfo("tr-tr"));
        }

        public static string ShortenFirstWord(this string text, int length)
        {
            if (text == null)
            {
                return null;
            }

            if (text.Length < length)
            {
                return text;
            }

            string[] texts = text.Trim().Split(' ');
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < texts.Length; i++)
            {
                if (i == 0)
                {
                    if (texts[i].Length > 0)
                    {
                        builder.Append(texts[i].Substring(0, 1));
                        builder.Append(". ");
                    }
                    else
                    {
                        builder.Append(texts[i]);
                    }
                }
                else
                {
                    builder.Append(texts[i]);
                    builder.Append(" ");
                }
            }

            return builder.ToString().Trim();
        }

        public static bool In(this string text, params string[] values)
        {
            if (values == null || values.Length <= 0)
            {
                return false;
            }

            return values.ToList().Contains(text);
        }

        public static string RemoveSpecialCharacters(this string text, bool removeSpaces = true, bool addDashForSpaces = false)
        {
            var result = text;
            if (removeSpaces)
            {
                if (addDashForSpaces)
                {
                    result = result.Replace(" ", "-");
                }
                else
                {
                    result = result.Replace(" ", "");
                }
            }

            result = result.Replace("/", "");
            result = result.Replace("!", "");
            result = result.Replace("@", "");
            result = result.Replace("#", "");
            result = result.Replace("\\", "");
            result = result.Replace("<", "");
            result = result.Replace(">", "");
            result = result.Replace("$", "");
            result = result.Replace("&", "");
            result = result.Replace("(", "");
            result = result.Replace(")", "");
            result = result.Replace("+", "");
            result = result.Replace("-", "");
            result = result.Replace("'", "");
            result = result.Replace("?", "");
            result = result.Replace(".", "");
            result = result.Replace(",", "");
            result = result.Replace(";", "");
            result = result.Replace("_", "");
//TODO ascii characterine gore yap
            return result;
        }
    }
}