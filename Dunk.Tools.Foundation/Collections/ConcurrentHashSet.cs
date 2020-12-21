using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// Represents a thread-safe hash-based unique collection that can be accessed by 
    /// multiple threads concurrently.
    /// </summary>
    /// <typeparam name="T">The type of items in this set.</typeparam>
    [DebuggerDisplay("Count={Count}")]
    public sealed class ConcurrentHashSet<T> : ICollection<T>, IReadOnlyCollection<T>
    {
        private readonly ConcurrentDictionary<T, byte> _inner;

        /// <summary>
        /// Initialises a new instance of <see cref="ConcurrentHashSet{T}"/> that is empy and uses 
        /// the default equality comparer for the set type.
        /// </summary>
        public ConcurrentHashSet()
            : this(EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="ConcurrentHashSet{T}"/> that uses the default equality 
        /// comparer and contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> was null.</exception>
        public ConcurrentHashSet(IEnumerable<T> collection)
            : this(collection, EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="ConcurrentHashSet{T}"/> that is empty and uses 
        /// the specified equality compare for the set type.
        /// </summary>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> that is used to determine equality </param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> was null.</exception>
        public ConcurrentHashSet(IEqualityComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"{comparer}",
                    $"Unable to initialise {typeof(ConcurrentHashSet<T>).Name}. ${comparer} cannot be null");
            }
            _inner = new ConcurrentDictionary<T, byte>(comparer);
        }

        /// <summary>
        /// Initialises a new instance of <see cref="ConcurrentHashSet{T}"/> that uses the specified equality comparer 
        /// and contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new set.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> that is used to determine equality for the values in the set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="comparer"/> was null.</exception>
        public ConcurrentHashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{collection}",
                    $"Unable to initialise {typeof(ConcurrentHashSet<T>).Name}. ${collection} cannot be null");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException($"{comparer}",
                    $"Unable to initialise {typeof(ConcurrentHashSet<T>).Name}. ${comparer} cannot be null");
            }

            _inner = new ConcurrentDictionary<T, byte>(comparer);
            foreach (T item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Attempts to add the specified element to the set.
        /// </summary>
        /// <param name="item">The element to add.</param>
        /// <returns>
        /// <c>true</c> if the element is added successfully; otherwise returns <c>false</c> if the element is already present.
        /// </returns>
        public bool TryAdd(T item)
        {
            return _inner.TryAdd(item, byte.MinValue);
        }

        /// <summary>
        /// Attempts to remove the specified element from the set.
        /// </summary>
        /// <param name="item">The element to add.</param>
        /// <returns>
        /// <c>true</c> if the element is reoved successfully; otherwise returns <c>false</c> if the element was not found.
        /// </returns>
        public bool TryRemove(T item)
        {
            byte ignore;
            return _inner.TryRemove(item, out ignore);
        }

        #region ICollection<T> Members
        ///<inheritdoc/>
        public int Count
        {
            get { return _inner.Count; }
        }

        ///<inheritdoc/>
        public bool IsReadOnly
        {
            get { return false; }
        }

        ///<inheritdoc/>
        public void Add(T item)
        {
            _inner.TryAdd(item, byte.MinValue);
        }

        ///<inheritdoc/>
        public void Clear()
        {
            _inner.Clear();
        }

        ///<inheritdoc/>
        public bool Contains(T item)
        {
            return _inner.ContainsKey(item);
        }

        ///<inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _inner.Keys.CopyTo(array, arrayIndex);
        }

        ///<inheritdoc/>
        public bool Remove(T item)
        {
            return TryRemove(item);
        }
        #endregion ICollection<T> Members

        #region IEnumerable<T> Members
        ///<inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return _inner.Keys.GetEnumerator();
        }

        ///<inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion IEnumerable<T> Members
    }

}
