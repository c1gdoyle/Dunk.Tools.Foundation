namespace Dunk.Tools.Foundation.Ranges
{
    /// <summary>
    /// An interface that defines the behaviour of a generic range of values.
    /// </summary>
    /// <typeparam name="T">The type of the range.</typeparam>
    /// <remarks>
    /// See https://martinfowler.com/eaaDev/Range.html
    /// </remarks>
    public interface IRange<T>
    {
        /// <summary>
        /// Gets the start value of the range.
        /// </summary>
        T Start { get; }

        /// <summary>
        /// Gets the end value of the range.
        /// </summary>
        T End { get; }

        /// <summary>
        /// Checks if a specified value is within this range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        /// <c>true</c> if the value is within the range; otherwise <c>false</c>.
        /// </returns>
        bool IsWithin(T value);

        /// <summary>
        /// Checks if a specified range is within this range.
        /// </summary>
        /// <param name="range">The range to check.</param>
        /// <returns>
        /// <c>true</c> if the range is within the range; otherwise <c>false</c>.
        /// </returns>
        bool IsWithin(IRange<T> range);
    }
}
