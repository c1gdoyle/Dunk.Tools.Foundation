using System;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Collections;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class MostRecentlyUsedCacheTests
    {
        [Test]
        public void MostRecentlyUsedCacheInitialises()
        {
            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);
            Assert.IsNotNull(cache);
        }

        [Test]
        public void MostRecentlyUsedCacheThrowsIfMaxCapacityIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MostRecentlyUsedCache<int, TestCacheStub>(0));
        }

        [Test]
        public void MostRecentlyUsedCacheThrowsIfMaxCapacityIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MostRecentlyUsedCache<int, TestCacheStub>(-1));
        }

        [Test]
        public void MostRecentlyUsedCacheInsertThrowsIfKeyIsNull()
        {
            var cache = new MostRecentlyUsedCache<int?, TestCacheStub>(5);
            var cacheItem = new TestCacheStub { Id = 1, Value = 1.1 };

            Assert.Throws<ArgumentNullException>(() => cache.Insert(null, cacheItem));
        }

        [Test]
        public void MostRecentlyUsedCacheInsertsItemIntoCache()
        {
            const int expectedCount = 1;

            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);
            var cacheItem = new TestCacheStub { Id = 1, Value = 1.1 };

            cache.Insert(cacheItem.Id, cacheItem);

            Assert.AreEqual(expectedCount, cache.Count);
        }

        [Test]
        public void MostRecentlyUsedCacheTryGetItemThrowsIfKeyIsNull()
        {
            var cache = new MostRecentlyUsedCache<int?, TestCacheStub>(5);

            TestCacheStub cacheItem;
            Assert.Throws<ArgumentNullException>(() => cache.TryGetItem(null, out cacheItem));
        }

        [Test]
        public void MostRecentlyUsedCacheTryGetItemReturnsTrueIfItemIsInCache()
        {
            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);
            var cacheItem = new TestCacheStub { Id = 1, Value = 1.1 };

            cache.Insert(cacheItem.Id, cacheItem);

            TestCacheStub value;
            bool result = cache.TryGetItem(1, out value);

            Assert.IsTrue(result);
        }

        [Test]
        public void MostRecentlyUsedCacheTryGetItemReturnsFalseIfItemIsInCache()
        {
            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);
            var cacheItem = new TestCacheStub { Id = 1, Value = 1.1 };

            cache.Insert(cacheItem.Id, cacheItem);

            TestCacheStub value;
            bool result = cache.TryGetItem(2, out value);

            Assert.IsFalse(result);
        }

        [Test]
        public void MostRecentlyUsedCacheSizeDoesNotExceedCapacity()
        {
            const int expectedCount = 5;

            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);

            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            cache.Insert(2, new TestCacheStub { Id = 2, Value = 1.2 });
            cache.Insert(3, new TestCacheStub { Id = 3, Value = 1.3 });
            cache.Insert(4, new TestCacheStub { Id = 4, Value = 1.4 });
            cache.Insert(5, new TestCacheStub { Id = 5, Value = 1.5 });
            cache.Insert(6, new TestCacheStub { Id = 6, Value = 1.6 });

            Assert.AreEqual(expectedCount, cache.Count);
        }

        [Test]
        public void MostRecentlyUsedCacheRemovesMostRecentlyUsedItemWhenCapacityReached()
        {
            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);

            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            cache.Insert(2, new TestCacheStub { Id = 2, Value = 1.2 });
            cache.Insert(3, new TestCacheStub { Id = 3, Value = 1.3 });
            cache.Insert(4, new TestCacheStub { Id = 4, Value = 1.4 });
            cache.Insert(5, new TestCacheStub { Id = 5, Value = 1.5 });
            cache.Insert(6, new TestCacheStub { Id = 6, Value = 1.6 });

            TestCacheStub value;
            bool result = cache.TryGetItem(5, out value);

            Assert.IsFalse(result);
        }

        [Test]
        public void MostRecentlyUsedCacheInsertMovesItemToMostRecentIfItAlreadyExistsInCache()
        {
            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);

            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            cache.Insert(2, new TestCacheStub { Id = 2, Value = 1.2 });
            cache.Insert(3, new TestCacheStub { Id = 3, Value = 1.3 });
            cache.Insert(4, new TestCacheStub { Id = 4, Value = 1.4 });
            cache.Insert(5, new TestCacheStub { Id = 5, Value = 1.5 });
            //should move 1 to most recently used
            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            //should force removal of MRU
            cache.Insert(6, new TestCacheStub { Id = 6, Value = 1.6 });

            TestCacheStub value;
            bool result = cache.TryGetItem(1, out value);

            Assert.IsFalse(result);
        }

        [Test]
        public void MostRecentlyUsedCacheInsertUpdatesCacheWithMostRecentInstanceOfItemIfItAlreadyExistsInCache()
        {
            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);

            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            cache.Insert(1, new TestCacheStub { Id = 2, Value = 1.2 });
            cache.Insert(1, new TestCacheStub { Id = 3, Value = 1.3 });
            cache.Insert(1, new TestCacheStub { Id = 4, Value = 1.4 });
            cache.Insert(1, new TestCacheStub { Id = 5, Value = 1.5 });

            TestCacheStub value;
            cache.TryGetItem(1, out value);

            Assert.AreEqual(1.5, value.Value);
        }

        [Test]
        public void MostRecentlyUsedCacheClearEmptiesCache()
        {
            const int expectedCount = 0;

            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);

            cache.Insert(1, new TestCacheStub { Id = 1, Value = 1.1 });
            cache.Insert(2, new TestCacheStub { Id = 2, Value = 1.2 });
            cache.Insert(3, new TestCacheStub { Id = 3, Value = 1.3 });
            cache.Insert(4, new TestCacheStub { Id = 4, Value = 1.4 });
            cache.Insert(5, new TestCacheStub { Id = 5, Value = 1.5 });

            cache.Clear();

            Assert.AreEqual(expectedCount, cache.Count);
        }

        [Test]
        public void MostRecentlyUsedCacheSizeDoesNotExceedCapacityWhenMultiThreaded()
        {
            const int expectedCount = 5;

            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);

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
        public void MostRecentlyUsedCacheDoesNotInsertDuplicateKeysWhenMultiThreaded()
        {
            const int expectedCount = 1;

            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);

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
        public void MostRecentlyUsedCacheImplementsDisposeOnLock()
        {
            var cache = new MostRecentlyUsedCache<int, TestCacheStub>(5);
            Assert.DoesNotThrow(() => cache.Dispose());
        }

        private class TestCacheStub
        {
            public int Id { get; set; }

            public double Value { get; set; }
        }
    }
}
