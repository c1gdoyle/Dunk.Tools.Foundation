using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class VarianceExtensionsTests
    {
        [Test]
        public void VarianceCalculatesForSequenceOfDecimals()
        {
            const double expected = 57.714285714285715d;

            var sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForEmptySequenceOfDecimals()
        {
            const double expected = 0;

            var sequence = Array.Empty<decimal>();

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceThrowsForNullSequenceOfDecimals()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<decimal>).Variance());
        }

        [Test]
        public void VarianceCalculatesForSequenceOfFloats()
        {
            const double expected = 57.714285714285715d;

            var sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForEmptySequenceOfFloats()
        {
            const double expected = 0;

            var sequence = Array.Empty<float>();

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceThrowsForNullSequenceOfFloats()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<float>).Variance());
        }

        [Test]
        public void VarianceCalculatesForSequenceOfInts()
        {
            const double expected = 57.714285714285715d;

            var sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForEmptySequenceOfInts()
        {
            const double expected = 0;

            var sequence = Array.Empty<int>();

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceThrowsForNullSequenceOfInts()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int>).Variance());
        }

        [Test]
        public void VarianceCalculatesForSequenceOfLongs()
        {
            const double expected = 57.714285714285715d;

            var sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForEmptySequenceOfLongs()
        {
            const double expected = 0;

            var sequence = Array.Empty<long>();

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceThrowsForNullSequenceOfLongs()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<long>).Variance());
        }

        [Test]
        public void VarianceCalculatesForSequenceOfDoubles()
        {
            const double expected = 57.714285714285715d;

            var sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForEmptySequenceOfDoubles()
        {
            const double expected = 0;

            var sequence = Array.Empty<double>();

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceThrowsForNullSequenceOfDoubles()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<double>).Variance());
        }

        [Test]
        public void VarianceCalculatesForSequenceONullableDecimals()
        {
            const double expected = 57.714285714285715d;

            var sequence = new decimal?[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceCalculatesForSequenceONullableDecimalsContainingNulls()
        {
            const double expected = 57.714285714285715d;

            var sequence = new decimal?[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m, null };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForEmptySequenceOfNullableDecimals()
        {
            const double expected = 0;

            var sequence = Array.Empty<decimal?>();

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForSequenceOfNullableDecimalsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new decimal?[] { null, null, null, null, null };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceThrowsForNullSequenceOfNullableDecimals()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<decimal?>).Variance());
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableFloats()
        {
            const double expected = 57.714285714285715d;

            var sequence = new float?[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableFloatsContainingNulls()
        {
            const double expected = 57.714285714285715d;

            var sequence = new float?[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f, null };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForEmptySequenceOfNullableFloats()
        {
            const double expected = 0;

            var sequence = Array.Empty<float?>();

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForSequenceOfNullableFloatsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new float?[] { null, null, null, null, null };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceThrowsForNullSequenceOfNullableFloats()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<float?>).Variance());
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableInts()
        {
            const double expected = 57.714285714285715d;

            var sequence = new int?[] { 1, 3, 24, 17, 12, 6, 14 };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableIntsContainingNulls()
        {
            const double expected = 57.714285714285715d;

            var sequence = new int?[] { 1, 3, 24, 17, 12, 6, 14, null };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForEmptySequenceOfNullableInts()
        {
            const double expected = 0;

            var sequence = Array.Empty<int?>();

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForSequenceOfNullableIntsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new int?[] { null, null, null, null, null };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceThrowsForNullSequenceOfNullableInts()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int?>).Variance());
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableLongs()
        {
            const double expected = 57.714285714285715d;

            var sequence = new long?[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableLongsContainingNulls()
        {
            const double expected = 57.714285714285715d;

            var sequence = new long?[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L, null };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForEmptySequenceOfNullableLongs()
        {
            const double expected = 0;

            var sequence = Array.Empty<long?>();

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForSequenceOfNullableLongsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new long?[] { null, null, null, null, null };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceThrowsForNullSequenceOfNullableLongs()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<long?>).Variance());
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableDoubles()
        {
            const double expected = 57.714285714285715d;

            var sequence = new double?[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableDoublesContainingNulls()
        {
            const double expected = 57.714285714285715d;

            var sequence = new double?[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d, null };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForEmptySequenceOfNullableDoubles()
        {
            const double expected = 0;

            var sequence = Array.Empty<double?>();

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceReturnsZeroForSequenceOfNullableDoublesContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new double?[] { null, null, null, null, null };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceThrowsForNullSequenceOfNullableDoubles()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<double?>).Variance());
        }
    }
}
