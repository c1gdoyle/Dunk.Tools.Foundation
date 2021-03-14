using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class StandardDeviationExtensionTests
    {
        [Test]
        public void StandardDeviationCalculatesForSequenceOfDecimals()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForEmptySequenceOfDecimals()
        {
            const double expected = 0;

            var sequence = Array.Empty<decimal>();

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationThrowsForNullSequenceOfDecimals()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<decimal>).StandardDeviation());
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfFloats()
        {
            const double expected = 7.5969921707776651d;

            var sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForEmptySequenceOfFloats()
        {
            const double expected = 0;

            var sequence = Array.Empty<float>();

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationThrowsForNullSequenceOfFloats()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<float>).StandardDeviation());
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfInts()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new int [] { 1, 3, 24, 17, 12, 6, 14 };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForEmptySequenceOfInts()
        {
            const double expected = 0;

            var sequence = Array.Empty<int>();

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationThrowsForNullSequenceOfInts()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int>).StandardDeviation());
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfLongs()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new long[] { 1, 3, 24, 17, 12, 6, 14 };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForEmptySequenceOfLongs()
        {
            const double expected = 0;

            var sequence = Array.Empty<long>();

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationThrowsForNullSequenceOfLongs()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<long>).StandardDeviation());
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfDoubles()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForEmptySequenceOfDoubles()
        {
            const double expected = 0;

            var sequence = Array.Empty<double>();

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationThrowsForNullSequenceOfDoubles()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<double>).StandardDeviation());
        }
    }
}
