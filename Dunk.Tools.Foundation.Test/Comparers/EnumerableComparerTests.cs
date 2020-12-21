using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Comparers;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Comparers
{
    [TestFixture]
    public class EnumerableComparerTests
    {
        [Test]
        public void EnumerableComparerInitialises()
        {
            var comparer = new EnumerableComparer<int>();
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void EnumerableComparerInitialisesWithSpecifiedElementComparer()
        {
            var comparer = new EnumerableComparer<int>(EqualityComparer<int>.Default);
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void EnumerableComparerThrowsIfSpecifiedElementComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EnumerableComparer<int>(null));
        }

        [Test]
        public void EnumerableEqualityComparerReturnsTrueIfSequencesAreSameReference()
        {
            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> second = first;

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void EnumerableEqualityComparerReturnsFalseIfFirstListIsNull()
        {
            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> first = null;
            IEnumerable<int> second = new List<int> { 1, 2, 3, 4, 5 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void EnumerableEqualityComparerReturnsFalseIfSecondListIsNull()
        {
            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> second = null;

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void EnumerableEqualityComparerReturnsTrueIfFirstAndSecondAreBothNull()
        {
            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> first = null;
            IEnumerable<int> second = null;

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void EnumerableEqualityComparerReturnsFalseIfFirstIsGreaterLengthThanSecond()
        {
            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> second = new List<int>();

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void EnumerableEqualityComparerReturnsFalseIfFirstIsShorterLengthThanSecond()
        {
            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> first = new List<int>();
            IEnumerable<int> second = new List<int> { 1, 2, 3, 4, 5 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void EnumerableEqualityComparerReturnsTrueIfFirstAndSecondSequenceElementsAreTheSame()
        {
            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> second = new List<int> { 1, 2, 3, 4, 5 };

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void EnumerableEqualityComparerReturnsFalseIfFirstAndSecondSequenceElementsAreNotTheSame()
        {
            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> second = new List<int> { 6, 7, 8, 9, 10 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void EnumerableEqualityComparerReturnsFalseIfFirstAndSecondSequenceElementsAreTheSameButDifferentOrder()
        {
            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> first = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> second = new List<int> { 5, 4, 3, 2, 1 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void EnumerableEqualityComparerGetHashCodeReturnsZeroIfSequenceIsNull()
        {
            const int expectedHashCode = 0;

            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> sequence = null;

            int result = comparer.GetHashCode(sequence);

            Assert.AreEqual(expectedHashCode, result);
        }

        [Test]
        public void EnumerableEqualityComparerGetHashCodeReturnsDefaultHashCodeIfSequenceIsEmpty()
        {
            const int expectedHashCode = 23;

            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> sequence = new List<int>();

            int result = comparer.GetHashCode(sequence);

            Assert.AreEqual(expectedHashCode, result);
        }

        [Test]
        public void EnumerableEqualityComparerGetHashCodeReturnsSameHashCodeIfSequenceHasElements()
        {
            var comparer = new EnumerableComparer<int>();

            IEnumerable<int> sequence = new List<int> { 1, 2, 3, 4, 5 };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of the enumerable
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(sequence));
            }

            Assert.AreEqual(1, hashes.Count);
        }

        [Test]
        public void EnumerableEqualityComparerGetHashCodeReturnsSameHashCodeIfSequenceHasNullableElements()
        {
            var comparer = new EnumerableComparer<int?>();

            IEnumerable<int?> sequence = new List<int?> { 1, 2, 3, 4, 5 };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of the enumerable
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(sequence));
            }

            Assert.AreEqual(1, hashes.Count);
        }

        [Test]
        public void EnumerableEqualityComparerGetHashCodeReturnsSameHashCodeIfSequenceContainsNullElements()
        {
            var comparer = new EnumerableComparer<int?>();

            IEnumerable<int?> sequence = new List<int?> { 1, 2, null, 4, 5 };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of the enumerable
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(sequence));
            }

            Assert.AreEqual(1, hashes.Count);
        }
    }

}
