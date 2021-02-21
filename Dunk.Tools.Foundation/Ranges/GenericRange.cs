using System;

namespace Dunk.Tools.Foundation.Ranges
{
    /// <summary>
    /// A generic implementation of <see cref="IRange{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the range.</typeparam>
    public sealed class GenericRange<T> : IRange<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Initialises a new instance of <see cref="GenericRange{T}"/> with a 
        /// specified start and end for the range.
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="end">The end of the range.</param>
        /// <exception cref="ArgumentException"><paramref name="start"/> must be less than <paramref name="end"/>.</exception>
        public GenericRange(T start, T end)
        {
            if(start.CompareTo(end) > 0)
            {
                throw new ArgumentException(
                    $"Unable to initialise {typeof(GenericRange<T>).Name}, {nameof(start)} must be less than {nameof(end)}");
            }

            Start = start;
            End = end;
        }

        #region IRange<T> Members
        /// <inheritdoc />
        public T Start { get; }

        /// <inheritdoc />
        public T End { get; }

        /// <inheritdoc />
        public bool IsWithin(T value)
        {
            return Start.CompareTo(value) <= 0 &&
                End.CompareTo(value) >= 0;
        }

        /// <inheritdoc />
        public bool IsWithin(IRange<T> range)
        {
            if (range == null)
            {
                return false;
            }
            return Start.CompareTo(range.Start) <= 0 &&
                End.CompareTo(range.End) >= 0;
        }
        #endregion IRange<T> Members
    }
}
