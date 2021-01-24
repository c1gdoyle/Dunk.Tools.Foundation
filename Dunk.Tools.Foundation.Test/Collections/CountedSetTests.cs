using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Collections;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class CountedSetTests
    {
        [Test]
        public void CountedSetIntialises()
        {
            var set = new CountedSet<string>();

            Assert.IsNotNull(set);
        }

        [Test]
        public void CountedSetInitialisesWithSpecifiedCollection()
        {
            var set = new CountedSet<string>(new[] { "foo", "foo", "bar" });

            Assert.IsNotNull(set);
            Assert.AreEqual(2, set.Count);
        }

        [Test]
        public void CountedSetInitialisesWithSpecifiedComparer()
        {
            var set = new CountedSet<string>(EqualityComparer<string>.Default);

            Assert.IsNotNull(set);
        }

        [Test]
        public void CountedSetThrowsIfCollectionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new CountedSet<string>(null as string[]));
        }

        [Test]
        public void CountedSetThrowsIfComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new CountedSet<string>(null as IEqualityComparer<string>));
        }

        [Test]
        public void CountedSetAddsItem()
        {
            var set = new CountedSet<string>();
            set.Add("foo");

            Assert.AreEqual(1, set.Count);
        }

        [Test]
        public void IfItemIsAddedToSetOnceAssociatedCountIsOne()
        {
            int count = 0;
            var set = new CountedSet<string>();

            set.Add("foo");
            set.TryGetCount("foo", out count);

            Assert.AreEqual(1, count);
        }

        [Test]
        public void IfItemIsAddedToSetMultipleTimesAssociatedCountIsIncreasedByOne()
        {
            int firstCount = 0;
            int secondCount = 0;
            int thirdCount = 0;

            var set = new CountedSet<string>();

            //add first time
            set.Add("foo");
            set.TryGetCount("foo", out firstCount);

            //add second time
            set.Add("foo");
            set.TryGetCount("foo", out secondCount);

            //add third time
            set.Add("foo");
            set.TryGetCount("foo", out thirdCount);

            Assert.AreEqual(1, firstCount);
            Assert.AreEqual(2, secondCount);
            Assert.AreEqual(3, thirdCount);

        }

        [Test]
        public void RemoveReturnsFalseIfSetDoesNotContainItem()
        {
            var set = new CountedSet<string>();
            bool result = set.Remove("foo");

            Assert.IsFalse(result);
        }

        [Test]
        public void RemoveReturnsTrueIfSetDoesNotContainItem()
        {
            var set = new CountedSet<string>();
            set.Add("foo");
            bool result = set.Remove("foo");

            Assert.IsTrue(result);
        }

        [Test]
        public void IfItemIsAddedToSetOnceRemoveCompletelyRemovesItem()
        {
            var set = new CountedSet<string>();

            set.Add("foo");
            set.Remove("foo");

            Assert.IsFalse(set.Contains("foo"));
        }

        [Test]
        public void IfItemIsAddedToSetMultipleTimesRemoveDoesNotCompletelyRemoveItem()
        {
            var set = new CountedSet<string>();

            set.Add("foo");
            set.Add("foo");
            set.Remove("foo");

            Assert.IsTrue(set.Contains("foo"));
        }

        [Test]
        public void IfItemIsAddedToSetMultipleTimesRemoveReducesCountByOne()
        {
            int firstCount = 0;
            int secondCount = 0;
            var set = new CountedSet<string>();

            set.Add("foo");
            set.Add("foo");

            set.TryGetCount("foo", out firstCount);

            set.Remove("foo");

            set.TryGetCount("foo", out secondCount);

            Assert.AreEqual(2, firstCount);
            Assert.AreEqual(1, secondCount);
        }

        [Test]
        public void IfItemIsAddedToSetMutlipleTimesItMustBeRemovedAnEqualNumberOfTimes()
        {
            bool firstCheck = false;
            bool secondCheck = false;
            bool thirdCheck = false;

            var set = new CountedSet<string>();

            set.Add("foo");
            set.Add("foo");
            set.Add("foo");

            set.Remove("foo");
            firstCheck = set.Contains("foo");
            set.Remove("foo");
            secondCheck = set.Contains("foo");
            set.Remove("foo");
            thirdCheck = set.Contains("foo");

            Assert.IsTrue(firstCheck);
            Assert.IsTrue(secondCheck);
            Assert.IsFalse(thirdCheck);
        }

        [Test]
        public void CountedSetMaintainsDistinctCountForDifferentItems()
        {
            int fooCount = 0;
            int barCount = 0;

            var set = new CountedSet<string>();

            set.Add("foo");
            set.Add("foo");
            set.Add("foo");
            set.Add("bar");
            set.Add("bar");

            set.TryGetCount("foo", out fooCount);
            set.TryGetCount("bar", out barCount);

            Assert.AreEqual(3, fooCount);
            Assert.AreEqual(2, barCount);
        }

        [Test]
        public void CountedSetSupportsLookupByKey()
        {
            var set = new CountedSet<string>();
            set.Add("foo");
            set.Add("foo");

            int count = set["foo"];

            Assert.AreEqual(2, count);
        }

        [Test]
        public void CountedSetSupportsGenericIteration()
        {
            var set = new CountedSet<string>(new[] { "foo", "foo", "foo", "bar", "bar"});

            Assert.DoesNotThrow(() =>
            {
                IEnumerator<string> enumerator = set.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    //ignore empty block
                }
            });
        }

        [Test]
        public void CountSetSupportsGenericIterationForExpectedNumberOfElements()
        {
            const int expected = 2;
            int count = 0;

            var set = new CountedSet<string>(new[] { "foo", "foo", "foo", "bar", "bar" });

            IEnumerator<string> enumerator = set.GetEnumerator();
            while (enumerator.MoveNext())
            {
                count++;
            }
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void CountedSetSupportsNonGenericIteration()
        {
            var set = new CountedSet<string>(new[] { "foo", "foo", "foo", "bar", "bar" });

            Assert.DoesNotThrow(() =>
            {
                System.Collections.IEnumerator enumerator = (set as System.Collections.IEnumerable).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    //ignore empty block
                }
            });
        }

        [Test]
        public void CountSetSupportsNonGenericIterationForExpectedNumberOfElements()
        {
            const int expected = 2;
            int count = 0;

            var set = new CountedSet<string>(new[] { "foo", "foo", "foo", "bar", "bar" });

            System.Collections.IEnumerator enumerator = (set as System.Collections.IEnumerable).GetEnumerator();
            while (enumerator.MoveNext())
            {
                count++;
            }
            Assert.AreEqual(expected, count);
        }
    }
}
