using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class SynchronisedDequeTests
    {
        [Test]
        public void SynchronisedDoubleEndedQueueInitialises()
        {
            var deque = new SynchronisedDeque<int>();
            Assert.IsNotNull(deque);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueInitialisesEmpty()
        {
            var deque = new SynchronisedDeque<int>();
            Assert.AreEqual(0, deque.Count);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueThrowsIfCollectionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SynchronisedDeque<int>(null as int[]));
        }

        [Test]
        public void SynchronisedDoubleEndedQueueInitialisesWithCollection()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            Assert.IsNotNull(deque);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueInitialisesWithCollectionCopiedToQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            Assert.AreEqual(8, deque.Count);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueSupportsEnqueueingItemToFrontOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);
            deque.EnqueueItemToFront(9);

            int front = deque.PeekAtItemFromFront();

            Assert.AreEqual(9, front);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueEnqueueItemToFrontDoesNotImpactBackOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int originalBack = deque.PeekAtItemFromBack();

            deque.EnqueueItemToFront(9);

            int newBack = deque.PeekAtItemFromBack();

            Assert.AreEqual(originalBack, newBack);
        }

        [Test]
        public void SynchronisedDoubleEndedQueuePeekAtItemFromFrontThrowsIfQueueIsEmpty()
        {
            var deque = new SynchronisedDeque<int>();

            Assert.Throws<InvalidOperationException>(() => deque.PeekAtItemFromFront());
        }

        [Test]
        public void SynchronisedDoubleEndedQueueSupportsEnqueueingItemToBackOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);
            deque.EnqueueItemToBack(9);

            int back = deque.PeekAtItemFromBack();

            Assert.AreEqual(9, back);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueEnqueueItemToBackDoesNotImpactFrontOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int originalFront = deque.PeekAtItemFromFront();

            deque.EnqueueItemToBack(9);

            int newFront = deque.PeekAtItemFromFront();

            Assert.AreEqual(originalFront, newFront);
        }

        [Test]
        public void SynchronisedDoubleEndedQueuePeekAtItemFromBackThrowsIfQueueIsEmpty()
        {
            var deque = new SynchronisedDeque<int>();

            Assert.Throws<InvalidOperationException>(() => deque.PeekAtItemFromBack());
        }

        [Test]
        public void SynchronisedDoubleEndedQueueSupportsDequeuingItemFromFrontOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int front = deque.DequeueItemFromFront();

            Assert.AreEqual(1, front);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueDequeuingItemFromFrontUpdatesFront()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            deque.DequeueItemFromFront();

            int newFront = deque.PeekAtItemFromFront();

            Assert.AreEqual(2, newFront);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueDequeuingItemFrontUpdatesCount()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            deque.DequeueItemFromFront();

            Assert.AreEqual(7, deque.Count);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueDequeuingItemFrontDoesNotImpactBack()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int originalBack = deque.PeekAtItemFromBack();

            deque.DequeueItemFromFront();

            int newBack = deque.PeekAtItemFromBack();

            Assert.AreEqual(newBack, originalBack);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueDequeueItemFromFrontThrowsIfQueueIsEmpty()
        {
            var deque = new SynchronisedDeque<int>();

            Assert.Throws<InvalidOperationException>(() => deque.DequeueItemFromFront());
        }

        [Test]
        public void SynchronisedDoubleEndedQueueSupportsDequeuingItemFromBackOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int back = deque.DequeueItemFromBack();

            Assert.AreEqual(8, back);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueDequeuingItemFromBackUpdatesBack()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            deque.DequeueItemFromBack();

            int newBack = deque.PeekAtItemFromBack();

            Assert.AreEqual(7, newBack);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueDequeuingItemBackUpdatesCount()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            deque.DequeueItemFromBack();

            Assert.AreEqual(7, deque.Count);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueDequeuingItemBackDoesNotImpactFront()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int originalFront = deque.PeekAtItemFromFront();

            deque.DequeueItemFromBack();

            int newFront = deque.PeekAtItemFromFront();

            Assert.AreEqual(originalFront, newFront);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueDequeueItemFromBackThrowsIfQueueIsEmpty()
        {
            var deque = new SynchronisedDeque<int>();

            Assert.Throws<InvalidOperationException>(() => deque.DequeueItemFromBack());
        }

        [Test]
        public void SynchronisedDoubleEndedQueueClearRemovesAllItems()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);
            deque.Clear();

            Assert.AreEqual(0, deque.Count);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueContainsReturnsTrueIfItemIsInDequeue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            Assert.IsTrue(deque.Contains(8));
        }

        [Test]
        public void SynchronisedDoubleEndedQueueContainsReturnsFalseIfItemIsNotInDequeue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            Assert.IsFalse(deque.Contains(9));
        }

        [Test]
        public void SynchronisedDoubleEndedQueueSupportEnumeration()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            Assert.DoesNotThrow(() =>
            {
                foreach (int i in deque) 
                {
                    //ignore
                }
            });
        }

        [Test]
        public void SynchronisedDoubleEndedQueueEnumerationThrowsIfCollectionIsModified()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (int i in deque)
                {
                    deque.DequeueItemFromBack();
                }
            });
        }

        [Test]
        public void SynchronisedDoubleEndedQueueCopyToThrowsIfArrayIsNull()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            Assert.Throws<ArgumentNullException>(() => deque.CopyTo(null, 0));
        }

        [Test]
        public void SynchronisedDoubleEndedQueueCopyToThrowsIfArrayIsLessThanZero()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            var array = new int[10];

            Assert.Throws<ArgumentOutOfRangeException>(() => deque.CopyTo(array, -1));
        }

        [Test]
        public void SynchronisedDoubleEndedQueueCopyToThrowsIfCountIsGreaterThanArrayLength()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            var array = new int[5];

            Assert.Throws<ArgumentException>(() => deque.CopyTo(array, 0));
        }

        [Test]
        public void SynchronisedDoubleEndedQueueCopyToCopiesContentsToArray()
        {
            var items = new[] { "1", "2", "3", "4", "5", "6", "7", "8" };

            var deque = new SynchronisedDeque<string>(items);

            var array = new string[8];

            deque.CopyTo(array, 0);

            array.ToList().ForEach(i => Assert.IsNotNull(i));
        }

        [Test]
        public void SynchronisedDoubleEndedQueueSupportsDequeueingFromFrontUntilQueueIsEmptySingleThreaded()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>();
            deque.EnqueueRangeToFront(items);

            while (!deque.IsEmpty)
            {
                deque.DequeueItemFromFront();
            }
            Assert.AreEqual(0, deque.Count);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueSupportDequeueingFromBackUntilQueueIsEmptySingleThreaded()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>();
            deque.EnqueueRangeToBack(items);

            while (!deque.IsEmpty)
            {
                deque.DequeueItemFromBack();
            }
            Assert.AreEqual(0, deque.Count);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueSupportsDequeueingFromFrontUntilQueueIsEmptyMultiThreaded()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>();
            deque.EnqueueRangeToFront(items);

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < items.Length * 2; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    int j;
                    deque.TryDequeueAtItemFromFront(out j);
                }));
            }

            Assert.DoesNotThrow(() => Task.WaitAll(tasks.ToArray()));
            Assert.AreEqual(0, deque.Count);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueSupportsDequeueingFromBackUntilQueueIsEmptyMultiThreaded()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>();
            deque.EnqueueRangeToBack(items);

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < items.Length * 2; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    int j;
                    deque.TryDequeueAtItemFromBack(out j);
                }));
            }

            Assert.DoesNotThrow(() => Task.WaitAll(tasks.ToArray()));
            Assert.AreEqual(0, deque.Count);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryPeekAtItemFromFrontGetsItemFromFront()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int i;
            deque.TryPeekAtItemFromFront(out i);

            Assert.AreEqual(1, i);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryPeekAtItemFromFrontReturnsTrueIfQueueContainsItems()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int i;
            bool result = deque.TryPeekAtItemFromFront(out i);

            Assert.IsTrue(result);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryPeekAtItemFromFrontReturnsFalseIfQueueDoesNotContainItems()
        {
            var deque = new SynchronisedDeque<int>();

            int i;
            bool result = deque.TryPeekAtItemFromFront(out i);

            Assert.IsFalse(result);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryPeekAtItemFromBackGetsItemFromBack()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int i;
            deque.TryPeekAtItemFromBack(out i);

            Assert.AreEqual(8, i);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryPeekAtItemFromBackReturnsTrueIfQueueContainsItems()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int i;
            bool result = deque.TryPeekAtItemFromBack(out i);

            Assert.IsTrue(result);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryPeekAtItemFromBackReturnsFalseIfQueueDoesNotContainItems()
        {
            var deque = new SynchronisedDeque<int>();

            int i;
            bool result = deque.TryPeekAtItemFromBack(out i);

            Assert.IsFalse(result);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryDequeueAtItemFromFrontGetsItemFromFront()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int i;
            deque.TryDequeueAtItemFromFront(out i);

            Assert.AreEqual(1, i);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryDequeueAtItemFromFrontRemovesItemFromFront()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int i;
            deque.TryDequeueAtItemFromFront(out i);

            Assert.AreEqual(7, deque.Count);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryQueueAtItemFromFrontReturnsTrueIfQueueContainsItems()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int i;
            bool result = deque.TryDequeueAtItemFromFront(out i);

            Assert.IsTrue(result);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryDequeueAtItemFromFrontReturnsFalseIfQueueDoesNotContainItems()
        {
            var deque = new SynchronisedDeque<int>();

            int i;
            bool result = deque.TryDequeueAtItemFromFront(out i);

            Assert.IsFalse(result);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryDequeueAtItemFromBackGetsItemFromBack()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int i;
            deque.TryDequeueAtItemFromBack(out i);

            Assert.AreEqual(8, i);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryDequeueAtItemFromBackRemovesItemFromBack()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int i;
            deque.TryDequeueAtItemFromBack(out i);

            Assert.AreEqual(7, deque.Count);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryDequeueAtItemFromBackReturnsTrueIfQueueContainsItems()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new SynchronisedDeque<int>(items);

            int i;
            bool result = deque.TryDequeueAtItemFromBack(out i);

            Assert.IsTrue(result);
        }

        [Test]
        public void SynchronisedDoubleEndedQueueTryDequeueAtItemFromBackReturnsFalseIfQueueDoesNotContainItems()
        {
            var deque = new SynchronisedDeque<int>();

            int i;
            bool result = deque.TryDequeueAtItemFromBack(out i);

            Assert.IsFalse(result);
        }
    }
}
