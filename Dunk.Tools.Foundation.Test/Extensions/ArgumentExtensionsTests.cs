using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class ArgumentExtensionsTests
    {
        [Test]
        public void ThrowIfNullThrowsIfParameterIsNull()
        {
            TestArgumentItem arg = null;

            Assert.Throws<ArgumentNullException>(() => arg.ThrowIfNull("param1"));
        }

        [Test]
        public void ThrowIfNullThrowsExceptionWithParameterName()
        {
            TestArgumentItem arg = null;
            string parameterName = null;

            try
            {
                arg.ThrowIfNull("param1");
            }
            catch (ArgumentNullException e)
            {
                parameterName = e.ParamName;
            }

            Assert.AreEqual("param1", parameterName);
        }

        [Test]
        public void ThrowIfNullOrEmptyThrowsForNullCollectionParameter()
        {
            IEnumerable<TestArgumentItem> collection = null;

            Assert.Throws<ArgumentNullException>(() => collection.ThrowIfNullOrEmpty("param1"));
        }

        [Test]
        public void ThrowIfNullOrEmptyThrowsForEmptyCollectionParameter()
        {
            IEnumerable<TestArgumentItem> collection = new List<TestArgumentItem>();

            Assert.Throws<ArgumentException>(() => collection.ThrowIfNullOrEmpty("param1"));
        }

        [Test]
        public void ThrowIfNullOrEmptyThrowsExceptionWithParameterName()
        {
            IEnumerable<TestArgumentItem> collection = null;
            string parameterName = null;

            try
            {
                collection.ThrowIfNullOrEmpty("param1");
            }
            catch (ArgumentNullException e)
            {
                parameterName = e.ParamName;
            }

            Assert.AreEqual("param1", parameterName);
        }

        [Test]
        public void ThrowIfNullOrEmptyDoesNotThrowIfSequenceContainsItems()
        {
            var collection = new[] { new TestArgumentItem() };

            Assert.DoesNotThrow(() => collection.ThrowIfNullOrEmpty("param1"));
        }

        [Test]
        public void StringThrowIfNullOrEmptyDoesNotThrowIfStringIsNotEmpty()
        {
            string s = "foo";
            Assert.DoesNotThrow(() => s.ThrowIfNullOrEmpty("param1"));
        }

        [Test]
        public void StringThrowIfNullOrEmptyThrowsIfNull()
        {
            string s = null;
            Assert.Throws<ArgumentNullException>(() => s.ThrowIfNullOrEmpty("param1"));
        }

        [Test]
        public void StringThrowIfNullOrEmptyThrowsIfEmpty()
        {
            string s = string.Empty;
            Assert.Throws<ArgumentNullException>(() => s.ThrowIfNullOrEmpty("param1"));
        }

        [Test]
        public void ThrowIfNullOrContainsNullThrowsIfSequenceIsNull()
        {
            IEnumerable<TestArgumentItem> sequence = null;
            Assert.Throws<ArgumentNullException>(() => sequence.ThrowIfNullOrContainsNull("param1"));
        }

        [Test]
        public void ThrowIfNullOrContainsNullThrowsIfSequenceContainsNull()
        {
            IEnumerable<TestArgumentItem> sequence = new TestArgumentItem[] { null };
            Assert.Throws<ArgumentException>(() => sequence.ThrowIfNullOrContainsNull("param1"));
        }

        [Test]
        public void ThrowIfNullOrContainsNullDoesNotThrowIfSequenceDoesNotContainNull()
        {
            IEnumerable<TestArgumentItem> sequence = new TestArgumentItem[] { new TestArgumentItem() };
            Assert.DoesNotThrow(() => sequence.ThrowIfNullOrContainsNull("param1"));
        }

        private class TestArgumentItem { }
    }
}
