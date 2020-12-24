using System;
using System.Collections.Generic;
using System.Linq;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Comparers;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods for performing sorted merged on a collection of sequences.
    /// </summary>
    public static class MergeByExtensions
    {
        /// <summary>
        /// Merges a collection of ordered sequences smallest to largest according to a specified key.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequene.</typeparam>
        /// <typeparam name="TKey">The type of key returned by the <paramref name="keySelector"/></typeparam>
        /// <param name="lists">The collection of sequences, each should be ordered smallest to largest.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <returns>
        /// A merged sequence containing all the elments of the collection of sequences, ordered smallest to largest.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="lists"/> or <paramref name="keySelector"/> was null.</exception>
        public static IEnumerable<T> MergeOrderedBy<T, TKey>(this IEnumerable<IEnumerable<T>> lists, Func<T, TKey> keySelector)
        {
            return MergeOrderedBy(lists, keySelector, null);
        }

        /// <summary>
        /// Merges a collection of ordered sequences smallest to largest according to a specified key comparer.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequene.</typeparam>
        /// <typeparam name="TKey">The type of key returned by the <paramref name="keySelector"/></typeparam>
        /// <param name="lists">The collection of sequences, each should be ordered smallest to largest.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="comparer">The comparer to compare the keys.</param>
        /// <returns>
        /// A merged sequence containing all the elments of the collection of sequences, ordered smallest to largest.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="lists"/> or <paramref name="keySelector"/> was null.</exception>
        public static IEnumerable<T> MergeOrderedBy<T, TKey>(this IEnumerable<IEnumerable<T>> lists, Func<T, TKey> keySelector, IComparer<TKey> comparer)
        {
            lists.ThrowIfNull(nameof(lists),
                $"Unable to perform ordered merge. {nameof(lists)} parameter cannot be null.");
            keySelector.ThrowIfNull(nameof(keySelector),
                $"Unable to perform ordered merge. {nameof(keySelector)} parameter cannot be null.");

            return MergeBy(lists, keySelector, comparer, false);
        }

        /// <summary>
        /// Merges a collection of ordered sequences largest to smallest according to a specified key.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequene.</typeparam>
        /// <typeparam name="TKey">The type of key returned by the <paramref name="keySelector"/></typeparam>
        /// <param name="lists">The collection of sequences, each should be ordered largest to smallest.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <returns>
        /// A merged sequence containing all the elments of the collection of sequences, ordered largest to smallest.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="lists"/> or <paramref name="keySelector"/> was null.</exception>
        public static IEnumerable<T> MergeOrderedByDescending<T, TKey>(this IEnumerable<IEnumerable<T>> lists, Func<T, TKey> keySelector)
        {
            return MergeOrderedByDescending(lists, keySelector, null);
        }

        /// <summary>
        /// Merges a collection of ordered sequences largest to smallest according to a specified key comparer.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequene.</typeparam>
        /// <typeparam name="TKey">The type of key returned by the <paramref name="keySelector"/></typeparam>
        /// <param name="lists">The collection of sequences, each should be ordered largest to smallest.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="comparer">The comparer to compare the keys.</param>
        /// <returns>
        /// A merged sequence containing all the elments of the collection of sequences, ordered largest to smallest.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="lists"/> or <paramref name="keySelector"/> was null.</exception>
        public static IEnumerable<T> MergeOrderedByDescending<T, TKey>(this IEnumerable<IEnumerable<T>> lists, Func<T, TKey> keySelector, IComparer<TKey> comparer)
        {
            lists.ThrowIfNull(nameof(lists),
                $"Unable to perform ordered descending merge. {nameof(lists)} parameter cannot be null.");
            keySelector.ThrowIfNull(nameof(keySelector),
                $"Unable to perform ordered descending merge. {nameof(keySelector)} parameter cannot be null.");

            return MergeBy(lists, keySelector, comparer, true);
        }

        internal static IEnumerable<T> MergeBy<T, TKey>(IEnumerable<IEnumerable<T>> lists, Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            var initialItems = lists
                .Select(l => l.GetEnumerator())
                .Where(i => i.MoveNext());

            IComparer<T> keyComparer = comparer != null ?
                new KeySelectorComparer<T, TKey>(keySelector, comparer) :
                new KeySelectorComparer<T, TKey>(keySelector);

            var enumerableComparer = new EnumeratorComparer<T>(keyComparer);

            DHeap<IEnumerator<T>> heap;
            if (descending)
            {
                heap = new MaxDHeap<IEnumerator<T>>(2, initialItems, enumerableComparer);
            }
            else
            {
                heap = new MinDHeap<IEnumerator<T>>(2, initialItems, enumerableComparer);
            }

            while (!heap.IsEmpty)
            {
                var i = heap.RemoveRoot();
                yield return i.Current;
                if (i.MoveNext())
                {
                    heap.Insert(i);
                }
            }
        }
    }
}