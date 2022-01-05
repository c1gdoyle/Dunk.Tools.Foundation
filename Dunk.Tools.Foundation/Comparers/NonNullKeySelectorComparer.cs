using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Comparers
{
    /// <summary>
    /// An implementation of <see cref="IComparer{T}"/> that selects a key from each
    /// object and then compares on those keys.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    /// <typeparam name="TKey">The type of key to compare.</typeparam>
    /// <remarks>
    /// This differs from the standard <see cref="KeySelectorComparer{T, TKey}"/> in that there
    /// are no null checks for the two items being compared.
    /// </remarks>
    public sealed class NonNullKeySelectorComparer<T, TKey> : IComparer<T>
    {
        private readonly Func<T, TKey> _keySelector;
        private readonly IComparer<TKey> _comparer;

        /// <summary>
        /// Initialises a new instance of <see cref="NonNullKeySelectorComparer{T, TKey}"/> with a specified
        /// function for selecting the key to compare on.
        /// </summary>
        /// <param name="keySelector">The function for selecting the key to compare on.</param>
        public NonNullKeySelectorComparer(Func<T, TKey> keySelector)
            :this(keySelector, null)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="NonNullKeySelectorComparer{T, TKey}"/> with a specified
        /// function for selecting the key to compare on and a specified comparer for the keys.
        /// </summary>
        /// <param name="keySelector">The function for selecting the key to compare on.</param>
        /// <param name="comparer">The comparer to use when comparing keys.</param>
        public NonNullKeySelectorComparer(Func<T, TKey> keySelector, IComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer ?? Comparer<TKey>.Default;
        }

        #region IComparer<T> Members
        /// <inheritdoc />
        public int Compare(T x, T y)
        {
            if(x == null)
            {
                throw new ArgumentNullException(
                    nameof(x), $"Unable to compare. {typeof(NonNullKeySelectorComparer<T, TKey>).Name} cannot compare if {nameof(x)} is null.");
            }
            if(y == null)
            {
                throw new ArgumentNullException(
                    nameof(y), $"Unable to compare. {typeof(NonNullKeySelectorComparer<T, TKey>).Name} cannot compare if {nameof(y)} is null.");
            }
            TKey xKey = _keySelector(x);
            TKey yKey = _keySelector(y);

            var result = _comparer.Compare(xKey, yKey);

            return result;
        }
        #endregion IComparer<T> Members
    }
}
