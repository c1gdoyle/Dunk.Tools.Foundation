using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Comparers
{
    /// <summary>
    /// An implemenation of <see cref="IComparer{T}"/> that chains two existing comparers
    /// and applies the comparison in sequence (i.e. compare/sort by a then by b)
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    public class ChainedComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> _primaryComparer;
        private readonly IComparer<T> _secondaryComparer;

        /// <summary>
        /// Initialises a new instance of <see cref="ChainedComparer{T}"/> with a specified 
        /// primary and secondary comparer.
        /// </summary>
        /// <param name="primaryComparer">The primary comparer to use.</param>
        /// <param name="secondaryComparer">The secondary comparer to use.</param>
        /// <exception cref="ArgumentNullException"><paramref name="primaryComparer"/> or <paramref name="secondaryComparer"/> was null.</exception>
        public ChainedComparer(IComparer<T> primaryComparer, IComparer<T> secondaryComparer)
        {
            if (primaryComparer == null)
            {
                throw new ArgumentNullException(nameof(primaryComparer), $"{nameof(primaryComparer)} parameter cannot be null");
            }
            if (secondaryComparer == null)
            {
                throw new ArgumentNullException(nameof(secondaryComparer), $"{nameof(secondaryComparer)} parameter cannot be null");
            }

            _primaryComparer = primaryComparer;
            _secondaryComparer = secondaryComparer;
        }

        #region IComparer<T> Members
        /// <summary>
        /// Compares x and y by comparing using the primary comparison first and then comparing
        /// on the secondary comparison if x and y have the same primary comparison.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of keys of x and y.
        /// - Less than zero means key of x is less that key of y
        /// - Zero means key of x is equal to key of y.
        /// - Greater than zero means key of x is greater than key of y.
        /// </returns>
        public int Compare(T x, T y)
        {
            int primaryResult = _primaryComparer.Compare(x, y);
            return primaryResult == 0 ? _secondaryComparer.Compare(x, y) : primaryResult;
        }
        #endregion IComparer<T> Members
    }
}
