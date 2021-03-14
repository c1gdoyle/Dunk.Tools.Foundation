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

            var sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };

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

        [Test]
        public void StandardDeviationCalculatesForSequenceONullableDecimals()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new decimal?[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceONullableDecimalsContainingNulls()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new decimal?[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m, null };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForEmptySequenceOfNullableDecimals()
        {
            const double expected = 0;

            var sequence = Array.Empty<decimal?>();

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForSequenceOfNullableDecimalsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new decimal?[] { null, null, null, null, null };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationThrowsForNullSequenceOfNullableDecimals()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<decimal?>).StandardDeviation());
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfNullableFloats()
        {
            const double expected = 7.5969921707776651d;

            var sequence = new float?[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfNullableFloatsContainingNulls()
        {
            const double expected = 7.5969921707776651d;

            var sequence = new float?[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f, null };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForEmptySequenceOfNullableFloats()
        {
            const double expected = 0;

            var sequence = Array.Empty<float?>();

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForSequenceOfNullableFloatsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new float?[] { null, null, null, null, null };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationThrowsForNullSequenceOfNullableFloats()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<float?>).StandardDeviation());
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfNullableInts()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new int?[] { 1, 3, 24, 17, 12, 6, 14 };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfNullableIntsContainingNulls()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new int?[] { 1, 3, 24, 17, 12, 6, 14, null };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForEmptySequenceOfNullableInts()
        {
            const double expected = 0;

            var sequence = Array.Empty<int?>();

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForSequenceOfNullableIntsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new int?[] { null, null, null, null, null };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationThrowsForNullSequenceOfNullableInts()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int?>).StandardDeviation());
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfNullableLongs()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new long?[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfNullableLongsContainingNulls()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new long?[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L, null };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForEmptySequenceOfNullableLongs()
        {
            const double expected = 0;

            var sequence = Array.Empty<long?>();

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForSequenceOfNullableLongsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new long?[] { null, null, null, null, null };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationThrowsForNullSequenceOfNullableLongs()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<long?>).StandardDeviation());
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfNullableDoubles()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new double?[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfNullableDoublesContainingNulls()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new double?[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d, null };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForEmptySequenceOfNullableDoubles()
        {
            const double expected = 0;

            var sequence = Array.Empty<double?>();

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationReturnsZeroForSequenceOfNullableDoublesContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new double?[] { null, null, null, null, null };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationThrowsForNullSequenceOfNullableDoubles()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<double?>).StandardDeviation());
        }
    }
}
