using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Collections;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class TimeToLiveCacheTests
    {
        [Test]
        public void CacheInitialises()
        {
            using (var cache = new TimeToLiveCache<long, object>())
            {
                Assert.IsNotNull(cache);
            }
        }

        [Test]
        public void CacheInitialisesWithInfiniteTimeoutByDefault()
        {
            using (var cache = new TimeToLiveCache<long, object>())
            {
                Assert.AreEqual(Timeout.Infinite, cache.DefaultTimeout);
            }
        }

        [Test]
        public void CacheInitialisesWithSpecifiedTimeout()
        {
            const int expected = 1000;

            using (var cache = new TimeToLiveCache<long, object>(expected))
            {
                Assert.AreEqual(expected, cache.DefaultTimeout);
            }
        }

        [Test]
        public void CacheThrowsIfDefaultTimeoutIsOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TimeToLiveCache<long, object>(0));
        }

        [Test]
        public void CacheAddsItem()
        {
            using (var cache = new TimeToLiveCache<long, object>(5000))
            {
                var item = new TimeToLiveTestItem { Id = 1 };
                cache.AddOrUpdate(item.Id, item);

                Assert.IsTrue(cache.Contains(item.Id));
            }
        }

        [Test]
        public void CacheEvictsItemIfTieoutReached()
        {
            using (var cache = new TimeToLiveCache<long, object>())
            {
                var item = new TimeToLiveTestItem { Id = 1 };
                cache.AddOrUpdate(item.Id, item, 100);

                Thread.Sleep(500);

                Assert.IsFalse(cache.Contains(item.Id));
            }
        }

        [Test]
        public void CacheDoesNotEvictItemBeforeTimeoutReached()
        {
            const int defaultTimeout = 500;
            const int customTimeout = 30000;

            using (var cache = new TimeToLiveCache<long, object>(defaultTimeout))
            {
                var item = new TimeToLiveTestItem { Id = 1 };
                cache.AddOrUpdate(item.Id, item, customTimeout);

                Thread.Sleep(defaultTimeout);

                Assert.IsTrue(cache.Contains(item.Id));
            }
        }

        [Test]
        public void CacheUpdatesItem()
        {
            const string expectedName = "bar";

            using (var cache = new TimeToLiveCache<long, object>())
            {
                var item = new TimeToLiveTestItem { Id = 1, Name = "foo" };
                cache.AddOrUpdate(item.Id, item);

                item = new TimeToLiveTestItem { Id = 1, Name = "bar" };
                cache.AddOrUpdate(item.Id, item);

                var result = cache[item.Id] as TimeToLiveTestItem;

                Assert.AreEqual(expectedName, result.Name);
            }
        }

        [Test]
        public void CacheRestartsTimerForItem()
        {
            using (var cache = new TimeToLiveCache<long, object>())
            {
                var item = new TimeToLiveTestItem { Id = 1 };

                cache.AddOrUpdate(item.Id, item, 500);
                cache.AddOrUpdate(item.Id, item, 2000, true);

                Thread.Sleep(500);

                Assert.IsTrue(cache.Contains(item.Id));
            }
        }

        [Test]
        public void CacheAddOrUpdateThrowsIfTimeoutIsZero()
        {
            using (var cache = new TimeToLiveCache<long, object>())
            {
                var item = new TimeToLiveTestItem { Id = 1 };

                Assert.Throws<ArgumentOutOfRangeException>(() => cache.AddOrUpdate(item.Id, item, 0));
            }
        }

        [Test]
        public void CacheAddOrUpdateThrowsIfTimeoutIsNegative()
        {
            using (var cache = new TimeToLiveCache<long, object>())
            {
                var item = new TimeToLiveTestItem { Id = 1 };

                Assert.Throws<ArgumentOutOfRangeException>(() => cache.AddOrUpdate(item.Id, item, -10));
            }
        }

        [Test]
        public void CacheDisposeRemovesAllItemsFromCache()
        {
            var cache = new TimeToLiveCache<long, object>();

            cache.AddOrUpdate(1, new TimeToLiveTestItem());
            cache.AddOrUpdate(2, new TimeToLiveTestItem());
            cache.AddOrUpdate(3, new TimeToLiveTestItem());
            cache.AddOrUpdate(4, new TimeToLiveTestItem());
            cache.AddOrUpdate(5, new TimeToLiveTestItem());

            cache.Dispose();

            Assert.AreEqual(0, cache.Count);
        }

        [Test]
        public void CacheSupportsLookupByIndex()
        {
            using (var cache = new TimeToLiveCache<long, object>())
            {
                cache.AddOrUpdate(1, new TimeToLiveTestItem { Id = 1 });

                var result = cache[1];

                Assert.IsNotNull(result);
            }
        }

        [Test]
        public void CacheIndexLookupThrowsIfKeyNotFound()
        {
            using (var cache = new TimeToLiveCache<long, TimeToLiveTestItem>())
            {
                cache.AddOrUpdate(1, new TimeToLiveTestItem { Id = 1 });

                Assert.Throws<KeyNotFoundException>(() =>
                {
                    _ = cache[2];
                });
            }
        }

        [Test]
        public void CacheTryGetItemReturnsTrueIfItemInCache()
        {
            using (var cache = new TimeToLiveCache<long, TimeToLiveTestItem>())
            {
                cache.AddOrUpdate(1, new TimeToLiveTestItem { Id = 1 });

                TimeToLiveTestItem ignore;
                bool result = cache.TryGetItem(1, out ignore);

                Assert.IsTrue(result);
            }
        }

        [Test]
        public void CacheTryGetItemReturnsFalseIfItemInCache()
        {
            using (var cache = new TimeToLiveCache<long, TimeToLiveTestItem>())
            {
                cache.AddOrUpdate(1, new TimeToLiveTestItem { Id = 1 });

                TimeToLiveTestItem ignore;
                bool result = cache.TryGetItem(2, out ignore);

                Assert.IsFalse(result);
            }
        }

        [Test]
        public void CacheDoesNotInsertDuplicateKeysWhenMultiThreaded()
        {
            const int expectedCount = 1;

            using (var cache = new TimeToLiveCache<long, TimeToLiveTestItem>())
            {
                var options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = 64
                };

                Parallel.For(0, 10000, options, i =>
                {
                    cache.AddOrUpdate(1, new TimeToLiveTestItem { Id = i });
                });
                Assert.AreEqual(expectedCount, cache.Count);
            }
        }

        [Test]
        public void CacheAddOrUpdateDoesNotInsertDuplicateKeysWhenMultiThreaded()
        {
            const int expectedCount = 1;

            using (var cache = new TimeToLiveCache<long, List<TimeToLiveTestItem>>())
            {
                var options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = 64
                };

                Parallel.For(0, 10000, options, i =>
                {
                    var cacheItem = new TimeToLiveTestItem { Id = 1 };
                    Func<long, List<TimeToLiveTestItem>, List<TimeToLiveTestItem>> updater =
                    (k, items) =>
                    {
                        items.Add(cacheItem);
                        return items;
                    };

                    cache.AddOrUpdate(1, new List<TimeToLiveTestItem> { cacheItem }, updater);
                });
                Assert.AreEqual(expectedCount, cache.Count);
            }
        }

        [Test]
        public void CacheAddOrUpdateAppliesUpdateToItemsWhenMultiThreaded()
        {
            const int expectedCount = 10000;

            using (var cache = new TimeToLiveCache<long, List<TimeToLiveTestItem>>())
            {
                var options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = 64
                };

                Parallel.For(0, 10000, options, i =>
                {
                    var cacheItem = new TimeToLiveTestItem { Id = 1 };
                    Func<long, List<TimeToLiveTestItem>, List<TimeToLiveTestItem>> updater =
                    (k, items) =>
                    {
                        items.Add(cacheItem);
                        return items;
                    };

                    cache.AddOrUpdate(1, new List<TimeToLiveTestItem> { cacheItem }, updater);
                });

                var result = cache[1];

                Assert.AreEqual(expectedCount, result.Count);
            }
        }

        [Test]
        public void CacheEvictsAllItemsIfTimeoutReached()
        {
            using (var cache = new TimeToLiveCache<long, TimeToLiveTestItem>(300))
            {
                for (int i = 0; i < 10000; i++)
                {
                    cache.AddOrUpdate(i, new TimeToLiveTestItem { Id = i });
                }
                ManualResetEventSlim pause = new ManualResetEventSlim(false);
                Task.Factory.StartNew(() =>
                {
                    while (cache.Count != 0)
                    {
                        Thread.Sleep(10);
                    }
                    pause.Set();
                });
                //block until cache is empty
                pause.Wait(TimeSpan.FromSeconds(10));

                Assert.AreEqual(0, cache.Count);
            }
        }

        [Test]
        public void CacheEvictsAllItemsIfTimeoutReachedWhenMultiThreaded()
        {
            using (var cache = new TimeToLiveCache<long, TimeToLiveTestItem>(300))
            {
                var options = new ParallelOptions { MaxDegreeOfParallelism = 64 };

                Parallel.For(0, 10000, options, i =>
                {
                    cache.AddOrUpdate(i, new TimeToLiveTestItem { Id = i });
                });
                ManualResetEventSlim pause = new ManualResetEventSlim(false);
                Task.Factory.StartNew(() =>
                {
                    while (cache.Count != 0)
                    {
                        Thread.Sleep(10);
                    }
                    pause.Set();
                });
                //block until cache is empty
                pause.Wait(TimeSpan.FromSeconds(10));

                Assert.AreEqual(0, cache.Count);
            }
        }

        private class TimeToLiveTestItem
        {
            public long Id { get; set; }

            public string Name { get; set; }
        }
    }
}
