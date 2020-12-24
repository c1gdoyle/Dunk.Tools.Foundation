using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class MaxDHeapTests
    {
        [Test]
        public void MaxHeapInitialises()
        {
            int testOrder = 2;
            var maxDHeap = new MaxDHeap<int>(testOrder);

            Assert.IsNotNull(maxDHeap);
        }

        [Test]
        public void MaxHeapThrowsIfOrderIsLessThanTwo()
        {
            int testOrder = 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new MaxDHeap<int>(testOrder));
        }

        [Test]
        public void MaxHeapThrowsIfSpecifiedCapacityIsLessThanZero()
        {
            int testOrder = 2;
            int testCapacity = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new MaxDHeap<int>(testOrder, testCapacity));
        }

        [Test]
        public void MaxHeapThrowsIfSpecifiedCollectionIsNull()
        {
            int testOrder = 2;

            Assert.Throws<ArgumentNullException>(() => new MaxDHeap<int>(testOrder, null as IEnumerable<int>));
        }

        [Test]
        public void MaxHeapInitialisesAndInsertsSpecifiedCollection()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var maxDHeap = new MaxDHeap<int>(testOrder, testCollection.Randomize());

            Assert.AreEqual(testCollection.Count, maxDHeap.Count);
        }

        [Test]
        public void MaxHeapsRootIsTheLargestValue()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var maxDHeap = new MaxDHeap<int>(testOrder, testCollection.Randomize());

            int root = maxDHeap.Peek();

            Assert.AreEqual(51, root);
        }

        [Test]
        public void MaxHeapRemoveRootReturnsLargestValue()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var maxDHeap = new MaxDHeap<int>(testOrder, testCollection.Randomize());

            int root = maxDHeap.RemoveRoot();

            Assert.AreEqual(51, root);
        }

        [Test]
        public void MaxHeapMovesNextLargestValueToRootAfterRemoveRoot()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var maxDHeap = new MaxDHeap<int>(testOrder, testCollection.Randomize());

            maxDHeap.RemoveRoot();

            int newRoot = maxDHeap.Peek();

            Assert.AreEqual(50, newRoot);
        }

        [Test]
        public void MaxHeapInsertsItemAsRootIfItemIsLargerThanOriginalRoot()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var maxDHeap = new MaxDHeap<int>(testOrder, testCollection.Randomize());

            int originalRoot = maxDHeap.Peek();

            maxDHeap.Insert(52);

            int newRoot = maxDHeap.Peek();

            Assert.AreEqual(51, originalRoot);
            Assert.AreEqual(52, newRoot);
        }

        [Test]
        public void MaxHeapDoesNotInsertItemAsRootIfItemIsSmallerThanOriginalRoot()
        {
            int testOrder = 2;
            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };

            var maxDHeap = new MaxDHeap<int>(testOrder, testCollection.Randomize());

            int originalRoot = maxDHeap.Peek();

            maxDHeap.Insert(3);

            int newRoot = maxDHeap.Peek();

            Assert.AreEqual(51, originalRoot);
            Assert.AreEqual(51, newRoot);
        }

        [Test]
        public void MaxHeapInsertsItemInCollectionAsRootIfItemIsLargerThanOriginalRoot()
        {
            int testOrder = 2;

            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };
            IList<int> newCollection = new List<int> { 34, 36, 38, 40, 42, 44, 46, 48, 52 };

            var maxDHeap = new MaxDHeap<int>(testOrder, testCollection.Randomize());

            int originalRoot = maxDHeap.Peek();

            maxDHeap.InsertRange(newCollection.Randomize());

            int newRoot = maxDHeap.Peek();

            Assert.AreEqual(51, originalRoot);
            Assert.AreEqual(52, newRoot);
        }

        [Test]
        public void MaxHeapDoesNotInsertItemInCollectionAsRootIfItemIsSmallerThanOriginalRoot()
        {
            int testOrder = 2;

            IList<int> testCollection = new List<int> { 50, 51, 38, 37, 23, 11, 5, 3 };
            IList<int> newCollection = new List<int> { 34, 36, 38, 40, 42, 44, 46, 48 };

            var maxDHeap = new MaxDHeap<int>(testOrder, testCollection.Randomize());

            int originalRoot = maxDHeap.Peek();

            maxDHeap.InsertRange(newCollection.Randomize());

            int newRoot = maxDHeap.Peek();

            Assert.AreEqual(51, originalRoot);
            Assert.AreEqual(51, newRoot);
        }
    }
}