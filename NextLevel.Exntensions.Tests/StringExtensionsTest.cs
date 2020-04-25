using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace NextLevel.Extensions.Tests
{
    public class StringExtensionsTest
    {
        [Fact]
        public void ToInt()
        {
            var t = new Dictionary<int,string>();
            t.Add(10,"10");
            t.Add(11,"12");
            var k = t.ToList();
            var me = 10;

        }
    }
}
