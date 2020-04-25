using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NextLevel.Extensions
{
    /// <summary>
    /// Type checks
    /// </summary>
    public static class TypeExtensions
    {
        
        public static bool IsTypeBoolen(this Type type)
        {
            return type == typeof(Boolean);
        }
        public static bool IsTypeString(this Type type)
        {
            return type == typeof(String);
        }
        public static bool IsTypeDate(this Type type)
        {

            return type == typeof(DateTime);
        }
        public static bool IsTypeNumeric(this Type t)
        {
            var type = t.GetTypeWithoutNullability();
            return
                type == typeof(Int16) ||
                type == typeof(Int32) ||
                type == typeof(Int64) ||
                type == typeof(UInt16) ||
                type == typeof(UInt32) ||
                type == typeof(UInt64) ||
                type == typeof(decimal) ||
                type == typeof(float) ||
                type == typeof(double);
        }

        public static Type GetTypeWithoutNullability(this Type t)
        {
            return t.IsTypeNullable() ? new NullableConverter(t).UnderlyingType : t;
        }

        public static bool IsTypeNullable(this Type t)
        {
            return t.IsGenericType &&
                   t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static bool IsTypeStatic(this Type t)
        {
            var c = t.GetConstructors();
            return (t.IsAbstract && t.IsSealed && c.Length == 0);
        }
    }
}
