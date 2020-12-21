using System;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods for calculating the Start and End of day for
    /// a UTC <see cref="DateTime"/>.
    /// </summary>
    public static class StartAndEndOfDayExtensions
    {
        /// <summary>
        /// Gets the start of day for this <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance representing the start of day.
        /// The date will be the same as <paramref name="dateTime"/> and the time of day
        /// will be midnight 00:00:00.000
        /// </returns>
        public static DateTime GetStartOfDay(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// Gets the start of day for this <see cref="DateTime"/> for a specified TimeZone.
        /// </summary>
        /// <param name="utcDateTime">The UTC date.</param>
        /// <param name="timeZone">The TimeZone</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance representing the start of day.
        /// The date will be the same as <paramref name="utcDateTime"/> and the time of day
        /// will be midnight 00:00:00.000
        /// </returns>
        public static DateTime GetStartOfDay(this DateTime utcDateTime, TimeZoneInfo timeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone).GetStartOfDay();
        }

        /// <summary>
        /// Gets the end of the day of this <see cref="DateTime"/> to the second.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance representing the end of day.
        /// The date will be the same as <paramref name="dateTime"/> and the time of day
        /// will be one second before midnight on the next day, 23:59:59
        /// </returns>
        public static DateTime GetEndOfDayInSeconds(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddSeconds(-1);
        }

        /// <summary>
        /// Gets the end of the day of this <see cref="DateTime"/> to the second for a specified TimeZone.
        /// </summary>
        /// <param name="utcDateTime">The date.</param>
        /// <param name="timeZone">The TimeZone.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance representing the end of day.
        /// The date will be the same as <paramref name="utcDateTime"/> and the time of day
        /// will be one second before midnight on the next day, 23:59:59
        /// </returns>
        public static DateTime GetEndOfDayInSeconds(this DateTime utcDateTime, TimeZoneInfo timeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone).GetEndOfDayInSeconds();
        }

        /// <summary>
        /// Gets the end of the day of this <see cref="DateTime"/> to the milli-second.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance representing the end of day.
        /// The date will be the same as <paramref name="dateTime"/> and the time of day
        /// will be one milli-second before midnight on the next day, 23:59:59.99
        /// </returns>
        public static DateTime GetEndOfDayInMilliSeconds(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// Gets the end of the day of this <see cref="DateTime"/> to the milli-second for a specified TimeZone.
        /// </summary>
        /// <param name="utcDateTime">The date.</param>
        /// <param name="timeZone">The TimeZone.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance representing the end of day.
        /// The date will be the same as <paramref name="utcDateTime"/> and the time of day
        /// will be one milli-second before midnight on the next day, 23:59:59.999
        /// </returns>
        public static DateTime GetEndOfDayInMilliSeconds(this DateTime utcDateTime, TimeZoneInfo timeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone).GetEndOfDayInMilliSeconds();
        }


        /// <summary>
        /// Gets the end of the day of this <see cref="DateTime"/> to the tick.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance representing the end of day.
        /// The date will be the same as <paramref name="dateTime"/> and the time of day
        /// will be one tick before midnight on the next day, 23:59:59.9999999
        /// </returns>
        public static DateTime GetEndOfDayInTicks(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddTicks(-1);
        }

        /// <summary>
        /// Gets the end of the day of this <see cref="DateTime"/> to the tick for a specified TimeZone.
        /// </summary>
        /// <param name="utcDateTime">The date.</param>
        /// <param name="timeZone">The TimeZone.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance representing the end of day.
        /// The date will be the same as <paramref name="utcDateTime"/> and the time of day
        /// will be one milli-second before midnight on the next day, 23:59:59.9999999
        /// </returns>
        public static DateTime GetEndOfDayInTicks(this DateTime utcDateTime, TimeZoneInfo timeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone).GetEndOfDayInTicks();
        }
    }
}
