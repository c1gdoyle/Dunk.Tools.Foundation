using System;
using System.Text;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void IsASCIIReturnsTrueForASCIIString()
        {
            string value = "9quali52ty3";

            bool result = value.IsASCII();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsASCIIReturnsTrueForSimpleValidString()
        {
            string value = Encoding.ASCII.GetString(new byte[0]);

            bool result = value.IsASCII();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsASCIIReturnsTrueForMultiByteString()
        {
            string value = "\0\0";

            bool result = value.IsASCII();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsASCIIReturnsFalseForUnicodeString()
        {
            string value = "€";

            bool result = value.IsASCII();

            Assert.IsFalse(result);
        }

        [Test]
        public void IsASCIIReturnsTrueForEmptyString()
        {
            string value = string.Empty;

            bool result = value.IsASCII();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsASCIIReturnsTrueForWhiteSpaceString()
        {
            string value = "     ";

            bool result = value.IsASCII();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsASCIIThrowsForNullString()
        {
            string value = null;

            Assert.Throws<ArgumentNullException>(() => value.IsASCII());
        }
    }
}
