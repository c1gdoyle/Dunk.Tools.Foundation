using System;
using System.Linq;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class DequeTests
    {
        [Test]
        public void DoubleEndedQueueInitialises()
        {
            var deque = new Deque<int>();
            Assert.IsNotNull(deque);
        }

        [Test]
        public void DoubleEndedQueueInitialisesEmpty()
        {
            var deque = new Deque<int>();
            Assert.AreEqual(0, deque.Count);
        }

        [Test]
        public void DoubleEndedQueueThrowsIfCollectionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Deque<int>(null as int[]));
        }

        [Test]
        public void DoubleEndedQueueInitialisesWithCollection()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            Assert.IsNotNull(deque);
        }

        [Test]
        public void DoubleEndedQueueInitialisesWithCollectionCopiedToQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            Assert.AreEqual(8, deque.Count);
        }

        [Test]
        public void DoubleEndedQueueSupportsEnqueueingItemToFrontOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);
            deque.EnqueueItemToFront(9);

            int front = deque.PeekAtItemFromFront();

            Assert.AreEqual(9, front);
        }

        [Test]
        public void DoubleEndedQueueEnqueueItemToFrontDoesNotImpactBackOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            int originalBack = deque.PeekAtItemFromBack();

            deque.EnqueueItemToFront(9);

            int newBack = deque.PeekAtItemFromBack();

            Assert.AreEqual(originalBack, newBack);
        }

        [Test]
        public void DoubleEndedQueuePeekAtItemFromFrontThrowsIfQueueIsEmpty()
        {
            var deque = new Deque<int>();

            Assert.Throws<InvalidOperationException>(() => deque.PeekAtItemFromFront());
        }

        [Test]
        public void DoubleEndedQueueSupportsEnqueueingItemToBackOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);
            deque.EnqueueItemToBack(9);

            int back = deque.PeekAtItemFromBack();

            Assert.AreEqual(9, back);
        }

        [Test]
        public void DoubleEndedQueueEnqueueItemToBackDoesNotImpactFrontOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            int originalFront = deque.PeekAtItemFromFront();

            deque.EnqueueItemToBack(9);

            int newFront = deque.PeekAtItemFromFront();

            Assert.AreEqual(originalFront, newFront);
        }

        [Test]
        public void DoubleEndedQueuePeekAtItemFromBackThrowsIfQueueIsEmpty()
        {
            var deque = new Deque<int>();

            Assert.Throws<InvalidOperationException>(() => deque.PeekAtItemFromBack());
        }

        [Test]
        public void DoubleEndedQueueSupportsDequeuingItemFromFrontOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            int front = deque.DequeueItemFromFront();

            Assert.AreEqual(1, front);
        }

        [Test]
        public void DoubleEndedQueueDequeuingItemFromFrontUpdatesFront()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            deque.DequeueItemFromFront();

            int newFront = deque.PeekAtItemFromFront();

            Assert.AreEqual(2, newFront);
        }

        [Test]
        public void DoubleEndedQueueDequeuingItemFrontUpdatesCount()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            deque.DequeueItemFromFront();

            Assert.AreEqual(7, deque.Count);
        }

        [Test]
        public void DoubleEndedQueueDequeuingItemFrontDoesNotImpactBack()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            int originalBack = deque.PeekAtItemFromBack();

            deque.DequeueItemFromFront();

            int newBack = deque.PeekAtItemFromBack();

            Assert.AreEqual(newBack, originalBack);
        }

        [Test]
        public void DoubleEndedQueueDequeueItemFromFrontThrowsIfQueueIsEmpty()
        {
            var deque = new Deque<int>();

            Assert.Throws<InvalidOperationException>(() => deque.DequeueItemFromFront());
        }

        [Test]
        public void DoubleEndedQueueSupportsDequeuingItemFromBackOfQueue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            int back = deque.DequeueItemFromBack();

            Assert.AreEqual(8, back);
        }

        [Test]
        public void DoubleEndedQueueDequeuingItemFromBackUpdatesBack()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            deque.DequeueItemFromBack();

            int newBack = deque.PeekAtItemFromBack();

            Assert.AreEqual(7, newBack);
        }

        [Test]
        public void DoubleEndedQueueDequeuingItemBackUpdatesCount()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            deque.DequeueItemFromBack();

            Assert.AreEqual(7, deque.Count);
        }

        [Test]
        public void DoubleEndedQueueDequeuingItemBackDoesNotImpactFront()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            int originalFront = deque.PeekAtItemFromFront();

            deque.DequeueItemFromBack();

            int newFront = deque.PeekAtItemFromFront();

            Assert.AreEqual(originalFront, newFront);
        }

        [Test]
        public void DoubleEndedQueueDequeueItemFromBackThrowsIfQueueIsEmpty()
        {
            var deque = new Deque<int>();

            Assert.Throws<InvalidOperationException>(() => deque.DequeueItemFromBack());
        }

        [Test]
        public void DoubleEndedQueueClearRemovesAllItems()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);
            deque.Clear();

            Assert.AreEqual(0, deque.Count);
        }

        [Test]
        public void DoubleEndedQueueContainsReturnsTrueIfItemIsInDequeue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            Assert.IsTrue(deque.Contains(8));
        }

        [Test]
        public void DoubleEndedQueueContainsReturnsFalseIfItemIsNotInDequeue()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            Assert.IsFalse(deque.Contains(9));
        }

        [Test]
        public void DoubleEndedQueueSupportEnumeration()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            Assert.DoesNotThrow(() =>
            {
                foreach (int i in deque) 
                {
                    //ignore
                }
            });
        }

        [Test]
        public void DoubleEndedQueueEnumerationThrowsIfCollectionIsModified()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (int i in deque)
                {
                    deque.DequeueItemFromBack();
                }
            });
        }

        [Test]
        public void DoubleEndedQueueCopyToThrowsIfArrayIsNull()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            Assert.Throws<ArgumentNullException>(() => deque.CopyTo(null, 0));
        }

        [Test]
        public void DoubleEndedQueueCopyToThrowsIfArrayIsLessThanZero()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            var array = new int[10];

            Assert.Throws<ArgumentOutOfRangeException>(() => deque.CopyTo(array, -1));
        }

        [Test]
        public void DoubleEndedQueueCopyToThrowsIfCountIsGreaterThanArrayLength()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>(items);

            var array = new int[5];

            Assert.Throws<ArgumentException>(() => deque.CopyTo(array, 0));
        }

        [Test]
        public void DoubleEndedQueueCopyToCopiesContentsToArray()
        {
            var items = new[] { "1", "2", "3", "4", "5", "6", "7", "8" };

            var deque = new Deque<string>(items);

            var array = new string[8];

            deque.CopyTo(array, 0);

            array.ToList().ForEach(i => Assert.IsNotNull(i));
        }

        [Test]
        public void DoubleEndedQueueSupportsDequeueingFromFrontUntilQueueIsEmpty()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>();
            deque.EnqueueRangeToFront(items);

            while (!deque.IsEmpty)
            {
                deque.DequeueItemFromFront();
            }
            Assert.AreEqual(0, deque.Count);
        }

        [Test]
        public void DoubleEndedQueueSupportDequeueingFromBackUntilQueueIsEmpty()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var deque = new Deque<int>();
            deque.EnqueueRangeToBack(items);

            while (!deque.IsEmpty)
            {
                deque.DequeueItemFromBack();
            }
            Assert.AreEqual(0, deque.Count);
        }
    }
}
