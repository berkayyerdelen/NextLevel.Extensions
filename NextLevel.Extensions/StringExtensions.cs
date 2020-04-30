using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace NextLevel.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// String to int
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static int ToInt(this string arg)
            => Convert.ToInt32(arg);
        /// <summary>
        /// String to double
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static double ToDouble(this string arg)
            => Convert.ToDouble(arg);
        /// <summary>
        /// String to decimal
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string arg)
            => Convert.ToDecimal(arg);
        /// <summary>
        /// String to Time
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string arg)
            => DateTime.Parse(arg);
        /// <summary>
        /// Check value is numberic
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string arg)
            => long.TryParse(arg, out _);

        /// <summary>
        /// Check the given email address is valid
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static bool IsValidEmailAddress(this string arg)
            => new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(arg);
        /// <summary>
        /// Substring from the left of word
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string CutFromLeft(this string arg, int index)
            => arg.Length > index ? arg.Substring(0, index) : arg;

        /// <summary>
        /// Substring from the right of word
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string CutFromRight(this string arg, int index)
            => arg.Length > index ? arg.Substring(arg.Length - index, index) : arg;
        /// <summary>
        /// Check the string is date
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static bool IsDate(this string arg)
        {
            try
            {
                if (!String.IsNullOrEmpty(arg) && DateTime.TryParse(arg, out _)) return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                
            }
           
            return false;
        }

        /// <summary>
        /// String to Int with default value
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToIntOrDefault(this string arg, int defaultValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(arg))
                {
                    var result = 0;

                    Int32.TryParse(arg, out result);
                    if (result==0)
                    {
                        return defaultValue;
                    }

                    return result;
                }
            }
            catch (Exception e)
            {
               throw new Exception(e.Message);
            }

            return defaultValue;
        }
        /// <summary>
        /// Replace the string from text
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="removetext"></param>
        /// <returns></returns>
        public static string Replace(this string arg, string removetext)
        {
            if (string.IsNullOrEmpty(arg)) return arg;

            try
            {
                var replacedtext = Regex.Replace(arg, removetext, string.Empty);
                return replacedtext;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// Change the matched argument in text the change with exchange parameter.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="removetext"></param>
        /// <param name="exchangeText"></param>
        /// <returns></returns>
        public static string Replace(this string arg, string removetext, string exchangeText)
        {
            var stripText = arg;

            if (string.IsNullOrEmpty(arg)) return stripText;

            try
            {
                stripText = Regex.Replace(arg, removetext, exchangeText);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return stripText;
        }
        /// <summary>
        /// Find the count of word.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return count;
        }
        /// <summary>
        /// Set default value if te given value is null
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <param name="considerWhiteSpaceIsEmpty"></param>
        /// <returns></returns>
        public static string DefaultIfEmpty(this string str, string defaultValue, bool considerWhiteSpaceIsEmpty = false) => (considerWhiteSpaceIsEmpty ? string.IsNullOrWhiteSpace(str) : string.IsNullOrEmpty(str)) ? defaultValue : str;
        /// <summary>
        /// Remove the non-digits values in string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveNonDigits(this string value) => new string(value?.Where(c => char.IsDigit(c)).ToArray());
    }
}