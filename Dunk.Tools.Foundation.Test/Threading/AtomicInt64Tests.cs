using Dunk.Tools.Foundation.Threading;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Threading
{
    [TestFixture]
    public class AtomicInt64Tests
    {
        [Test]
        public void AtomicInt64InitialisesWithDefaultValue()
        {
            const long expected = 0;

            var i = new AtomicInt64();

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64InitialisesWithSpecifiedvalue()
        {
            const long expected = 47;

            var i = new AtomicInt64(expected);

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsPostIncrement()
        {
            const long expected = 1000;

            var i = new AtomicInt64();

            for (int j = 0; j < expected; j++)
            {
                i.PostIncrement();
            }

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsPreIncrement()
        {
            const long expected = 1000;

            var i = new AtomicInt64();

            for (int j = 0; j < expected; j++)
            {
                i.PreIncrement();
            }

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsPostIncrementMultiThreaded()
        {
            const long expected = 1000;

            var i = new AtomicInt64();

            System.Threading.Tasks.Parallel.For(0, expected, j => i.PostIncrement());

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsPreIncrementMultiThreaded()
        {
            const long expected = 1000;

            var i = new AtomicInt64();

            System.Threading.Tasks.Parallel.For(0, expected, j => i.PreIncrement());

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsPostDecrement()
        {
            const long expected = 0;

            var i = new AtomicInt64();
            i.Set(1000);

            for (int j = 0; j < 1000; j++)
            {
                i.PostDecrement();
            }

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsPreDecrement()
        {
            const long expected = 0;

            var i = new AtomicInt64();
            i.Set(1000);

            for (int j = 0; j < 1000; j++)
            {
                i.PreDecrement();
            }

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsPostDecrementMultiThreaded()
        {
            const long expected = 0;

            var i = new AtomicInt64();
            i.Set(1000);

            System.Threading.Tasks.Parallel.For(0, 1000, j => i.PostDecrement());

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsPreDecrementMultiThreaded()
        {
            const long expected = 0;

            var i = new AtomicInt64();
            i.Set(1000);

            System.Threading.Tasks.Parallel.For(0, 1000, j => i.PreDecrement());

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsGetAndAdd()
        {
            const long expected = 1000;

            var i = new AtomicInt64();

            for (int j = 0; j < expected; j++)
            {
                i.GetAndAdd(1);
            }

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsGetAndAddNegatives()
        {
            const long expected = 0;

            var i = new AtomicInt64();
            i.GetAndSet(1000);

            for (int j = 0; j < 1000; j++)
            {
                i.GetAndAdd(-1);
            }

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsGetAndAddNegativesMultiThreaded()
        {
            const long expected = 1000;

            var i = new AtomicInt64();

            System.Threading.Tasks.Parallel.For(0, expected, j => i.GetAndAdd(1));

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt64SupportsGetAndAddMultiThreaded()
        {
            const long expected = 0;

            var i = new AtomicInt64();
            i.GetAndSet(1000);

            System.Threading.Tasks.Parallel.For(0, 1000, j => i.GetAndAdd(-1));

            Assert.AreEqual(expected, (long)i);
            Assert.AreEqual(expected, i.Get());
        }
    }
}
