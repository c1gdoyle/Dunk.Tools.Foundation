using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Threading;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Threading
{
    [TestFixture]
    public class AtomicBooleanTests
    {
        [Test]
        public void AtomicBooleanInitialisesWithExpectedDefault()
        {
            var b = new AtomicBoolean();

            Assert.IsFalse(b.Value);
            Assert.IsFalse(b);
        }

        [Test]
        public void AtomicBooleanInitialisesWithExpectedSpecifiedValue()
        {
            var b = new AtomicBoolean(true);

            Assert.IsTrue(b.Value);
            Assert.IsTrue(b);
        }

        [Test]
        public void AtomicBooleanToStringReturnsExpectedStringWhenTrue()
        {
            var b = new AtomicBoolean(true);

            Assert.AreEqual(true.ToString(), b.ToString());
        }

        [Test]
        public void AtomicBooleanToStringReturnsExpectedStringWhenFalse()
        {
            var b = new AtomicBoolean(false);

            Assert.AreEqual(false.ToString(), b.ToString());
        }

        [Test]
        public void AtomicBooleanSetsUnderlyingValue()
        {
            var b = new AtomicBoolean();

            for (int i = 0; i < 1000; i++)
            {
                b.Value = i % 2 == 0;
            }

            Assert.IsFalse(b.Value);
            Assert.IsFalse(b);
        }

        [Test]
        public void AtomicBooleanSetsUnderlyingValueMultiThreaded()
        {
            var b = new AtomicBoolean();

            System.Threading.Tasks.Parallel.For(0, 1000, i => b.Value = true);

            Assert.IsTrue(b.Value);
            Assert.IsTrue(b);
        }

        [Test]
        public void AtomicBooleanGetAndSetReturnsOriginalValue()
        {
            const int expected = 1000;

            ConcurrentCountedSet<bool> values = new ConcurrentCountedSet<bool>();

            var b = new AtomicBoolean();

            for (int i = 0; i < 1000; i++)
            {
                values.Add(b.GetAndSet(i % 2 == 0));
            }

            Assert.AreEqual(expected, values[true] + values[false]);
        }

        [Test]
        public void AtomicBooleanGetAndSetReturnsOriginalValueMultiThreaded()
        {
            const int expected = 1000;

            ConcurrentCountedSet<bool> values = new ConcurrentCountedSet<bool>();

            var b = new AtomicBoolean(true);

            System.Threading.Tasks.Parallel.For(0, 1000, i => values.Add(b.GetAndSet(i % 2 == 0)));

            Assert.AreEqual(expected, values[true] + values[false]);
        }

        [Test]
        public void AtomicBooleanCompareAndSetReturnsTrueIfComparisonMatches()
        {
            var b = new AtomicBoolean(true);

            bool result = b.CompareAndSet(true, false);

            Assert.IsTrue(result);
            Assert.IsFalse(b.Value);
            Assert.IsFalse(b);
        }

        [Test]
        public void AtomicBooleanCompareAndSetReturnsFalseIfComparisonDoesNotMatch()
        {
            var b = new AtomicBoolean(false);

            bool result = b.CompareAndSet(true, false);

            Assert.IsFalse(result);
            Assert.IsFalse(b.Value);
            Assert.IsFalse(b);
        }

        [Test]
        public void AtomicBooleanCompareAndSetReturnsExpectedValuesForMatches()
        {
            const int expected = 1000;

            var b = new AtomicBoolean();

            var values = new ConcurrentCountedSet<bool>();

            for(int i = 0; i < 1000; i++)
            {
                values.Add(b.CompareAndSet(i % 2 == 0, true));
            }

            Assert.AreEqual(expected, values[true] + values[false]);
        }

        [Test]
        public void AtomicBooleanCompareAndSetReturnsExpectedValuesForMatchesMultiThreaded()
        {
            const int expected = 1000;

            var b = new AtomicBoolean();

            var values = new ConcurrentCountedSet<bool>();

            System.Threading.Tasks.Parallel.For(0, 1000, i => values.Add(b.CompareAndSet(i % 2 == 0, true)));

            Assert.AreEqual(expected, values[true] + values[false]);
        }

        [Test]
        public void AtomicBooleanCompareAndSetReturnsExpectedValuesForFailedMatches()
        {
            const int expected = 1000;

            var b = new AtomicBoolean(true);

            var values = new ConcurrentCountedSet<bool>();

            for (int i = 0; i < 1000; i++)
            {
                values.Add(b.CompareAndSet(i % 2 != 0, false));
            }

            Assert.AreEqual(expected, values[true] + values[false]);
        }

        [Test]
        public void AtomicBooleanCompareAndSetReturnsExpectedValuesForFailedMatchesMultiThreaded()
        {
            const int expected = 1000;

            var b = new AtomicBoolean(true);

            var values = new ConcurrentCountedSet<bool>();

            System.Threading.Tasks.Parallel.For(0, 1000, i => values.Add(b.CompareAndSet(i % 2 != 0, false)));

            Assert.AreEqual(expected, values[true] + values[false]);
        }
    }
}
