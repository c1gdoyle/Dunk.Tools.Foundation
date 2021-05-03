using System;
using System.Collections.Generic;
using System.Threading;
using Dunk.Tools.Foundation.Collections;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class ConcurrentCountedSetTests
    {
        [Test]
        public void CountedSetIntialises()
        {
            var set = new CountedSet<string>();

            Assert.IsNotNull(set);
        }

        [Test]
        public void ConcurrentCountedSetInitialisesWithSpecifiedCollection()
        {
            var set = new ConcurrentCountedSet<string>(new[] { "foo", "foo", "bar" });

            Assert.IsNotNull(set);
            Assert.AreEqual(2, set.Count);
        }

        [Test]
        public void ConcurrentCountedSetInitialisesWithSpecifiedComparer()
        {
            var set = new ConcurrentCountedSet<string>(EqualityComparer<string>.Default);

            Assert.IsNotNull(set);
        }

        [Test]
        public void ConcurrentCountedSetInitialisesAsNotReadOnly()
        {
            var set = new ConcurrentCountedSet<string>();

            Assert.IsFalse(set.IsReadOnly);
        }

        [Test]
        public void ConcurrentCountedSetThrowsIfCollectionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new ConcurrentCountedSet<string>(null as string[]));
        }

        [Test]
        public void ConcurrentCountedSetThrowsIfComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new ConcurrentCountedSet<string>(null as IEqualityComparer<string>));
        }

        [Test]
        public void ConcurrentCountedSetAddsItem()
        {
            var set = new ConcurrentCountedSet<string>();
            set.Add("foo");

            Assert.AreEqual(1, set.Count);
        }

        [Test]
        public void IfItemIsAddedToSetOnceAssociatedCountIsOne()
        {
            int count = 0;
            var set = new ConcurrentCountedSet<string>();

            set.Add("foo");
            set.TryGetCount("foo", out count);

            Assert.AreEqual(1, count);
        }

        [Test]
        public void IfItemIsAddedToSetMultipleTimesAssociatedCountIsIncreasedByOne()
        {
            int firstCount;
            int secondCount;
            int thirdCount;

            var set = new ConcurrentCountedSet<string>();

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
            var set = new ConcurrentCountedSet<string>();
            bool result = set.Remove("foo");

            Assert.IsFalse(result);
        }

        [Test]
        public void RemoveReturnsTrueIfSetDoesNotContainItem()
        {
            var set = new ConcurrentCountedSet<string>();
            set.Add("foo");
            bool result = set.Remove("foo");

            Assert.IsTrue(result);
        }

        [Test]
        public void IfItemIsAddedToSetOnceRemoveCompletelyRemovesItem()
        {
            var set = new ConcurrentCountedSet<string>();

            set.Add("foo");
            set.Remove("foo");

            Assert.IsFalse(set.Contains("foo"));
        }

        [Test]
        public void IfItemIsAddedToSetMultipleTimesRemoveDoesNotCompletelyRemoveItem()
        {
            var set = new ConcurrentCountedSet<string>();

            set.Add("foo");
            set.Add("foo");
            set.Remove("foo");

            Assert.IsTrue(set.Contains("foo"));
        }

        [Test]
        public void IfItemIsAddedToSetMultipleTimesRemoveReducesCountByOne()
        {
            int firstCount;
            int secondCount;
            var set = new ConcurrentCountedSet<string>();

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
            bool firstCheck;
            bool secondCheck;
            bool thirdCheck;

            var set = new ConcurrentCountedSet<string>();

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
        public void ConcurrentCountedSetMaintainsDistinctCountForDifferentItems()
        {
            int fooCount;
            int barCount;

            var set = new ConcurrentCountedSet<string>();

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
        public void ConcurrentCountedSetTryGetCountReturnsFalseIfItemIsNotPresent()
        {
            var set = new ConcurrentCountedSet<string>();

            bool result = set.TryGetCount("foo", out _);

            Assert.IsFalse(result);
        }

        [Test]
        public void ConcurrentCountedSetTryGetCountReturnsZeroIfItemIsNotPresent()
        {
            var set = new ConcurrentCountedSet<string>();

            int count;
            Assert.IsFalse(set.TryGetCount("foo", out count));
            Assert.AreEqual(0, count);
        }

        [Test]
        public void ConcurrentCountedSetClearEmptiesSet()
        {
            var set = new ConcurrentCountedSet<string>(new[] { "foo", "foo", "bar" });
            set.Clear();

            Assert.IsEmpty(set);
        }

        [Test]
        public void ConcurrentCountedSetMaintainsDistinctCountForDifferentItemsInLoop()
        {
            var set = new ConcurrentCountedSet<string>();

            for(int i = 0; i < 1000; i++)
            {
                if(i % 2 == 0)
                {
                    set.Add("foo");
                }
                else
                {
                    set.Add("bar");
                }
            }

            Assert.AreEqual(500, set["foo"]);
            Assert.AreEqual(500, set["bar"]);
        }

        [Test]
        public void ConcurrentCountedSetMaintainsDistinctCountForDifferentItemsInLoopMultiThreaded()
        {
            var set = new ConcurrentCountedSet<string>();

            System.Threading.Tasks.Parallel.For(0, 1000, i =>
            {
                if (i % 2 == 0)
                {
                    set.Add("foo");
                }
                else
                {
                    set.Add("bar");
                }
            });

            Assert.AreEqual(500, set["foo"]);
            Assert.AreEqual(500, set["bar"]);
        }

        [Test]
        public void ConcurrentCountedSetDoesNotRemoveItemIfCountIsGreaterThanZero()
        {
            const int expected = 1;

            var set = new ConcurrentCountedSet<string>();

            for (int i = 0; i < 1000; i++)
            {
                set.Add("bar");
            }

            for (int i = 0; i < 999; i++)
            {
                set.Remove("bar");
            }

            int currentCount;
            Assert.IsTrue(set.TryGetCount("bar", out currentCount));
            Assert.AreEqual(expected, currentCount);
        }

        [Test]
        public void ConcurrentCountedSetDoesNotRemoveItemIfCountIsGreaterThanZeroMultiThreaded()
        {
            const int expected = 1;

            var set = new ConcurrentCountedSet<string>();

            for (int i = 0; i < 1000; i++)
            {
                set.Add("bar");
            }

            System.Threading.Tasks.Parallel.For(0, 999, i =>
            {
                set.Remove("bar");
            });

            int currentCount;
            Assert.IsTrue(set.TryGetCount("bar", out currentCount));
            Assert.AreEqual(expected, currentCount);
        }

        [Test]
        public void ConcurrentCountedSetRemovesItemOnceCountReducedToZero()
        {
            int removeCount = 0;

            var set = new ConcurrentCountedSet<string>();

            for (int i = 0; i < 1000; i++)
            {
                set.Add("bar");
            }

            for(int i = 0; i < 1000; i++)
            {
                if (set.Remove("bar"))
                {
                    removeCount = Interlocked.Increment(ref removeCount);
                }
            }

            Assert.AreEqual(1000, removeCount);
            Assert.IsFalse(set.Contains("bar"));
        }

        [Test]
        public void ConcurrentCountedSetRemovesItemOnceCountReducedToZeroMultiThreaded()
        {
            var set = new ConcurrentCountedSet<string>();

            for (int i = 0; i < 1000; i++)
            {
                set.Add("bar");
            }

            System.Threading.Tasks.Parallel.For(0, 1000, i =>
            {
                set.Remove("bar");
            });

            Assert.IsFalse(set.Contains("bar"));
        }

        [Test]
        public void ConcurrentCountedSetSupportsLookupByKey()
        {
            var set = new ConcurrentCountedSet<string>();
            set.Add("foo");
            set.Add("foo");

            int count = set["foo"];

            Assert.AreEqual(2, count);
        }

        [Test]
        public void ConcurrentCountedSetSupportsGenericIteration()
        {
            var set = new ConcurrentCountedSet<string>(new[] { "foo", "foo", "foo", "bar", "bar" });

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

            var set = new ConcurrentCountedSet<string>(new[] { "foo", "foo", "foo", "bar", "bar" });

            IEnumerator<string> enumerator = set.GetEnumerator();
            while (enumerator.MoveNext())
            {
                count++;
            }
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void ConcurrentCountedSetSupportsNonGenericIteration()
        {
            var set = new ConcurrentCountedSet<string>(new[] { "foo", "foo", "foo", "bar", "bar" });

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
        public void ConcurrentCountedSetSupportsNonGenericIterationForExpectedNumberOfElements()
        {
            const int expected = 2;
            int count = 0;

            var set = new ConcurrentCountedSet<string>(new[] { "foo", "foo", "foo", "bar", "bar" });

            System.Collections.IEnumerator enumerator = (set as System.Collections.IEnumerable).GetEnumerator();
            while (enumerator.MoveNext())
            {
                count++;
            }
            Assert.AreEqual(expected, count);
        }
    }
}
