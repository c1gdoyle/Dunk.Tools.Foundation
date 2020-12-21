using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Dunk.Tools.Foundation.Extensions;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// Represents a thread-safe hash-based unique collection.
    /// </summary>
    /// <typeparam name="T">The type of the items in this set.</typeparam>
    [DebuggerDisplay("Count={Count}")]
    public sealed class SynchronisedHashSet<T> : ICollection<T>, IReadOnlyCollection<T>, IDisposable
    {
        private readonly ReaderWriterLockSlim _sync = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        private readonly HashSet<T> _innerSet;

        /// <summary>
        /// Initialises a new instance of <see cref="SynchronisedHashSet{T}"/> that is empty and
        /// uses the default equality comparer for the set type.
        /// </summary>
        public SynchronisedHashSet()
            : this(EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="SynchronisedHashSet{T}"/> that uses the default equality 
        /// comparer and contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> was null.</exception>
        public SynchronisedHashSet(IEnumerable<T> collection)
            : this(collection, EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="SynchronisedHashSet{T}"/> that is empty and uses
        /// the specified equality comparer for the set type.
        /// </summary>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> that is ued to determine equality for the values in the set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> was null.</exception>
        public SynchronisedHashSet(IEqualityComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"{comparer}",
                    $"Unable to initialise {typeof(SynchronisedHashSet<T>).Name}. ${comparer} cannot be null.");
            }

            _innerSet = new HashSet<T>(comparer);
        }

        /// <summary>
        /// Initialises a new instance of <see cref="SynchronisedHashSet{T}"/> that uses the specified 
        /// equality comparer and contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new set.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> that is ued to determine equality for the values in the set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="comparer"/> was null.</exception>
        public SynchronisedHashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{collection}",
                    $"Unable to initialise {typeof(SynchronisedHashSet<T>).Name}. ${collection} cannot be null.");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException($"{comparer}",
                    $"Unable to initialise {typeof(SynchronisedHashSet<T>).Name}. ${comparer} cannot be null.");
            }
            _innerSet = new HashSet<T>(collection, comparer);
        }

        /// <summary>
        /// Gets the <see cref="IEqualityComparer{T}"/> that is used to determine 
        /// equaility for the values in the set.
        /// </summary>
        public IEqualityComparer<T> Comparer
        {
            get { return _innerSet.Comparer; }
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
            using (_sync.WriteLock())
            {
                return _innerSet.Add(item);
            }
        }

        /// <summary>
        /// Attempts to remove the specified element from the set.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        /// <returns>
        /// <c>true</c> if the element is removed successfully;  otherwise returns <c>false</c> if the element was not found.
        /// </returns>
        public bool TryRemove(T item)
        {
            using (_sync.WriteLock())
            {
                return _innerSet.Remove(item);
            }
        }

        #region ICollection<T> Members
        ///<inheritdoc/>
        public int Count
        {
            get
            {
                using (_sync.ReadLock())
                {
                    return _innerSet.Count;
                }
            }
        }

        ///<inheritdoc/>
        public bool IsReadOnly
        {
            get { return false; }
        }

        ///<inheritdoc/>
        public void Add(T item)
        {
            using (_sync.WriteLock())
            {
                _innerSet.Add(item);
            }
        }

        public void Clear()
        {
            using (_sync.WriteLock())
            {
                _innerSet.Clear();
            }
        }

        ///<inheritdoc/>
        public bool Contains(T item)
        {
            using (_sync.ReadLock())
            {
                return _innerSet.Contains(item);
            }
        }

        ///<inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex)
        {
            GetThreadSafeClone()
                .CopyTo(array, arrayIndex);
        }

        ///<inheritdoc/>
        public bool Remove(T item)
        {
            return TryRemove(item);
        }
        #endregion ICollection<T> Members

        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return GetThreadSafeClone()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion IEnumerable<T> Members

        private HashSet<T> GetThreadSafeClone()
        {
            using (_sync.ReadLock())
            {
                return new HashSet<T>(_innerSet, Comparer);
            }
        }

        #region IDisposable Members
        public void Dispose()
        {
            _sync.Dispose();
        }
        #endregion IDisposable Members
    }

}
