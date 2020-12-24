using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// Represents a D-Ary maximum heap of objects.
    /// </summary>
    /// <typeparam name="T">The type of elements in the heap.</typeparam>
    public sealed class MaxDHeap<T> : DHeap<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool MaxCompare(int result)
        {
            return result < 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaxDHeap{T}"/> class that is empty
        /// and has the specified initial capacity.
        /// </summary>
        /// <param name="order">The order of the heap. For example, a binary heap is a 2-heap.</param>
        /// <param name="capacity">The number of elements that the heap can initially store.</param>
        /// <param name="comparer">The IComparer&lt;T&gt; implementation to use when
        /// comparing keys. If null or not supplied, the default Comparer&lt;T&gt; is used.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <para><paramref name="order"/>is less than or equal to one.</para>
        /// <para><paramref name="capacity"/>is less than zero.</para>
        /// </exception>
        public MaxDHeap(int order, int capacity, IComparer<T> comparer = null)
            : base(order, MaxCompare, capacity, comparer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaxDHeap{T}"/> class that is empty
        /// and has the default initial capacity.
        /// </summary>
        /// <param name="order">The order of the heap. For example, a binary heap is a 2-heap.</param>
        /// <param name="comparer">The IComparer&lt;T&gt; implementation to use when
        /// comparing keys. If null or not supplied, the default Comparer&lt;T&gt; is used.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="order"/>is less than or equal to one.</exception>
        public MaxDHeap(int order, IComparer<T> comparer = null)
            : this(order, 0, comparer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaxDHeap{T}"/> class that contains 
        /// elements copied from the specified collection and has sufficient capacity 
        /// to accommodate the number of elements copied.
        /// </summary>
        /// <param name="order">The order of the heap. For example, a binary heap is a 2-heap.</param>
        /// <param name="collection">The collection whose elements are copied to the new heap. The collection may not be null.</param>
        /// <param name="comparer">The IComparer&lt;T&gt; implementation to use when
        /// comparing keys. If null or not supplied, the default Comparer&lt;T&gt; is used.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="collection"/>is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="order"/>is less than or equal to one.</exception>
        public MaxDHeap(int order, IEnumerable<T> collection, IComparer<T> comparer = null)
            : base(order, MaxCompare, collection, comparer)
        {
        }
    }
}
