using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Comparers;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Comparers
{
    [TestFixture]
    public class ListEqualityComparerTests
    {
        [Test]
        public void ListEqualityComparerInitialises()
        {
            var comparer = new ListEqualityComparer<int>();
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void ListEqualityComparerInitialisesWithSpecifiedElementComparer()
        {
            var comparer = new ListEqualityComparer<int>(EqualityComparer<int>.Default);
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void ListEqualityComparerThrowsIfSpecifiedElementComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ListEqualityComparer<int>(null));
        }

        [Test]
        public void ListEqualityComparerReturnsTrueIfListsAreSameReference()
        {
            var comparer = new ListEqualityComparer<int>();

            IList<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IList<int> second = first;

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void ListEqualityComparerReturnsFalseIfFirstListIsNull()
        {
            var comparer = new ListEqualityComparer<int>();

            IList<int> first = null;
            IList<int> second = new List<int> { 1, 2, 3, 4, 5 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ListEqualityComparerReturnsFalseIfSecondListIsNull()
        {
            var comparer = new ListEqualityComparer<int>();

            IList<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IList<int> second = null;

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ListEqualityComparerReturnsTrueIfFirstAndSecondAreBothNull()
        {
            var comparer = new ListEqualityComparer<int>();

            IList<int> first = null;
            IList<int> second = null;

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void ListEqualityComparerReturnsFalseIfFirstIsGreaterLengthThanSecond()
        {
            var comparer = new ListEqualityComparer<int>();

            IList<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IList<int> second = new List<int>();

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ListEqualityComparerReturnsFalseIfFirstIsShorterLengthThanSecond()
        {
            var comparer = new ListEqualityComparer<int>();

            IList<int> first = new List<int>();
            IList<int> second = new List<int> { 1, 2, 3, 4, 5 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ListEqualityComparerReturnsTrueIfFirstAndSecondListElementsAreTheSame()
        {
            var comparer = new ListEqualityComparer<int>();

            IList<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IList<int> second = new List<int> { 1, 2, 3, 4, 5 };

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void ListEqualityComparerReturnsFalseIfFirstAndSecondListElementsAreNotTheSame()
        {
            var comparer = new ListEqualityComparer<int>();

            IList<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IList<int> second = new List<int> { 6, 7, 8, 9, 10 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ListEqualityComparerReturnsFalseIfFirstAndSecondListElementsAreTheSameButDifferentOrder()
        {
            var comparer = new ListEqualityComparer<int>();

            IList<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IList<int> second = new List<int> { 5, 4, 3, 2, 1 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ListEqualityComparerGetHashCodeReturnsZeroIfListIsNull()
        {
            const int expectedHashCode = 0;

            var comparer = new ListEqualityComparer<int>();

            IList<int> list = null;

            int result = comparer.GetHashCode(list);

            Assert.AreEqual(expectedHashCode, result);
        }

        [Test]
        public void ListEqualityComparerGetHashCodeReturnsDefaultHashCodeIfListIsEmpty()
        {
            const int expectedHashCode = 23;

            var comparer = new ListEqualityComparer<int>();

            IList<int> list = new List<int>();

            int result = comparer.GetHashCode(list);

            Assert.AreEqual(expectedHashCode, result);
        }

        [Test]
        public void ListEqualityComparerGetHashCodeReturnsSameHashCodeIfListHasElements()
        {
            var comparer = new ListEqualityComparer<int>();

            IList<int> list = new List<int> { 1, 2, 3, 4, 5 };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of the list
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(list));
            }

            Assert.AreEqual(1, hashes.Count);
        }

        [Test]
        public void ListEqualityComparerGetHashCodeReturnsSameHashCodeIfListHasNullableElements()
        {
            var comparer = new ListEqualityComparer<int?>();

            IList<int?> list = new List<int?> { 1, 2, 3, 4, 5 };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of the list
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(list));
            }

            Assert.AreEqual(1, hashes.Count);
        }

        [Test]
        public void ListEqualityComparerGetHashCodeReturnsSameHashCodeIfListContainsNullElements()
        {
            var comparer = new ListEqualityComparer<int?>();

            IList<int?> list = new List<int?> { 1, 2, null, 4, 5 };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of the list
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(list));
            }

            Assert.AreEqual(1, hashes.Count);
        }
    }

}
