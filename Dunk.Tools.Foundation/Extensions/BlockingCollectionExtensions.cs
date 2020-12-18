using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of static extension methods for a <see cref="BlockingCollection{T}"/> instance.
    /// </summary>
    public static class BlockingCollectionExtensions
    {
        /// <summary>
        /// Adds a sequence of items to the <see cref="BlockingCollection{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="sequence">The sequence of items to add, the sequence can contain null references.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="sequence"/> was null.</exception>
        public static void AddRange<T>(this BlockingCollection<T> collection, IEnumerable<T> sequence)
        {
            collection.ThrowIfNull(nameof(collection));
            sequence.ThrowIfNull(nameof(sequence));

            foreach(T item in sequence)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Adds a sequence of items to the <see cref="BlockingCollection{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="sequence">The sequence of items to add, the sequence can contain null references.</param>
        /// <param name="cancellationToken">A cancellation token to observe.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="sequence"/> was null.</exception>
        public static void AddRange<T>(this BlockingCollection<T> collection, IEnumerable<T> sequence, CancellationToken cancellationToken)
        {
            collection.ThrowIfNull(nameof(collection));
            sequence.ThrowIfNull(nameof(sequence));

            foreach (T item in sequence)
            {
                collection.Add(item, cancellationToken);
            }

        }
    }
}
