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
        public void StandardDeviationSelectCalculatesForSequenceOfDecimals()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal> selector = i => i;

            double result = sequence.StandardDeviation(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationSelectReturnsZeroForEmptySequenceOfDecimals()
        {
            const double expected = 0;

            var sequence = Array.Empty<decimal>();
            Func<decimal, decimal> selector = i => i;

            double result = sequence.StandardDeviation(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationSelectThrowsForNullSequenceOfDecimals()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<decimal>).StandardDeviation(i => i));
        }

        [Test]
        public void StandardDeviationSelectThrowsForNullDecimalSelector()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<decimal>().StandardDeviation(null as Func<decimal, decimal>));
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfFloats()
        {
            const double expected = 7.5969918858904748d;

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
        public void StandardDeviationSelectCalculatesForSequenceOfFloats()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float> selector = i => i;

            double result = sequence.StandardDeviation(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationSelectReturnsZeroForEmptySequenceOfFloats()
        {
            const double expected = 0;

            var sequence = Array.Empty<float>();
            Func<float, float> selector = i => i;

            double result = sequence.StandardDeviation(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationSelectThrowsForNullSequenceOfFloats()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<float>).StandardDeviation(i => i));
        }

        [Test]
        public void StandardDeviationSelectThrowsForNullFloatSelector()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<float>().StandardDeviation(null as Func<float, float>));
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
        public void StandardDeviationSelectCalculatesForSequenceOfInts()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int> selector = i => i;

            double result = sequence.StandardDeviation(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationSelectReturnsZeroForEmptySequenceOfInts()
        {
            const double expected = 0;

            var sequence = Array.Empty<int>();
            Func<int, int> selector = i => i;

            double result = sequence.StandardDeviation(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationSelectThrowsForNullSequenceOfInts()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int>).StandardDeviation(i => i));
        }

        [Test]
        public void StandardDeviationSelectThrowsForNullIntSelector()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<int>().StandardDeviation(null as Func<int, int>));
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
        public void StandardDeviationSelectCalculatesForSequenceOfLongs()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long> selector = i => i;

            double result = sequence.StandardDeviation(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationSelectReturnsZeroForEmptySequenceOfLongs()
        {
            const double expected = 0;

            var sequence = Array.Empty<long>();
            Func<long, long> selector = i => i;

            double result = sequence.StandardDeviation(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationSelectThrowsForNullSequenceOfLongs()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<long>).StandardDeviation(i => i));
        }

        [Test]
        public void StandardDeviationSelectThrowsForNullLongSelector()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<long>().StandardDeviation(null as Func<long, long>));
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
        public void StandardDeviationSelectCalculatesForSequenceOfDoubles()
        {
            const double expected = 7.5969918858904748d;

            var sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double> selector = i => i;

            double result = sequence.StandardDeviation(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationSelectReturnsZeroForEmptySequenceOfDoubles()
        {
            const double expected = 0;

            var sequence = Array.Empty<double>();
            Func<double, double> selector = i => i;

            double result = sequence.StandardDeviation(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationSelectThrowsForNullSequenceOfDoubles()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<double>).StandardDeviation(i => i));
        }

        [Test]
        public void StandardDeviationSelectThrowsForNullDoubleSelector()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<double>().StandardDeviation(null as Func<double, double>));
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
            const double expected = 7.5969918858904748d;

            var sequence = new float?[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };

            double result = sequence.StandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardDeviationCalculatesForSequenceOfNullableFloatsContainingNulls()
        {
            const double expected = 7.5969918858904748d;

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

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfDecimals()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForEmptySequenceOfDecimals()
        {
            const double expected = 0;

            var sequence = Array.Empty<decimal>();

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationThrowsForNullSequenceOfDecimals()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<decimal>).SampleStandardDeviation());
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfFloats()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForEmptySequenceOfFloats()
        {
            const double expected = 0;

            var sequence = Array.Empty<float>();

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationThrowsForNullSequenceOfFloats()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<float>).SampleStandardDeviation());
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfInts()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForEmptySequenceOfInts()
        {
            const double expected = 0;

            var sequence = Array.Empty<int>();

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationThrowsForNullSequenceOfInts()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int>).SampleStandardDeviation());
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfLongs()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForEmptySequenceOfLongs()
        {
            const double expected = 0;

            var sequence = Array.Empty<long>();

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationThrowsForNullSequenceOfLongs()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<long>).SampleStandardDeviation());
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfDoubles()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForEmptySequenceOfDoubles()
        {
            const double expected = 0;

            var sequence = Array.Empty<double>();

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationThrowsForNullSequenceOfDoubles()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<double>).SampleStandardDeviation());
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceONullableDecimals()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new decimal?[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceONullableDecimalsContainingNulls()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new decimal?[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m, null };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForEmptySequenceOfNullableDecimals()
        {
            const double expected = 0;

            var sequence = Array.Empty<decimal?>();

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForSequenceOfNullableDecimalsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new decimal?[] { null, null, null, null, null };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationThrowsForNullSequenceOfNullableDecimals()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<decimal?>).SampleStandardDeviation());
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfNullableFloats()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new float?[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfNullableFloatsContainingNulls()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new float?[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f, null };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForEmptySequenceOfNullableFloats()
        {
            const double expected = 0;

            var sequence = Array.Empty<float?>();

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForSequenceOfNullableFloatsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new float?[] { null, null, null, null, null };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationThrowsForNullSequenceOfNullableFloats()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<float?>).SampleStandardDeviation());
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfNullableInts()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new int?[] { 1, 3, 24, 17, 12, 6, 14 };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfNullableIntsContainingNulls()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new int?[] { 1, 3, 24, 17, 12, 6, 14, null };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForEmptySequenceOfNullableInts()
        {
            const double expected = 0;

            var sequence = Array.Empty<int?>();

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForSequenceOfNullableIntsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new int?[] { null, null, null, null, null };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationThrowsForNullSequenceOfNullableInts()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int?>).SampleStandardDeviation());
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfNullableLongs()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new long?[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfNullableLongsContainingNulls()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new long?[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L, null };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForEmptySequenceOfNullableLongs()
        {
            const double expected = 0;

            var sequence = Array.Empty<long?>();

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForSequenceOfNullableLongsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new long?[] { null, null, null, null, null };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationThrowsForNullSequenceOfNullableLongs()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<long?>).SampleStandardDeviation());
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfNullableDoubles()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new double?[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationCalculatesForSequenceOfNullableDoublesContainingNulls()
        {
            const double expected = 8.2056890833941143d;

            var sequence = new double?[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d, null };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForEmptySequenceOfNullableDoubles()
        {
            const double expected = 0;

            var sequence = Array.Empty<double?>();

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationReturnsZeroForSequenceOfNullableDoublesContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new double?[] { null, null, null, null, null };

            double result = sequence.SampleStandardDeviation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SampleStandardDeviationThrowsForNullSequenceOfNullableDoubles()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<double?>).SampleStandardDeviation());
        }
    }
}
