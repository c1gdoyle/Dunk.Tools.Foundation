using System;
using System.Collections.Generic;
using System.Linq;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/> instances.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns the values in a sequence in random order.
        /// </summary>
        /// <typeparam name="T">The type of element in the collection.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <returns>
        /// A <see cref="IEnumerable{T}"/> containing the elements of the original sequence in random order.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2245: Random is used to reorder enumerable. No security or encryption risk")]
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            Random r = new Random();

            return source.OrderBy(x => r.Next());
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of <see cref="decimal"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double StandardDeviation(this IEnumerable<decimal> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            decimal mean = 0;
            decimal sum = 0;

            long n = 0;
            foreach (decimal value in source)
            {
                n++;
                decimal delta = value - mean;
                mean += delta / n;
                sum += delta * (value - mean);
            }
            if (n > 1)
            {
                return Math.Sqrt((double)sum / n);
            }
            return 0;
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of <see cref="float"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double StandardDeviation(this IEnumerable<float> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            float mean = 0;
            decimal sum = 0;

            long n = 0;
            foreach (float value in source)
            {
                n++;
                float delta = value - mean;
                mean += delta / n;
                sum += (decimal)(delta * (value - mean));
            }
            if (n > 1)
            {
                return Math.Sqrt((double)sum / n);
            }
            return 0;
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of <see cref="int"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double StandardDeviation(this IEnumerable<int> source)
        {
            if(source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;

            long n = 0;
            foreach(int value in source)
            {
                n++;
                double delta = value - mean;
                mean += delta / n;
                sum += delta * (value - mean);
            }
            if(n > 1)
            {
                return Math.Sqrt(sum / n);
            }
            return 0;
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of <see cref="long"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double StandardDeviation(this IEnumerable<long> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;

            long n = 0;
            foreach (long value in source)
            {
                n++;
                double delta = value - mean;
                mean += delta / n;
                sum += delta * (value - mean);
            }
            if (n > 1)
            {
                return Math.Sqrt(sum / n);
            }
            return 0;
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of <see cref="double"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double StandardDeviation(this IEnumerable<double> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;

            long n = 0;
            foreach (double value in source)
            {
                n++;
                double delta = value - mean;
                mean += delta / n;
                sum += delta * (value - mean);
            }
            if (n > 1)
            {
                return Math.Sqrt(sum / n);
            }
            return 0;
        }

    }
}
