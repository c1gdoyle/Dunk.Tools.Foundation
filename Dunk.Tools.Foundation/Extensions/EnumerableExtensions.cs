using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        /// Converts a given sequence into a <see cref="SynchronisedHashSet{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The source to convert.</param>
        /// <returns>
        /// A hash-set containing the unique values from the original source.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> parameter was null.</exception>
        public static SynchronisedHashSet<T> ToSynchronisedHashSet<T>(this IEnumerable<T> source)
        {
            return ToSynchronisedHashSet<T>(source, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Converts a given sequence into a <see cref="SynchronisedHashSet{T}"/> using a specified comparer.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The source to convert.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>
        /// A hash-set containing the unique values from the original source.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="comparer"/> parameter was null.</exception>
        public static SynchronisedHashSet<T> ToSynchronisedHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            source.ThrowIfNull(nameof(source),
                $"Unable to convert to HashSet. {nameof(source)} parameter cannot be null");
            comparer.ThrowIfNull(nameof(comparer),
                $"Unable to convert to HashSet. {nameof(comparer)} parameter cannot be null");

            return new SynchronisedHashSet<T>(source, comparer);
        }

        /// <summary>
        /// Converts a given sequence into a <see cref="ConcurrentHashSet{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The source to convert.</param>
        /// <returns>
        /// A hash-set containing the unique values from the original source.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> parameter was null.</exception>
        public static ConcurrentHashSet<T> ToConcurrentHashSet<T>(this IEnumerable<T> source)
        {
            return ToConcurrentHashSet<T>(source, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Converts a given sequence into a <see cref="ConcurrentHashSet{T}"/> using a specified comparer.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The source to convert.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>
        /// A hash-set containing the unique values from the original source.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="comparer"/> parameter was null.</exception>
        public static ConcurrentHashSet<T> ToConcurrentHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            source.ThrowIfNull(nameof(source),
                $"Unable to convert to HashSet. {nameof(source)} parameter cannot be null");
            comparer.ThrowIfNull(nameof(comparer),
                $"Unable to convert to HashSet. {nameof(comparer)} parameter cannot be null");

            return new ConcurrentHashSet<T>(source, comparer);
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using a specified delegate to
        /// compare the elements.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the source.</typeparam>
        /// <typeparam name="TKey">The type of the key used to compare the elements.</typeparam>
        /// <param name="source">The sequence to remove duplicate elements from.</param>
        /// <param name="keySelector">The delegate to use to compare elements.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains distinct elements from 
        /// the <paramref name="source"/> sequence.
        /// </returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            CheckDistinctByArguments(source, keySelector);
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Determines whether a given sequence is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns>
        /// <c>true</c> if the <paramref name="sequence"/> is null or contains no elements; otherwise returns <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmtpty<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                return true;
            }

            var collection = sequence as ICollection<T>;
            if (collection != null)
            {
                return collection.Count == 0;
            }
            return !sequence.Any();
        }

        /// <summary>
        /// Partitions a sequence of values into a collection of batches of a specified size.
        /// </summary>
        /// <typeparam name="T">The type of elements of the sour.ce</typeparam>
        /// <param name="source">The source to partition.</param>
        /// <param name="size">The size of the batches.</param>
        /// <returns>
        /// A collection containing all values of the original sequence partitioned into batches.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="size"/> was zero or negative.</exception>
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int size)
        {
            CheckPartitionArguments(source, size);

            int count = 0;
            T[] group = null;
            foreach (T item in source)
            {
                if (group == null)
                {
                    group = new T[size];
                }
                group[count] = item;
                count++;

                if (count == size)
                {
                    yield return group;
                    group = null;
                    count = 0;
                }
            }

            if (count != 0)
            {
                Array.Resize(ref group, count);
                yield return group;
            }
        }

        /// <summary>
        /// Concatenates multiple <see cref="IEnumerable{T}"/> instances into a single <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of element in the collections.</typeparam>
        /// <param name="toCombine">The collections to concatenate together.</param>
        /// <returns>
        /// An enumerable containing all items in the supplied lists.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="toCombine"/> was null.</exception>
        public static IEnumerable<T> Concatenate<T>(params IEnumerable<T>[] toCombine)
        {
            toCombine.ThrowIfNull(nameof(toCombine),
                $"Unable to concatenate sequences. {nameof(toCombine)} parameter cannot be null");
            return toCombine.SelectMany(x => x);
        }

        /// <summary>
        /// Returns the values in a sequence whose result key values fall between the
        /// supplied lower and upper limits.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of key value to compare the elements.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="keySelector">A predicate used to select the key value to compare against the lower and upper limits.</param>
        /// <param name="lower">The lowest value of the key selector that will appear in the new collection.</param>
        /// <param name="upper">The highest value of the key selector that will appear in the new collection.</param>
        /// <returns>
        /// A <see cref="IEnumerable{T}"/> sequence whose selected values fall within the range of the <paramref name="lower"/> and <paramref name="upper"/>.
        /// </returns>
        public static IEnumerable<T> Between<T, TKey>(this IEnumerable<T> source, Expression<Func<T, TKey>> keySelector, TKey lower, TKey upper)
            where TKey : IComparable<TKey>
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), 
                    $"{nameof(source)} parameter for Enumerable Between cannot be null");
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector),
                    $"{nameof(keySelector)} parameter for Enumerable Between cannot be null");
            }

            Expression key = Expression.Invoke(keySelector, keySelector.Parameters.ToArray());

            Expression lowerBound = Expression.GreaterThanOrEqual(key, Expression.Constant(lower));
            Expression upperBound = Expression.LessThanOrEqual(key, Expression.Constant(upper));

            Expression andClause = Expression.AndAlso(lowerBound, upperBound);

            Func<T, bool> whereClause =
                Expression.Lambda<Func<T, bool>>(andClause, keySelector.Parameters)
                .Compile();

            return source.Where(whereClause);
        }

        /// <summary>
        /// Pivots values in a sequence by selecting a specified first and second key and
        /// then apply an aggregation on the output.
        /// </summary>
        /// <typeparam name="T">The type of element in the original sequence.</typeparam>
        /// <typeparam name="TFirstKey">The type of the first key.</typeparam>
        /// <typeparam name="TSecondKey">The type of the second key.</typeparam>
        /// <typeparam name="TOutput">The type of the output from the aggregation.</typeparam>
        /// <param name="source">The original source sequence.</param>
        /// <param name="firstKeySelector">The function for selecting the first key.</param>
        /// <param name="secondKeySelector">The function for selecting the second key.</param>
        /// <param name="aggregator">The function for performing aggregation.</param>
        /// <returns>
        /// A dictionary of dictionaries where the keys are the TFirstKey and TSecondKey respectively and the value is the output of the aggregation function.
        /// </returns>
        public static IDictionary<TFirstKey, IDictionary<TSecondKey, TOutput>> Pivot<T, TFirstKey, TSecondKey, TOutput>
            (this IEnumerable<T> source, Func<T, TFirstKey> firstKeySelector, Func<T, TSecondKey> secondKeySelector,
            Func<IEnumerable<T>, TOutput> aggregator)
        {
            source.ThrowIfNull(nameof(source),
                $"Unable to Pivot. {nameof(source)} parameter cannot be null.");
            firstKeySelector.ThrowIfNull(nameof(firstKeySelector),
               $"Unable to Pivot. {nameof(firstKeySelector)} parameter cannot be null.");
            secondKeySelector.ThrowIfNull(nameof(secondKeySelector),
               $"Unable to Pivot. {nameof(secondKeySelector)} parameter cannot be null.");
            aggregator.ThrowIfNull(nameof(aggregator),
               $"Unable to Pivot. {nameof(aggregator)} parameter cannot be null.");

            var result = new Dictionary<TFirstKey, IDictionary<TSecondKey, TOutput>>();

            var lookup = source.ToLookup(firstKeySelector);
            foreach (var kvp in lookup)
            {
                var dict = new Dictionary<TSecondKey, TOutput>();
                result.Add(kvp.Key, dict);
                var subDict = kvp.ToLookup(secondKeySelector);
                foreach (var subKvp in subDict)
                {
                    dict.Add(subKvp.Key, aggregator(subKvp));
                }
            }
            return result;
        }

        private static void CheckPartitionArguments<T>(IEnumerable<T> source, int size)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"{nameof(source)} parameter for partition cannot be null.");
            }
            if (size <= 0)
            {
                throw new ArgumentException($"{nameof(size)} parameter for partition cannot be zero or negative.",
                    nameof(size));
            }
        }

        private static void CheckDistinctByArguments<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source),
                    $"{nameof(source)} for DistinctBy cannot be null");
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector),
                    $"{nameof(source)} for DistinctBy cannot be null");
            }
        }
    }
}
