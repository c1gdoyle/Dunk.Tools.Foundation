using System;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for rounding a <see cref="DateTime"/> instance.
    /// </summary>
    public static class DateTimeRoundingExtensions
    {
        /// <summary>
        /// Rounds the datetime to the nearest day.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A rounded (up on midpoint) datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime RoundToNearestDay(this DateTime date)
        {
            return Round(date, new TimeSpan(TimeSpan.TicksPerDay));
        }

        /// <summary>
        /// Rounds the datetime to the nearest hour.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A rounded (up on midpoint) datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime RoundToNearestHour(this DateTime date)
        {
            return Round(date, new TimeSpan(TimeSpan.TicksPerHour));
        }

        /// <summary>
        /// Rounds the datetime to the nearest minute.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A rounded (up on midpoint) datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime RoundToNearestMinute(this DateTime date)
        {
            return Round(date, new TimeSpan(TimeSpan.TicksPerMinute));
        }

        /// <summary>
        /// Rounds the datetime to the nearest second.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A rounded (up on midpoint) datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime RoundToNearestSecond(this DateTime date)
        {
            return Round(date, new TimeSpan(TimeSpan.TicksPerSecond));
        }

        /// <summary>
        /// Rounds the datetime to the nearest milli-second.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A rounded (up on midpoint) datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime RoundToNearestMilliSecond(this DateTime date)
        {
            return Round(date, new TimeSpan(TimeSpan.TicksPerMillisecond));
        }

        /// <summary>
        /// Rounds the datetime to a given <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <param name="timeSpan">The timespan precision to round to.</param>
        /// <returns>
        /// A rounded (up on midpoint) datetime instance that is the same <see cref="DateTimeKind"/> as the original.
        /// </returns>
        public static DateTime Round(this DateTime date, TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.Zero)
            {
                return date;
            }
            long num = (date.Ticks + (timeSpan.Ticks / 2) + 1) / timeSpan.Ticks;

            return new DateTime(num * timeSpan.Ticks, date.Kind);
        }
    }
}
