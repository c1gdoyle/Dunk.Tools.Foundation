using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class BusinessDateTimeExtensionsTests
    {
        [Test]
        public void IsBusinessDayReturnsTrueForWeekDay()
        {
            DateTime original = new DateTime(2017, 01, 02);

            Assert.IsTrue(original.IsBuisnessDay());
        }

        [Test]
        public void IsBusinessDayReturnsFalseForSaturday()
        {
            DateTime original = new DateTime(2017, 01, 07);

            Assert.IsFalse(original.IsBuisnessDay());
        }

        [Test]
        public void IsBusinessDayReturnsTrueForSunday()
        {
            DateTime original = new DateTime(2017, 01, 08);

            Assert.IsFalse(original.IsBuisnessDay());
        }

        [Test]
        public void AddBusinessDaysThrowsIfDaysIsNegative()
        {
            DateTime dt = new DateTime(2018, 01, 01);
            Assert.Throws<ArgumentException>(() => dt.AddBusinessDays(-1));
        }

        [Test]
        public void AddBusinessDaysReturnsOriginalDateIfDaysIsZero()
        {
            DateTime original = new DateTime(2018, 01, 01);
            DateTime dt = original.AddBusinessDays(0);

            Assert.AreEqual(original, dt);
        }

        [Test]
        public void AddBusinessDaysAddsBusinessDays()
        {
            DateTime expected = new DateTime(2017, 01, 06);
            DateTime original = new DateTime(2017, 01, 02);

            DateTime dt = original.AddBusinessDays(4);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void AddBusinessDaysAdjustsExtraDaysIfOriginalDayIsSaturday()
        {
            DateTime expected = new DateTime(2017, 01, 12);
            DateTime original = new DateTime(2017, 01, 07);

            DateTime dt = original.AddBusinessDays(4);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void AddBusinessDaysAdjustsExtraDaysIfOriginalDayIsSunday()
        {
            DateTime expected = new DateTime(2017, 01, 12);
            DateTime original = new DateTime(2017, 01, 08);

            DateTime dt = original.AddBusinessDays(4);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void AddBusinessDaysAddsFullWeeks()
        {
            DateTime expected = new DateTime(2017, 01, 19);
            DateTime original = new DateTime(2017, 01, 08);

            DateTime dt = original.AddBusinessDays(9);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void AddBusinessDaysAdjsutsIfExtraDaysPushToSaturday()
        {
            DateTime expected = new DateTime(2017, 01, 23);
            DateTime original = new DateTime(2017, 01, 10);

            DateTime dt = original.AddBusinessDays(9);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void AddBusinessDaysAdjsutsIfExtraDaysPushToSunday()
        {
            DateTime expected = new DateTime(2017, 01, 24);
            DateTime original = new DateTime(2017, 01, 11);

            DateTime dt = original.AddBusinessDays(9);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void SubtractBusinessDaysThrowsIfDaysIsNegative()
        {
            DateTime dt = new DateTime(2018, 01, 01);
            Assert.Throws<ArgumentException>(() => dt.SubtractBusinessDays(-1));
        }

        [Test]
        public void SubtractBusinessDaysReturnsOriginalDateIfDaysIsZero()
        {
            DateTime original = new DateTime(2018, 01, 01);
            DateTime dt = original.SubtractBusinessDays(0);

            Assert.AreEqual(original, dt);
        }

        [Test]
        public void SubtractBusinessDaysSubtractsBusinessDays()
        {
            DateTime expected = new DateTime(2017, 01, 02);
            DateTime original = new DateTime(2017, 01, 06);

            DateTime dt = original.SubtractBusinessDays(4);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void SubtractBusinessDaysAdjustsExtraDaysIfOriginalDayIsSaturday()
        {
            DateTime expected = new DateTime(2017, 01, 03);
            DateTime original = new DateTime(2017, 01, 07);

            DateTime dt = original.SubtractBusinessDays(4);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void SubtractBusinessDaysAdjustsExtraDaysIfOriginalDayIsSundayy()
        {
            DateTime expected = new DateTime(2017, 01, 03);
            DateTime original = new DateTime(2017, 01, 08);

            DateTime dt = original.SubtractBusinessDays(4);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void SubtractBusinessDaySubtractsfullWeeks()
        {
            DateTime expected = new DateTime(2017, 01, 09);
            DateTime original = new DateTime(2017, 01, 19);

            DateTime dt = original.SubtractBusinessDays(8);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void SubtractBusinessDayAdjustsIfExtraDaysPushToSaturday()
        {
            DateTime expected = new DateTime(2017, 01, 05);
            DateTime original = new DateTime(2017, 01, 18);

            DateTime dt = original.SubtractBusinessDays(9);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void SubtractBusinessDayAdjustsIfExtraDaysPushToSunday()
        {
            DateTime expected = new DateTime(2017, 01, 06);
            DateTime original = new DateTime(2017, 01, 19);

            DateTime dt = original.SubtractBusinessDays(9);

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void GetNextBusinessDayReturnsNextBusinessDay()
        {
            DateTime expected = new DateTime(2017, 01, 05);
            DateTime original = new DateTime(2017, 01, 04);

            DateTime dt = original.GetNextBusinessDay();

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void GetNextBusinessDayAdjustsIfOriginalDayIsSaturday()
        {
            DateTime expected = new DateTime(2017, 01, 09);
            DateTime original = new DateTime(2017, 01, 07);

            DateTime dt = original.GetNextBusinessDay();

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void GetNextBusinessDayAdjustsIfOriginalDayIsSunday()
        {
            DateTime expected = new DateTime(2017, 01, 09);
            DateTime original = new DateTime(2017, 01, 08);

            DateTime dt = original.GetNextBusinessDay();

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void GetNextBusinessDayAdjustsIfExtraDayPushsToWeekend()
        {
            DateTime expected = new DateTime(2017, 01, 09);
            DateTime original = new DateTime(2017, 01, 06);

            DateTime dt = original.GetNextBusinessDay();

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void GetPriorBusinessDayReturnsPreviousBusinessDay()
        {
            DateTime expected = new DateTime(2017, 01, 04);
            DateTime original = new DateTime(2017, 01, 05);

            DateTime dt = original.GetPriorBusiness();

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void GetPriorBusinessDayAdjustsIfOriginalDayIsSaturday()
        {
            DateTime expected = new DateTime(2017, 01, 06);
            DateTime original = new DateTime(2017, 01, 07);

            DateTime dt = original.GetPriorBusiness();

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void GetPriorBusinessDayAdjustsIfOriginalDayIsSunday()
        {
            DateTime expected = new DateTime(2017, 01, 06);
            DateTime original = new DateTime(2017, 01, 08);

            DateTime dt = original.GetPriorBusiness();

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void GetPriorBusinessDayAdjustsIfExtraDaysPushToWeekend()
        {
            DateTime expected = new DateTime(2017, 01, 06);
            DateTime original = new DateTime(2017, 01, 09);

            DateTime dt = original.GetPriorBusiness();

            Assert.AreEqual(expected, dt);
        }

        [Test]
        public void GetBusinessDaysThrowsIfStartDateIsAfterEndDate()
        {
            DateTime start = new DateTime(2017, 01, 06);
            DateTime end = new DateTime(2017, 01, 02);

            Assert.Throws<ArgumentException>(() => start.GetBusinessDays(end));
        }

        [Test]
        public void GetBusinessDaysReturnsZeroIfStartDateAndEndDateAreTheSame()
        {
            const int expected = 0;

            DateTime start = new DateTime(2017, 01, 02);
            DateTime end = new DateTime(2017, 01, 02);

            int result = start.GetBusinessDays(end);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetBusinessDaysReturnsExpectedDays()
        {
            const int expected = 5;

            DateTime start = new DateTime(2017, 01, 02);
            DateTime end = new DateTime(2017, 01, 06);

            int result = start.GetBusinessDays(end);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetBusinessDaysReturnsIfFiveDaysForEveryFullBusinessWeeks()
        {
            const int expected = 10;

            DateTime start = new DateTime(2017, 01, 02);
            DateTime end = new DateTime(2017, 01, 13);

            int result = start.GetBusinessDays(end);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetBusinessDaysAdjustsIfStartIsSaturday()
        {
            const int expected = 5;

            DateTime start = new DateTime(2016, 12, 31);
            DateTime end = new DateTime(2017, 01, 06);

            int result = start.GetBusinessDays(end);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetBusinessDaysAdjustsIfStartIsSunday()
        {
            const int expected = 5;

            DateTime start = new DateTime(2017, 01, 01);
            DateTime end = new DateTime(2017, 01, 06);

            int result = start.GetBusinessDays(end);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetBusinessDaysAdjustsIfEndIsSaturday()
        {
            const int expected = 5;

            DateTime start = new DateTime(2017, 01, 01);
            DateTime end = new DateTime(2017, 01, 07);

            int result = start.GetBusinessDays(end);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetBusinessDaysAdjustsIfEndIsSunday()
        {
            const int expected = 5;

            DateTime start = new DateTime(2017, 01, 01);
            DateTime end = new DateTime(2017, 01, 08);

            int result = start.GetBusinessDays(end);

            Assert.AreEqual(expected, result);
        }
    }
}
