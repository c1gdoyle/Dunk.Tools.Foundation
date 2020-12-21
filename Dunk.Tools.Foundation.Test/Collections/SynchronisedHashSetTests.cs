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
    public class SynchronisedHashSetTests
    {
        [Test]
        public void SynchronisedHashSetInitialises()
        {
            using (var set = new SynchronisedHashSet<string>())
            {
                Assert.IsNotNull(set);
            }
        }

        [Test]
        public void SynchronisedHashSetInitialisesEmptyByDefault()
        {
            using (var set = new SynchronisedHashSet<string>())
            {
                Assert.AreEqual(0, set.Count);
            }
        }

        [Test]
        public void SynchronisedHashSetIsNotReadOnly()
        {
            using (var set = new SynchronisedHashSet<string>())
            {
                Assert.IsFalse(set.IsReadOnly);
            }
        }

        [Test]
        public void SynchronisedHashSetThrowsIfEqualityComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SynchronisedHashSet<string>(null as IEqualityComparer<string>));
        }

        [Test]
        public void SynchronisedHashSetInitialisesWithCollection()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                Assert.IsNotNull(set);
            }
        }

        [Test]
        public void SynchronisedHashSetAddsElementsFromCollectionToSet()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                Assert.AreEqual(items.Count, set.Count);
            }
        }

        [Test]
        public void SynchronisedHashSetAddsUniqueElementsFromCollectionToSet()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                Assert.AreNotEqual(items.Count, set.Count);
                Assert.AreEqual(4, set.Count);
            }
        }

        [Test]
        public void SynchronisedHashSetInitialiseWithCollectionThrowsIfComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SynchronisedHashSet<string>(new List<string>(), null as IEqualityComparer<string>));
        }

        [Test]
        public void SynchronisedHashSetInitialiseWithCollectionThrowsIfCollectionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SynchronisedHashSet<string>(null as IEnumerable<string>));
        }

        [Test]
        public void SynchronisedHashSetContainsReturnsTrueIfItemIsPresentInUnderlyingSet()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                bool result = set.Contains("Frodo");

                Assert.IsTrue(result);
            }
        }

        [Test]
        public void SynchronisedHashSetContainsReturnsFalseIfItemIsNotPresentInUnderlyingSet()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                bool result = set.Contains("Gandalf");

                Assert.IsFalse(result);
            }
        }

        [Test]
        public void SynchronisedHashSetAddsItemIfUnderlyingSetDoesNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                set.Add("Gandalf");

                Assert.AreEqual(5, set.Count);
            }
        }

        [Test]
        public void SynchronisedHashSetDoesNotAddItemIfUnderlyingSetDoesContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                set.Add("Frodo");

                Assert.AreEqual(4, set.Count);
            }
        }

        [Test]
        public void SynchronisedHashSetRemovesItemIfUnderlyingSetDoesContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                set.Remove("Frodo");

                Assert.AreEqual(3, set.Count);
            }
        }

        [Test]
        public void SynchronisedHashSetRemoveReturnsTrueIfUnderlyingSetContainedItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                bool result = set.Remove("Frodo");

                Assert.IsTrue(result);
            }
        }

        [Test]
        public void SynchronisedHashSetDoesNotRemoveItemIfUnderlyingSetDoesNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                set.Remove("Gandalf");

                Assert.AreEqual(4, set.Count);
            }
        }

        [Test]
        public void SynchronisedHashSetRemoveReturnsFalseIfUnderlyingSetDidNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                bool result = set.Remove("Gandalf");

                Assert.IsFalse(result);
            }
        }

        [Test]
        public void SynchronisedHashSetClearRemovesAllItemsFromSet()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                set.Clear();

                Assert.IsEmpty(set);
            }
        }

        [Test]
        public void SynchronsiedHashSetSupportsIteration()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                var i = (set as IEnumerable<string>).GetEnumerator();

                Assert.DoesNotThrow(() =>
                {
                    while (i.MoveNext())
                    {
                        //iterate to end of hash-set
                    }
                });
            }
        }

        [Test]
        public void SynchronisedHashSetIteratesOverAllItems()
        {
            int count = 0;

            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                var i = (set as IEnumerable<string>).GetEnumerator();

                while (i.MoveNext())
                {
                    count++;
                }
                Assert.AreEqual(4, count);
            }
        }

        [Test]
        public void SynchronisedHashSetSupportsIterationForEmptySet()
        {
            using (var set = new SynchronisedHashSet<string>())
            {
                var i = (set as IEnumerable<string>).GetEnumerator();

                Assert.DoesNotThrow(() =>
                {
                    while (i.MoveNext())
                    {
                        //iterate to end of hash-set
                    }
                });
            }
        }

        [Test]
        public void SynchronsiedHashSetSupportsNonGenericIteration()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                var i = (set as System.Collections.IEnumerable).GetEnumerator();

                Assert.DoesNotThrow(() =>
                {
                    while (i.MoveNext())
                    {
                        //iterate to end of hash-set
                    }
                });
            }
        }

        [Test]
        public void SynchronisedHashSetNonGenericIteratesOverAllItems()
        {
            int count = 0;

            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                var i = (set as System.Collections.IEnumerable).GetEnumerator();

                while (i.MoveNext())
                {
                    count++;
                }
                Assert.AreEqual(4, count);
            }
        }

        [Test]
        public void SynchronisedHashSetSupportsNonGenericIterationForEmptySet()
        {
            using (var set = new SynchronisedHashSet<string>())
            {
                var i = (set as System.Collections.IEnumerable).GetEnumerator();

                Assert.DoesNotThrow(() =>
                {
                    while (i.MoveNext())
                    {
                        //iterate to end of hash-set
                    }
                });
            }
        }

        [Test]
        public void SynchronisedHashSetCopyToArrayCopiesItemsToArray()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                string[] array = new string[4];

                set.CopyTo(array, 0);

                array.ToList().ForEach(i =>
                {
                    Assert.IsNotNull(i);
                });
            }
        }

        [Test]
        public void SynchronisedHashSetTryAddAddsIfUnderlyingSetDoesNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                set.TryAdd("Gandalf");

                Assert.IsTrue(set.Contains("Gandalf"));
                Assert.AreEqual(5, set.Count);
            }
        }

        [Test]
        public void SynchronisedHashSetTryAddReturnsTrueIfUnderlyingSetDoesNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                bool result = set.TryAdd("Gandalf");

                Assert.IsTrue(result);
            }
        }

        [Test]
        public void SynchronisedHashSetTryAddDoesNotAddIfUnderlyingSetContainsItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                set.TryAdd("Sam");

                Assert.IsTrue(set.Contains("Sam"));
                Assert.AreEqual(4, set.Count);
            }
        }

        [Test]
        public void SynchronsiedHashSetTryAddReturnsFalseIfUnderlyingSetDoesContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                bool result = set.TryAdd("Sam");

                Assert.IsFalse(result);
            }
        }

        [Test]
        public void SynchronisedHashSetTryAddAddsEachUniqueItemsOnlyOnce()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var itemsToAdd = new List<string> { "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            int successfulAddCount = 0;

            using (var set = new SynchronisedHashSet<string>(items))
            {
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
        }

        [Test]
        public void SynchronsiedHashSetTryAddAddsEachUniqueItemOnlyOnceMultiThreaded()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            var itemsToAdd = new List<string> { "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            int successfulAddCount = 0;

            using (var set = new SynchronisedHashSet<string>(items))
            {
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
        }

        [Test]
        public void SynchronisedHashSetTryRemoveRemovesIfUnderlyingSetContainsItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                set.TryRemove("Frodo");

                Assert.IsFalse(set.Contains("Frodo"));
                Assert.AreEqual(3, set.Count);
            }
        }

        [Test]
        public void SynchronisedHashSetTryRemoveReturnsTrueIfUnderlyingSetContainsItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                bool result = set.TryRemove("Frodo");

                Assert.IsTrue(result);
            }
        }

        [Test]
        public void SynchronsiedHashSetTryRemoveDoesNotRemoveIfUnderlyingSetDoesNotContainItem()
        {
            var collection = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(collection))
            {
                set.TryRemove("Gandalf");

                Assert.AreEqual(4, set.Count);
            }
        }

        [Test]
        public void SynchronisedHashSetTryRemoveReturnsFalseIfUnderlyingSetDoesNotContainItem()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin" };

            using (var set = new SynchronisedHashSet<string>(items))
            {
                bool result = set.TryRemove("Gandalf");

                Assert.IsFalse(result);
            }
        }

        [Test]
        public void SynchronisedHashSetTryRemoveRemoveEachUniqueItemOnlyOnce()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin", "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            var itemsToRemove = new List<string> { "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            int successfulRemoveCount = 0;

            using (var set = new SynchronisedHashSet<string>(items))
            {
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
        }

        [Test]
        public void SynchronisedHashSetTryRemoveRemoveEachUniqueItemOnlyOnceMultiThreaded()
        {
            var items = new List<string> { "Frodo", "Sam", "Merry", "Pippin", "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            var itemsToRemove = new List<string> { "Gandalf", "Aragorn", "Gimli", "Legolas", "Boromir" };

            int successfulRemoveCount = 0;

            using (var set = new SynchronisedHashSet<string>(items))
            {
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

}
