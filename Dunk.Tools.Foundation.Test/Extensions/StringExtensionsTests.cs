﻿using System;
using System.Collections.Generic;
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

        [Test]
        public void StringReverseReturnsExpectedString()
        {
            string value = "Aardvark";
            string expected = "kravdraA";

            string reversed = value.Reverse();

            Assert.AreEqual(expected, reversed);
        }

        [Test]
        public void StringReverseHandlesEmptyString()
        {
            Assert.DoesNotThrow(() => string.Empty.Reverse());
        }

        [Test]
        public void StringReverseHandlesWhiteSpaceString()
        {
            Assert.DoesNotThrow(() => "     ".Reverse());
        }

        [Test]
        public void StringReverseThrowsIfInputIsNull()
        {
            string value = null;
            Assert.Throws<ArgumentNullException>(() => value.Reverse());
        }

        [Test]
        public void GenerateRandomStringReturnsStringOfExpectedLength()
        {
            const int expected = 100;

            string result = StringExtensions.GenerateRandomString(expected);

            Assert.AreEqual(expected, result.Length);
        }

        [Test]
        public void GenerateRandomStringReturnsStringOfLengthZero()
        {
            const int expected = 0;

            string result = StringExtensions.GenerateRandomString(expected);

            Assert.AreEqual(expected, result.Length);
        }

        [Test]
        public void GenerateRandomStringThrowsIfLengthIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => StringExtensions.GenerateRandomString(-1));
        }

        [Test]
        public void GenerateRandomAsciiStringOfExpectedLength()
        {
            const int expected = 100;

            string result = StringExtensions.GenerateRandomAsciiString(expected);

            Assert.AreEqual(expected, result.Length);
        }

        [Test]
        public void GenerateRandomAsciiStringIsAscii()
        {
            const int expected = 100;

            string result = StringExtensions.GenerateRandomAsciiString(expected);

            Assert.IsTrue(result.IsASCII());
        }

        [Test]
        public void GenerateRandomAsciiStringReturnsStringOfLengthZero()
        {
            const int expected = 0;

            string result = StringExtensions.GenerateRandomAsciiString(expected);

            Assert.AreEqual(expected, result.Length);
        }

        [Test]
        public void GenerateRandomAsciiStringThrowsIfLengthIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => StringExtensions.GenerateRandomAsciiString(-1));
        }

        [Test]
        public void UnquoteThrowsIfStringIsNull()
        {
            string s = null;

            Assert.Throws<ArgumentNullException>(() => s.Unquote());
        }

        [Test]
        public void UnquoteRemovesSingleQuotationMarksFromString()
        {
            const string expected = "foo";
            string s = "\'foo\'";

            string value = s.Unquote();

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void UnquoteRemovesDoubleQuotationMarksFromString()
        {
            const string expected = "foo";
            string s = "\"foo\"";

            string value = s.Unquote();

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void ReplaceThrowsIfStringIsNull()
        {
            string s = null;
            var replacements = new List<Tuple<string, string>>();

            Assert.Throws<ArgumentNullException>(() => s.Replace(replacements));
        }

        [Test]
        public void ReplaceThrowsIfReplacementsIsNull()
        {
            string s = "bbbb";
            List<Tuple<string, string>> replacements = null;

            Assert.Throws<ArgumentNullException>(() => s.Replace(replacements));
        }

        [Test]
        public void ReplaceReplacesStrings()
        {
            const string expected = "AAAA";
            string s = "bbbb";
            List<Tuple<string, string>> replacements = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("bb", "AA")
            };

            string value = s.Replace(replacements);

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void ReplaceCharThrowsIfStringIsNull()
        {
            string s = null;
            var replacements = new List<Tuple<char, char>>();

            Assert.Throws<ArgumentNullException>(() => s.Replace(replacements));
        }

        [Test]
        public void ReplaceCharThrowsIfReplacementsIsNull()
        {
            string s = "bbbb";
            List<Tuple<char, char>> replacements = null;

            Assert.Throws<ArgumentNullException>(() => s.Replace(replacements));
        }

        [Test]
        public void ReplaceCharReplacesStrings()
        {
            const string expected = "AAAA";
            string s = "bbbb";
            List<Tuple<char, char>> replacements = new List<Tuple<char, char>>
            {
                new Tuple<char, char>('b', 'A')
            };

            string value = s.Replace(replacements);

            Assert.AreEqual(expected, value);
        }
    }
}
