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
        public void VarianceSelectCalculatesForSequenceOfDecimals()
        {
            const double expected = 57.714285714285715d;

            var sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForEmptySequenceOfDecimals()
        {
            const double expected = 0;

            var sequence = Array.Empty<decimal>();
            Func<decimal, decimal> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectThrowsForNullSequenceOfDecimals()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<decimal>).Variance(i => i));
        }

        [Test]
        public void VarianceSelectThrowsForNullSelectorOfDecimals()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<decimal>().Variance(null as Func<decimal, decimal>));
        }

        [Test]
        public void VarianceCalculatesForSequenceOfFloats()
        {
            const double expected =
#if NET472
                57.714290073939729d;
#elif NETCOREAPP3_1
                57.714285714285715d;
#endif

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
        public void VarianceSelectCalculatesForSequenceOfFloats()
        {
            const double expected =
#if NET472
                57.714290073939729d;
#elif NETCOREAPP3_1
                57.714285714285715d;
#endif

            var sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForEmptySequenceOfFloats()
        {
            const double expected = 0;

            var sequence = Array.Empty<float>();
            Func<float, float> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectThrowsForNullSequenceOfFloats()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<float>).Variance(i => i));
        }

        [Test]
        public void VarianceSelectThrowsForNullSelectorOfFloats()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<float>().Variance(null as Func<float, float>));
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
        public void VarianceSelectCalculatesForSequenceOfInts()
        {
            const double expected = 57.714285714285715d;

            var sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForEmptySequenceOfInts()
        {
            const double expected = 0;

            var sequence = Array.Empty<int>();
            Func<int, int> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectThrowsForNullSequenceOfInts()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int>).Variance(i => i));
        }

        [Test]
        public void VarianceSelectThrowsForNullSelectorOfInts()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<int>().Variance(null as Func<int, int>));
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
        public void VarianceSelectCalculatesForSequenceOfLongs()
        {
            const double expected = 57.714285714285715d;

            var sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForEmptySequenceOfLongs()
        {
            const double expected = 0;

            var sequence = Array.Empty<long>();
            Func<long, long> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectThrowsForNullSequenceOfLongs()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<long>).Variance(i => i));
        }

        [Test]
        public void VarianceSelectThrowsForNullSelectorOfLongs()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<long>().Variance(null as Func<long, long>));
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
        public void VarianceSelectCalculatesForSequenceOfDoubles()
        {
            const double expected = 57.714285714285715d;

            var sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForEmptySequenceOfDoubles()
        {
            const double expected = 0;

            var sequence = Array.Empty<double>();
            Func<double, double> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectThrowsForNullSequenceOfDoubles()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<double>).Variance(i => i));
        }

        [Test]
        public void VarianceSelectThrowsForNullSelectorOfDoubles()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<double>().Variance(null as Func<double, double>));
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableDecimals()
        {
            const double expected = 57.714285714285715d;

            var sequence = new decimal?[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableDecimalsContainingNulls()
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
        public void VarianceSelectCalculatesForSequenceOfNullableDecimals()
        {
            const double expected = 57.714285714285715d;

            var sequence = new decimal?[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal?, decimal?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectCalculatesForSequenceOfNullableDecimalsContainingNulls()
        {
            const double expected = 57.714285714285715d;

            var sequence = new decimal?[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m, null };
            Func<decimal?, decimal?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForEmptySequenceOfNullableDecimals()
        {
            const double expected = 0;

            var sequence = Array.Empty<decimal?>();
            Func<decimal?, decimal?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForSequenceOfNullableDecimalsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new decimal?[] { null, null, null, null, null };
            Func<decimal?, decimal?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectThrowsForNullSequenceOfNullableDecimals()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<decimal?>).Variance(i => i));
        }

        [Test]
        public void VarianceSelectThrowsForNullSelectorOfNullableDecimals()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<decimal?>().Variance(null as Func<decimal?, decimal?>));
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableFloats()
        {
            const double expected =
#if NET472
                57.714290073939729d;
#elif NETCOREAPP3_1
                57.714285714285715d;
#endif

            var sequence = new float?[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };

            double result = sequence.Variance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceCalculatesForSequenceOfNullableFloatsContainingNulls()
        {
            const double expected =
#if NET472
                57.714290073939729d;
#elif NETCOREAPP3_1
                57.714285714285715d;
#endif

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
        public void VarianceSelectCalculatesForSequenceOfNullableFloats()
        {
            const double expected =
#if NET472
                57.714290073939729d;
#elif NETCOREAPP3_1
                57.714285714285715d;
#endif

            var sequence = new float?[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float?, float?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectCalculatesForSequenceOfNullableFloatsContainingNulls()
        {
            const double expected =
#if NET472
                57.714290073939729d;
#elif NETCOREAPP3_1
                57.714285714285715d;
#endif

            var sequence = new float?[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f, null };
            Func<float?, float?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForEmptySequenceOfNullableFloats()
        {
            const double expected = 0;

            var sequence = Array.Empty<float?>();
            Func<float?, float?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForSequenceOfNullableFloatsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new float?[] { null, null, null, null, null };
            Func<float?, float?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectThrowsForNullSequenceOfNullableFloats()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<float?>).Variance(i => i));
        }

        [Test]
        public void VarianceSelectThrowsForNullSelectorOfNullableFloats()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<float?>().Variance(null as Func<float?, float?>));
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
        public void VarianceSelectCalculatesForSequenceOfNullableInts()
        {
            const double expected = 57.714285714285715d;

            var sequence = new int?[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int?, int?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectCalculatesForSequenceOfNullableIntsContainingNulls()
        {
            const double expected = 57.714285714285715d;

            var sequence = new int?[] { 1, 3, 24, 17, 12, 6, 14, null };
            Func<int?, int?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForEmptySequenceOfNullableInts()
        {
            const double expected = 0;

            var sequence = Array.Empty<int?>();
            Func<int?, int?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForSequenceOfNullableIntsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new int?[] { null, null, null, null, null };
            Func<int?, int?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectThrowsForNullSequenceOfNullableInts()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int?>).Variance(i => i));
        }

        [Test]
        public void VarianceSelectThrowsForNullSelectorOfNullableInts()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<int?>().Variance(null as Func<int?, int?>));
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
        public void VarianceSelectCalculatesForSequenceOfNullableLongs()
        {
            const double expected = 57.714285714285715d;

            var sequence = new long?[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long?, long?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectCalculatesForSequenceOfNullableLongsContainingNulls()
        {
            const double expected = 57.714285714285715d;

            var sequence = new long?[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L, null };
            Func<long?, long?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForEmptySequenceOfNullableLongs()
        {
            const double expected = 0;

            var sequence = Array.Empty<long?>();
            Func<long?, long?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForSequenceOfNullableLongsContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new long?[] { null, null, null, null, null };
            Func<long?, long?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectThrowsForNullSequenceOfNullableLongs()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<long?>).Variance(i => i));
        }

        [Test]
        public void VarianceSelectThrowsForNullSelectorOfNullableLongs()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<long?>().Variance(null as Func<long?, long?>));
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

        [Test]
        public void VarianceSelectCalculatesForSequenceOfNullableDoubles()
        {
            const double expected = 57.714285714285715d;

            var sequence = new double?[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double?, double?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectCalculatesForSequenceOfNullableDoublesContainingNulls()
        {
            const double expected = 57.714285714285715d;

            var sequence = new double?[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d, null };
            Func<double?, double?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForEmptySequenceOfNullableDoubles()
        {
            const double expected = 0;

            var sequence = Array.Empty<double?>();
            Func<double?, double?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectReturnsZeroForSequenceOfNullableDoublesContainingOnlyNulls()
        {
            const double expected = 0;

            var sequence = new double?[] { null, null, null, null, null };
            Func<double?, double?> selector = i => i;

            double result = sequence.Variance(selector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VarianceSelectThrowsForNullSequenceOfNullableDoubles()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<double?>).Variance(i => i));
        }

        [Test]
        public void VarianceSelectThrowsForNullSelectorOfNullableDoubles()
        {
            Assert.Throws<ArgumentNullException>(() => Array.Empty<double?>().Variance(null as Func<double?, double?>));
        }
    }
}
