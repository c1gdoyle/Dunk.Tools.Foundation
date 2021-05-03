using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Threading;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// A thread-safe collection of unique items that maintains a count of how many times each item has been added 
    /// and requires the objects to be removed the same number of times.
    /// </summary>
    /// <remarks>
    /// Inspired by IOS NSCountedSet, https://developer.apple.com/library/mac/documentation/Cocoa/Reference/Foundation/Classes/NSCountedSet_Class/
    /// </remarks>
    [System.Diagnostics.DebuggerDisplay("Count={Count}")]
    public sealed class ConcurrentCountedSet<T> : ICollection<T>
    {
        private readonly ConcurrentDictionary<T, AtomicInt32> _itemsAndCounts = new ConcurrentDictionary<T, AtomicInt32>();

        /// <summary>
        /// Initialises a new default instance of <see cref="ConcurrentCountedSet{T}"/>
        /// </summary>
        public ConcurrentCountedSet()
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="ConcurrentCountedSet{T}"/> with a specified collection 
        /// and default equality-comparer.
        /// </summary>
        /// <param name="collection">The collection of items to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> was null.</exception>
        public ConcurrentCountedSet(IEnumerable<T> collection)
            : this(collection, EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initialises a new empty instance of <see cref="ConcurrentCountedSet{T}"/> with a specified equality-comparer 
        /// for comparing elements to add.
        /// </summary>
        /// <param name="comparer">The comparer for comparing elements.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> was null.</exception>
        public ConcurrentCountedSet(IEqualityComparer<T> comparer)
            : this(System.Array.Empty<T>(), comparer)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="ConcurrentCountedSet{T}"/> with a specified collection and equality-comparer.
        /// </summary>
        /// <param name="collection">The collection of items to add.</param>
        /// <param name="comparer">The comparer for comparing elements.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="comparer"/> was null.</exception>
        public ConcurrentCountedSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(
                    nameof(collection), $"Unable to initialise {typeof(ConcurrentCountedSet<T>).Name}. {nameof(collection)} cannot be null.");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException(
                    nameof(comparer), $"Unable to initialise {typeof(ConcurrentCountedSet<T>).Name}. {nameof(comparer)} cannot be null.");
            }

            _itemsAndCounts = new ConcurrentDictionary<T, AtomicInt32>(comparer);
            foreach (T item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Gets the count associated with the specified item.
        /// </summary>
        /// <param name="item">The item to get the associated count for.</param>
        /// <returns>
        /// The value of the key/value pair at the specified index.
        /// </returns>
        /// <exception cref="KeyNotFoundException">The item does not exist int his set.</exception>
        public int this[T item]
        {
            get { return _itemsAndCounts[item]; }
        }

        /// <summary>
        /// Gets the count associated with the specified item.
        /// </summary>
        /// <param name="item">The item to get the associated count for.</param>
        /// <param name="count">
        /// When this method returns, contains the count associated with the specified item, 
        /// if the key is found; otherwise zero. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// <c>true</c> if the <see cref="CountedSet{T}"/> contains the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool TryGetCount(T item, out int count)
        {
            AtomicInt32 value;
            if(_itemsAndCounts.TryGetValue(item, out value))
            {
                count = value;
                return true;
            }
            count = 0;
            return false;
        }

        #region ICollection<T> Members
        /// <inheritdoc />
        public int Count
        {
            get { return _itemsAndCounts.Count; }
        }

        /// <inheritdoc />
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <inheritdoc />
        /// <remarks>
        /// If the element has not been added to the set this method will add it
        /// and set the count associated with that element to 1.
        /// 
        /// If the element has already been added to the set this method
        /// will increase the count associated with that element count by one. 
        /// </remarks>
        public void Add(T item)
        {
            _itemsAndCounts.AddOrUpdate(
                item, 
                new AtomicInt32(1), 
                (k, v) =>
                {
                    v.PreIncrement();
                    return v;
                });
        }

        /// <inheritdoc />
        public void Clear()
        {
            _itemsAndCounts.Clear();
        }

        /// <inheritdoc />
        public bool Contains(T item)
        {
            return _itemsAndCounts.ContainsKey(item);
        }

        /// <inheritdoc />
        public void CopyTo(T[] array, int arrayIndex)
        {
            _itemsAndCounts.Keys.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        /// <remarks>
        /// If the specified element has been added to the set only once this method 
        /// will reduce the count associated with the element to zero and remove the element.
        /// 
        /// If the specified element has been added to the set more than once
        /// this method will reduce the count associated with that element count by one.
        /// </remarks>
        public bool Remove(T item)
        {
            AtomicInt32 value;

            if(_itemsAndCounts.TryGetValue(item, out value))
            {
                if(value.PreDecrement() == 0)
                {
                    return _itemsAndCounts.TryRemove(item, out value);
                }
                return true;
            }
            return false;
        }
        #endregion ICollection<T> Members

        #region IEnumerator<T> Members
        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            return _itemsAndCounts.Keys.GetEnumerator();
        }
        #endregion IEnumerator<T> Members

        #region IEnumerator Members
        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion IEnumerator Members
    }
}
