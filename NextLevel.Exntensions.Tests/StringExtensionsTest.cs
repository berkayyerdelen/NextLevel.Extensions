using System;
using Xunit;

namespace NextLevel.Extensions.Tests
{
    public class StringExtensionsTest
    {
        [Fact]
        public void To_Date_Time()
        {
            var date = "12.11.1994";
            var temp = date.ToDateTime();
            Assert.IsType<DateTime>(temp);
        }
        [Fact]
        public void Is_Numeric()
        {
            var number = "30000";
            var value = number.IsNumeric();
            Assert.True(value);
        }
        [Fact]
        public void Is_Valid_Email_Adress()
        {
            var email = "berkayyerdelen@gmail.com";
            Assert.True(email.IsValidEmailAddress());
        }
        [Fact]
        public void Cut_From_Left()
        {
            var email = "this is text";
            var temp = email.CutFromLeft(4);
            Assert.Equal("this", temp);
        }

        [Fact]
        public void Cut_From_Right()
        {
            var email = "this is text";
            var temp = email.CutFromRight(4);
            Assert.Equal("text", temp);
        }

        [Fact]
        public void ToInt_WithDefault_Value()
        {
            var text = "12";
            Assert.Equal(12, text.ToIntOrDefault(5));
        }

        [Fact]
        public void Strip()
        {
            var text = "this is test";
            var temptext = text.CutFromRight(10);
            Assert.Equal(" is test", temptext);
        }
        [Fact]
        public void StripWithText()
        {
            var text = "this is test";
            var temptext = text.CutFromLeft(10);
            Assert.Equal("that is test", temptext);
        }

        [Fact]
        public void Word_Count()
        {
            var text = "this is test";
            var temptext = text.WordCount();
            Assert.Equal(3, temptext);
        }
    }
}