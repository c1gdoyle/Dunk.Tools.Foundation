using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Comparers
{
    /// <summary>
    /// An implementation of <see cref="IComparer{T}"/> based on another comparer;
    /// that simply reverses the original comparison.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    public class ReverseComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> _originalComparer;

        /// <summary>
        /// Initialises a new instance of <see cref="ReverseComparer{T}"/> with a 
        /// specified comparer.
        /// </summary>
        /// <param name="originalComparer">The original comparer to use for reverse comparisons.</param>
        public ReverseComparer(IComparer<T> originalComparer)
        {
            if (originalComparer == null)
            {
                throw new ArgumentNullException(nameof(originalComparer),
                    $"Unable to initialise ReverseComparer. {nameof(originalComparer)} parameter cannot be null");
            }
            _originalComparer = originalComparer;
        }

        /// <summary>
        /// Gets the original comparer
        /// </summary>
        public IComparer<T> OriginalComparer
        {
            get { return _originalComparer; }
        }

        #region IComparer<T> Members
        /// <summary>
        /// Compares the two objects using the original comparer but reverses the order of comparison.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of x and y reveresed.
        /// </returns>
        public int Compare(T x, T y)
        {
            return OriginalComparer.Compare(y, x);
        }
        #endregion IComparer<T> Members
    }
}
