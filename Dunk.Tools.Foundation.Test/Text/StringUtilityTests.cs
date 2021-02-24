using System;
using Dunk.Tools.Foundation.Text;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Text
{
    [TestFixture]
    public class StringUtilityTests
    {
        [Test]
        public void StringUtilityJoinThrowsIfStringsParameterIsNull()
        {
            string[] array = null;
            string separator = ", ";
            string lastSeparator = " and ";

            Assert.Throws<ArgumentNullException>(() => StringUtility.Join(array, separator, lastSeparator));
        }

        [Test]
        public void StringUtilityJoinThrowsIfSeparatorParameterIsNull()
        {
            string[] array = { "Tom", "Dick", "Harry" };
            string separator = null;
            string lastSeparator = " and ";

            Assert.Throws<ArgumentNullException>(() => StringUtility.Join(array, separator, lastSeparator));
        }

        [Test]
        public void StringUtilityJoinThrowsIfLastSeparatorParameterIsNull()
        {
            string[] array = { "Tom", "Dick", "Harry" };
            string separator = ", ";
            string lastSeparator = null;

            Assert.Throws<ArgumentNullException>(() => StringUtility.Join(array, separator, lastSeparator));
        }

        [Test]
        public void StringUtilityJoinConcatenatesStringsToExpectedResultString()
        {
            const string expected = "Tom, Dick and Harry";

            string[] array = { "Tom", "Dick", "Harry" };
            string separator = ", ";
            string lastSeparator = " and ";

            string result = StringUtility.Join(array, separator, lastSeparator);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringUtilityJoinConcatenatesWhenStringsContainsTwoElements()
        {
            const string expected = "Tom and Harry";

            string[] array = { "Tom", "Harry" };
            string separator = ", ";
            string lastSeparator = " and ";

            string result = StringUtility.Join(array, separator, lastSeparator);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringUtilityJoinConcatenatesWhenStringsContainsOneElement()
        {
            const string expected = "Tom";

            string[] array = { "Tom" };
            string separator = ", ";
            string lastSeparator = " and ";

            string result = StringUtility.Join(array, separator, lastSeparator);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringUtilityJoinConcatenatesWhenStringsContainsNoElements()
        {
            const string expected = "";

            string[] array = new string[0];
            string separator = ", ";
            string lastSeparator = " and ";

            string result = StringUtility.Join(array, separator, lastSeparator);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringUtilityJoinWithQuotationConcatenatesStringsToExpectedResultString()
        {
            const string expected = "'Tom', 'Dick' and 'Harry'";

            string[] array = { "Tom", "Dick", "Harry" };
            string separator = ", ";
            string lastSeparator = " and ";
            string quotation = "'";

            string result = StringUtility.Join(array, separator, lastSeparator, quotation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringUtilityJoinWithQuotationConcatenatesWhenStringsContainsTwoElements()
        {
            const string expected = "'Tom' and 'Harry'";

            string[] array = { "Tom", "Harry" };
            string separator = ", ";
            string lastSeparator = " and ";
            string quotation = "'";

            string result = StringUtility.Join(array, separator, lastSeparator, quotation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringUtilityJoinWithQuotationConcatenatesWhenStringsContainsOneElement()
        {
            const string expected = "'Tom'";

            string[] array = { "Tom" };
            string separator = ", ";
            string lastSeparator = " and ";
            string quotation = "'";

            string result = StringUtility.Join(array, separator, lastSeparator, quotation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringUtilityJoinWithQuotationConcatenatesWhenStringsContainsNoElements()
        {
            const string expected = "";

            string[] array = new string[0];
            string separator = ", ";
            string lastSeparator = " and ";
            string quotation = "'";

            string result = StringUtility.Join(array, separator, lastSeparator, quotation);

            Assert.AreEqual(expected, result);
        }
    }
}
