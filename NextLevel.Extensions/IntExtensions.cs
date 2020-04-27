using System;
using System.Collections.Generic;
using System.Text;

namespace NextLevel.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Check the arr is in between startpoint and endpoint
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public static bool Between(this int arr, int startPoint, int endPoint)
        {
            return arr >= startPoint && arr <= endPoint;
        }
    }
}
