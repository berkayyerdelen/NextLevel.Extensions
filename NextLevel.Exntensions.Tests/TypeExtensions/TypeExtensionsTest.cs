using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NextLevel.Extensions.Tests.TypeExtensions
{
    public class TypeExtensionsTest
    {
      
        [Fact]
        public void Check_Type_IsDate()
        {
            
            Type type = typeof(DateTime);
            var value = type.IsDate();
            Assert.True(value);
        }
        [Fact]
        public void Check_Type_IsString()
        {
            Type type = typeof(string);
            var value = type.IsString();
            Assert.True(value);
        }
        [Fact]
        public void Check_Type_IsBoolen()
        {
            Type type = typeof(Boolean);
            var value = type.IsBoolen();
            Assert.True(value);
        }
        [Fact]
        public void Check_Type_IsNumeric()
        {
            Type type = typeof(int);
            var value = type.IsNumeric();
            Assert.True(value);
        }

       

    }
}
