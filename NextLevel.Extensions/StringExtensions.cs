using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NextLevel.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string arg)
            => Convert.ToInt32(arg);

        public static double ToDouble(this string arg)
            => Convert.ToDouble(arg);

        public static decimal ToDecimal(this string arg)
            => Convert.ToDecimal(arg);

        public static DateTime ToDateTime(this string arg)
            => DateTime.Parse(arg);

        public static bool IsNumeric(this string arg)
            => long.TryParse(arg, out _);


        public static bool IsValidEmailAddress(this string arg)
            => new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(arg);

        public static string CutFromLeft(this string arg, int index)
            => arg.Length > index ? arg.Substring(0, index) : arg;


        public static string CutFromRight(this string arg, int index)
            => arg.Length > index ? arg.Substring(arg.Length - index, index) : arg;

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
    }
}