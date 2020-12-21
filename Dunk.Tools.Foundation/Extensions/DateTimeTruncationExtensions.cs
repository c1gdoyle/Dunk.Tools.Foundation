using System;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for truncating a <see cref="DateTime"/> instance.
    /// </summary>
    public static class DateTimeTruncationExtensions
    {
        /// <summary>
        /// Truncates the datetime to the day.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A truncated datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime TruncateToDay(this DateTime date)
        {
            return Truncate(date, new TimeSpan(TimeSpan.TicksPerDay));
        }

        /// <summary>
        /// Truncates the datetime to the hour.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A truncated datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime TruncateToHour(this DateTime date)
        {
            return Truncate(date, new TimeSpan(TimeSpan.TicksPerHour));
        }

        /// <summary>
        /// Truncates the datetime to the minute.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A truncated datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime TruncateToMinute(this DateTime date)
        {
            return Truncate(date, new TimeSpan(TimeSpan.TicksPerMinute));
        }

        /// <summary>
        /// Truncates the datetime to the second.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A truncated datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime TruncateToSecond(this DateTime date)
        {
            return Truncate(date, new TimeSpan(TimeSpan.TicksPerSecond));
        }

        /// <summary>
        /// Truncates the datetime to the milli-second.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A truncated datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime TruncateToMilliSecond(this DateTime date)
        {
            return Truncate(date, new TimeSpan(TimeSpan.TicksPerMillisecond));
        }

        /// <summary>
        /// Truncates the datetime by a given <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <param name="timeSpan">The timespan precision to truncate off the original datetime.</param>
        /// <returns>
        /// A truncated datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime Truncate(this DateTime date, TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.Zero)
            {
                return date;
            }
            long ticks = date.Ticks - (date.Ticks % timeSpan.Ticks);
            return new DateTime(ticks, date.Kind);
        }
    }
}
