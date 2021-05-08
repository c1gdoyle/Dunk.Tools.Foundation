using Dunk.Tools.Foundation.Threading;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Threading
{
    [TestFixture]
    public class AtomicInt32Tests
    {
        [Test]
        public void AtomicInt32InitialisesWithDefaultValue()
        {
            const int expected = 0;

            var i = new AtomicInt32();

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32InitialisesWithSpecifiedvalue()
        {
            const int expected = 47;

            var i = new AtomicInt32(expected);

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32ToStringReturnsExpectedStringForDefault()
        {
            const int expected = 0;

            var i = new AtomicInt32();

            Assert.AreEqual(expected.ToString(), i.ToString());
        }

        [Test]
        public void AtomicInt32ToStringReturnsExpectedStringForSpecified()
        {
            const int expected = 47;

            var i = new AtomicInt32(expected);

            Assert.AreEqual(expected.ToString(), i.ToString());
        }

        [Test]
        public void AtomicInt32SupportsPostIncrement()
        {
            const int expected = 1000;

            var i = new AtomicInt32();

            for(int j = 0; j < expected; j++)
            {
                i.PostIncrement();
            }

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32SupportsPreIncrement()
        {
            const int expected = 1000;

            var i = new AtomicInt32();

            for (int j = 0; j < expected; j++)
            {
                i.PreIncrement();
            }

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32SupportsPostIncrementMultiThreaded()
        {
            const int expected = 1000;

            var i = new AtomicInt32();

            System.Threading.Tasks.Parallel.For(0, expected, j => i.PostIncrement());

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32SupportsPreIncrementMultiThreaded()
        {
            const int expected = 1000;

            var i = new AtomicInt32();

            System.Threading.Tasks.Parallel.For(0, expected, j => i.PreIncrement());

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32SupportsPostDecrement()
        {
            const int expected = 0;

            var i = new AtomicInt32();
            i.Set(1000);

            for (int j = 0; j < 1000; j++)
            {
                i.PostDecrement();
            }

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32SupportsPreDecrement()
        {
            const int expected = 0;

            var i = new AtomicInt32();
            i.Set(1000);

            for (int j = 0; j < 1000; j++)
            {
                i.PreDecrement();
            }

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32SupportsPostDecrementMultiThreaded()
        {
            const int expected = 0;

            var i = new AtomicInt32();
            i.Set(1000);

            System.Threading.Tasks.Parallel.For(0, 1000, j => i.PostDecrement());

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32SupportsPreDecrementMultiThreaded()
        {
            const int expected = 0;

            var i = new AtomicInt32();
            i.Set(1000);

            System.Threading.Tasks.Parallel.For(0, 1000, j => i.PreDecrement());

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32SupportsGetAndAdd()
        {
            const int expected = 1000;

            var i = new AtomicInt32();

            for(int j = 0; j < expected; j++)
            {
                i.GetAndAdd(1);
            }

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32SupportsGetAndAddNegatives()
        {
            const int expected = 0;

            var i = new AtomicInt32();
            i.GetAndSet(1000);

            for (int j = 0; j < 1000; j++)
            {
                i.GetAndAdd(-1);
            }

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32SupportsGetAndAddNegativesMultiThreaded()
        {
            const int expected = 1000;

            var i = new AtomicInt32();

            System.Threading.Tasks.Parallel.For(0, expected, j => i.GetAndAdd(1));

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }

        [Test]
        public void AtomicInt32SupportsGetAndAddMultiThreaded()
        {
            const int expected = 0;

            var i = new AtomicInt32();
            i.GetAndSet(1000);

            System.Threading.Tasks.Parallel.For(0, 1000, j => i.GetAndAdd(-1));

            Assert.AreEqual(expected, (int)i);
            Assert.AreEqual(expected, i.Get());
        }
    }
}
