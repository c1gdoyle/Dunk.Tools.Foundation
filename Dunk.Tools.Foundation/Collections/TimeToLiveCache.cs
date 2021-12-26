using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Dunk.Tools.Foundation.Extensions;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// A generic time-to-live (TTL) cache based on key/value pairs. The key must be unique.
    /// </summary>
    /// <typeparam name="TKey">The type used to key items in the cache.</typeparam>
    /// <typeparam name="TValue">The type of items in the cache.</typeparam>
    /// <remarks>
    /// Every cache item has its' own timeout.
    /// The cache is thread safe and will delete expired entries on its' own using <see cref="Timer"/>s.
    /// </remarks>
    [DebuggerDisplay("Count = {Count}")]
    public class TimeToLiveCache<TKey, TValue> : IDisposable
    {
        private readonly Dictionary<TKey, TimeToLiveCacheItem> _cacheItemsByKeys = new Dictionary<TKey, TimeToLiveCacheItem>();

        private readonly ReaderWriterLockSlim _entriesSync = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        private readonly int _defaultTimeout;

        private bool _disposed;

        /// <summary>
        /// Initialises a new default instance of <see cref="TimeToLiveCache{TKey, TValue}"/> with a
        /// default time-out of <see cref="Timeout.Infinite"/>.
        /// </summary>
        public TimeToLiveCache()
        {
            _defaultTimeout = Timeout.Infinite;
        }

        /// <summary>
        /// Initialises a new instance of <see cref="TimeToLiveCache{TKey, TValue}"/> with a specified
        /// time-out. in milli-seconds.
        /// </summary>
        /// <param name="defaultTimeout">The default time-out for items stored in this cache, must be 1 or greater.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="defaultTimeout"/> was less than 1.</exception>
        public TimeToLiveCache(int defaultTimeout)
        {
            if (defaultTimeout < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(defaultTimeout),
                    $"Unable to initialise TimeToLiveCache. {nameof(defaultTimeout)} must greater than or equal to 1 but was {defaultTimeout}");
            }
            _defaultTimeout = defaultTimeout;
        }

        /// <summary>
        /// Gets the cache item associated the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The value associated with the specified key. If the specified key 
        /// is not found this operation will through a <see cref="KeyNotFoundException"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="key"/> does not exist in the cache.</exception>
        public TValue this[TKey key]
        {
            get { return GetItem(key); }
        }

        /// <summary>
        /// Gets the default timeout for items in this cache in milli-seconds.
        /// </summary>
        /// <remarks>
        /// DefaultTimeout -1 indicates that items in the cache have an infinite time-out by default.
        /// </remarks>
        public int DefaultTimeout
        {
            get { return _defaultTimeout; }
        }

        /// <summary>
        /// Gets the number of items in this cache.
        /// </summary>
        public int Count
        {
            get
            {
                return _cacheItemsByKeys.Count;
            }
        }

        /// <summary>
        /// Gets the cache item associated the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The value associated with the specified key. If the specified key 
        /// is not found this operation will through a <see cref="KeyNotFoundException"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="key"/> does not exist in the cache.</exception>
        public TValue GetItem(TKey key)
        {
            key.ThrowIfNull(nameof(key), $"Unable to access TimeToLive cache. {nameof(key)} parameter cannot be null.");

            using (_entriesSync.ReadLock())
            {
                if (_cacheItemsByKeys.ContainsKey(key))
                {
                    return _cacheItemsByKeys[key].Value;
                }
                throw new KeyNotFoundException($"The given key {0} is not present in the TimeToLive cache.");
            }
        }

        /// <summary>
        /// Gets the cache item associated with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">
        /// When this method returns; contains the cache item associated with the key
        /// if the key was found; otherwise the default value of TValue.
        /// </param>
        /// <returns>
        /// <c>true</c> if the cache contains the value associated with the key; otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public bool TryGetItem(TKey key, out TValue item)
        {
            key.ThrowIfNull(nameof(key), $"Unable to access TimeToLive cache. {nameof(key)} parameter cannot be null.");

            using (_entriesSync.ReadLock())
            {
                TimeToLiveCacheItem i;
                if (_cacheItemsByKeys.TryGetValue(key, out i))
                {
                    item = i.Value;
                    return true;
                }
                item = default(TValue);
                return false;
            }
        }

        /// <summary>
        /// Adds or updates the specified key with the specified cache object and 
        /// applies the default time-out.
        /// </summary>
        /// <param name="key">The key to add or update.</param>
        /// <param name="cacheObj">The cache object to store if the key does not already exist.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public void AddOrUpdate(TKey key, TValue cacheObj)
        {
            AddOrUpdate(key, cacheObj, DefaultTimeout);
        }

        /// <summary>
        /// Adds or updates the specified key with the specified cache object and 
        /// applies a specified timeout (in milli-seconds) to the key if it was not already present.
        /// </summary>
        /// <param name="key">The key to add or update.</param>
        /// <param name="cacheObj">The cache object to store if the key does not already exist.</param>
        /// <param name="cacheTimeout">The cache timeout (lifespan) of this object. Must be 1 or greater,</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public void AddOrUpdate(TKey key, TValue cacheObj, int cacheTimeout)
        {
            AddOrUpdate(key, cacheObj, cacheTimeout, false);
        }

        /// <summary>
        /// Adds or updates the specified key and cacheObject to the <see cref="TimeToLiveCache{TKey, TValue}"/> if the key does not already exist,
        /// and applies a specified timeout (in milli-seconds) to the key if 
        /// it was not already present or the <paramref name="restartTimeIfExists"/> flag is set to <c>true</c>.
        /// </summary>
        /// <param name="key">The key to add or update.</param>
        /// <param name="cacheObj">The cache object to store if the key does not already exist.</param>
        /// <param name="cacheTimeout">The cache timeout (lifespan) of this object. Must be 1 or greater,</param>
        /// <param name="restartTimeIfExists">If set to true the timer for this cacheObject will be reset if object already exists in the cache.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public void AddOrUpdate(TKey key, TValue cacheObj, int cacheTimeout, bool restartTimeIfExists)
        {
            AddOrUpdate(key, cacheObj, (k, v) => cacheObj, cacheTimeout, restartTimeIfExists);
        }

        /// <summary>
        /// Adds the specified key and cacheObject to the <see cref="TimeToLiveCache{TKey, TValue}"/> if the key does not already exist,
        /// or updates the key/cacheObject pair if the key already exists.
        /// </summary>
        /// <param name="key">The key to add or update.</param>
        /// <param name="cacheObj">The cache object to store if the key does not already exist.</param>
        /// <param name="updateFactory">The function used to generate a new cache object for an existing key based on the key's existing cache object.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public void AddOrUpdate(TKey key, TValue cacheObj, Func<TKey, TValue, TValue> updateFactory)
        {
            AddOrUpdate(key, cacheObj, updateFactory, _defaultTimeout);
        }

        /// <summary>
        /// Adds the specified key and cacheObject to the <see cref="TimeToLiveCache{TKey, TValue}"/> if the key does not already exist,
        /// or updates the key/cacheObject pair if the key already exists and applies a specified timeout (in milli-seconds) to the key if 
        /// it was not already present.
        /// </summary>
        /// <param name="key">The key to add or update.</param>
        /// <param name="cacheObj">The cache object to store if the key does not already exist.</param>
        /// <param name="updateFactory">The function used to generate a new cache object for an existing key based on the key's existing cache object.</param>
        /// <param name="cacheTimeout">The cache timeout (lifespan) of this object. Must be 1 or greater,</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public void AddOrUpdate(TKey key, TValue cacheObj, Func<TKey, TValue, TValue> updateFactory, int cacheTimeout)
        {
            AddOrUpdate(key, cacheObj, updateFactory, cacheTimeout, false);
        }

        /// <summary>
        /// Adds the specified key and cacheObject to the <see cref="TimeToLiveCache{TKey, TValue}"/> if the key does not already exist,
        /// or updates the key/cacheObject pair if the key already exists and applies a specified timeout (in milli-seconds) to the key if 
        /// it was not already present or the <paramref name="restartTimeIfExists"/> flag is set to <c>true</c>.
        /// </summary>
        /// <param name="key">The key to add or update.</param>
        /// <param name="cacheObj">The cache object to store if the key does not already exist.</param>
        /// <param name="updateFactory">The function used to generate a new cache object for an existing key based on the key's existing cache object.</param>
        /// <param name="cacheTimeout">The cache timeout (lifespan) of this object. Must be 1 or greater,</param>
        /// <param name="restartTimeIfExists">If set to true the timer for this cacheObject will be reset if object already exists in the cache.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public void AddOrUpdate(TKey key, TValue cacheObj, Func<TKey, TValue, TValue> updateFactory, int cacheTimeout, bool restartTimeIfExists)
        {
            if (_disposed)
            {
                return;
            }
            key.ThrowIfNull(nameof(key), $"Unable to access TimeToLive cache. {nameof(key)} parameter cannot be null.");


            if (cacheTimeout != _defaultTimeout && cacheTimeout < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(cacheTimeout),
                    $"{nameof(cacheTimeout)} must be greater than 0");
            }

            using (_entriesSync.WriteLock())
            {
                int timerTimeout = cacheTimeout == DefaultTimeout ? DefaultTimeout : cacheTimeout;

                Func<TKey, TimeToLiveCacheItem> addFunc = k =>
                {
                    return new TimeToLiveCacheItem
                    {
                        Value = cacheObj,
                        Timer = new Timer(RemoveByTimer, key, timerTimeout, Timeout.Infinite)
                    };
                };
                Func<TKey, TimeToLiveCacheItem, TimeToLiveCacheItem> updateFunc = (k, v) =>
                {
                    if (restartTimeIfExists)
                    {
                        v.Timer.Change(timerTimeout, Timeout.Infinite);
                    }
                    v.Value = updateFactory(key, v.Value);
                    return v;
                };

                _cacheItemsByKeys.AddOrUpdate(key, addFunc, updateFunc);
            }
        }

        /// <summary>
        /// Removes all items in the cache and disposes all active timers.
        /// </summary>
        public void Clear()
        {
            using (_entriesSync.WriteLock())
            {
                foreach (var i in _cacheItemsByKeys.Values)
                {
                    i.Timer.Dispose();
                }
                _cacheItemsByKeys.Clear();
            }
        }

        /// <summary>
        /// Determines whether the cache contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate.</param>
        /// <returns>
        /// <c>true</c> if the cache contains the specified element; otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public bool Contains(TKey key)
        {
            key.ThrowIfNull(nameof(key), $"Unable to access TimeToLive cache. {nameof(key)} parameter cannot be null.");

            using (_entriesSync.ReadLock())
            {
                return _cacheItemsByKeys.ContainsKey(key);
            }
        }

        /// <summary>
        /// Removes the cache entry with the specified key.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        /// <returns>
        /// <c>true</c> if key was successfully found and removed. If the key was not found returns <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public bool Remove(TKey key)
        {
            key.ThrowIfNull(nameof(key), $"Unable to access TimeToLive cache. {nameof(key)} parameter cannot be null.");

            using (_entriesSync.WriteLock())
            {
                if (_cacheItemsByKeys.ContainsKey(key))
                {
                    _cacheItemsByKeys[key].Timer.Dispose();
                    return _cacheItemsByKeys.Remove(key);
                }
                return false;
            }
        }

        private void RemoveByTimer(object state)
        {
            Remove((TKey)state);
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
                //clear the cache and associated timers
                Clear();
                //dispose of the lock
                _entriesSync?.Dispose();
                _disposed = true;
            }
        }
        #endregion IDisposable Members

        private sealed class TimeToLiveCacheItem
        {
            public TValue Value { get; set; }

            public Timer Timer { get; set; }
        }
    }
}
