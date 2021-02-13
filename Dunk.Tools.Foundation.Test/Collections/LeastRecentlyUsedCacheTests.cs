using System;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Collections;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class LeastRecentlyUsedCacheTests
    {
        [Test]
        public void LeastRecentlyUsedCacheInitialises()
        {
            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);
            Assert.IsNotNull(cache);
        }

        [Test]
        public void LeastRecentlyUsedCacheThrowsIfMaxCapacityIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new LeastRecentlyUsedCache<int, TestCacheStub>(0));
        }

        [Test]
        public void LeastRecentlyUsedCacheThrowsIfMaxCapacityIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new LeastRecentlyUsedCache<int, TestCacheStub>(-1));
        }

        [Test]
        public void LeastRecentlyUsedCacheInsertThrowsIfKeyIsNull()
        {
            var cache = new LeastRecentlyUsedCache<int?, TestCacheStub>(5);
            var cacheItem = new TestCacheStub { Id = 1, Value = 1.1 };

            Assert.Throws<ArgumentNullException>(() => cache.Insert(null, cacheItem));
        }

        [Test]
        public void LeastRecentlyUsedCacheInsertsItemIntoCache()
        {
            const int expectedCount = 1;

            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);
            var cacheItem = new TestCacheStub { Id = 1, Value = 1.1 };

            cache.Insert(cacheItem.Id, cacheItem);

            Assert.AreEqual(expectedCount, cache.Count);
        }

        [Test]
        public void LeastRecentlyUsedCacheTryGetItemThrowsIfKeyIsNull()
        {
            var cache = new LeastRecentlyUsedCache<int?, TestCacheStub>(5);

            TestCacheStub cacheItem;
            Assert.Throws<ArgumentNullException>(() => cache.TryGetItem(null, out cacheItem));
        }

        [Test]
        public void LeastRecentlyUsedCacheTryGetItemReturnsTrueIfItemIsInCache()
        {
            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);
            var cacheItem = new TestCacheStub { Id = 1, Value = 1.1 };

            cache.Insert(cacheItem.Id, cacheItem);

            TestCacheStub value;
            bool result = cache.TryGetItem(1, out value);

            Assert.IsTrue(result);
        }

        [Test]
        public void LeastRecentlyUsedCacheTryGetItemReturnsFalseIfItemIsInCache()
        {
            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);
            var cacheItem = new TestCacheStub { Id = 1, Value = 1.1 };

            cache.Insert(cacheItem.Id, cacheItem);

            TestCacheStub value;
            bool result = cache.TryGetItem(2, out value);

            Assert.IsFalse(result);
        }

        [Test]
        public void LeastRecentlyUsedCacheSizeDoesNotExceedCapacity()
        {
            const int expectedCount = 5;

            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);

            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            cache.Insert(2, new TestCacheStub { Id = 2, Value = 1.2 });
            cache.Insert(3, new TestCacheStub { Id = 3, Value = 1.3 });
            cache.Insert(4, new TestCacheStub { Id = 4, Value = 1.4 });
            cache.Insert(5, new TestCacheStub { Id = 5, Value = 1.5 });
            cache.Insert(6, new TestCacheStub { Id = 6, Value = 1.6 });

            Assert.AreEqual(expectedCount, cache.Count);
        }

        [Test]
        public void LeastRecentlyUsedCacheRemovesLeastRecentlyUsedItemWhenCapacityReached()
        {
            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);

            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            cache.Insert(2, new TestCacheStub { Id = 2, Value = 1.2 });
            cache.Insert(3, new TestCacheStub { Id = 3, Value = 1.3 });
            cache.Insert(4, new TestCacheStub { Id = 4, Value = 1.4 });
            cache.Insert(5, new TestCacheStub { Id = 5, Value = 1.5 });
            cache.Insert(6, new TestCacheStub { Id = 6, Value = 1.6 });

            TestCacheStub value;
            bool result = cache.TryGetItem(1, out value);

            Assert.IsFalse(result);
        }

        [Test]
        public void LeastRecentlyUsedCacheInsertMovesItemToMostRecentlyUsedIfItAlreadyExistsInCache()
        {
            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);

            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            cache.Insert(2, new TestCacheStub { Id = 2, Value = 1.2 });
            cache.Insert(3, new TestCacheStub { Id = 3, Value = 1.3 });
            cache.Insert(4, new TestCacheStub { Id = 4, Value = 1.4 });
            cache.Insert(5, new TestCacheStub { Id = 5, Value = 1.5 });
            //should move 1 to most recently used
            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            //should force removal of LRU
            cache.Insert(6, new TestCacheStub { Id = 6, Value = 1.6 });

            TestCacheStub value;
            bool result1 = cache.TryGetItem(1, out value);
            bool result2 = cache.TryGetItem(2, out value);

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [Test]
        public void LeastRecentlyUsedCacheInsertUpdatesCacheWithMostRecentInstanceOfItemIfItAlreadyExistsInCache()
        {
            const double expectedValue = 5.5;

            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);

            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            cache.Insert(2, new TestCacheStub { Id = 2, Value = 1.2 });
            cache.Insert(3, new TestCacheStub { Id = 3, Value = 1.3 });
            cache.Insert(4, new TestCacheStub { Id = 4, Value = 1.4 });
            cache.Insert(5, new TestCacheStub { Id = 5, Value = 1.5 });
            //should move 1 to most recently used
            cache.Insert(1, new TestCacheStub { Id = 1, Value = 5.5 });

            TestCacheStub item;
            cache.TryGetItem(1, out item);

            Assert.AreEqual(expectedValue, item.Value);
        }


        [Test]
        public void LeasttRecentlyUsedCacheClearEmptiesCache()
        {
            const int expectedCount = 0;

            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);

            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            cache.Insert(2, new TestCacheStub { Id = 2, Value = 1.2 });
            cache.Insert(3, new TestCacheStub { Id = 3, Value = 1.3 });
            cache.Insert(4, new TestCacheStub { Id = 4, Value = 1.4 });
            cache.Insert(5, new TestCacheStub { Id = 5, Value = 1.5 });

            cache.Clear();

            Assert.AreEqual(expectedCount, cache.Count);
        }

        [Test]
        public void LeastRecentlyUsedCacheSizeDoesNotExceedCapacityWhenMultiThreaded()
        {
            const int expectedCount = 5;

            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 8
            };
            Parallel.For(0, 100, options, i =>
            {
                cache.Insert(i, new TestCacheStub { Id = i, Value = i * 1.1 });
            });
            Assert.AreEqual(expectedCount, cache.Count);
        }

        [Test]
        public void LeastRecentlyUsedCacheDoesNotInsertDuplicateKeysWhenMultiThreaded()
        {
            const int expectedCount = 1;

            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 8
            };
            Parallel.For(0, 100, options, i =>
            {
                cache.Insert(1, new TestCacheStub { Id = i, Value = i * 1.1 });
            });
            Assert.AreEqual(expectedCount, cache.Count);
        }

        [Test]
        public void LeastRecentlyUsedCacheImplementsDisposeOnLock()
        {
            var cache = new LeastRecentlyUsedCache<int, TestCacheStub>(5);
            Assert.DoesNotThrow(() => cache.Dispose());
        }

        private class TestCacheStub
        {
            public int Id { get; set; }

            public double Value { get; set; }
        }
    }
}
