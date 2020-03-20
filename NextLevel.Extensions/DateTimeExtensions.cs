using System;
using System.Collections.Generic;
using System.Text;

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
        public static DateTime EndOfTheMonth(this DateTime date)
        {
            var endOfTheMonth = new DateTime(date.Year, date.Month, 1)
                .AddMonths(1)
                .AddDays(-1);

            return endOfTheMonth;
        }
        public static DateTime AddWorkdays(this DateTime d, int days)
        {
            // start from a weekday
            while (d.DayOfWeek.IsWeekday()) d = d.AddDays(1.0);
            for (int i = 0; i < days; ++i)
            {
                d = d.AddDays(1.0);
                while (d.DayOfWeek.IsWeekday()) d = d.AddDays(1.0);
            }
            return d;
        }
        public static bool Between(this DateTime dt, DateTime rangeBeg, DateTime rangeEnd)
        {
            return dt.Ticks >= rangeBeg.Ticks && dt.Ticks <= rangeEnd.Ticks;
        }

    }
}
