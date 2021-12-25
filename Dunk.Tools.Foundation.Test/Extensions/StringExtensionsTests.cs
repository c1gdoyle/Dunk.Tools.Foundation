using System;
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
        public void DeleteLastCharacterReturnsEmptyIfStringIsNull()
        {
            string s = null;
            string result = s.DeleteLastCharacter();

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void DeleteLastCharacterReturnsEmptyIfStringIsEmpty()
        {
            string s = string.Empty;
            string result = s.DeleteLastCharacter();

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void DeleteLastCharacterReturnsEmptyIfStringIsSingleCharacter()
        {
            string s = "s";
            string result = s.DeleteLastCharacter();

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void DeleteLastCharacterReturnsExpectedString()
        {
            string s = "Hello World!";
            string result = s.DeleteLastCharacter();

            Assert.AreEqual("Hello World", result);
        }

        [Test]
        public void DeleteLastCharacterReturnsExpectedStringForWhiteSpace()
        {
            string s = "      ";
            string result = s.DeleteLastCharacter();

            Assert.AreEqual("     ", result);
        }

        [Test]
        public void TrimLastCharacterReturnsEmptyIfStringIsNull()
        {
            string s = null;
            string result = s.TrimLastCharacter();

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void TrimLastCharacterReturnsEmptyIfStringIsEmpty()
        {
            string s = string.Empty;
            string result = s.TrimLastCharacter();

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void TrimLastCharacterReturnsEmptyIfStringIsSingleCharacter()
        {
            string s = "s";
            string result = s.TrimLastCharacter();

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void TrimLastCharacterReturnsExpectedString()
        {
            string s = "Hello World!";
            string result = s.TrimLastCharacter();

            Assert.AreEqual("Hello World", result);
        }

        [Test]
        public void TrimeLastCharacterReturnsEmptyStringForWhiteSpace()
        {
            string s = "      ";
            string result = s.TrimLastCharacter();

            Assert.AreEqual(string.Empty, result);
        }

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

        [Test]
        public void DefaultUnderlineThrowsIfStringIsNull()
        {
            string s = null;
            Assert.Throws<ArgumentNullException>(() => s.Underline());
        }

        [Test]
        public void DefaultUnderlineApplysUnderlineToString()
        {
            string expected = "Aardvark" + Environment.NewLine + "--------";
            string s = "Aardvark";

            string value = s.Underline();

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void CustomUnderlineThrowsIfStringIsNull()
        {
            string s = null;

            Assert.Throws<ArgumentNullException>(() => s.Underline('_'));
        }

        [Test]
        public void CustomUnderlineApplysUnderlineToString()
        {
            string expected = "Aardvark" + Environment.NewLine + "________";
            string s = "Aardvark";

            string value = s.Underline('_');

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void ComputeLevenshteinDistanceThrowsIfFirstStringIsNull()
        {
            string s = null;
            string neighbour = "Aardvark";

            Assert.Throws<ArgumentNullException>(() => s.ComputeLevenshteinDistance(neighbour));
        }

        [Test]
        public void ComputeLevenshteinDistanceThrowsIfNeightbourIsNull()
        {
            string s = "Aardvark";
            string neighbour = null;

            Assert.Throws<ArgumentNullException>(() => s.ComputeLevenshteinDistance(neighbour));
        }

        [Test]
        public void ComputeLevenshteinDistanceReturnsExpectedNumberIfStringAndNeighbourAreSame()
        {
            const int expected = 0;

            string s = "Aardvark";
            string neighbour = "Aardvark";

            int distance = s.ComputeLevenshteinDistance(neighbour);

            Assert.AreEqual(expected, distance);
        }

        [Test]
        public void ComputeLevenshteinDistanceReturnsExpectedNumberIfStringAndNeighbourAreDifferent()
        {
            const int expected = 6;

            string s = "Aardvark";
            string neighbour = "kravdraA";

            int distance = s.ComputeLevenshteinDistance(neighbour);

            Assert.AreEqual(expected, distance);
        }

        [Test]
        public void ComputeLevenshteinDistanceReturnsExpectedNumberIfStringAndNeighbourAreBothEmpty()
        {
            const int expected = 0;

            string s = string.Empty;
            string neighbour = string.Empty;

            int distance = s.ComputeLevenshteinDistance(neighbour);

            Assert.AreEqual(expected, distance);
        }

        [Test]
        public void ComputeLevenshteinDistanceReturnsExpectedNumberIfStringIsEmpty()
        {
            const int expected = 8;

            string s = string.Empty;
            string neighbour = "Aardvark";

            int distance = s.ComputeLevenshteinDistance(neighbour);

            Assert.AreEqual(expected, distance);
        }

        [Test]
        public void ComputeLevenshteinDistanceReturnsExpectedNumberIfNeighbourIsEmpty()
        {
            const int expected = 8;

            string s = "Aardvark";
            string neighbour = string.Empty;

            int distance = s.ComputeLevenshteinDistance(neighbour);

            Assert.AreEqual(expected, distance);
        }

        [Test]
        public void ComputeLevenshteinDistanceReturnsExpectedNumberIfStringContainsWhiteSpace()
        {
            const int expected = 8;

            string s = "Tom the Aardvark";
            string neighbour = "Aardvark";

            int distance = s.ComputeLevenshteinDistance(neighbour);

            Assert.AreEqual(expected, distance);
        }

        [Test]
        public void ComputeLevenshteinDistanceReturnsExpectedNumberIfNeighbourContainsWhiteSpace()
        {
            const int expected = 8;

            string s = "Aardvark";
            string neighbour = "Tom the Aardvark";

            int distance = s.ComputeLevenshteinDistance(neighbour);

            Assert.AreEqual(expected, distance);
        }

        [Test]
        public void ComputeLevenshteinDistanceReturnsExpectedNumberIfStringContainsSpecialCharacter()
        {
            const int expected = 1;

            string s = "Aardvark!";
            string neighbour = "Aardvark";

            int distance = s.ComputeLevenshteinDistance(neighbour);

            Assert.AreEqual(expected, distance);
        }

        [Test]
        public void ComputeLevenshteinDistanceReturnsExpectedNumberIfNeighbourContainsSpecialCharacter()
        {
            const int expected = 1;

            string s = "Aardvark";
            string neighbour = "Aardvark!";

            int distance = s.ComputeLevenshteinDistance(neighbour);

            Assert.AreEqual(expected, distance);
        }

        [Test]
        public void ToTitleCaseThrowsIfStringIsNull()
        {
            string s = null;

            Assert.Throws<ArgumentNullException>(() => s.ToTitleCase());
        }

        [Test]
        public void ToTitleCaseConvertsToTitleCase()
        {
            const string expected = "To Title Case";

            string s = "to title case";
            Assert.AreEqual(expected, s.ToTitleCase());
        }

        [Test]
        public void ToTitleCaseDoesNotAlterTitleCaseString()
        {
            const string expected = "To Title Case";

            string s = "To Title Case";
            Assert.AreEqual(expected, s.ToTitleCase());
        }

        [Test]
        public void ToTitleCaseConvertsUpperCaseWord()
        {
            const string expected = "To Title Case";

            var s = "To TITLE Case";
            Assert.AreEqual(expected, s.ToTitleCase());
        }

        [Test]
        public void ToTitleCaseConvertsCamelCaseString()
        {
            const string expected = "Totitlecase";

            string s = "ToTitleCase";
            Assert.AreEqual(expected, s.ToTitleCase());
        }

        [Test]
        public void ToTitleCaseConvertsUpperCaseCamelCaseString()
        {
            const string expected = "Totitlecase";

            string s = "TOTITLECASE";
            Assert.AreEqual(expected, s.ToTitleCase());
        }

        [Test]
        public void ToTitleCaseHandlesEmptyString()
        {
            const string expected = "";

            var s = string.Empty;
            Assert.AreEqual(expected, s.ToTitleCase());
        }

        [Test]
        public void ToTitleCaseRecognisesSpecialCharactersAsWhiteSpace()
        {
            const string expected = "To      Title\tCase";

            string s = "To      Title\tcase";
            Assert.AreEqual(expected, s.ToTitleCase());
        }

        [Test]
        public void ToTitleCaseChompsWhiteSpace()
        {
            const string expected = "To Title Case";

            string s = "To      Title\tcase";
            Assert.AreEqual(expected, s.ToTitleCase(true));
        }

        [Test]
        public void ToCamelCaseThrowsIfStringIsNull()
        {
            string s = null;
            Assert.Throws<ArgumentNullException>(() => s.ToCamelCase());
        }

        [Test]
        public void ToCamelCaseThrowsIfStringIsNullAndCustomDelimiter()
        {
            string s = null;
            Assert.Throws<ArgumentNullException>(() => s.ToCamelCase('_'));
        }

        [Test]
        public void ToCamelCaseReturnsCamelCaseString()
        {
            const string expected = "ToCamelCase";

            string s = "to camel case";

            Assert.AreEqual(expected, s.ToCamelCase());
        }

        [Test]
        public void ToCamelCaseReturnsCamelCaseStringWithCustomDelimiter()
        {
            const string expected = "ToCamelCase";

            string s = "to_camel_case";

            Assert.AreEqual(expected, s.ToCamelCase('_'));
        }

        [Test]
        public void ToCamelCaseReturnsExpectedStringIfLettersAreUpperCase()
        {
            const string expected = "ToCamelCase";

            string s = "TO CAMEL CASE";

            Assert.AreEqual(expected, s.ToCamelCase());
        }

        [Test]
        public void ToCamelCaseReturnsExpectedStringIfLettersAreUpperCaseWithCustomDelimiter()
        {
            const string expected = "ToCamelCase";

            string s = "TO_CAMEL_CASE";

            Assert.AreEqual(expected, s.ToCamelCase('_'));
        }

        [Test]
        public void ToCamelCaseReturnsCamelCaseStringIfStringStartsWithDefaultDelimiter()
        {
            const string expected = "ToCamelCase";

            string s = " to camel case";

            Assert.AreEqual(expected, s.ToCamelCase());
        }

        [Test]
        public void ToCamelCaseReturnsCamelCaseStringIfStringStartsWithCustomDelimiter()
        {
            const string expected = "ToCamelCase";

            string s = "_to_camel_case";

            Assert.AreEqual(expected, s.ToCamelCase('_'));
        }

        [Test]
        public void ToCamelCaseReturnsCamelCaseStringIfStringEndsWithDefaultDelimiter()
        {
            const string expected = "ToCamelCase";

            string s = "to camel case ";

            Assert.AreEqual(expected, s.ToCamelCase());
        }

        [Test]
        public void ToCamelCaseReturnsCamelCaseStringIfStringEndsWithCustomDelimiter()
        {
            const string expected = "ToCamelCase";

            string s = "to_camel_case_";

            Assert.AreEqual(expected, s.ToCamelCase('_'));
        }

        [Test]
        public void ToCamelCaseReturnsExpectedStringIfStringIsEmpty()
        {
            const string expected = "";

            string s = string.Empty;

            Assert.AreEqual(expected, s.ToCamelCase());
        }

        [Test]
        public void ToCamelCaseReturnsExpectedStringIfStringIsEmptyWithCustomDelimiter()
        {
            const string expected = "";

            string s = string.Empty;

            Assert.AreEqual(expected, s.ToCamelCase('_'));
        }

        [Test]
        public void ExpandCamelCaseThrowsIfStringIsNull()
        {
            string s = null;
            Assert.Throws<ArgumentNullException>(() => s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseThrowsIfStringIsNullAndCustomDelimiter()
        {
            string s = null;
            Assert.Throws<ArgumentNullException>(() => s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseExpands()
        {
            const string expected = "Expand Camel Case";

            string s = "ExpandCamelCase";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsWithSpecifedDelimiter()
        {
            const string expected = "Expand-Camel-Case";

            string s = "ExpandCamelCase";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseHandlesEmptString()
        {
            const string expected = "";

            string s = string.Empty;
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsStringContainingWhitespace()
        {
            const string expected = "Expand Camel Case";

            string s = "Expand CamelCase";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsStringContainingWhitespaceWithCustomDelimiter()
        {
            const string expected = "Expand-Camel-Case";

            string s = "Expand CamelCase";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseExpandsStringContainingNonLetterCharacter()
        {
            const string expected = "Expand Cam 3l Case";

            string s = "ExpandCam3lCase";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsStringContainingNonLetterCharacterWithCustomDelimiter()
        {
            const string expected = "Expand-Cam-3l-Case";

            string s = "ExpandCam3lCase";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseExpandsStringContainingUpperLetterAtEndOfString()
        {
            const string expected = "Expand Camel Case S";

            string s = "ExpandCamelCaseS";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsStringContainingUpperLetterAtEndOfStringWithCustomDelimiter()
        {
            const string expected = "Expand-Camel-Case-S";

            string s = "ExpandCamelCaseS";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseExpandsStringContainingNonLetterAtEndOfString()
        {
            const string expected = "Expand Camel Case 3";

            string s = "ExpandCamelCase3";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsStringContainingNonLetterAtEndOfStringWithCustomDelimiter()
        {
            const string expected = "Expand-Camel-Case-3";

            string s = "ExpandCamelCase3";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseDoesNotExpandsStringContainingOnlyUpperCaseLetters()
        {
            const string expected = "EXPANDCAMELCASE";

            string s = "EXPANDCAMELCASE";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseDoesNotExpandsStringContainingOnlyUpperCaseLettersWithCustomDelimiter()
        {
            const string expected = "EXPANDCAMELCASE";

            string s = "EXPANDCAMELCASE";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseDoesNotExpandsStringContainingOnlyNonLetterCharacters()
        {
            const string expected = "12345678";

            string s = "12345678";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseDoesNotExpandsStringContainingOnlyNonLetterCharactersWithCustomDelimiter()
        {
            const string expected = "12345678";

            string s = "12345678";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithSameAdjacentUpperCaseLetter()
        {
            const string expected = "Expand Camel Case SS";

            string s = "ExpandCamelCaseSS";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithSameAdjacentUpperCaseLetterWithCustomDelimiter()
        {
            const string expected = "Expand-Camel-Case-SS";

            string s = "ExpandCamelCaseSS";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithSameAdjacentNonLetterCharacter()
        {
            const string expected = "Expand Camel Case 22";

            string s = "ExpandCamelCase22";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithSameAdjacentNonLetterCharacterWithCustomDelimiter()
        {
            const string expected = "Expand-Camel-Case-22";

            string s = "ExpandCamelCase22";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithDifferentAdjacentUpperCaseLetter()
        {
            const string expected = "Expand Camel Case SZ";

            string s = "ExpandCamelCaseSZ";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithDifferentAdjacentUpperCaseLetterWithCustomDelimiter()
        {
            const string expected = "Expand-Camel-Case-SZ";

            string s = "ExpandCamelCaseSZ";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithDifferentAdjacentNonLetterCharacter()
        {
            const string expected = "Expand Camel Case 12";

            string s = "ExpandCamelCase12";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithDifferentAdjacentNonLetterCharacterWithCustomDelimiter()
        {
            const string expected = "Expand-Camel-Case-12";

            string s = "ExpandCamelCase12";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithAdjacentUpperCaseAndNonLetterCharacter()
        {
            const string expected = "E 2pand Camel Case";

            string s = "E2pandCamelCase";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithAdjacentUpperCaseAndNonLetterCharacterWithCustomDelimiter()
        {
            const string expected = "E-2pand-Camel-Case";

            string s = "E2pandCamelCase";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithAdjacentNonLetterAndUpperCaseCharacter()
        {
            const string expected = "3 Xpand Camel Case";

            string s = "3XpandCamelCase";
            Assert.AreEqual(expected, s.ExpandCamelCase());
        }

        [Test]
        public void ExpandCamelCaseExpandsStringWithAdjacentNonLetterAndUpperCaseCharacterWithCustomDelimiter()
        {
            const string expected = "3-Xpand-Camel-Case";

            string s = "3XpandCamelCase";
            Assert.AreEqual(expected, s.ExpandCamelCase('-'));
        }

        [Test]
        public void ToCamelCaseCreatesStringThatCanBeExpandedFromCamelCase()
        {
            const string expected = "To Camel Case And Back";

            string camelCase = expected.ToCamelCase();

            Assert.AreEqual(expected, camelCase.ExpandCamelCase());
        }

        [Test]
        public void ToCamelCaseCreatesStringThatCanBeExpandedFromCamelCaseWithCustomDelimiter()
        {
            const string expected = "To_Camel_Case_And_Back";

            string camelCase = expected.ToCamelCase('_');

            Assert.AreEqual(expected, camelCase.ExpandCamelCase('_'));
        }

        [Test]
        public void GetSubStringBeforeOrEmptyThrowsIfStopAtIsNull()
        {
            string text = "abcdefg";
            Assert.Throws<ArgumentNullException>(() => text.GetSubStringBeforeOrEmpty(null));
        }

        [Test]
        public void GetSubStringBeforeOrEmptyReturnsEmptyForNullString()
        {
            const string expected = "";

            string text = null;

            string result = text.GetSubStringBeforeOrEmpty("cd");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringBeforeOrEmptyReturnsEmptyForEmptyString()
        {
            const string expected = "";

            string text = string.Empty;

            string result = text.GetSubStringBeforeOrEmpty("cd");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringBeforeOrEmptyReturnsEmptyForWhiteSpace()
        {
            const string expected = "";

            string text = "  ";

            string result = text.GetSubStringBeforeOrEmpty("cd");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringBeforeOrEmptyReturnsEmptyIfTextDoesNotContainStopAtString()
        {
            const string expected = "";

            string text = "abcdefg";

            string result = text.GetSubStringBeforeOrEmpty("yz");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringBeforeOrEmptyReturnsExpectedSubStringForSpecifiedStopAtCharacter()
        {
            const string expected = "ab";

            string text = "abcdefg";

            string result = text.GetSubStringBeforeOrEmpty("c");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringBeforeOrEmptyReturnsExpectedSubStringForSpecifiedStopAtString()
        {
            const string expected = "ab";

            string text = "abcdefg";

            string result = text.GetSubStringBeforeOrEmpty("cd");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringBeforeOrEmptyReturnsExpectedSubStringForSpecifiedComparison()
        {
            const string expected = "ab";

            string text = "abcdefg";

            string result = text.GetSubStringBeforeOrEmpty("CD", StringComparison.InvariantCultureIgnoreCase);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringBeforeOrEmptyReturnsEmptyIfSubStringOccursAtStartOfString()
        {
            const string expected = "";

            string text = "abcdefg";

            string result = text.GetSubStringBeforeOrEmpty("ab");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringBeforeOrEmptyReturnsEmptyIfSubStringOccursAtStartOfStringUsingSpecifiedStringComparison()
        {
            const string expected = "";

            string text = "abcdefg";

            string result = text.GetSubStringBeforeOrEmpty("AB", StringComparison.InvariantCultureIgnoreCase);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringAfterOrEmptyThrowsIfStartAtIsNull()
        {
            string text = "abcdefg";
            Assert.Throws<ArgumentNullException>(() => text.GetSubStringAfterOrEmpty(null));
        }

        [Test]
        public void GetSubStringAfterOrEmptyReturnsEmptyForNullString()
        {
            const string expected = "";

            string text = null;

            string result = text.GetSubStringAfterOrEmpty("cd");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringAfterOrEmptyReturnsEmptyForEmptyString()
        {
            const string expected = "";

            string text = string.Empty;

            string result = text.GetSubStringAfterOrEmpty("cd");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringAfterOrEmptyReturnsEmptyForWhiteSpace()
        {
            const string expected = "";

            string text = "  ";

            string result = text.GetSubStringAfterOrEmpty("cd");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringAfterOrEmptyReturnsEmptyIfTextDoesNotContainStartFromString()
        {
            const string expected = "";

            string text = "abcdefg";

            string result = text.GetSubStringAfterOrEmpty("yz");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringAfterOrEmptyReturnsExpectedSubStringForSpecifiedStartFromCharacter()
        {
            const string expected = "defg";

            string text = "abcdefg";

            string result = text.GetSubStringAfterOrEmpty("c");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringAfterOrEmptyReturnsExpectedSubStringForSpecifiedStartFromString()
        {
            const string expected = "efg";

            string text = "abcdefg";

            string result = text.GetSubStringAfterOrEmpty("cd");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringAfterOrEmptyReturnsExpectedSubStringForSpecifiedComparison()
        {
            const string expected = "efg";

            string text = "abcdefg";

            string result = text.GetSubStringAfterOrEmpty("CD", StringComparison.InvariantCultureIgnoreCase);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringAfterOrEmptyReturnsEmptyIfSubStringOccursAtEndOfString()
        {
            const string expected = "";

            string text = "abcdefg";

            string result = text.GetSubStringAfterOrEmpty("fg");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetSubStringAfterOrEmptyReturnsEmptyIfSubStringOccursAtEndOfStringUsingSpecifiedStringComparison()
        {
            const string expected = "";

            string text = "abcdefg";

            string result = text.GetSubStringAfterOrEmpty("FG", StringComparison.InvariantCultureIgnoreCase);

            Assert.AreEqual(expected, result);
        }
    }
}
