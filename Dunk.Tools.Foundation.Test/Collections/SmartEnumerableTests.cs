using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Collections;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class SmartEnumerableTests
    {
        [Test]
        public void SmartEnumerableInitialises()
        {
            IList<string> inner = new List<string> { "a", "b", "c" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);

            Assert.IsNotNull(smart);
        }

        [Test]
        public void SmartEnumerableThrowsIfInnerEnumerableIsNull()
        {
            IList<string> inner = null;

            Assert.Throws<ArgumentNullException>(() => new SmartEnumerable<string>(inner));
        }

        [Test]
        public void SmartEnumerableInitialisesWithEmptyCollection()
        {
            IList<string> inner = new List<string>();

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);

            Assert.IsNotNull(smart);
        }

        [Test]
        public void SmartEnumerableDoesNotIterateForEmptyCollection()
        {
            IList<string> inner = new List<string>();

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                Assert.IsFalse(iterator.MoveNext());
            }
        }

        [Test]
        public void SmartEnumerableIteratesForCollectionWithSingleEntry()
        {
            List<string> inner = new List<string> { "a" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                iterator.MoveNext();

                var current = iterator.Current;
                Assert.IsNotNull(current);
            }
        }

        [Test]
        public void SmartEnumerableForCollectionWithOneEntryStopsIterating()
        {
            List<string> inner = new List<string> { "a" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                iterator.MoveNext();

                var current = iterator.Current;
                
                Assert.IsNotNull(current);
                Assert.IsFalse(iterator.MoveNext());
            }
        }

        [Test]
        public void SmartEnumerableIteratorReturnsSingleEntryWithExpectedValue()
        {
            const string expected = "a";

            List<string> inner = new List<string> { "a" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                iterator.MoveNext();

                var current = iterator.Current;

                Assert.AreEqual(expected, current.Value);
            }
        }

        [Test]
        public void SmartEnumerableIteratorReturnsSingleEntryWithExpectedIndex()
        {
            const int expected = 0;

            List<string> inner = new List<string> { "a" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                iterator.MoveNext();

                var current = iterator.Current;

                Assert.AreEqual(expected, current.Index);
            }
        }

        [Test]
        public void SmartEnumerableIteratorReturnsSingleEntryThatIsFirstAndLastEntry()
        {

            List<string> inner = new List<string> { "a" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                iterator.MoveNext();

                var current = iterator.Current;

                Assert.IsTrue(current.IsFirst);
                Assert.IsTrue(current.IsLast);
            }
        }

        [Test]
        public void SmartEnumerableIteratesForCollectionWithMoreThanOneEntry()
        {
            List<string> inner = new List<string> { "a", "b" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                iterator.MoveNext();
                iterator.MoveNext();

                var current = iterator.Current;

                Assert.IsNotNull(current);
            }
        }

        [Test]
        public void SmartEnumerableForCollectionWithMoreThanOneEntryStopsIterating()
        {
            List<string> inner = new List<string> { "a", "b" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                iterator.MoveNext();
                iterator.MoveNext();

                Assert.IsFalse(iterator.MoveNext());
            }
        }

        [Test]
        public void SmartEnumerableIteratorForCollectionWithMoreThanOneEntryReturnsEntryThatIsFirstButNotLast()
        {
            List<string> inner = new List<string> { "a", "b" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                iterator.MoveNext();

                var first = iterator.Current;

                Assert.IsTrue(first.IsFirst);
                Assert.IsFalse(first.IsLast);
            }
        }

        [Test]
        public void SmartEnumerableIteratorWithMoreThanOneEntryReturnsFirstEntryWithExpectedIndex()
        {
            List<string> inner = new List<string> { "a", "b" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                iterator.MoveNext();

                var first = iterator.Current;

                Assert.AreEqual(0, first.Index);
            }
        }

        [Test]
        public void SmartEnumerableIteratorWithMoreThanOneEntryReturnsEntryThatIsLastButNotFirst()
        {
            List<string> inner = new List<string> { "a", "b" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                iterator.MoveNext();
                iterator.MoveNext();

                var last = iterator.Current;

                Assert.IsTrue(last.IsLast);
                Assert.IsFalse(last.IsFirst);
            }
        }

        [Test]
        public void SmartEnumerableIteratorWithMoreThanOneEntryReturnsLastEntryWithExpectedIndex()
        {
            const int expected = 1;

            List<string> inner = new List<string> { "a", "b" };

            SmartEnumerable<string> smart = new SmartEnumerable<string>(inner);
            using (IEnumerator<SmartEnumerable<string>.Entry> iterator = smart.GetEnumerator())
            {
                iterator.MoveNext();
                iterator.MoveNext();

                var last = iterator.Current;

                Assert.AreEqual(expected, last.Index);
            }
        }
    }
}
