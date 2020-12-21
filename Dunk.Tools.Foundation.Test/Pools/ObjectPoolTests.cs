using System;
using System.Linq;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Pools;
using Dunk.Tools.Foundation.Test.Stubs;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Pools
{
    [TestFixture]
    public class ObjectPoolTests
    {
        [Test]
        public void ObjectPoolThrowsIfGeneratorIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ObjectPool<TestPoolObject>(null));
        }

        [Test]
        public void ObjectPoolInitialises()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new ObjectPool<TestPoolObject>(objGenerator);

            Assert.IsNotNull(pool);
        }

        [Test]
        public void ObjectPoolInitialisesEmptyByDefault()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new ObjectPool<TestPoolObject>(objGenerator);

            Assert.AreEqual(0, pool.PoolCount);
        }

        [Test]
        public void ObjectPoolInitialisesWithInitialCount()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new ObjectPool<TestPoolObject>(objGenerator, 10);

            Assert.AreEqual(10, pool.PoolCount);
        }

        [Test]
        public void ObjectPoolThrowsIfInitialSizeIsNegative()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            Assert.Throws<ArgumentOutOfRangeException>(() => new ObjectPool<TestPoolObject>(objGenerator, -1));
        }

        [Test]
        public void ObjectPoolGetsObjectFromPool()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new ObjectPool<TestPoolObject>(objGenerator, 10);

            var item = pool.GetObject();

            Assert.IsNotNull(item);
            Assert.AreEqual(9, pool.PoolCount);
        }

        [Test]
        public void ObjectPoolCreatesObjectIfPoolIsEmpty()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new ObjectPool<TestPoolObject>(objGenerator);

            var item = pool.GetObject();

            Assert.IsNotNull(item);
        }

        [Test]
        public void ObjectPoolReturnsObjectToPool()
        {
            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new ObjectPool<TestPoolObject>(objGenerator, 10);

            var item = pool.GetObject();
            pool.ReturnObjectToPool(item);

            Assert.AreEqual(10, pool.PoolCount);
        }

        [Test]
        public void ObjectPoolGetsObectsFromPoolMultiThreaded()
        {
            double?[] values = new double?[10000];

            Func<TestPoolObject> objGenerator = () => new TestPoolObject();
            var pool = new ObjectPool<TestPoolObject>(objGenerator, 10);

            Parallel.For(0, 10000, i =>
            {
                var item = pool.GetObject();
                values[i] = item.GetValue(i);
                pool.ReturnObjectToPool(item);
            });

            Assert.IsTrue(values.All(i => i.HasValue));
        }
    }
}
