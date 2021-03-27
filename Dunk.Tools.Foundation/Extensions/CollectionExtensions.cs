using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods for a <see cref="ICollection{T}"/> instance.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds the elements of the specified collection to this sequence.
        /// </summary>
        /// <typeparam name="T">The type of element in the sequence.</typeparam>
        /// <param name="sequence">The sequeuence.</param>
        /// <param name="collection">The collection whose elements should be added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> cannot be null.</exception>
        public static void AddRange<T>(this ICollection<T> sequence, IEnumerable<T> collection)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            List<T> list = sequence as List<T>;
            if (list != null)
            {
                list.AddRange(collection);
            }
            else
            {
                foreach (T item in collection)
                {
                    sequence.Add(item);
                }
            }
        }
    }
}
