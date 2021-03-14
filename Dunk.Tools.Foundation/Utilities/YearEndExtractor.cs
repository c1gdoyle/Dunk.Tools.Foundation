using System;
using System.Collections.Generic;
using System.Linq;

namespace Dunk.Tools.Foundation.Utilities
{
    /// <summary>
    /// Contains helper methods for retrieving year end <see cref="DateTime"/> from 
    /// a given date range.
    /// </summary>
    public static class YearEndExtractor
    {
        /// <summary>
        /// Gets the year ends that occur between a specified start-date and end-date.
        /// </summary>
        /// <param name="start">The start-date of the date range.</param>
        /// <param name="end">The end-date of the date range.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the year end dates.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="start"/> was greater than <paramref name="end"/>.</exception>
        public static IEnumerable<DateTime> GetYearEnds(DateTime start, DateTime end)
        {
            ValidateArguments(start, end);

            int currentYear = 0;
            DateTime currentEndOfYear = start;

            while (currentEndOfYear <= end)
            {
                var dt = start.AddYears(currentYear);
                currentEndOfYear = new DateTime(dt.Year, 12, 31);

                if (currentEndOfYear <= end)
                {
                    yield return currentEndOfYear;
                }
                currentYear++;
            }
        }

        /// <summary>
        /// Gets the year ends that occur between a specified start-date and end-date which 
        /// are weekdays (Mon - Fri).
        /// </summary>
        /// <param name="start">The start-date of the date range.</param>
        /// <param name="end">The end-date of the date range.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the year end dates.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="start"/> was greater than <paramref name="end"/>.</exception>
        public static IEnumerable<DateTime> GetWeekdayYearEnds(DateTime start, DateTime end)
        {
            return GetYearEnds(start, end)
                .Where(dt => dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday);
        }

        /// <summary>
        /// Gets the year ends that occur between a specified start-date and end-date which 
        /// are weekends (Sat or Sun).
        /// </summary>
        /// <param name="start">The start-date of the date range.</param>
        /// <param name="end">The end-date of the date range.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the year end dates.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="start"/> was greater than <paramref name="end"/>.</exception>
        public static IEnumerable<DateTime> GetWeekendsYearEnds(DateTime start, DateTime end)
        {
            return GetYearEnds(start, end)
                .Where(dt => dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday);
        }

        private static void ValidateArguments(DateTime start, DateTime end)
        {
            if (end < start)
            {
                throw new ArgumentException("Unable to extract year ends. End-Date cannot be greater than Start-Date");
            }
        }
    }
}
