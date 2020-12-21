using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Comparers
{
    /// <summary>
    /// An implementation of <see cref="IComparer{T}"/> that selects a key from each
    /// object and then compares on those keys.
    /// </summary>
    /// <typeparam name="T">The type of ojects to compare.</typeparam>
    /// <typeparam name="TKey">The type of key to compare.</typeparam>
    public class KeySelectorComparer<T, TKey> : IComparer<T>
    {
        private readonly Func<T, TKey> _keySelector;
        private readonly IComparer<TKey> _comparer;

        /// <summary>
        /// Initialises a new instance of <see cref="KeySelectorComparer{T, TKey}"/> with a specified
        /// function for selecting the key to compare on.
        /// </summary>
        /// <param name="keySelector">The function for selecting the key to compare on.</param>
        public KeySelectorComparer(Func<T, TKey> keySelector)
            : this(keySelector, null)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="KeySelectorComparer{T, TKey}"/> with a specified
        /// function for selecting the key to compare on and a specified comparer for the keys.
        /// </summary>
        /// <param name="keySelector">The function for selecting the key to compare on.</param>
        /// <param name="comparer">The comparer to use when comparing keys.</param>
        public KeySelectorComparer(Func<T, TKey> keySelector, IComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer ?? Comparer<TKey>.Default;
        }

        #region IComparer<T> Members
        /// <summary>
        /// Compares x and y by selecting keys from them and then comparing the keys.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of keys of x and y.
        /// - Less than zero means key of x is less that key of y
        /// - Zero means key of x is equal to key of y.
        /// - Greater than zero means key of x is greater than key of y.
        /// </returns>
        /// <remarks>
        /// Null values are not projected. Instead they obey the standard comparer contract
        /// - if both x and y are null they are treated as equal
        /// - if x is null and y is not null y is greater than x.
        /// - if y is not null and y is null x is greater than y.
        /// </remarks>
        public int Compare(T x, T y)
        {
            //Don't want to project from null
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }

            TKey xKey = _keySelector(x);
            TKey yKey = _keySelector(y);

            var result = _comparer.Compare(xKey, yKey);
            return result;
        }
        #endregion IComparer<T> Members
    }
}
