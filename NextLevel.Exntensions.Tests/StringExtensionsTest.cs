using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NextLevel.Extensions.Tests
{
    public class StringExtensionsTest
    {
        [Fact]
        public void ToInt()
        {
            var date = "142";
            var k = date.ToIntOrDefault(10);
        }
    }
}
