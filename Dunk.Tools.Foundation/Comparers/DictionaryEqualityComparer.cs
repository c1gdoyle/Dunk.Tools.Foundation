using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Comparers
{
    /// <summary>
    /// An implementation of <see cref="IEqualityComparer{T}"/> for comparing dictionaries.
    /// </summary>
    /// <typeparam name="TKey">The type of keys stored in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of values stored in the dictionaries.</typeparam>
    public sealed class DictionaryEqualityComparer<TKey, TValue> : IEqualityComparer<IDictionary<TKey, TValue>>
    {
        private readonly EqualityComparer<TValue> _valueComparer;

        /// <summary>
        /// Initialsies a new isntance of <see cref="DictionaryEqualityComparer{TKey, TValue}"/>.
        /// </summary>
        public DictionaryEqualityComparer()
            : this(EqualityComparer<TValue>.Default)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="DictionaryEqualityComparer{TKey, TValue}"/> with a specified 
        /// value equality comparer.
        /// </summary>
        /// <param name="valueComparer">The comparer to use to compare the values stored in the dictionaries.</param>
        /// <exception cref="ArgumentNullException"><paramref name="valueComparer"/> parameter was null.</exception>
        public DictionaryEqualityComparer(EqualityComparer<TValue> valueComparer)
        {
            if (valueComparer == null)
            {
                throw new ArgumentNullException(nameof(valueComparer));
            }
            _valueComparer = valueComparer;
        }

        #region IEqualityComparer<T[]> Members
        public bool Equals(IDictionary<TKey, TValue> x, IDictionary<TKey, TValue> y)
        {
            //are they the same dictionary
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            //is either dictionary null
            if (x == null || y == null)
            {
                return false;
            }
            //are the dictionaries a different length
            if (x.Count != y.Count)
            {
                return false;
            }

            foreach (var kvp in x)
            {
                TValue value;
                if (!y.TryGetValue(kvp.Key, out value))
                {
                    return false;
                }
                if (!_valueComparer.Equals(kvp.Value, value))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(IDictionary<TKey, TValue> obj)
        {
            unchecked
            {
                if (obj == null)
                {
                    return 0;
                }

                int hash = 23;

                foreach (var kvp in obj)
                {
                    hash = hash * 31 + kvp.Key.GetHashCode();
                    if (kvp.Value != null)
                    {
                        hash = hash * 31 + _valueComparer.GetHashCode(kvp.Value);
                    }
                }
                return hash;
            }
        }
        #endregion IEqualityComparer<T[]> Members
    }
}
