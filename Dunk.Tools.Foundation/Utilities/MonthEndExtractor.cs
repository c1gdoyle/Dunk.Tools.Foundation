using System;
using System.Collections.Generic;
using System.Linq;

namespace Dunk.Tools.Foundation.Utilities
{
    /// <summary>
    /// Contains helper methods for retrieving month end <see cref="DateTime"/> from 
    /// a given date range.
    /// </summary>
    public static class MonthEndExtractor
    {
        /// <summary>
        /// Gets the month ends that occur between a specified start-date and end-date.
        /// </summary>
        /// <param name="start">The start-date of the date range.</param>
        /// <param name="end">The end-date of the date range.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the month end dates.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="start"/> was greater than <paramref name="end"/>.</exception>
        public static IEnumerable<DateTime> GetMonthEnds(DateTime start, DateTime end)
        {
            ValidateArguments(start, end);

            int currentMonth = 0;
            DateTime currentEndOfMonth = start;

            while (currentEndOfMonth <= end)
            {
                var dt = start.AddMonths(currentMonth);
                currentEndOfMonth = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));

                if (currentEndOfMonth <= end)
                {
                    yield return currentEndOfMonth;
                }
                currentMonth++;
            }
        }

        /// <summary>
        /// Gets the month ends that occur between a specified start-date and end-date which 
        /// are weekdays (Mon - Fri).
        /// </summary>
        /// <param name="start">The start-date of the date range.</param>
        /// <param name="end">The end-date of the date range.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the month end dates.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="start"/> was greater than <paramref name="end"/>.</exception>
        public static IEnumerable<DateTime> GetWeekdayMonthEnds(DateTime start, DateTime end)
        {
            return GetMonthEnds(start, end)
                .Where(dt => dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday);
        }

        /// <summary>
        /// Gets the month ends that occur between a specified start-date and end-date which 
        /// are weekends (Sat or Sun).
        /// </summary>
        /// <param name="start">The start-date of the date range.</param>
        /// <param name="end">The end-date of the date range.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the month end dates.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="start"/> was greater than <paramref name="end"/>.</exception>
        public static IEnumerable<DateTime> GetWeekendsMonthEnds(DateTime start, DateTime end)
        {
            return GetMonthEnds(start, end)
                .Where(dt => dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday);
        }

        private static void ValidateArguments(DateTime start, DateTime end)
        {
            if (end < start)
            {
                throw new ArgumentException("Unable to extract month ends. End-Date cannot be greater than Start-Date");
            }
        }
    }
}
