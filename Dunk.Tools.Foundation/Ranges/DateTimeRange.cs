using System;

namespace Dunk.Tools.Foundation.Ranges
{
    /// <summary>
    /// An implementation of <see cref="IRange{T}"/> that stores C# DateTimes.
    /// </summary>
    public sealed class DateTimeRange : IRange<DateTime>
    {
        /// <summary>
        /// Initialises a new instance of <see cref="DateTimeRange"/> with a specified 
        /// Start and End.
        /// </summary>
        /// <param name="start">The start DateTime for the range.</param>
        /// <param name="end">The end DateTime for the range.</param>
        /// <exception cref="ArgumentException"><paramref name="start"/> must be before <paramref name="end"/>.</exception>
        public DateTimeRange(DateTime start, DateTime end)
        {
            if(start > end)
            {
                throw new ArgumentException(
                    $"Unable to initialise {typeof(DateTimeRange).Name}, {nameof(start)} must be before {nameof(end)}");
            }

            Start = start;
            End = end;
        }

        #region IRange<DateTime> Members

        ///<inheritdoc/>
        public DateTime Start { get; }

        ///<inheritdoc/>
        public DateTime End { get; }

        ///<inheritdoc/>
        public bool IsWithin(DateTime value)
        {
            return Start <= value &&
                End >= value;
        }

        ///<inheritdoc/>
        public bool IsWithin(IRange<DateTime> range)
        {
            if(range == null)
            {
                return false;
            }
            return Start <= range.Start &&
                End >= range.End;
        }

        #endregion IRange<DateTime> Members
    }
}