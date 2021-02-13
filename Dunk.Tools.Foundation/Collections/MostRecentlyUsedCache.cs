using System;
using System.Collections.Generic;
using System.Threading;
using Dunk.Tools.Foundation.Extensions;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// A MRU (Most Recently Used) cache which evicts the MRU item when 
    /// the cache reaches its' maximum capacity.
    /// </summary>
    /// <typeparam name="TKey">The type used to key items in the cache.</typeparam>
    /// <typeparam name="TValue">The type of items in the cache.</typeparam>
    public class MostRecentlyUsedCache<TKey, TValue> : IDisposable
    {
        private readonly IDictionary<TKey, MostRecentlyUsedCacheNode> _nodesByKey;
        private bool _disposed;
        private readonly ReaderWriterLockSlim _entriesSync = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        private int _currentCount;
        private readonly int _maxCapacity;
        private MostRecentlyUsedCacheNode _head;
        private MostRecentlyUsedCacheNode _tail;

        /// <summary>
        /// Initialises a new instance of <see cref="MostRecentlyUsedCache{TKey, TValue}"/> with a specified maximum capacity 
        /// for the cache.
        /// </summary>
        /// <param name="maxCapacity">The maximum capacity.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxCapacity"/> was zero or negative.</exception>
        public MostRecentlyUsedCache(int maxCapacity)
        {
            if (maxCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxCapacity),
                    $"{nameof(maxCapacity)} parameter must be greater than zero");
            }
            _maxCapacity = maxCapacity;
            _nodesByKey = new Dictionary<TKey, MostRecentlyUsedCacheNode>(_maxCapacity);
        }

        /// <summary>
        /// Gets the maximum capacity of the cache.
        /// </summary>
        public int MaxCapacity
        {
            get { return _maxCapacity; }
        }

        /// <summary>
        /// Gets the current count of items in the cache.
        /// </summary>
        public int Count
        {
            get
            {
                using (_entriesSync.ReadLock())
                {
                    return _nodesByKey.Count;
                }
            }
        }

        /// <summary>
        /// Gets whether or not the cache is full.
        /// </summary>
        public bool IsFull
        {
            get { return _currentCount == MaxCapacity; }
        }

        /// <summary>
        /// Inserts a specified key and value into the cache.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> was null.</exception>
        /// <remarks>
        /// Internall this method will :
        /// 1) If the cache is full, remove the MRU item from the cache.
        /// 2) If the specified key already exists in the cache, update the value held in the cache.
        /// 3) Mark the key/value added as the new MRU item in the cache.
        /// </remarks>
        public void Insert(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key),
                    $"Unable to insert into MRU Cache. {nameof(key)} parameter cannot be null");
            }

            using (_entriesSync.WriteLock())
            {
                MostRecentlyUsedCacheNode node;
                if (!_nodesByKey.TryGetValue(key, out node))
                {
                    //not in cache so insert
                    //check another thread has not inserted the node
                    if (!_nodesByKey.TryGetValue(key, out node))
                    {
                        if (IsFull)
                        {
                            node = _head;
                            _nodesByKey.Remove(_head.Key);
                            node.Key = key;
                            node.Value = value;
                        }
                        else
                        {
                            _currentCount++;
                            node = new MostRecentlyUsedCacheNode { Key = key, Value = value };
                        }
                        _nodesByKey.Add(key, node);
                    }
                }
                else
                {
                    //exists in cache so locak the node and update its' value
                    lock (node)
                    {
                        node.Value = value;
                    }
                }

                MakeMostRecentlyUsed(node);

                if (_tail == null)
                {
                    _tail = _head;
                }
            }
        }

        /// <summary>
        /// Gets the value associated with the specified key from the cache.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">
        /// When this method returns, contains the value associated with the key, 
        /// if the key was found; otherwise the default value of TValue.
        /// </param>
        /// <returns>
        /// <c>true</c> if the cache contains the value with the specified key; otherwise <c>false</c>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> was null.</exception>
        public bool TryGetItem(TKey key, out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key),
                    $"Unable to insert into MRU Cache. {nameof(key)} parameter cannot be null");
            }

            using (_entriesSync.WriteLock())
            {
                MostRecentlyUsedCacheNode node;
                value = default(TValue);

                if (!_nodesByKey.TryGetValue(key, out node))
                {
                    return false;
                }

                MakeMostRecentlyUsed(node);

                lock (node)
                {
                    value = node.Value;
                }
                return true;
            }
        }

        /// <summary>
        /// Removes all items from the cache.
        /// </summary>
        public void Clear()
        {
            using (_entriesSync.WriteLock())
            {
                _nodesByKey.Clear();
                _head = null;
                _tail = null;
                _currentCount = 0;
            }
        }

        private void MakeMostRecentlyUsed(MostRecentlyUsedCacheNode node)
        {
            if (node == _head)
            {
                return;
            }
            RemoveFromLinkedList(node);
            AddToHead(node);
        }

        private void RemoveFromLinkedList(MostRecentlyUsedCacheNode node)
        {
            var nextNode = node.Next;
            var prevNode = node.Previous;

            if (nextNode != null)
            {
                nextNode.Previous = node.Previous;
            }
            if (prevNode != null)
            {
                prevNode.Next = node.Next;
            }

            if (_head == node)
            {
                _head = nextNode;
            }
            if (_tail == node)
            {
                _tail = prevNode;
            }
        }

        private void AddToHead(MostRecentlyUsedCacheNode node)
        {
            node.Previous = null;
            node.Next = _head;

            if (_head != null)
            {
                _head.Previous = node;
            }
            _head = node;
        }

        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _entriesSync?.Dispose();
                _disposed = true;
            }
        }
        #endregion IDisposable Members

        private class MostRecentlyUsedCacheNode
        {
            public TKey Key { get; set; }

            public TValue Value { get; set; }

            public MostRecentlyUsedCacheNode Next { get; set; }

            public MostRecentlyUsedCacheNode Previous { get; set; }

            public override string ToString()
            {
                return $"Key:{Key} -> Value:{Value}";
            }
        }
    }
}
