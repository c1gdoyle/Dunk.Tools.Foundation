using System;
using System.Collections.Generic;
using System.Linq;
using Dunk.Tools.Foundation.Collections;

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
        /// Converts a given sequence into a <see cref="SmartEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The source to convert.</param>
        /// <returns>
        /// A smart-enumerable containing the elements from the original source.
        /// </returns>
        public static SmartEnumerable<T> ToSmartEnumerable<T>(this IEnumerable<T> source)
        {
            source.ThrowIfNull(nameof(source),
                $"Unable to convert to smart-enumerable. {nameof(source)} parameter cannot be null");

            return new SmartEnumerable<T>(source);
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
            long number = 0;

            foreach (decimal value in source)
            {
                number++;
                decimal delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if (number > 1)
            {
                return Math.Sqrt((double)sum / number);
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
            float sum = 0;

            long n = 0;
            foreach (float value in source)
            {
                n++;
                float delta = value - mean;
                mean += delta / n;
                sum += (delta * (value - mean));
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
            long number = 0;

            foreach(int value in source)
            {
                number++;
                double delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if(number > 1)
            {
                return Math.Sqrt(sum / number);
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
            long number = 0;

            foreach (long value in source)
            {
                number++;
                double delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if (number > 1)
            {
                return Math.Sqrt(sum / number);
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
            long number = 0;

            foreach (double value in source)
            {
                number++;
                double delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if (number > 1)
            {
                return Math.Sqrt(sum / number);
            }
            return 0;
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of nullable <see cref="decimal"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double StandardDeviation(this IEnumerable<decimal?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            decimal mean = 0;
            decimal sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (decimal? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                decimal delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return Math.Sqrt((double)sum / number);
            }
            return 0;
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of nullable <see cref="float"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double StandardDeviation(this IEnumerable<float?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            float mean = 0;
            float sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (float? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                float delta = value.Value - mean;
                mean += delta / number;
                sum += (delta * (value.Value - mean));
            }
            if (number > 1 && hasValues)
            {
                return Math.Sqrt((double)sum / number);
            }
            return 0;
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of nullable <see cref="int"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double StandardDeviation(this IEnumerable<int?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (int? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                double delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return Math.Sqrt(sum / number);
            }
            return 0;
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of nullable <see cref="long"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double StandardDeviation(this IEnumerable<long?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (long? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                double delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return Math.Sqrt(sum / number);
            }
            return 0;
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of nullable <see cref="double"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double StandardDeviation(this IEnumerable<double?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (double? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }
                hasValues = true;
                number++;
                double delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return Math.Sqrt(sum / number);
            }
            return 0;
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of <see cref="decimal"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return StandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of <see cref="float"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return StandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of <see cref="int"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return StandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of <see cref="long"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return StandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of <see cref="double"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return StandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of nullable <see cref="decimal"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return StandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of nullable <see cref="float"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return StandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of nullable <see cref="int"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return StandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of nullable <see cref="long"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return StandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes standard-deviation for a sequence of nullable <see cref="double"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return StandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of <see cref="decimal"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double SampleStandardDeviation(this IEnumerable<decimal> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate sample Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            decimal mean = 0;
            decimal sum = 0;
            long number = 0;

            foreach (decimal value in source)
            {
                number++;
                decimal delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if (number > 1)
            {
                return Math.Sqrt((double)sum / (number - 1));
            }
            return 0;
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of <see cref="float"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double SampleStandardDeviation(this IEnumerable<float> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate sample Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            float mean = 0;
            float sum = 0;
            long number = 0;

            foreach (float value in source)
            {
                number++;
                float delta = value - mean;
                mean += delta / number;
                sum += (delta * (value - mean));
            }
            if (number > 1)
            {
                return Math.Sqrt((double)sum / (number - 1));
            }
            return 0;
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of <see cref="int"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double SampleStandardDeviation(this IEnumerable<int> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate sample Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;

            foreach (int value in source)
            {
                number++;
                double delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if (number > 1)
            {
                return Math.Sqrt(sum / (number - 1));
            }
            return 0;
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of <see cref="long"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double SampleStandardDeviation(this IEnumerable<long> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate sample Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;

            foreach (long value in source)
            {
                number++;
                double delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if (number > 1)
            {
                return Math.Sqrt(sum / (number - 1));
            }
            return 0;
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of <see cref="double"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double SampleStandardDeviation(this IEnumerable<double> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate sample Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;

            foreach (double value in source)
            {
                number++;
                double delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if (number > 1)
            {
                return Math.Sqrt(sum / (number - 1));
            }
            return 0;
        }


        /// <summary>
        /// Computes sample standard-deviation for a sequence of nullable <see cref="decimal"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double SampleStandardDeviation(this IEnumerable<decimal?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate sample Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            decimal mean = 0;
            decimal sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (decimal? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                decimal delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return Math.Sqrt((double)sum / (number - 1));
            }
            return 0;
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of nullable <see cref="float"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double SampleStandardDeviation(this IEnumerable<float?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate sample Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            float mean = 0;
            float sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (float? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                float delta = value.Value - mean;
                mean += delta / number;
                sum += (delta * (value.Value - mean));
            }
            if (number > 1 && hasValues)
            {
                return Math.Sqrt((double)sum / (number - 1));
            }
            return 0;
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of nullable <see cref="int"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double SampleStandardDeviation(this IEnumerable<int?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate sample Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (int? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                double delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return Math.Sqrt(sum / (number - 1));
            }
            return 0;
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of nullable <see cref="long"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double SampleStandardDeviation(this IEnumerable<long?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate sample Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (long? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                double delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return Math.Sqrt(sum / (number - 1));
            }
            return 0;
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of nullable <see cref="double"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double SampleStandardDeviation(this IEnumerable<double?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate sample Standard-Deviation, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (double? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }
                hasValues = true;
                number++;
                double delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return Math.Sqrt(sum / (number - 1));
            }
            return 0;
        }


        /// <summary>
        /// Computes sample standard-deviation for a sequence of <see cref="decimal"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double SampleStandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate sample Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return SampleStandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of <see cref="float"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double SampleStandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate sample Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return SampleStandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of <see cref="int"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double SampleStandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate sample Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return SampleStandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of <see cref="long"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double SampleStandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate sample Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return SampleStandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of <see cref="double"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double SampleStandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate sample Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return SampleStandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of nullable <see cref="decimal"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double SampleStandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate sample Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return SampleStandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of nullable <see cref="float"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double SampleStandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate sample Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return SampleStandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of nullable <see cref="int"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double SampleStandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate sample Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return SampleStandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of nullable <see cref="long"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double SampleStandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate sample Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return SampleStandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes sample standard-deviation for a sequence of nullable <see cref="double"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The standard-deviation, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double SampleStandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate sample Standard-Deviation, {nameof(selector)} parameter cannot be null");
            }
            return SampleStandardDeviation(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes variance for a sequence of <see cref="decimal"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double Variance(this IEnumerable<decimal> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate variance, {nameof(source)} parameter cannot be null");
            }

            decimal mean = 0;
            decimal sum = 0;
            long number = 0;

            foreach (decimal value in source)
            {
                number++;
                decimal delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if (number > 1)
            {
                return (double)sum / number;
            }
            return 0;
        }

        /// <summary>
        /// Computes variance for a sequence of <see cref="float"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double Variance(this IEnumerable<float> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate variance, {nameof(source)} parameter cannot be null");
            }

            float mean = 0;
            float sum = 0;

            long n = 0;
            foreach (float value in source)
            {
                n++;
                float delta = value - mean;
                mean += delta / n;
                sum += (delta * (value - mean));
            }
            if (n > 1)
            {
                return (double)sum / n;
            }
            return 0;
        }

        /// <summary>
        /// Computes variance for a sequence of <see cref="int"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double Variance(this IEnumerable<int> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate variance, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;

            foreach (int value in source)
            {
                number++;
                double delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if (number > 1)
            {
                return sum / number;
            }
            return 0;
        }

        /// <summary>
        /// Computes variance for a sequence of <see cref="long"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double Variance(this IEnumerable<long> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate variance, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;

            foreach (long value in source)
            {
                number++;
                double delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if (number > 1)
            {
                return sum / number;
            }
            return 0;
        }

        /// <summary>
        /// Computes variance for a sequence of <see cref="double"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double Variance(this IEnumerable<double> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate variance, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;

            foreach (double value in source)
            {
                number++;
                double delta = value - mean;
                mean += delta / number;
                sum += delta * (value - mean);
            }
            if (number > 1)
            {
                return sum / number;
            }
            return 0;
        }


        /// <summary>
        /// Computes variance for a sequence of nullable <see cref="decimal"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double Variance(this IEnumerable<decimal?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate variance, {nameof(source)} parameter cannot be null");
            }

            decimal mean = 0;
            decimal sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (decimal? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                decimal delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return (double)sum / number;
            }
            return 0;
        }

        /// <summary>
        /// Computes variance for a sequence of nullable <see cref="float"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double Variance(this IEnumerable<float?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate variance, {nameof(source)} parameter cannot be null");
            }

            float mean = 0;
            float sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (float? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                float delta = value.Value - mean;
                mean += delta / number;
                sum += (delta * (value.Value - mean));
            }
            if (number > 1 && hasValues)
            {
                return (double)sum / number;
            }
            return 0;
        }

        /// <summary>
        /// Computes variance for a sequence of nullable <see cref="int"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double Variance(this IEnumerable<int?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate variance, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (int? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                double delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return sum / number;
            }
            return 0;
        }

        /// <summary>
        /// Computes variance for a sequence of nullable <see cref="long"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double Variance(this IEnumerable<long?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate variance, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (long? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }

                hasValues = true;
                number++;
                double delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return sum / number;
            }
            return 0;
        }

        /// <summary>
        /// Computes variance for a sequence of nullable <see cref="double"/>s.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> cannot be null.</exception>
        public static double Variance(this IEnumerable<double?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate variance, {nameof(source)} parameter cannot be null");
            }

            double mean = 0;
            double sum = 0;
            long number = 0;
            bool hasValues = false;

            foreach (double? value in source)
            {
                if (!value.HasValue)
                {
                    continue;
                }
                hasValues = true;
                number++;
                double delta = value.Value - mean;
                mean += delta / number;
                sum += delta * (value.Value - mean);
            }
            if (number > 1 && hasValues)
            {
                return sum / number;
            }
            return 0;
        }

        /// <summary>
        /// Computes variance for a sequence of <see cref="decimal"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate variance, {nameof(selector)} parameter cannot be null");
            }
            return Variance(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes variance for a sequence of <see cref="float"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate variance, {nameof(selector)} parameter cannot be null");
            }
            return Variance(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes variance for a sequence of <see cref="int"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate variance, {nameof(selector)} parameter cannot be null");
            }
            return Variance(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes variance for a sequence of <see cref="long"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate variance, {nameof(selector)} parameter cannot be null");
            }
            return Variance(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes variance for a sequence of <see cref="double"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate variance, {nameof(selector)} parameter cannot be null");
            }
            return Variance(Enumerable.Select(source, selector));
        }


        /// <summary>
        /// Computes variance for a sequence of nullable <see cref="decimal"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate variance, {nameof(selector)} parameter cannot be null");
            }
            return Variance(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes variance for a sequence of nullable <see cref="float"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate variance, {nameof(selector)} parameter cannot be null");
            }
            return Variance(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes variance for a sequence of nullable <see cref="int"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate variance, {nameof(selector)} parameter cannot be null");
            }
            return Variance(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes variance for a sequence of nullable <see cref="long"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate variance, {nameof(selector)} parameter cannot be null");
            }
            return Variance(Enumerable.Select(source, selector));
        }

        /// <summary>
        /// Computes variance for a sequence of nullable <see cref="double"/>s that are obtained by 
        /// invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">The sequence.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <returns>
        /// The variance, or <c>0</c> if the sequence is empty or only contains nulls.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> was null.</exception>
        public static double Variance<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector),
                    $"Unable to calculate variance, {nameof(selector)} parameter cannot be null");
            }
            return Variance(Enumerable.Select(source, selector));
        }
    }
}
