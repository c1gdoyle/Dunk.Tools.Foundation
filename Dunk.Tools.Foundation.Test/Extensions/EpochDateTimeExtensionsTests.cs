using System;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class EpochDateTimeExtensionsTests
    {
        [Test]
        public void ConvertsUnixTimeStampToDateTime()
        {
            DateTime expectedDt = new DateTime(2018, 01, 29, 09, 31, 38, DateTimeKind.Utc);

            long unixTimeStamp = 1517218298;
            DateTime dt = unixTimeStamp.FromUnixTimeStamp();

            Assert.AreEqual(expectedDt, dt);
        }

        [Test]
        public void ConvertsNegativeUnixTimeStampToDateTime()
        {
            DateTime expectedDt = new DateTime(1921, 12, 03, 14, 28, 22, DateTimeKind.Utc);

            long unixTimeStamp = -1517218298;
            DateTime dt = unixTimeStamp.FromUnixTimeStamp();

            Assert.AreEqual(expectedDt, dt);
        }

        [Test]
        public void ConvertsJavaTimeStampToDateTime()
        {
            DateTime expectedDt = new DateTime(2018, 01, 29, 09, 31, 38, DateTimeKind.Utc);

            long unixTimeStamp = 1517218298000;
            DateTime dt = unixTimeStamp.FromJavaTimeStamp();

            Assert.AreEqual(expectedDt, dt);
        }

        [Test]
        public void ConvertsNegativeJavaTimeStampToDateTime()
        {
            DateTime expectedDt = new DateTime(1921, 12, 03, 14, 28, 22, DateTimeKind.Utc);

            long unixTimeStamp = -1517218298000;
            DateTime dt = unixTimeStamp.FromJavaTimeStamp();

            Assert.AreEqual(expectedDt, dt);
        }

        [Test]
        public void ConvertsDateTimeToUnixTimeStamp()
        {
            const long expectedTimeStampSeconds = 1517218298;

            DateTime dt = new DateTime(2018, 01, 29, 09, 31, 38, DateTimeKind.Utc);

            long unixTimeStamp = dt.ToUnixTimeStamp();

            Assert.AreEqual(expectedTimeStampSeconds, unixTimeStamp);
        }

        [Test]
        public void ConvertsLocalDateTimeToUnixTimeStamp()
        {
            const long expectedTimeStampSeconds = 1517218298;

            DateTime dt = new DateTime(2018, 01, 29, 09, 31, 38, DateTimeKind.Utc).ToLocalTime();

            long unixTimeStamp = dt.ToUnixTimeStamp();

            Assert.AreEqual(expectedTimeStampSeconds, unixTimeStamp);
        }

        [Test]
        public void ConvertsDateTimePreEpochToUnixTimeStamp()
        {
            const long expectedTimeStampSeconds = -1517218298;

            DateTime dt = new DateTime(1921, 12, 03, 14, 28, 22, DateTimeKind.Utc);

            long unixTimeStamp = dt.ToUnixTimeStamp();

            Assert.AreEqual(expectedTimeStampSeconds, unixTimeStamp);
        }


        [Test]
        public void ConvertsLocalDateTimePreEpochToUnixTimeStamp()
        {
            const long expectedTimeStampSeconds = -1517218298;

            DateTime dt = new DateTime(1921, 12, 03, 14, 28, 22, DateTimeKind.Utc).ToLocalTime();

            long unixTimeStamp = dt.ToUnixTimeStamp();

            Assert.AreEqual(expectedTimeStampSeconds, unixTimeStamp);
        }

        [Test]
        public void ConvertsDateTimeToJavaTimeStamp()
        {
            const long expectedTimeStampMilliSeconds = 1517218298000;

            DateTime dt = new DateTime(2018, 01, 29, 09, 31, 38, DateTimeKind.Utc);

            long javaTimeStamp = dt.ToJavaTimeStamp();

            Assert.AreEqual(expectedTimeStampMilliSeconds, javaTimeStamp);
        }

        [Test]
        public void ConvertsLocalDateTimeToJavaTimeStamp()
        {
            const long expectedTimeStampMilliSeconds = 1517218298000;

            DateTime dt = new DateTime(2018, 01, 29, 09, 31, 38, DateTimeKind.Utc).ToLocalTime();

            long javaTimeStamp = dt.ToJavaTimeStamp();

            Assert.AreEqual(expectedTimeStampMilliSeconds, javaTimeStamp);
        }

        [Test]
        public void ConvertsDateTimePreEpochToJavaTimeStamp()
        {
            const long expectedTimeStampMilliSeconds = -1517218298000;

            DateTime dt = new DateTime(1921, 12, 03, 14, 28, 22, DateTimeKind.Utc);

            long javaTimeStamp = dt.ToJavaTimeStamp();

            Assert.AreEqual(expectedTimeStampMilliSeconds, javaTimeStamp);
        }


        [Test]
        public void ConvertsLocalDateTimePreEpochToJavaTimeStamp()
        {
            const long expectedTimeStampMilliSeconds = -1517218298000;

            DateTime dt = new DateTime(1921, 12, 03, 14, 28, 22, DateTimeKind.Utc).ToLocalTime();

            long javaTimeStamp = dt.ToJavaTimeStamp();

            Assert.AreEqual(expectedTimeStampMilliSeconds, javaTimeStamp);
        }
    }
}