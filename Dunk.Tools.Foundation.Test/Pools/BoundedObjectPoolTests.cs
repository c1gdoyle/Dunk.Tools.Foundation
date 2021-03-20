using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Pools;
using Dunk.Tools.Foundation.Test.Stubs;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Pools
{
    [TestFixture]
    public class BoundedObjectPoolTests
    {
        [Test]
        public void BoundedObjectPoolThrowsIfGeneratorIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new BoundedObjectPool<TestPoolObject>(null));
        }

        [Test]
        public void BoundedObjectPoolInitialises()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator);

            Assert.IsNotNull(pool);
        }

        [Test]
        public void BoundedObjectPoolsInitialisesWithDefaultMinimumSize()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator);

            Assert.AreEqual(5, pool.MinimumPoolSize);
        }

        [Test]
        public void BoundedObjectPoolInitialisesWithDefaultMaximumSize()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator);

            Assert.AreEqual(25, pool.MaximumPoolSize);
        }

        [Test]
        public void BoundedObjectPoolThrowsIfMinimumSizeIsLessThanZero()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            Assert.Throws<ArgumentException>(() => new BoundedObjectPool<TestPoolObject>(objGenerator, -1, 10));
        }

        [Test]
        public void BoundedObjectPoolThrowsIfMaximumSizeIsLessThanOne()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            Assert.Throws<ArgumentException>(() => new BoundedObjectPool<TestPoolObject>(objGenerator, 0, 0));
        }

        [Test]
        public void BoundedObjectPoolThrowsIfMinimumSizeIsGreaterThanMaximumSize()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            Assert.Throws<ArgumentException>(() => new BoundedObjectPool<TestPoolObject>(objGenerator, 10, 5));
        }

        [Test]
        public void BoundedObjectPoolInitialisesWithSpecifiedMinimumSize()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator, 5, 10);

            Assert.AreEqual(5, pool.MinimumPoolSize);
        }

        [Test]
        public void BoundedObjectPoolInitialisesWithSpecifiedMaximumSize()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator, 5, 10);

            Assert.AreEqual(10, pool.MaximumPoolSize);
        }

        [Test]
        public void BoundedObjectPoolGetsObjectFromPool()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator, 5, 10);

            var item = pool.GetObject();

            Assert.IsNotNull(item);
        }

        [Test]
        public void BoundedObjectPoolReturnObjectToPoolDoesNotExceedMaxSize()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator, 5, 10);

            var item = pool.GetObject();
            pool.ReturnObjectToPool(item);

            Assert.IsTrue(pool.PoolCount <= 10);
        }

        [Test]
        public void BoundedObjectPoolResetsObjectStateWhenReturningObjectToPool()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator, 5, 10);

            var item = pool.GetObject();
            pool.ReturnObjectToPool(item);

            Assert.IsTrue(item.StateReset);
        }

        [Test]
        public void BoundedObjectPoolReturnsMultipleObjectsToPoolDoesNotExceedMaxSize()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator, 5, 10);

            //simulate a collection of pool items to be returned
            TestPoolObject[] items = new TestPoolObject[10];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = objGenerator();
            }
            items.ToList().ForEach(i => pool.ReturnObjectToPool(i));

            Assert.IsTrue(pool.PoolCount <= 10);
        }

        [Test]
        public void BoundedObjectPoolReleasesResourcesForObjectsNotReAddedToPool()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator, 5, 10);

            //simulate a collection of pool items to be returned
            TestPoolObject[] items = new TestPoolObject[10];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = objGenerator();
            }
            items.ToList().ForEach(i => pool.ReturnObjectToPool(i));

            var itemsDestroyed = items.Where(i => i.ResourcesRelated);
            Assert.AreEqual(5, itemsDestroyed.Count());
        }

        [Test]
        public void BoundedObjectPoolGetsObjectFromPoolMultiThreaded()
        {
            double?[] values = new double?[10000];

            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator, 5, 10);

            Parallel.For(0, 10000, i =>
            {
                var item = pool.GetObject();
                values[i] = item.GetValue(i);
                pool.ReturnObjectToPool(item);
            });

            Assert.IsTrue(values.All(i => i.HasValue));
        }

        [Test]
        public void BoundedObjectPoolDoesNotExceedMaxSizeForMultiThreadedCalls()
        {
            double?[] values = new double?[10000];

            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator, 5, 10);

            var loopResult = Parallel.For(0, 10000, i =>
            {
                var item = pool.GetObject();
                values[i] = item.GetValue(i);
                pool.ReturnObjectToPool(item);
            });

            while (!loopResult.IsCompleted ||
                pool.PoolCount > 10)
            {
                Thread.Sleep(10);
            }

            Assert.IsTrue(pool.PoolCount <= 10);
        }

        [Test]
        public void BoundedObjectPoolGetsObjectFromPoolMultiThreadedWithBlockingOperations()
        {
            double?[] values = new double?[10000];

            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator, 5, 10);

            Parallel.For(0, 10000, i =>
            {
                var item = pool.GetObject();
                values[i] = item.GetValue(i);

                //simulate a blocking operation
                if (i % 1000 == 0)
                {
                    Thread.Sleep(100);
                }

                pool.ReturnObjectToPool(item);
            });

            Assert.IsTrue(values.All(i => i.HasValue));
        }

        [Test]
        public void BoundedObjectPoolDoesNotExceedMaxSizeForMultiThreadedCallsWithBlockingOperations()
        {
            double?[] values = new double?[10000];

            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new BoundedObjectPool<TestPoolObject>(objGenerator, 5, 10);

            var loopResult = Parallel.For(0, 10000, i =>
            {
                var item = pool.GetObject();
                values[i] = item.GetValue(i);

                //simulate a blocking operation
                if (i % 1000 == 0)
                {
                    Thread.Sleep(100);
                }

                pool.ReturnObjectToPool(item);
            });

            while(!loopResult.IsCompleted || 
                pool.PoolCount > 10)
            {
                Thread.Sleep(10);
            }

            Assert.IsTrue(pool.PoolCount <= 10);
        }
    }
}
