using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class SafeWeightedAverageExtensionsTests
    {
        [Test]
        public void SafeWeightedAverageForNullableDecimalsThrowsIfSequenceIsNull()
        {
            IEnumerable<decimal> sequence = null;
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableDecimalsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal?> valueSelector = null;
            Func<decimal, decimal?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableDecimalsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableDecimalsReturnsExpectedValue()
        {
            double? expected = 16.246753246753247d;

            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableDecimalsReturnsExpectedValueForEmptySequence()
        {
            double? expected = double.NaN;

            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableDecimalsReturnsExpectedValueForTotalWeightOfZero()
        {
            double? expected = double.NaN;

            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = d => 0.0m;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableDecimalsReturnsExpectedValueForWeightNull()
        {
            double? expected = null;

            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal?> valueSelector = d => d;
            Func<decimal, decimal?> weightSelector = d => null;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableDecimalsReturnsExpectedValueForValueNull()
        {
            double? expected = null;

            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal?> valueSelector = d => null;
            Func<decimal, decimal?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForDecimalsThrowsIfSequenceIsNull()
        {
            IEnumerable<decimal> sequence = null;
            Func<decimal, decimal> valueSelector = d => d;
            Func<decimal, decimal> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForDecimalsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal> valueSelector = null;
            Func<decimal, decimal> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForDecimalsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal> valueSelector = d => d;
            Func<decimal, decimal> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForDecimalsReturnsExpectedValue()
        {
            double expected = 16.246753246753247d;

            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal> valueSelector = d => d;
            Func<decimal, decimal> weightSelector = d => d;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForDecimalsReturnsExpectedValueForEmptySequence()
        {
            double expected = double.NaN;

            IEnumerable<decimal> sequence = Array.Empty<decimal>();
            Func<decimal, decimal> valueSelector = d => d;
            Func<decimal, decimal> weightSelector = d => d;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForDecimalsReturnsExpectedValueForTotalWeightOfZero()
        {
            double expected = double.NaN;

            IEnumerable<decimal> sequence = new decimal[] { 1m, 3m, 24m, 17m, 12m, 6m, 14m };
            Func<decimal, decimal> valueSelector = d => d;
            Func<decimal, decimal> weightSelector = d => 0.0m;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableDoublesThrowsIfSequenceIsNull()
        {
            IEnumerable<double> sequence = null;
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableDoublesThrowsIfValueSelectorIsNull()
        {
            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double?> valueSelector = null;
            Func<double, double?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableDoublesThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableDoublesReturnsExpectedValue()
        {
            double? expected = 16.246753246753247d;

            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableDoublesReturnsExpectedValueForEmptySequence()
        {
            double? expected = double.NaN;

            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableDoublesReturnsExpectedValueForTotalWeightOfZero()
        {
            double? expected = double.NaN;

            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = d => 0.0;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableDoublesReturnsExpectedValueForWeightNull()
        {
            double? expected = null;

            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double?> valueSelector = d => d;
            Func<double, double?> weightSelector = d => null;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableDoublesReturnsExpectedValueForValueNull()
        {
            double? expected = null;

            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double?> valueSelector = d => null;
            Func<double, double?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForDoublesThrowsIfSequenceIsNull()
        {
            IEnumerable<double> sequence = null;
            Func<double, double> valueSelector = d => d;
            Func<double, double> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForDoublesThrowsIfValueSelectorIsNull()
        {
            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double> valueSelector = null;
            Func<double, double> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForDoublesThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double> valueSelector = d => d;
            Func<double, double> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForDoublesReturnsExpectedValue()
        {
            double expected = 16.246753246753247d;

            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double> valueSelector = d => d;
            Func<double, double> weightSelector = d => d;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForDoublesReturnsExpectedValueForEmptySequence()
        {
            double expected = double.NaN;

            IEnumerable<double> sequence = Array.Empty<double>();
            Func<double, double> valueSelector = d => d;
            Func<double, double> weightSelector = d => d;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForDoublesReturnsExpectedValueForTotalWeightOfZero()
        {
            double expected = double.NaN;

            IEnumerable<double> sequence = new double[] { 1d, 3d, 24d, 17d, 12d, 6d, 14d };
            Func<double, double> valueSelector = d => d;
            Func<double, double> weightSelector = d => 0.0;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableFloatsThrowsIfSequenceIsNull()
        {
            IEnumerable<float> sequence = null;
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableFloatsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float?> valueSelector = null;
            Func<float, float?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableFloatsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableFloatsReturnsExpectedValue()
        {
            double? expected = 16.246753246753247d;

            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableFloatsReturnsExpectedValueForEmptySequence()
        {
            double? expected = double.NaN;

            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableFloatsReturnsExpectedValueForTotalWeightOfZero()
        {
            double? expected = double.NaN;

            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = d => 0.0f;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableFloatsReturnsExpectedValueForWeightNull()
        {
            double? expected = null;

            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float?> valueSelector = d => d;
            Func<float, float?> weightSelector = d => null;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableFloatsReturnsExpectedValueForValueNull()
        {
            double? expected = null;

            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float?> valueSelector = d => null;
            Func<float, float?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForFloatsThrowsIfSequenceIsNull()
        {
            IEnumerable<float> sequence = null;
            Func<float, float> valueSelector = d => d;
            Func<float, float> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForFloatsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float> valueSelector = null;
            Func<float, float> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForFloatsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float> valueSelector = d => d;
            Func<float, float> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForFloatsReturnsExpectedValue()
        {
            double expected = 16.246753246753247d;

            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float> valueSelector = d => d;
            Func<float, float> weightSelector = d => d;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForFloatsReturnsExpectedValueForEmptySequence()
        {
            double expected = double.NaN;

            IEnumerable<float> sequence = Array.Empty<float>();
            Func<float, float> valueSelector = d => d;
            Func<float, float> weightSelector = d => d;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForFloatsReturnsExpectedValueForTotalWeightOfZero()
        {
            double expected = double.NaN;

            IEnumerable<float> sequence = new float[] { 1f, 3f, 24f, 17f, 12f, 6f, 14f };
            Func<float, float> valueSelector = d => d;
            Func<float, float> weightSelector = d => 0.0f;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableIntsThrowsIfSequenceIsNull()
        {
            IEnumerable<int> sequence = null;
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableIntsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int?> valueSelector = null;
            Func<int, int?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableIntsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableIntsReturnsExpectedValue()
        {
            double? expected = 16.246753246753247d;

            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableIntsReturnsExpectedValueForEmptySequence()
        {
            double? expected = double.NaN;

            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableIntsReturnsExpectedValueForTotalWeightOfZero()
        {
            double? expected = double.NaN;

            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = d => 0;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableIntsReturnsExpectedValueForWeightNull()
        {
            double? expected = null;

            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int?> valueSelector = d => d;
            Func<int, int?> weightSelector = d => null;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableIntsReturnsExpectedValueForValueNull()
        {
            double? expected = null;

            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int?> valueSelector = d => null;
            Func<int, int?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForIntsThrowsIfSequenceIsNull()
        {
            IEnumerable<int> sequence = null;
            Func<int, int> valueSelector = d => d;
            Func<int, int> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForIntsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int> valueSelector = null;
            Func<int, int> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForIntsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int> valueSelector = d => d;
            Func<int, int> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForIntsReturnsExpectedValue()
        {
            double expected = 16.246753246753247d;

            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int> valueSelector = d => d;
            Func<int, int> weightSelector = d => d;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForIntsReturnsExpectedValueForEmptySequence()
        {
            double expected = double.NaN;

            IEnumerable<int> sequence = Array.Empty<int>();
            Func<int, int> valueSelector = d => d;
            Func<int, int> weightSelector = d => d;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForIntsReturnsExpectedValueForTotalWeightOfZero()
        {
            double expected = double.NaN;

            IEnumerable<int> sequence = new int[] { 1, 3, 24, 17, 12, 6, 14 };
            Func<int, int> valueSelector = d => d;
            Func<int, int> weightSelector = d => 0;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableLongsThrowsIfSequenceIsNull()
        {
            IEnumerable<long> sequence = null;
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableLongsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long?> valueSelector = null;
            Func<long, long?> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableLongsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForNullableLongsReturnsExpectedValue()
        {
            double? expected = 16.246753246753247d;

            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableLongsReturnsExpectedValueForEmptySequence()
        {
            double? expected = double.NaN;

            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableLongsReturnsExpectedValueForTotalWeightOfZero()
        {
            double? expected = double.NaN;

            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = d => 0L;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableLongsReturnsExpectedValueForWeightNull()
        {
            double? expected = null;

            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long?> valueSelector = d => d;
            Func<long, long?> weightSelector = d => null;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForNullableLongsReturnsExpectedValueForValueNull()
        {
            double? expected = null;

            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long?> valueSelector = d => null;
            Func<long, long?> weightSelector = d => d;

            double? result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForLongsThrowsIfSequenceIsNull()
        {
            IEnumerable<long> sequence = null;
            Func<long, long> valueSelector = d => d;
            Func<long, long> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForLongsThrowsIfValueSelectorIsNull()
        {
            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long> valueSelector = null;
            Func<long, long> weightSelector = d => d;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForLongsThrowsIfWeightSelectorIsNull()
        {
            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long> valueSelector = d => d;
            Func<long, long> weightSelector = null;

            Assert.Throws<ArgumentNullException>(() => sequence.SafeWeightedAverage(valueSelector, weightSelector));
        }

        [Test]
        public void SafeWeightedAverageForLongsReturnsExpectedValue()
        {
            double expected = 16.246753246753247d;

            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long> valueSelector = d => d;
            Func<long, long> weightSelector = d => d;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForLongsReturnsExpectedValueForEmptySequence()
        {
            double expected = double.NaN;

            IEnumerable<long> sequence = Array.Empty<long>();
            Func<long, long> valueSelector = d => d;
            Func<long, long> weightSelector = d => d;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SafeWeightedAverageForLongsReturnsExpectedValueForTotalWeightOfZero()
        {
            double expected = double.NaN;

            IEnumerable<long> sequence = new long[] { 1L, 3L, 24L, 17L, 12L, 6L, 14L };
            Func<long, long> valueSelector = d => d;
            Func<long, long> weightSelector = d => 0L;

            double result = sequence.SafeWeightedAverage(valueSelector, weightSelector);

            Assert.AreEqual(expected, result);
        }
    }
}