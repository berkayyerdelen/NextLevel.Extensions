using System;

namespace NextLevel.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Convert to time stamp date time
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            if (dateTime == null)
                throw new ArgumentNullException("dateTime");

            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }
        /// <summary>
        /// Get year as string
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToYearString(this DateTime dateTime)
        {
            if (dateTime == null)
                throw new ArgumentNullException("dateTime");

            return dateTime.ToString("yyyy");
        }

        /// <summary>
        /// Get Month as string
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToMonthString(this DateTime dateTime)
        {
            if (dateTime == null)
                throw new ArgumentNullException("dateTime");

            return dateTime.ToString("MM");
        }
        /// <summary>
        /// Get Date as string
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToDayString(this DateTime dateTime)
        {
            if (dateTime == null)
                throw new ArgumentNullException("dateTime");

            return dateTime.ToString("dd");
        }
        /// <summary>
        /// Check the day is weekend day
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday);
        }
        /// <summary>
        /// Check the day is week day
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekday(this DateTime date)
        {
            return (date.DayOfWeek != DayOfWeek.Sunday || date.DayOfWeek != DayOfWeek.Saturday);
        }
        /// <summary>
        /// Get the lasy day of month
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1);
        }
        /// <summary>
        /// Date filter
        /// </summary>
        /// <param name="date"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static bool Between(this DateTime date, DateTime startDate, DateTime endDate)
        {
            return date.Ticks >= startDate.Ticks && date.Ticks <= endDate.Ticks;
        }
        /// <summary>
        /// First day of the month
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime BeginningOfTheMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

    }
}