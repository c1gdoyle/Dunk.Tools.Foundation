using System;
using System.Security;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class SecureStringExtensionsTests
    {
        [Test]
        public void ToSecureStringThrowsIfStringIsNull()
        {
            const string s = null;

            Assert.Throws<ArgumentNullException>(() => s.ToSecureString());
        }

        [Test]
        public void ToSecureStringConvertsStringToSecureString()
        {
            const string s = "Aardvark_42";

            SecureString secure = s.ToSecureString();

            Assert.IsNotNull(secure);
        }

        [Test]
        public void ToSecureStringConvertsStringToSecureStringOfExpectedLength()
        {
            const string s = "Aardvark_42";

            SecureString secure = s.ToSecureString();

            Assert.AreEqual(s.Length, secure.Length);
        }

        [Test]
        public void ToSecureStringConvertsEmptyStringToSecureString()
        {
            const string s = "";

            SecureString secure = s.ToSecureString();

            Assert.IsNotNull(secure);
        }

        [Test]
        public void ToSecureStringConvertsEmptyStringToSecureStringOfExpectedLength()
        {
            const string s = "";

            SecureString secure = s.ToSecureString();

            Assert.AreEqual(s.Length, secure.Length);
        }

        [Test]
        public void ToInSecureStringConvertsSecureStringToString()
        {
            const string s = "Aardvark_42";

            SecureString secure = s.ToSecureString();

            string result = secure.ToInSecureString();

            Assert.IsNotNull(result);
        }

        [Test]
        public void ToInSecureStringConvertsSecureStringToExpectedString()
        {
            const string s = "Aardvark_42";

            SecureString secure = s.ToSecureString();

            string result = secure.ToInSecureString();

            Assert.AreEqual(s, result);
        }

        [Test]
        public void ToInSecureStringConvertsEmptySecureStringToExpectedString()
        {
            const string s = "";

            SecureString secure = s.ToSecureString();

            string result = secure.ToInSecureString();

            Assert.AreEqual(s, result);
        }

        [Test]
        public void ToInSecureStringThrowsIfSecureStringIsNull()
        {
            SecureString secure = null;

            Assert.Throws<ArgumentNullException>(() => secure.ToInSecureString());
        }
    }
}
