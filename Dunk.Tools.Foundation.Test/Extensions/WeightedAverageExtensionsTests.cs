using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class WeightedAverageExtensionsTests
    {
        [Test]
        public void WeightedAverageForNullableDecimalsThrowsIfSequenceIsNull()
        {
            IEnumerable<decimal> sequence = null;
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableDecimalsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal?> valueSelector = null;
            Func<decimal, decimal?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableDecimalsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableDecimalsReturnsExpectedValue()
        {
            decimal? expected = 16.246753246753246753246753247m;

            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = d => d;

            decimal? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForNullableDecimalsThrowsForEmptySequence()
        {
            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = d => d;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableDecimalsThrowsForTotalWeightOfZero()
        {
            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = d => 0.0m;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableDecimalsReturnsExpectedValueForWeightNull()
        { 
            decimal? expected = null;

            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = d => null;

            decimal? result = sequence.WeightedAverage(valueSelector, weightSelector);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForNullableDecimalsReturnsExpectedValueForValueNull()
        {
            decimal? expected = null;

            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal?> valueSelector = d => null;
            Func<decimal, decimal?> weightSelector = d => d;

            decimal? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForDecimalsThrowsIfSequenceIsNull()
        {
            IEnumerable<decimal> sequence = null;
            Func<decimal, decimal> valueSelector = d => d;
            Func<decimal, decimal> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForDecimalsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal> valueSelector = null;
            Func<decimal, decimal> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForDecimalsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal> valueSelector = d => d;
            Func<decimal, decimal> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForDecimalsReturnsExpectedValue()
        {
            decimal expected = 16.246753246753246753246753247m;

            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal> valueSelector = d => d;
            Func<decimal, decimal> weightSelector = d => d;

            decimal result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForDecimalsReturnsThrowsForEmptySequence()
        {
            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal> valueSelector = d => d;
            Func<decimal, decimal> weightSelector = d => d;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForDecimalsThrowsForTotalWeightOfZero()
        {
            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal> valueSelector = d => d;
            Func<decimal, decimal> weightSelector = d => 0.0m;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableDoublesThrowsIfSequenceIsNull()
        {
            IEnumerable<double> sequence = null;
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableDoublesThrowsIfValueSelectorIsNull()
        {
            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double?> valueSelector = null;
            Func<double, double?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableDoublesThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableDoublesReturnsExpectedValue()
        {
            double? expected = 16.246753246753247d;

            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = d => d;

            double? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForNullableDoublesThrowsForEmptySequence()
        {
            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = d => d;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableDoublesThrowsForTotalWeightOfZero()
        {
            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = d => 0.0;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableDoublesReturnsExpectedValueForWeightNull()
        {
            double? expected = null;

            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = d => null;

            double? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForNullableDoublesReturnsExpectedValueForValueNull()
        {
            double? expected = null;

            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double?> valueSelector = d => null;
            Func<double, double?> weightSelector = d => d;

            double? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForDoublesThrowsIfSequenceIsNull()
        {
            IEnumerable<double> sequence = null;
            Func<double, double> valueSelector = d => d;
            Func<double, double> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForDoublesThrowsIfValueSelectorIsNull()
        {
            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double> valueSelector = null;
            Func<double, double> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForDoublesThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double> valueSelector = d => d;
            Func<double, double> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForDoublesReturnsExpectedValue()
        {
            double expected = 16.246753246753247d;

            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double> valueSelector = d => d;
            Func<double, double> weightSelector = d => d;

            double result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForDoublesThrowsForEmptySequence()
        {
            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double> valueSelector = d => d;
            Func<double, double> weightSelector = d => d;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForDoublesThrowsForTotalWeightOfZero()
        {
            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double> valueSelector = d => d;
            Func<double, double> weightSelector = d => 0.0;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableFloatsThrowsIfSequenceIsNull()
        {
            IEnumerable<float> sequence = null;
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableFloatsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float?> valueSelector = null;
            Func<float, float?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableFloatsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableFloatsReturnsExpectedValue()
        {
            float? expected = 16.246753246753247f;

            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = d => d;

            float? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForNullableFloatsThrowsForEmptySequence()
        {
            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = d => d;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableFloatsThrowsForTotalWeightOfZero()
        {
            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = d => 0.0f;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableFloatsReturnsExpectedValueForWeightNull()
        {
            double? expected = null;

            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = d => null;

            double? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForNullableFloatsReturnsExpectedValueForValueNull()
        {
            double? expected = null;

            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float?> valueSelector = d => null;
            Func<float, float?> weightSelector = d => d;

            double? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForFloatsThrowsIfSequenceIsNull()
        {
            IEnumerable<float> sequence = null;
            Func<float, float> valueSelector = d => d;
            Func<float, float> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForFloatsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float> valueSelector = null;
            Func<float, float> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForFloatsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float> valueSelector = d => d;
            Func<float, float> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForFloatsReturnsExpectedValue()
        {
            float expected = 16.246753246753247f;

            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float> valueSelector = d => d;
            Func<float, float> weightSelector = d => d;

            float result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForFloatsThrowsForEmptySequence()
        {
            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float> valueSelector = d => d;
            Func<float, float> weightSelector = d => d;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForFloatsThrowsForTotalWeightOfZero()
        {
            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float> valueSelector = d => d;
            Func<float, float> weightSelector = d => 0.0f;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableIntsThrowsIfSequenceIsNull()
        {
            IEnumerable<int> sequence = null;
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableIntsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int?> valueSelector = null;
            Func<int, int?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableIntsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableIntsReturnsExpectedValue()
        {
            double? expected = 16.246753246753247d;

            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = d => d;

            double? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForNullableIntsThrowsForEmptySequence()
        {
            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = d => d;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableIntsThrowsForTotalWeightOfZero()
        {
            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = d => 0;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableIntsReturnsExpectedValueForWeightNull()
        {
            double? expected = null;

            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = d => null;

            double? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForNullableIntsReturnsExpectedValueForValueNull()
        {
            double? expected = null;

            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int?> valueSelector = d => null;
            Func<int, int?> weightSelector = d => d;

            double? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForIntsThrowsIfSequenceIsNull()
        {
            IEnumerable<int> sequence = null;
            Func<int, int> valueSelector = d => d;
            Func<int, int> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForIntsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int> valueSelector = null;
            Func<int, int> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForIntsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int> valueSelector = d => d;
            Func<int, int> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForIntsReturnsExpectedValue()
        {
            double expected = 16.246753246753247d;

            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int> valueSelector = d => d;
            Func<int, int> weightSelector = d => d;

            double result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForIntsThrowsForEmptySequence()
        {
            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int> valueSelector = d => d;
            Func<int, int> weightSelector = d => d;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForIntsThrowsForTotalWeightOfZero()
        {
            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int> valueSelector = d => d;
            Func<int, int> weightSelector = d => 0;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableLongsThrowsIfSequenceIsNull()
        {
            IEnumerable<long> sequence = null;
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableLongsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long?> valueSelector = null;
            Func<long, long?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableLongsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableLongsReturnsExpectedValue()
        {
            double? expected = 16.246753246753247d;

            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = d => d;

            double? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForNullableLongsThrowsForEmptySequence()
        {
            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = d => d;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableLongsThrowsForTotalWeightOfZero()
        {
            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = d => 0L;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForNullableLongsReturnsExpectedValueForWeightNull()
        {
            double? expected = null;

            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = d => null;

            double? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForNullableLongsReturnsExpectedValueForValueNull()
        {
            double? expected = null;

            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long?> valueSelector = d => null;
            Func<long, long?> weightSelector = d => d;

            double? result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForLongsThrowsIfSequenceIsNull()
        {
            IEnumerable<long> sequence = null;
            Func<long, long> valueSelector = d => d;
            Func<long, long> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForLongsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long> valueSelector = null;
            Func<long, long> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForLongsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long> valueSelector = d => d;
            Func<long, long> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForLongsReturnsExpectedValue()
        {
            double expected = 16.246753246753247d;

            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long> valueSelector = d => d;
            Func<long, long> weightSelector = d => d;

            double result = sequence.WeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WeightedAverageForLongsThrowsForEmptySequence()
        {
            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long> valueSelector = d => d;
            Func<long, long> weightSelector = d => d;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void WeightedAverageForLongsThrowsForTotalWeightOfZero()
        {
            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long> valueSelector = d => d;
            Func<long, long> weightSelector = d => 0L;

            Assert.Throws<InvalidOperationException>(() => sequence.WeightedAverage(valueSelector, weightSelector));
        }
    }
}
