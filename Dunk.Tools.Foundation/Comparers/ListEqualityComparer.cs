using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Comparers
{
    /// <summary>
    /// An implementation of <see cref="IEqualityComparer{T}"/> for comparing lists.
    /// </summary>
    /// <typeparam name="T">The type of items stored in the list.</typeparam>
    public sealed class ListEqualityComparer<T> : IEqualityComparer<IList<T>>
    {
        private readonly EqualityComparer<T> _elementComparer;

        /// <summary>
        /// Initialises a new instance of <see cref="ListEqualityComparer{T}"/>.
        /// </summary>
        public ListEqualityComparer()
            : this(EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="ListEqualityComparer{T}"/> with a specified 
        /// element equality comparer.
        /// </summary>
        /// <param name="elementComparer">The comparer to use to compare the elements stored in the lists.</param>
        /// <exception cref="ArgumentNullException"><paramref name="elementComparer"/> parameter was null.</exception>
        public ListEqualityComparer(EqualityComparer<T> elementComparer)
        {
            if (elementComparer == null)
            {
                throw new ArgumentNullException(nameof(elementComparer));
            }

            _elementComparer = elementComparer;
        }

        #region IEqualityComparer<T[]> Members
        public bool Equals(IList<T> x, IList<T> y)
        {
            //are they the same list            
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            //is either list null
            if (x == null || y == null)
            {
                return false;
            }
            //are the lists a different length
            if (x.Count != y.Count)
            {
                return false;
            }

            for (int i = 0; i < x.Count; i++)
            {
                if (!_elementComparer.Equals(x[i], y[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(IList<T> obj)
        {
            unchecked
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
        }
        #endregion IEqualityComparer<T[]> Members
    }

}
