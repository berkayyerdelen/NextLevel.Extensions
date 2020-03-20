using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NextLevel.Extensions
{
    public static class StringExtensions
    {
        public static DateTime? ToDateTime(this string date)
        {
            DateTime _date;
            var parsedDate = DateTime.TryParse(date, out _date);
            return parsedDate ? _date : new DateTime?();
        }
        public static bool IsNumeric(this string text)
        {
            long number;
            return long.TryParse(text, out number);
        }
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
       public static string CutFromLeft(this string text, int length)
        {
            if (text.Length>length)
            {
                return text.Substring(0, length);
            }
            return text;
        }

        public static string CutFromRight(this string text, int length)
        {
            if (text.Length > length)
            {
                return text.Substring(text.Length-length, length);
            }
            return text;
        }
        public static bool IsDate(this string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                DateTime date;
                return (DateTime.TryParse(text, out date));
            }
            else
            {
                return false;
            }
        }

        public static int ToIntWithDefaultValue(this string text,int defaultValue)
        {
            try
            {
                if (!String.IsNullOrEmpty(text))
                {
                    return Convert.ToInt32(text);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return defaultValue;
        }

        public static int ToInt(this string text)
        {
            Int32.TryParse(text, out int number);
            return number;
        }
        public static string Strip(this string data, string textToStrip)
        {
            var stripText = data;
            if (string.IsNullOrEmpty(data))
            {
                return data;
            }
            try
            {
                stripText = Regex.Replace(data, textToStrip, string.Empty);
            }
            catch (Exception)
            {

                
            }
            return stripText;
        }
        public static string Strip(this string data, string textToStrip, string textToReplace)
        {
            var stripText = data;

            if (string.IsNullOrEmpty(data)) return stripText;

            try
            {
                stripText = Regex.Replace(data, textToStrip, textToReplace);
            }
            catch
            {
            }
            return stripText;
        }
        public static int WordCount(this string input)
        {
            var count = 0;
            try
            {
                // Exclude whitespaces, Tabs and line breaks
                var re = new Regex(@"[^\s]+");
                var matches = re.Matches(input);
                count = matches.Count;
            }
            catch
            {
            }
            return count;
        }
    }
}
