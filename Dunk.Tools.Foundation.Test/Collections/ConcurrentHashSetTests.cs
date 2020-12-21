using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Collections;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class ConcurrentHashSetTests
    {
        [Test]
        public void ConcurrentHashSetInitialises()
        {
            var set = new ConcurrentHashSet<string>();

            Assert.IsNotNull(set);
        }

        [Test]
        public void ConcurrentHashSetInitialisesEmptyByDefault()
        {
            var set = new ConcurrentHashSet<string>();

            Assert.AreEqual(0, set.Count);
        }

        [Test]
        public void ConcurrentHashSetIsNotReadOnly()
        {
            var set = new ConcurrentHashSet<string>();

            Assert.IsFalse(set.IsReadOnly);
        }

        [Test]
        public void ConcurrentHashSetThrowsIfEqualityComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ConcurrentHashSet<string>(null as IEqualityComparer<string>));
        }

        [Test]
        public void ConcurrentHashSetInitialisesWithCollection()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            Assert.IsNotNull(set);
        }

        [Test]
        public void ConcurrentHashSetAddsElementsFromCollectionToSet()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            Assert.AreEqual(items.Count, set.Count);
        }

        [Test]
        public void ConcurrentHashSetAddsUniqueElementsFromCollectionToSet()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            Assert.AreNotEqual(items.Count, set.Count);
            Assert.AreEqual(4, set.Count);
        }

        [Test]
        public void ConcurrentHashSetInitialiseWithCollectionThrowsIfComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ConcurrentHashSet<string>(new List<string>(), null as IEqualityComparer<string>));
        }

        [Test]
        public void ConcurrentHashSetInitialiseWithCollectionThrowsIfCollectionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ConcurrentHashSet<string>(null as IEnumerable<string>));
        }

        [Test]
        public void ConcurrentHashSetContainsReturnsTrueIfItemIsPresent()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            bool result = set.Contains("Frodo");

            Assert.IsTrue(result);
        }

        [Test]
        public void ConcurrentHashSetContainsReturnsFalseIfItemIsNotPresent()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            bool result = set.Contains("Gandalf");

            Assert.IsFalse(result);
        }

        [Test]
        public void ConcurrentHashSetAddsItemIfSetDoesNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            set.Add("Gandalf");

            Assert.AreEqual(5, set.Count);
        }

        [Test]
        public void ConcurrentHashSetDoesNotAddItemIfSetAlreadyContainsItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            set.Add("Frodo");

            Assert.AreEqual(4, set.Count);
        }

        [Test]
        public void ConcurrentHashSetRemovesItemIfUnderlyingSetDoesContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            set.Remove("Frodo");

            Assert.AreEqual(3, set.Count);
        }

        [Test]
        public void ConcurrentHashSetRemoveReturnsTrueIfUnderlyingSetContainedItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            bool result = set.Remove("Frodo");

            Assert.IsTrue(result);
        }

        [Test]
        public void ConcurrentHashSetDoesNotRemoveItemIfUnderlyingSetDoesNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            set.Remove("Gandalf");

            Assert.AreEqual(4, set.Count);
        }

        [Test]
        public void ConcurrentHashSetRemoveReturnsFalseIfUnderlyingSetDidNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            bool result = set.Remove("Gandalf");

            Assert.IsFalse(result);
        }

        [Test]
        public void ConcurrentHashSetClearRemovesAllItemsFromSet()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            set.Clear();

            Assert.IsEmpty(set);
        }

        [Test]
        public void ConcurrentHashSetSupportsIteration()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            var i = (set as IEnumerable<string>).GetEnumerator();

            Assert.DoesNotThrow(() =>
            {
                while (i.MoveNext())
                {
                    //iterate to end of hash-set
                }
            });
        }

        [Test]
        public void ConcurrentHashSetIteratesOverAllItems()
        {
            int count = 0;

            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            var i = (set as IEnumerable<string>).GetEnumerator();

            while (i.MoveNext())
            {
                count++;
            }
            Assert.AreEqual(4, count);
        }

        [Test]
        public void ConcurrentHashSetSupportsIterationForEmptySet()
        {
            var set = new ConcurrentHashSet<string>();

            var i = (set as IEnumerable<string>).GetEnumerator();

            Assert.DoesNotThrow(() =>
            {
                while (i.MoveNext())
                {
                    //iterate to end of hash-set
                }
            });
        }

        [Test]
        public void ConcurrentHashSetSupportsNonGenericIteration()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            var i = (set as System.Collections.IEnumerable).GetEnumerator();

            Assert.DoesNotThrow(() =>
            {
                while (i.MoveNext())
                {
                    //iterate to end of hash-set
                }
            });
        }

        [Test]
        public void ConcurrentHashSetNonGenericIteratesOverAllItems()
        {
            int count = 0;

            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            var i = (set as System.Collections.IEnumerable).GetEnumerator();

            while (i.MoveNext())
            {
                count++;
            }
            Assert.AreEqual(4, count);
        }

        [Test]
        public void ConcurrentHashSetSupportsNonGenericIterationForEmptySet()
        {
            var set = new ConcurrentHashSet<string>();

            var i = (set as System.Collections.IEnumerable).GetEnumerator();

            Assert.DoesNotThrow(() =>
            {
                while (i.MoveNext())
                {
                    //iterate to end of hash-set
                }
            });
        }

        [Test]
        public void ConcurrentHashSetCopyToArrayCopiesItemsToArray()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            string[] array = new string[4];

            set.CopyTo(array, 0);

            array.ToList().ForEach(i =>
            {
                Assert.IsNotNull(i);
            });
        }

        [Test]
        public void ConcurrentHashSetTryAddAddsIfSetDoesNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            set.TryAdd("Gandalf");

            Assert.IsTrue(set.Contains("Gandalf"));
            Assert.AreEqual(5, set.Count);
        }

        [Test]
        public void ConcurrentHashSetTryAddReturnsTrueIfSetDoesNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            bool result = set.TryAdd("Gandalf");

            Assert.IsTrue(result);
        }

        [Test]
        public void ConcurrentHashSetTryAddDoesNotAddIfSetContainsItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            set.TryAdd("Sam");

            Assert.IsTrue(set.Contains("Sam"));
            Assert.AreEqual(4, set.Count);
        }

        [Test]
        public void ConcurrentHashSetTryAddReturnsFalseIfSetDoesContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            bool result = set.TryAdd("Sam");

            Assert.IsFalse(result);
        }

        [Test]
        public void ConcurrentHashSetTryAddAddsEachUniqueItemOnlyOnce()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var itemsToAdd = new List<string> { "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            int successfulAddCount = 0;

            var set = new ConcurrentHashSet<string>(items);

            for (int i = 0; i < 10000; i++)
            {
                if (set.TryAdd(itemsToAdd[i % 5]))
                {
                    successfulAddCount++;
                }
            }

            Assert.AreEqual(9, set.Count);
            Assert.AreEqual(5, successfulAddCount);
        }

        [Test]
        public void ConcurrentHashSetTryAddAddsEachUniqueItemOnlyOnceMultiThreaded()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var itemsToAdd = new List<string> { "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            int successfulAddCount = 0;

            var set = new ConcurrentHashSet<string>(items);

            var status = Parallel.For(0, 10000, i =>
            {
                if (set.TryAdd(itemsToAdd[i % 5]))
                {
                    Interlocked.Increment(ref successfulAddCount);
                }
            });

            while (!status.IsCompleted)
            {
                Thread.Sleep(5);
            }

            Assert.AreEqual(9, set.Count);
            Assert.AreEqual(5, successfulAddCount);
        }

        [Test]
        public void ConcurrentHashSetTryRemoveRemovesIfSetContainsItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            set.TryRemove("Frodo");

            Assert.IsFalse(set.Contains("Frodo"));
            Assert.AreEqual(3, set.Count);
        }

        [Test]
        public void ConcurrentHashSetTryRemoveReturnsTrueIfSetContainsItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            bool result = set.TryRemove("Frodo");

            Assert.IsTrue(result);
        }

        [Test]
        public void ConcurrentHashSetTryRemoveDoesNotRemoveIfSetDiesNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            set.TryRemove("Gandalf");

            Assert.AreEqual(4, set.Count);
        }

        [Test]
        public void ConcurrentHashSetTryRemoveReturnsFalseIfSetDoesNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var set = new ConcurrentHashSet<string>(items);

            bool result = set.TryRemove("Gandalf");

            Assert.IsFalse(result);
        }

        [Test]
        public void ConcurrentHashSetTryRemoveRemovesEachUniqueItemOnlyOnce()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin", "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            var itemsToRemove = new List<string> { "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            int successfulRemoveCount = 0;

            var set = new ConcurrentHashSet<string>(items);

            for (int i = 0; i < 10000; i++)
            {
                if (set.TryRemove(itemsToRemove[i % 5]))
                {
                    successfulRemoveCount++;
                }
            }

            Assert.AreEqual(4, set.Count);
            Assert.AreEqual(5, successfulRemoveCount);
        }

        [Test]
        public void ConcurrentHashSetTryRemoveRemovesEachUniqueItemOnlyOnceMultiThreaded()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin", "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            var itemsToRemove = new List<string> { "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            int successfulRemoveCount = 0;

            var set = new ConcurrentHashSet<string>(items);

            var status = Parallel.For(0, 10000, i =>
            {
                if (set.TryRemove(itemsToRemove[i % 5]))
                {
                    Interlocked.Increment(ref successfulRemoveCount);
                }
            });

            while (!status.IsCompleted)
            {
                Thread.Sleep(5);
            }

            Assert.AreEqual(4, set.Count);
            Assert.AreEqual(5, successfulRemoveCount);
        }
    }

}
