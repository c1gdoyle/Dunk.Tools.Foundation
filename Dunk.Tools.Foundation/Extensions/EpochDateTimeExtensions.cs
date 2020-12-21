using System;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Providers static helper methods for converting a C# <see cref="DateTime"/> value 
    /// to Unix and Java timeStamps and vice versa.
    /// </summary>
    public static class EpochDateTimeExtensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts a given unix timestamp to a C# <see cref="DateTime"/>.
        /// </summary>
        /// <param name="unixTimeStamp">The unix time, which is defined as the number of seconds since midnight UTC on 1970-01-01.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance whose value is the sum of the <paramref name="unixTimeStamp"/> in seconds from 
        /// the Unix Epoch date (midnight UTC on 1970-01-01).
        /// </returns>
        public static DateTime FromUnixTimeStamp(this long unixTimeStamp)
        {
            DateTime dt = Epoch.AddSeconds(unixTimeStamp);
            return dt;
        }

        /// <summary>
        /// Converts a given unix timestamp to a C# <see cref="DateTime"/>.
        /// </summary>
        /// <param name="javaTimeStamp">The java time, which is defined as the number of milli-seconds since midnight UTC on 1970-01-01.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance whose value is the sum of the <paramref name="javaTimeStamp"/> in milli-seconds from 
        /// the Unix Epoch date (midnight UTC on 1970-01-01).
        /// </returns>
        public static DateTime FromJavaTimeStamp(this long javaTimeStamp)
        {
            DateTime dt = Epoch.AddMilliseconds(javaTimeStamp);
            return dt;
        }

        /// <summary>
        /// Converts a given C# <see cref="DateTime"/> to a Unix timestamp.
        /// </summary>
        /// <param name="dt">The C# datetime.</param>
        /// <returns>
        /// A <see cref="long"/> representing the Unix timestamp which is defined as the number of seconds since midnight 1970-01-1.
        /// </returns>
        public static long ToUnixTimeStamp(this DateTime dt)
        {
            DateTime utcDt = dt.Kind == DateTimeKind.Utc ? dt : dt.ToUniversalTime();
            return (long)(utcDt - Epoch).TotalSeconds;
        }

        /// <summary>
        /// Converts a given C# <see cref="DateTime"/> to a Java timestamp.
        /// </summary>
        /// <param name="dt">The C# datetime.</param>
        /// <returns>
        /// A <see cref="long"/> representing the Java timestamp which is defined as the number of milli-seconds since midnight 1970-01-1.
        /// </returns>
        public static long ToJavaTimeStamp(this DateTime dt)
        {
            DateTime utcDt = dt.Kind == DateTimeKind.Utc ? dt : dt.ToUniversalTime();
            return (long)(utcDt - Epoch).TotalMilliseconds;
        }
    }
}
