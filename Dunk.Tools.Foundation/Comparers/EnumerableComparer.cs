using System;
using System.Collections.Generic;
using System.Linq;

namespace Dunk.Tools.Foundation.Comparers
{
    /// <summary>
    /// An implementation of <see cref="IEqualityComparer{T}"/> for comparing enumerables.
    /// </summary>
    /// <typeparam name="T">The type of items stored in the enumerable.</typeparam>
    public sealed class EnumerableComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        private readonly EqualityComparer<T> _elementComparer;

        /// <summary>
        /// Initialises a new instance of <see cref="EnumerableComparer{T}"/>.
        /// </summary>
        public EnumerableComparer()
            : this(EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="EnumerableComparer{T}"/> with a specified 
        /// element equality comparer.
        /// </summary>
        /// <param name="elementComparer">The comparer to use to compare the elements stored in the lists.</param>
        /// <exception cref="ArgumentNullException"><paramref name="elementComparer"/> parameter was null.</exception>
        public EnumerableComparer(EqualityComparer<T> elementComparer)
        {
            if (elementComparer == null)
            {
                throw new ArgumentNullException(nameof(elementComparer));
            }

            _elementComparer = elementComparer;
        }

        #region IEqualityComparer<T[]> Members
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            return x.SequenceEqual(y, _elementComparer);
        }

        public int GetHashCode(IEnumerable<T> obj)
        {
            if (obj == null)
            {
                return 0;
            }

            int hash = 23;
            foreach (T element in obj)
            {
                if (element != null)
                {
                    hash = hash * 31 + _elementComparer.GetHashCode(element);
                }
            }
            return hash;
        }
        #endregion IEqualityComparer<T[]> Members
    }

}
