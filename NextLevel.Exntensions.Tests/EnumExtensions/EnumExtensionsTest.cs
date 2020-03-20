using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NextLevel.Exntensions.Tests.EnumExtensions
{
    public class EnumExtensionsTest
    {
        [Fact]
        public void Convert_To_Enum()
        {          
            var methodType = NextLevel.Extensions.EnumExtensions.ConvertTo<HttpType, HttpTypeNew>(HttpType.GET);
            Assert.IsType<HttpTypeNew>(methodType);
        }
    }
    public enum HttpType
    {
        GET = 0,
        POST = 1
    }
    public enum HttpTypeNew
    {
        GET = 0,
        POST = 1
    }
}
