using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Extensions;

namespace Dunk.Tools.Foundation.Utilities
{
    /// <summary>
    /// Contains helper methods for splitting a range of <see cref="DateTime"/>s into batches. 
    /// </summary>
    public static class DateRangeSplitter
    {
        /// <summary>
        /// Splits a date range into batches using a specified batch-size.
        /// </summary>
        /// <param name="start">The start-date of the date range.</param>
        /// <param name="end">The end-date of the date range.</param>
        /// <param name="batchSize">The batch-size, representing the number of days for the start-date and end-date of each batch.</param>
        /// <returns>
        /// A <see cref="IEnumerable{T}"/> containing the date batches.
        /// Each item in the enumerable is a <see cref="Tuple{T1, T2}"/> in which <see cref="Tuple{T1, T2}.Item1"/> is the start-date of 
        /// the individual batch and <see cref="Tuple{T1, T2}.Item2"/> is the end-date of the individual batch.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="start"/> was greater than <paramref name="end"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="batchSize"/> was less than or equal to zero.</exception>
        public static IEnumerable<Tuple<DateTime, DateTime>> SplitDateRange(DateTime start, DateTime end, int batchSize)
        {
            ValidateArguments(start, end, batchSize);
            DateTime batchStart = start;

            DateTime batchEnd;
            while ((batchEnd = batchStart.AddDays(batchSize)) < end)
            {
                yield return Tuple.Create(batchStart, batchEnd);
                batchStart = batchEnd.AddDays(1);
            }
            yield return Tuple.Create(batchStart, end);
        }

        /// <summary>
        /// Splits a date range into batches (excludng any weekends that occur within the range) using a specified batch-size.
        /// </summary>
        /// <param name="start">The start-date of the date range.</param>
        /// <param name="end">The end-date of the date range.</param>
        /// <param name="batchSize">The batch-size, representing the number of days for the start-date and end-date of each batch.</param>
        /// <returns>
        /// A <see cref="IEnumerable{T}"/> containing the date batches.
        /// Each item in the enumerable is a <see cref="Tuple{T1, T2}"/> in which <see cref="Tuple{T1, T2}.Item1"/> is the start-date of 
        /// the individual batch and <see cref="Tuple{T1, T2}.Item2"/> is the end-date of the individual batch.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="start"/> was greater than <paramref name="end"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="batchSize"/> was less than <c>1</c> or greater than <c>5</c> days.</exception>
        public static IEnumerable<Tuple<DateTime, DateTime>> SplitDateRangeWeekDays(DateTime start, DateTime end, int batchSize)
        {
            ValidateWeekDaysArguments(start, end, batchSize);

            DateTime batchStart = DetermineBatchStart(start);
            DateTime dateRangeEnd = DetermineBatchEnd(end);

            DateTime batchEnd;
            while ((batchEnd = batchStart.AddDays(batchSize - 1)) < dateRangeEnd)
            {
                //adjust if the batch-size pushed result to Saturday or Sunday
                if (batchEnd.DayOfWeek == DayOfWeek.Saturday)
                {
                    batchEnd = batchEnd.AddDays(-1);
                }
                else if (batchEnd.DayOfWeek == DayOfWeek.Sunday)
                {
                    batchEnd = batchEnd.AddDays(-2);
                }

                //adjust if batch-size pushed result into next week
                if (batchStart.DayOfWeek > batchEnd.DayOfWeek)
                {
                    batchEnd = batchEnd.AddDays(-((int)batchEnd.DayOfWeek + 2));
                }
                yield return Tuple.Create(batchStart, batchEnd);
                batchStart = batchEnd.AddBusinessDays(1);
            }

            if (batchStart <= dateRangeEnd)
            {
                yield return Tuple.Create(batchStart, dateRangeEnd);
            }
        }

        private static void ValidateArguments(DateTime start, DateTime end, int batchSize)
        {
            if (end < start)
            {
                throw new ArgumentException("Unable to split date range. End-Date cannot be greater than Start-Date");
            }
            if (batchSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(batchSize),
                    $"Unable to split date range. {nameof(batchSize)} parameter must be greater than 0 days but was {batchSize}");
            }
        }

        private static void ValidateWeekDaysArguments(DateTime start, DateTime end, int batchSize)
        {
            if (end < start)
            {
                throw new ArgumentException("Unable to split date range. End-Date cannot be greater than Start-Date");
            }
            if (batchSize < 1 || batchSize > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(batchSize),
                    $"Unable to split date range. {nameof(batchSize)} parameter must between 1 and 5 days but was {batchSize}");
            }
        }

        private static DateTime DetermineBatchStart(DateTime start)
        {
            return start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday
                ? start.AddBusinessDays(1)
                : start;
        }

        private static DateTime DetermineBatchEnd(DateTime end)
        {
            return end.DayOfWeek == DayOfWeek.Saturday || end.DayOfWeek == DayOfWeek.Sunday
                ? end.SubtractBusinessDays(1)
                : end;
        }
    }
}
