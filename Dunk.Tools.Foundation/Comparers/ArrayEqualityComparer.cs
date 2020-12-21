using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Comparers
{
    /// <summary>
    /// An implementation of <see cref="IEqualityComparer{T}"/> for comparing arrays.
    /// </summary>
    /// <typeparam name="T">The type of items stored in the arrays.</typeparam>         
    public sealed class ArrayEqualityComparer<T> : IEqualityComparer<T[]>
    {
        private readonly EqualityComparer<T> _elementComparer;

        /// <summary>
        /// Initialises a new instance of <see cref="ArrayEqualityComparer{T}"/>.
        /// </summary>
        public ArrayEqualityComparer()
            : this(EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initialises a new instance of <sxee cref="ArrayEqualityComparer{T}"/> with a specified 
        /// element equality comparer.
        /// </summary>
        /// <param name="elementComparer">The comparer to use to compare the elements stored in the arrays.</param>
        /// <exception cref="ArgumentNullException"><paramref name="elementComparer"/> parameter was null.</exception>
        public ArrayEqualityComparer(EqualityComparer<T> elementComparer)
        {
            if (elementComparer == null)
            {
                throw new ArgumentNullException(nameof(elementComparer));
            }

            _elementComparer = elementComparer;
        }

        #region IEqualityComparer<T[]> Members
        public bool Equals(T[] x, T[] y)
        {
            //are they the same array
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            //is either array null
            if (x == null || y == null)
            {
                return false;
            }
            //are the arrays a different length
            if (x.Length != y.Length)
            {
                return false;
            }

            for (int i = 0; i < x.Length; i++)
            {
                if (!_elementComparer.Equals(x[i], y[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(T[] obj)
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
