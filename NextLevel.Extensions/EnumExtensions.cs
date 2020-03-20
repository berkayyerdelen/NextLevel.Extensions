using System;

namespace NextLevel.Extensions
{
    public static class EnumExtensions
    {
        public static TDest ConvertTo<TSource, TDest>(this Enum source)
        {
            try
            {
                return (TDest)Enum.Parse(typeof(TDest), source.ToString());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
                throw e;
            }

        }

    
    }
}
