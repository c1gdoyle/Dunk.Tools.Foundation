using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class MinDHeapTests
    {
        [Test]
        public void MinHeapInitialises()
        {
            int testOrder = 2;
            var minDHeap = new MinDHeap<int>(testOrder);

            Assert.IsNotNull(minDHeap);
        }

        [Test]
        public void MinHeapThrowsIfOrderIsLessThanTwo()
        {
            int testOrder = 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new MinDHeap<int>(testOrder));
        }

        [Test]
        public void MinHeapThrowsIfSpecifiedCapacityIsLessThanZero()
        {
            int testOrder = 2;
            int testCapacity = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new MinDHeap<int>(testOrder, testCapacity));
        }

        [Test]
        public void MinHeapThrowsIfSpecifiedCollectionIsNull()
        {
            int testOrder = 2;

            Assert.Throws<ArgumentNullException>(() => new MinDHeap<int>(testOrder, null as IEnumerable<int>));
        }

        [Test]
        public void MinHeapInitialisesAndInsertsSpecifiedCollection()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var minDHeap = new MinDHeap<int>(testOrder, testCollection.Randomize());

            Assert.AreEqual(testCollection.Count, minDHeap.Count);
        }

        [Test]
        public void MinHeapsRootIsTheSmallestValue()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var minDHeap = new MinDHeap<int>(testOrder, testCollection.Randomize());

            int root = minDHeap.Peek();

            Assert.AreEqual(3, root);
        }

        [Test]
        public void MinHeapRemoveRootReturnsSmallestValue()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var minDHeap = new MinDHeap<int>(testOrder, testCollection.Randomize());

            int root = minDHeap.RemoveRoot();

            Assert.AreEqual(3, root);
        }

        [Test]
        public void MinHeapMovesNextSmallestValueToRootAfterRemoveRoot()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var minDHeap = new MinDHeap<int>(testOrder, testCollection.Randomize());

            minDHeap.RemoveRoot();

            int newRoot = minDHeap.Peek();

            Assert.AreEqual(5, newRoot);
        }

        [Test]
        public void MinHeapInsertsItemAsRootIfItemIsSmallerThanOriginalRoot()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var minDHeap = new MinDHeap<int>(testOrder, testCollection.Randomize());

            int originalRoot = minDHeap.Peek();

            minDHeap.Insert(2);

            int newRoot = minDHeap.Peek();

            Assert.AreEqual(3, originalRoot);
            Assert.AreEqual(2, newRoot);
        }

        [Test]
        public void MinHeapDoesNotInsertItemAsRootIfItemIsLargerThanOriginalRoot()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var minDHeap = new MinDHeap<int>(testOrder, testCollection.Randomize());

            int originalRoot = minDHeap.Peek();

            minDHeap.Insert(4);

            int newRoot = minDHeap.Peek();

            Assert.AreEqual(3, originalRoot);
            Assert.AreEqual(3, newRoot);
        }

        [Test]
        public void MinHeapInsertsItemInCollectionAsRootIfItemIsSmallerThanOriginalRoot()
        {
            int testOrder = 2;

            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };
            IList<int> newCollection = new List<int> { 2, 4, 6, 8, 10, 12, 14, 16, 18 };

            var minDHeap = new MinDHeap<int>(testOrder, testCollection.Randomize());

            int originalRoot = minDHeap.Peek();

            minDHeap.InsertRange(newCollection.Randomize());

            int newRoot = minDHeap.Peek();

            Assert.AreEqual(3, originalRoot);
            Assert.AreEqual(2, newRoot);
        }

        [Test]
        public void MinHeapDoesNotInsertItemInCollectionAsRootIfItemIsLargerThanOriginalRoot()
        {
            int testOrder = 2;

            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };
            IList<int> newCollection = new List<int> { 4, 6, 8, 10, 12, 14, 16, 18 };

            var minDHeap = new MinDHeap<int>(testOrder, testCollection.Randomize());

            int originalRoot = minDHeap.Peek();

            minDHeap.InsertRange(newCollection.Randomize());

            int newRoot = minDHeap.Peek();

            Assert.AreEqual(3, originalRoot);
            Assert.AreEqual(3, newRoot);
        }
    }
}
