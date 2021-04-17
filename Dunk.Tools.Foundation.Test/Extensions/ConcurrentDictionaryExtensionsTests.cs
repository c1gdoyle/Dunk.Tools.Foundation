using System;
using System.Collections.Concurrent;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class ConcurrentDictionaryExtensionsTests
    {
        [Test]
        public void GetOrAddSafeReturnsValueIfDictionaryContainsKey()
        {
            const string expected = "foo";
            var dictionary = new ConcurrentDictionary<int, Lazy<string>>();
            dictionary[1] = new Lazy<string>(() => expected);

            string value = dictionary.GetOrAddSafe(1, k => expected);

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void GetOrAddSafeReturnsDefaultValueIfDictionaryDoesNotContainKey()
        {
            const string expected = "foo";
            var dictionary = new ConcurrentDictionary<int, Lazy<string>>();

            string value = dictionary.GetOrAddSafe(1, k => expected);

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void GetOrAddSafeAddsDefaultKeyValuePairIfDictionaryDoesNotContainKey()
        {
            const string expected = "foo";
            var dictionary = new ConcurrentDictionary<int, Lazy<string>>();

            dictionary.GetOrAddSafe(1, k => expected);

            Lazy<string> value;
            Assert.IsTrue(dictionary.TryGetValue(1, out value));
            Assert.AreEqual(expected, value.Value);
        }

        [Test]
        public void AddOrUpdateSafeAddsValuePairIfDictionaryDoesNotContainKey()
        {
            const string expected = "foo";
            var dictionary = new ConcurrentDictionary<int, Lazy<string>>();

            dictionary.AddOrUpdateSafe(1, k => expected, (k, v) => string.Empty);

            Lazy<string> value;
            Assert.IsTrue(dictionary.TryGetValue(1, out value));
            Assert.AreEqual(expected, value.Value);
        }

        [Test]
        public void AddOrUpdateSafeUpdatesValueIfDictionaryDoesContainKey()
        {
            const string expected = "bar";
            var dictionary = new ConcurrentDictionary<int, Lazy<string>>();
            dictionary[1] = new Lazy<string>(() => "foo");

            dictionary.AddOrUpdateSafe(1, k => string.Empty, (k, v) => expected);

            Lazy<string> value;
            Assert.IsTrue(dictionary.TryGetValue(1, out value));
            Assert.AreEqual(expected, value.Value);
        }
    }
}
