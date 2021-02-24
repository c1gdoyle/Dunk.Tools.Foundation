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
    }
}
