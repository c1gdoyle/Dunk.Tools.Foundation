using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Comparers;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Comparers
{
    [TestFixture]
    public class DictionaryEqualityComparerTests
    {
        [Test]
        public void DictionaryEqualityComparerInitialises()
        {
            var comparer = new DictionaryEqualityComparer<string, int>();
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void DictionaryEqualityComparerInitialisesWithSpecifiedValueComparer()
        {
            var comparer = new DictionaryEqualityComparer<string, int>(EqualityComparer<int>.Default);
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void DictionaryEqualityComparerThrowsIfSpecifiedElementComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new DictionaryEqualityComparer<string, int>(null));
        }

        [Test]
        public void DictionaryEqualityComparerReturnsTrueIfDictionariesAreSameReference()
        {
            var comparer = new DictionaryEqualityComparer<string, int>(EqualityComparer<int>.Default);

            IDictionary<string, int> first = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };
            IDictionary<string, int> second = first;

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void DictionaryEqualityComparerReturnsFalseIfFirstDictionaryIsNull()
        {
            var comparer = new DictionaryEqualityComparer<string, int>(EqualityComparer<int>.Default);

            IDictionary<string, int> first = null;
            IDictionary<string, int> second = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void DictionaryEqualityComaprerReturnsFalseIfSecondDictionaryIsNull()
        {
            var comparer = new DictionaryEqualityComparer<string, int>(EqualityComparer<int>.Default);

            IDictionary<string, int> first = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };
            IDictionary<string, int> second = null;

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void DictionaryEqualityComparerReturnsTrueIfFirstAndSecondAreBothNull()
        {
            var comparer = new DictionaryEqualityComparer<string, int>(EqualityComparer<int>.Default);

            IDictionary<string, int> first = null;
            IDictionary<string, int> second = null;

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void DictionaryEqualityComparerReturnsFalseIfFirstIsGreaterLengthThanSecond()
        {
            var comparer = new DictionaryEqualityComparer<string, int>(EqualityComparer<int>.Default);

            IDictionary<string, int> first = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };
            IDictionary<string, int> second = new Dictionary<string, int>();

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void DictionaryEqualityComparerReturnsFalseIfFirstIsShorterLengthThanSecond()
        {
            var comparer = new DictionaryEqualityComparer<string, int>(EqualityComparer<int>.Default);

            IDictionary<string, int> first = new Dictionary<string, int>();
            IDictionary<string, int> second = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void DictionaryEqualityComparerReturnsTrueIfFirstAndSecondKeyValuePairsAreTheSame()
        {
            var comparer = new DictionaryEqualityComparer<string, int>(EqualityComparer<int>.Default);

            IDictionary<string, int> first = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };
            IDictionary<string, int> second = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void DictionaryEqualityComparerReturnsFalseIfFirstAndSecondKeysAreDifferent()
        {
            var comparer = new DictionaryEqualityComparer<string, int>(EqualityComparer<int>.Default);

            IDictionary<string, int> first = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };
            IDictionary<string, int> second = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D4", 4},
            };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void DictionaryEqualityComparerReturnsFalseIfFirstAndSecondValuesAreDifferent()
        {
            var comparer = new DictionaryEqualityComparer<string, int>(EqualityComparer<int>.Default);

            IDictionary<string, int> first = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };
            IDictionary<string, int> second = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 5},
            };

            bool result = comparer.Equals(first, second);

            Assert.IsFalse(result);
        }

        [Test]
        public void DictionaryEqualityComparerReturnsTrueIfFirstAndSecondDictionaryKeyValuePairsAreTheSameButDifferentOrder()
        {
            var comparer = new DictionaryEqualityComparer<string, int>(EqualityComparer<int>.Default);

            IDictionary<string, int> first = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };
            IDictionary<string, int> second = new Dictionary<string, int>
            {
                { "D", 4},
                { "B", 2},
                { "C", 3},
                { "A", 1}
            };

            bool result = comparer.Equals(first, second);

            Assert.IsTrue(result);
        }

        [Test]
        public void DictionaryEqualityComparerGetHashCodeReturnsZeroIfDictionaryIsNull()
        {
            const int expectedHashCode = 0;

            var comparer = new DictionaryEqualityComparer<string, int>();

            Dictionary<string, int> dictionary = null;

            int result = comparer.GetHashCode(dictionary);

            Assert.AreEqual(expectedHashCode, result);
        }

        [Test]
        public void DictionaryEqualityComparerGetHashCodeReturnsDefaultHashCodeIfDictionaryIsEmpty()
        {
            const int expectedHashCode = 23;

            var comparer = new DictionaryEqualityComparer<string, int>();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            int result = comparer.GetHashCode(dictionary);

            Assert.AreEqual(expectedHashCode, result);
        }

        [Test]
        public void DictionaryEqualityComparerGetHashCodeReturnsSameHashCodeIfDictionaryHasEntries()
        {
            var comparer = new DictionaryEqualityComparer<string, int>();

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of dictionary
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(dictionary));
            }

            Assert.AreEqual(1, hashes.Count);
        }

        [Test]
        public void DictionaryEqualityComparerGetHashCodeReturnsSameHashCodeIfDictionaryHasNullableValues()
        {
            var comparer = new DictionaryEqualityComparer<string, int?>();

            Dictionary<string, int?> dictionary = new Dictionary<string, int?>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
            };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of dictionary
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(dictionary));
            }

            Assert.AreEqual(1, hashes.Count);
        }

        [Test]
        public void DictionaryEqualityComparerGetHashCodeReturnsSameHashCodeIfDictionaryContainsNullValues()
        {
            var comparer = new DictionaryEqualityComparer<string, int?>();

            Dictionary<string, int?> dictionary = new Dictionary<string, int?>
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", null},
            };

            //get the HashCode 2000 times to confirm it is consistent for lifetime of dictionary
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(dictionary));
            }

            Assert.AreEqual(1, hashes.Count);
        }
    }

}
