using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Comparers;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Comparers
{
    [TestFixture]
    public class ArrayEqualityComparerTests
    {
        [Test]
        public void ArrayEqualityComparerInitialises()
        {
            var comparer = new ArrayEqualityComparer<int>();
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void ArrayEqualityComparerInitialisesWithSpecifiedElementComparer()
        {
            var comparer = new ArrayEqualityComparer<int>(EqualityComparer<int>.Default);
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void ArrayEqualityComparerThrowsIfSpecifiedElementComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ArrayEqualityComparer<int>(null));
        }

        [Test]
        public void ArrayEqualityComparerReturnsTrueIfArraysAreSameReference()
        {
            var comparer = new ArrayEqualityComparer<int>();

            int[] first = new[] { 1, 2, 3, 4, 5 };
            int[] second = first;

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void ArrayEqualityComparerReturnsFalseIfFirstArrayIsNull()
        {
            var comparer = new ArrayEqualityComparer<int>();

            int[] first = null;
            int[] second = new[] { 6, 7, 8, 9, 10 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ArrayEqualityComparerReturnsFalseIfSecondArrayIsNull()
        {
            var comparer = new ArrayEqualityComparer<int>();

            int[] first = new[] { 1, 2, 3, 4, 5 };
            int[] second = null;

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ArrayEqualityComparerReturnsTrueIfFirstAndSecondAreBothNull()
        {
            var comparer = new ArrayEqualityComparer<int>();

            int[] first = null;
            int[] second = null;

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void ArrayEqualityComparerReturnsFalseIfFirstIsGreaterLengthThanSecond()
        {
            var comparer = new ArrayEqualityComparer<int>();

            int[] first = new[] { 1, 2, 3, 4, 5 };
            int[] second = new int[0];

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ArrayEqualityComparerReturnsFalseIfFirstIsShorterLengthThanSecond()
        {
            var comparer = new ArrayEqualityComparer<int>();

            int[] first = new int[0];
            int[] second = new[] { 6, 7, 8, 9, 10 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ArrayEqualityComparerReturnsTrueIfFirstAndSecondArrayElementsAreTheSame()
        {
            var comparer = new ArrayEqualityComparer<int>();

            int[] first = new[] { 1, 2, 3, 4, 5 };
            int[] second = new[] { 1, 2, 3, 4, 5 };

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void ArrayEqualityComparerReturnsFalseIfFirstAndSecondArrayElementsAreNotTheSame()
        {
            var comparer = new ArrayEqualityComparer<int>();

            int[] first = new[] { 1, 2, 3, 4, 5 };
            int[] second = new[] { 6, 7, 8, 9, 10 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ArrayEqualityComparerReturnsFalseIfFirstAndSecondArrayElementsAreTheSameButDifferentOrder()
        {
            var comparer = new ArrayEqualityComparer<int>();

            int[] first = new[] { 1, 2, 3, 4, 5 };
            int[] second = new[] { 5, 4, 3, 2, 1 };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void ArrayEqualityComparerGetHashCodeReturnsZeroIfArrayIsNull()
        {
            const int expectedHashCode = 0;

            var comparer = new ArrayEqualityComparer<int>();

            int[] array = null;

            int result = comparer.GetHashCode(array);

            Assert.AreEqual(expectedHashCode, result);
        }

        [Test]
        public void ArrayEqualityComparerGetHashCodeReturnsDefaultHashCodeIfArrayIsEmpty()
        {
            const int expectedHashCode = 23;

            var comparer = new ArrayEqualityComparer<int>();

            int[] array = new int[0];

            int result = comparer.GetHashCode(array);

            Assert.AreEqual(expectedHashCode, result);
        }

        [Test]
        public void ArrayEqualityComparerGetHashCodeReturnsSameHashCodeIfArrayHasElements()
        {
            var comparer = new ArrayEqualityComparer<int>();

            int[] array = new[] { 1, 2, 3, 4, 5 };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of the array
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(array));
            }

            Assert.AreEqual(1, hashes.Count);
        }

        [Test]
        public void ArrayEqualityComparerGetHashCodeReturnsSameHashCodeIfArrayHasNullableElements()
        {
            var comparer = new ArrayEqualityComparer<int?>();

            int?[] array = new int?[] { 1, 2, 3, 4, 5 };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of the array
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(array));
            }

            Assert.AreEqual(1, hashes.Count);
        }

        [Test]
        public void ArrayEqualityComparerGetHashCodeReturnsSameHashCodeIfArrayContainsNullElements()
        {
            var comparer = new ArrayEqualityComparer<int?>();

            int?[] array = new int?[] { 1, 2, null, 4, 5 };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of the array
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(array));
            }

            Assert.AreEqual(1, hashes.Count);
        }
    }

}
