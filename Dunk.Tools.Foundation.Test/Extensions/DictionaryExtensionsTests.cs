using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class DictionaryExtensionsTests
    {
        [Test]
        public void GetValueOrDefaultReturnsValueIfKeyIsPresent()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            int result = dictionary.GetValueOrDefault("key1", () => default(int));

            Assert.AreEqual(1, result);
        }

        [Test]
        public void GetValueOrDefaultReturnsDefaultIfKeyIsNotPresent()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            int result = dictionary.GetValueOrDefault("key3", () => default(int));

            Assert.AreEqual(0, result);
        }

        [Test]
        public void GetOrAddReturnsValueIfKeyIsPresent()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            int result = dictionary.GetOrAdd("key1");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void GetOrAddAddsKeyValuePairToDictionaryIfKeyIsNotPresent()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            dictionary.GetOrAdd("key3");

            Assert.IsTrue(dictionary.ContainsKey("key3"));
        }

        [Test]
        public void GetOrAddReturnsDefaultValueIfKeyIsNotPresent()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            int result = dictionary.GetOrAdd("key3");

            Assert.AreEqual(0, result);
        }

        [Test]
        public void GetOrAddOverloadReturnsValueIfKeyIsNotPresent()
        {
            const int addValue = 15;
            Func<string, int> addValueFactory = s => { return addValue; };

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            int result = dictionary.GetOrAdd("key1", addValueFactory);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void GetOrAddOverloadAddsKeyValuePairToDictionaryIfKeyIsNotPresent()
        {
            const int addValue = 15;
            Func<string, int> addValueFactory = s => { return addValue; };

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            dictionary.GetOrAdd("key3", addValueFactory);

            Assert.IsTrue(dictionary.ContainsKey("key3"));
        }

        [Test]
        public void GetOrAddOverloadReturnsAddFactoryResultIfKeyIsNotPresent()
        {
            const int addValue = 15;
            Func<string, int> addValueFactory = s => { return addValue; };

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            int result = dictionary.GetOrAdd("key3", addValueFactory);

            Assert.AreEqual(addValue, result);
        }

        [Test]
        public void AddOrUpdateUpdatesValueInDictionaryIfKeyIsPresent()
        {
            const int addValue = 15;
            Func<string, int, int> updateFactory = (s, i) => { return i + 5; };

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            dictionary.AddOrUpdate("key1", addValue, updateFactory);

            Assert.AreEqual(6, dictionary["key1"]);
        }

        [Test]
        public void AddOrUpdateReturnsUpdatedValueIfKeyIsPresent()
        {
            const int addValue = 15;
            Func<string, int, int> updateFactory = (s, i) => { return i + 5; };

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            int result = dictionary.AddOrUpdate("key1", addValue, updateFactory);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void AddOrUpdateAddsKeyValuePairToDictionaryIfKeyIsNotPresent()
        {
            const int addValue = 15;
            Func<string, int, int> updateFactory = (s, i) => { return i + 5; };

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            dictionary.AddOrUpdate("key3", addValue, updateFactory);

            Assert.IsTrue(dictionary.ContainsKey("key3"));
        }

        [Test]
        public void AddOrUpdateReturnsAddedValueIfKeyIsNotPresent()
        {
            const int addValue = 15;
            Func<string, int, int> updateFactory = (s, i) => { return i + 5; };

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"key1", 1 },
                {"key2", 2 }
            };

            int result = dictionary.AddOrUpdate("key3", addValue, updateFactory);

            Assert.AreEqual(addValue, result);
        }

        [Test]
        public void DictionaryMergeThrowsIfNull()
        {
            Dictionary<string, string>[] dictionaries = null;
            Assert.Throws<ArgumentNullException>(() => dictionaries.Merge());
        }

        [Test]
        public void DictionaryMergeCombinesDictionariesIfNoDuplicateKeys()
        {
            Dictionary<string, string>[] dictionaries = new[]
            {
                new Dictionary<string, string>
                {
                    {"Key_1", "Value_1" },
                    {"Key_2", "Value_2" }
                },
                new Dictionary<string, string>
                {
                    {"Key_3", "Value_3" }
                }
            };

            IDictionary<string, string> mergedDictionary = dictionaries.Merge();

            Assert.IsNotNull(mergedDictionary);
            Assert.AreEqual(3, mergedDictionary.Count);
        }

        [Test]
        public void DictionaryMergeThrowsIfDuplicateKeys()
        {
            Dictionary<string, string>[] dictionaries = new[]
            {
                new Dictionary<string, string>
                {
                    {"Key_1", "Value_1" },
                    {"Key_2", "Value_2" }
                },
                new Dictionary<string, string>
                {
                    {"Key_1", "Value_3" }
                }
            };
            Assert.Throws<ArgumentException>(() => dictionaries.Merge());
        }

        [Test]
        public void DictionarySafeMergeThrowsIfNull()
        {
            Dictionary<string, string>[] dictionaries = null;
            Assert.Throws<ArgumentNullException>(() => dictionaries.SafeMerge());
        }

        [Test]
        public void DictionarySafeMergeCombinesDictionariesIfNoDuplicateKeys()
        {
            Dictionary<string, string>[] dictionaries = new[]
            {
                new Dictionary<string, string>
                {
                    {"Key_1", "Value_1" },
                    {"Key_2", "Value_2" }
                },
                new Dictionary<string, string>
                {
                    {"Key_3", "Value_3" }
                }
            };

            IDictionary<string, string> mergedDictionary = dictionaries.SafeMerge();

            Assert.IsNotNull(mergedDictionary);
            Assert.AreEqual(3, mergedDictionary.Count);
        }

        [Test]
        public void DictionarySafeMergeCombinesDictionariesIfDuplicateKeys()
        {
            Dictionary<string, string>[] dictionaries = new[]
            {
                new Dictionary<string, string>
                {
                    {"Key_1", "Value_1" },
                    {"Key_2", "Value_2" }
                },
                new Dictionary<string, string>
                {
                    {"Key_1", "Value_3" }
                }
            };

            IDictionary<string, string> mergedDictionary = dictionaries.SafeMerge();

            Assert.IsNotNull(mergedDictionary);
            Assert.AreEqual(2, mergedDictionary.Count);
        }
    }
}
