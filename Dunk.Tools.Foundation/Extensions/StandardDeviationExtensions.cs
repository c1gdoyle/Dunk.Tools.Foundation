﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods for calculating Standard-Deviation for 
    /// an <see cref="IEnumerable{T}"/> instance.
    /// </summary>
    public static class StandardDeviationExtensions
    {
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
            return Math.Sqrt(Variance(source));
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
            return Math.Sqrt(Variance(source));
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
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"Unable to calculate Standard-Deviation, {nameof(source)} parameter cannot be null");
            }
            return Math.Sqrt(Variance(source));
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
            return Math.Sqrt(Variance(source));
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
            return Math.Sqrt(Variance(source));
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
            return Math.Sqrt(Variance(source));
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
            return Math.Sqrt(Variance(source));
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
            return Math.Sqrt(Variance(source));
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
            return Math.Sqrt(Variance(source));
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
            return Math.Sqrt(Variance(source));
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

            checked
            {
                foreach (decimal value in source)
                {
                    number++;
                    decimal delta = value - mean;
                    mean += delta / number;
                    sum += delta * (value - mean);
                }
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

            checked
            {
                foreach (float value in source)
                {
                    number++;
                    float delta = value - mean;
                    mean += delta / number;
                    sum += (delta * (value - mean));
                }
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

            checked
            {
                foreach (int value in source)
                {
                    number++;
                    double delta = value - mean;
                    mean += delta / number;
                    sum += delta * (value - mean);
                }
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

            checked
            {
                foreach (long value in source)
                {
                    number++;
                    double delta = value - mean;
                    mean += delta / number;
                    sum += delta * (value - mean);
                }
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

            checked
            {
                foreach (double value in source)
                {
                    number++;
                    double delta = value - mean;
                    mean += delta / number;
                    sum += delta * (value - mean);
                }
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

            checked
            {
                foreach (decimal? value in source)
                {
                    if (value != null)
                    {
                        hasValues = true;
                        number++;
                        decimal delta = value.GetValueOrDefault() - mean;
                        mean += delta / number;
                        sum += delta * (value.GetValueOrDefault() - mean);
                    }
                }
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

            checked
            {
                foreach (float? value in source)
                {
                    if (value != null)
                    {
                        hasValues = true;
                        number++;
                        float delta = value.GetValueOrDefault() - mean;
                        mean += delta / number;
                        sum += (delta * (value.GetValueOrDefault() - mean));
                    }
                }
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

            checked
            {
                foreach (int? value in source)
                {
                    if (value != null)
                    {
                        hasValues = true;
                        number++;
                        double delta = value.GetValueOrDefault() - mean;
                        mean += delta / number;
                        sum += delta * (value.GetValueOrDefault() - mean);
                    }
                }
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

            checked
            {
                foreach (long? value in source)
                {
                    if (value != null)
                    {
                        hasValues = true;
                        number++;
                        double delta = value.GetValueOrDefault() - mean;
                        mean += delta / number;
                        sum += delta * (value.GetValueOrDefault() - mean);
                    }
                }
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

            checked
            {
                foreach (double? value in source)
                {
                    if (value != null)
                    {
                        hasValues = true;
                        number++;
                        double delta = value.GetValueOrDefault() - mean;
                        mean += delta / number;
                        sum += delta * (value.GetValueOrDefault() - mean);
                    }
                }
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

            checked
            {
                foreach (decimal value in source)
                {
                    number++;
                    decimal delta = value - mean;
                    mean += delta / number;
                    sum += delta * (value - mean);
                }
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
            long number = 0;

            checked
            {
                foreach (float value in source)
                {
                    number++;
                    float delta = value - mean;
                    mean += delta / number;
                    sum += (delta * (value - mean));
                }
            }
            if (number > 1)
            {
                return (double)sum / number;
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

            checked
            {
                foreach (int value in source)
                {
                    number++;
                    double delta = value - mean;
                    mean += delta / number;
                    sum += delta * (value - mean);
                }
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

            checked
            {
                foreach (long value in source)
                {
                    number++;
                    double delta = value - mean;
                    mean += delta / number;
                    sum += delta * (value - mean);
                }
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

            checked
            {
                foreach (double value in source)
                {
                    number++;
                    double delta = value - mean;
                    mean += delta / number;
                    sum += delta * (value - mean);
                }
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

            checked
            {
                foreach (decimal? value in source)
                {
                    if (value != null)
                    {
                        hasValues = true;
                        number++;
                        decimal delta = value.GetValueOrDefault() - mean;
                        mean += delta / number;
                        sum += delta * (value.GetValueOrDefault() - mean);
                    }
                }
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

            checked
            {
                foreach (float? value in source)
                {
                    if (value != null)
                    {
                        hasValues = true;
                        number++;
                        float delta = value.GetValueOrDefault() - mean;
                        mean += delta / number;
                        sum += (delta * (value.GetValueOrDefault() - mean));
                    }
                }
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

            checked
            {
                foreach (int? value in source)
                {
                    if (value != null)
                    {
                        hasValues = true;
                        number++;
                        double delta = value.GetValueOrDefault() - mean;
                        mean += delta / number;
                        sum += delta * (value.GetValueOrDefault() - mean);
                    }
                }
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

            checked
            {
                foreach (long? value in source)
                {
                    if (value != null)
                    {
                        hasValues = true;
                        number++;
                        double delta = value.GetValueOrDefault() - mean;
                        mean += delta / number;
                        sum += delta * (value.GetValueOrDefault() - mean);
                    }
                }
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

            checked
            {
                foreach (double? value in source)
                {
                    if (value != null)
                    {
                        hasValues = true;
                        number++;
                        double delta = value.GetValueOrDefault() - mean;
                        mean += delta / number;
                        sum += delta * (value.GetValueOrDefault() - mean);
                    }
                }
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
