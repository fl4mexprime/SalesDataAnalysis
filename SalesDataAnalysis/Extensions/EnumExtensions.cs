using System;

namespace SalesDataAnalysis.Extensions
{
    /// <summary>
    /// Extensions for working with enums
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Parse a string to enum
        /// </summary>
        /// <param name="value">your string</param>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns>T</returns>
        public static T ToEnum<T>(this string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }
    }
}