using System;
using NextLevel.Exntensions.Tests.EnumExtensions;
using Xunit;

namespace NextLevel.Extensions.Tests.DataTimeExtensions
{
    public class DataTimeExtensionsTest
    {
        [Fact]
        public void Change_Time()
        {
            var date = DateTime.Now.AddHours(1).AddMinutes(00).AddSeconds(00).AddMilliseconds(00);
            var tempDate = date;
            tempDate.ChangeTime(1, 00, 00, 00);
            Assert.Equal(date, tempDate);
        }

        [Fact]
        public void To_Year_String()
        {
            var date = DateTime.Now;
            Assert.Equal("2020", date.ToYearString());
        }
        [Fact]
        public void To_Month_String()
        {
            var date = DateTime.Now;
            Assert.Equal("03", date.ToMonthString());
        }
        [Fact]
        public void To_Date_String()
        {
            var date = DateTime.Now;
            Assert.Equal("20", date.ToDayString());
        }

        [Fact]
        public void Check_Today_IsWeekend()
        {
            var date = DateTime.Now.AddDays(1);
            Assert.True(date.IsWeekend());
        }
        [Fact]
        public void Check_Today_IsWeekDay()
        {
            var date = DateTime.Now.DayOfWeek;
            Assert.True(date.IsWeekday());
        }
        [Fact]
        public void Get_Last_Day_Of_Month()
        {
            var date = DateTime.Now;
            Assert.Equal(Convert.ToDateTime("2020.03.31"), date.GetLastDayOfMonth());
        }

        [Fact]
        public void Between_Two_Date()
        {
            var date = DateTime.Now;
            var value = date.Between(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            Assert.True(value);
        }
        [Fact]
        public void Add_Work_Days()
        {

            var date = DateTime.Now;
            var tempdate = date;
            var workday = tempdate.AddWorkdays(1);
            Assert.Equal(date.AddDays(2),workday);
        }
        [Fact]
        public void Get_End_OfThe_Month()
        {

            var date = DateTime.Now;
            var tempdate = date;
            var endofMonth = tempdate.EndOfTheMonth();
            Assert.Equal(Convert.ToDateTime("2020.03.31"), endofMonth);
        }

    }
}