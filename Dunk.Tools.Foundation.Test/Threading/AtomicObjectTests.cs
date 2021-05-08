using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Threading;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Threading
{
    [TestFixture]
    public class AtomicObjectTests
    {
        [Test]
        public void AtomicObjectInitialisesWithExpectedNullDefault()
        {
            var o = new AtomicObject<string>();

            Assert.IsNull(o.Value);
            Assert.IsNull((string)o);
        }

        [Test]
        public void AtomicObjectInitialisesWithExpectedSpecifiedValue()
        {
            const string expected = "foo";

            var o = new AtomicObject<string>(expected);

            Assert.AreEqual(expected, o.Value);
            Assert.AreEqual(expected, (string)o);
        }

        [Test]
        public void AtomicObjectToStringReturnsExpectedStringWithDefault()
        {
            var o = new AtomicObject<string>();

            Assert.AreEqual(string.Empty, o.ToString());
        }

        [Test]
        public void AtomicObjectToStringReturnsExpectedStringWithSpecifiedValue()
        {
            const string expected = "foo";

            var o = new AtomicObject<string>(expected);

            Assert.AreEqual(expected, o.ToString());
        }

        [Test]
        public void AtomicObjectSetsUnderlyingValue()
        {
            const string expected = "999";

            var o = new AtomicObject<string>();

            for (int i = 0; i < 1000; i++)
            {
                o.Value = i.ToString();
            }

            Assert.AreEqual(expected, o.Value);
            Assert.AreEqual(expected, (string)o);
        }

        [Test]
        public void AtomicObjectSetsUnderlyingValueMultiThreaded()
        {
            var o = new AtomicObject<string>();

            System.Threading.Tasks.Parallel.For(0, 1000, i => o.Value = i.ToString());

            Assert.IsNotNull(o.Value);
            Assert.IsNotNull((string)o);
        }

        [Test]
        public void AtomicObjectGetAndSetReturnsOriginalValue()
        {
            const int expected = 1000;

            ConcurrentCountedSet<string> values = new ConcurrentCountedSet<string>();

            var o = new AtomicObject<string>("foo");

            for (int i = 0; i < 1000; i++)
            {
                values.Add(o.GetAndSet(i % 2 == 0 ? "bar" : "foo"));
            }

            Assert.AreEqual(expected, values["foo"] + values["bar"]);
        }

        [Test]
        public void AtomicObjectGetAndSetReturnsOriginalValueMultiThreaded()
        {
            const int expected = 1000;

            ConcurrentCountedSet<string> values = new ConcurrentCountedSet<string>();

            var o = new AtomicObject<string>("foo");

            System.Threading.Tasks.Parallel.For(0, 1000, i => values.Add(o.GetAndSet(i % 2 == 0 ? "bar" : "foo")));

            Assert.AreEqual(expected, values["foo"] + values["bar"]);
        }

        [Test]
        public void AtomicObjectCompareAndSetReturnsTrueIfComparisonMatches()
        {
            var o = new AtomicObject<string>("foo");

            bool result = o.CompareAndSet("foo", "bar");

            Assert.IsTrue(result);
            Assert.AreEqual("bar", o.Value);
            Assert.AreEqual("bar", (string)o);
        }

        [Test]
        public void AtomicObjectCompareAndSetReturnsFalseIfComparisonDoesNotMatch()
        {
            var o = new AtomicObject<string>("bar");

            bool result = o.CompareAndSet("foo", "bar");

            Assert.IsFalse(result);
            Assert.AreEqual("bar", o.Value);
            Assert.AreEqual("bar", (string)o);
        }

        [Test]
        public void AtomicObjectCompareAndSetReturnsExpectedValuesForMatches()
        {
            const int expected = 1000;

            var o = new AtomicObject<string>("bar");

            var values = new ConcurrentCountedSet<bool>();

            for (int i = 0; i < 1000; i++)
            {
                values.Add(o.CompareAndSet(i % 2 == 0 ? "bar" : "foo", "bar"));
            }

            Assert.AreEqual(expected, values[true] + values[false]);
        }

        [Test]
        public void AtomicObjectCompareAndSetReturnsExpectedValuesForMatchesMultiThreaded()
        {
            const int expected = 1000;

            var o = new AtomicObject<string>("bar");

            var values = new ConcurrentCountedSet<bool>();

            System.Threading.Tasks.Parallel.For(0, 1000, i => values.Add(o.CompareAndSet(i % 2 == 0 ? "bar" : "foo", "bar")));

            Assert.AreEqual(expected, values[true] + values[false]);
        }

        [Test]
        public void AtomicObjectCompareAndSetReturnsExpectedValuesForFailedMatches()
        {
            const int expected = 1000;

            var o = new AtomicObject<string>("foo");

            var values = new ConcurrentCountedSet<bool>();

            for (int i = 0; i < 1000; i++)
            {
                values.Add(o.CompareAndSet(i % 2 == 0 ? "bar" : "foo", "bar"));
            }

            Assert.AreEqual(expected, values[true] + values[false]);
        }

        [Test]
        public void AtomicObjectCompareAndSetReturnsExpectedValuesForFailedMatchesMultiThreaded()
        {
            const int expected = 1000;

            var o = new AtomicObject<string>("foo");

            var values = new ConcurrentCountedSet<bool>();

            System.Threading.Tasks.Parallel.For(0, 1000, i => values.Add(o.CompareAndSet(i % 2 == 0 ? "bar" : "foo", "bar")));

            Assert.AreEqual(expected, values[true] + values[false]);
        }
    }
}
