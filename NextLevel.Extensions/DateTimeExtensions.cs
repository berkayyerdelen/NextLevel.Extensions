using System;

namespace NextLevel.Extensions
{
    public static class DateTimeExtensions
    {
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

        public static string ToYearString(this DateTime dateTime)
        {
            if (dateTime == null)
                throw new ArgumentNullException("dateTime");

            return dateTime.ToString("yyyy");
        }
        public static string ToMonthString(this DateTime dateTime)
        {
            if (dateTime == null)
                throw new ArgumentNullException("dateTime");

            return dateTime.ToString("MM");
        }

        public static string ToDayString(this DateTime dateTime)
        {
            if (dateTime == null)
                throw new ArgumentNullException("dateTime");

            return dateTime.ToString("dd");
        }

        public static bool IsWeekend(this DateTime value)
        {
            return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
        }
        public static bool IsWeekday(this DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Sunday: return false;
                case DayOfWeek.Saturday: return false;

                default: return true;
            }
        }
        public static DateTime GetLastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1);
        }
        public static bool Between(this DateTime date, DateTime startDate, DateTime endDate)
        {
            return date.Ticks >= startDate.Ticks && date.Ticks <= endDate.Ticks;
        }
    }
}