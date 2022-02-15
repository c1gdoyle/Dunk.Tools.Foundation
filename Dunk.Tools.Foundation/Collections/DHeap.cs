// Copyright © 2014, Jim Mischel

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// An implementation of <see cref="IHeap{T}"/> that represents a d-order hearp 
    /// of objects.
    /// </summary>
    /// <typeparam name="T">The type of elements in the heap.</typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public class DHeap<T> : IHeap<T>
    {
        private readonly IComparer<T> comparer;
        private readonly Func<int, bool> _resultComparer;

        private readonly int _order;

        private readonly List<T> _items;

        internal DHeap(int order, Func<int, bool> resultComparer, IEnumerable<T> collection, IComparer<T> comparer = null)
            : this(order, resultComparer, comparer)
        {
            if (order < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(order), $"{nameof(order)} must be greater than or equal to two.");
            }
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), $"{nameof(collection)} may not be null.");
            }
            _items = new List<T>(collection);
            Heapify();
        }

        internal DHeap(int order, Func<int, bool> resultComparer, int capacity, IComparer<T> comparer = null)
            : this(order, resultComparer, comparer)
        {
            if (order < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(order), $"{nameof(order)} must be greater than or equal to two.");
            }
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"{nameof(capacity)} must be greater than zero.");
            }
            _items = new List<T>(capacity);
        }

        private DHeap(int order, Func<int, bool> resultComparer, IComparer<T> comparer = null)
        {
            _order = order;
            this.comparer = comparer ?? Comparer<T>.Default;
            _resultComparer = resultComparer;
        }

        /// <summary>
        /// Gets the underlying items contained in the hep
        /// </summary>
        internal IList<T> Items
        {
            get { return _items; }
        }

        #region IHeap<T> Members
        /// <summary>
        /// Gets or sets the total number of items the internal data structure can
        /// hold without resizing.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Capacity is set to a value that is less than Count.</exception>
        /// <exception cref="System.OutOfMemoryException">
        /// There is not enough memory on the system.</exception>
        public int Capacity
        {
            get { return _items.Capacity; }
            set
            {
                if (value < _items.Count)
                {
                    throw new ArgumentOutOfRangeException("value", "must be greater than or equal to Count");
                }
                _items.Capacity = value;
            }
        }

        /// <summary>
        /// Gets the number of items actually contained in the heap.
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// Gets a value that indicates whether the heap is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return _items.Count == 0; }
        }

        /// <summary>
        /// Remove all items from the heap.
        /// </summary>
        /// <remarks>This method is an O(n) operation, where n is <c>Count</c>.</remarks>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Returns a consuming enumerable for items in the MinMaxHeap&lt;T&gt;.
        /// </summary>
        /// <returns>An IEnumerable&lt;T&gt; that removes and returns items from the collection,
        /// in ascending order.</returns>
        /// <remarks>
        /// <para>Removes and returns items in order, starting with the minimum element.</para>
        /// </remarks>
        public IEnumerable<T> GetConsumingEnumerable()
        {
            while (_items.Count > 0)
            {
                yield return RemoveRoot();
            }
        }

        /// <summary>
        /// Inserts a value into the heap.
        /// </summary>
        /// <param name="item">The value to be inserted. If T is a reference type,
        /// item may not be null.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <remarks>
        /// 1.  Add the item to the first empty spot in the structure. That is the lowest, leftmost position.
        /// 2.  Bubble up. While the item is smaller than its' parent, swap the item with its' parent.
        ///     If the node gets to the top of the tree, stop. The root has no parent.
        /// </remarks>
        public void Insert(T item)
        {
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException("item");
            }
            _items.Add(item);

            //Get index of the newly added item
            int index = _items.Count - 1;
            BubbleUp(index);
        }

        /// <summary>
        /// Inserts the items of the specified collection into the MinMaxHeap&lt;T&gt;.
        /// </summary>
        /// <param name="collection">The collection whose elements should be inserted
        /// into the heap.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="collection"/>is null</exception>
        /// <exception cref="System.InvalidOperationException">An item in <paramref name="collection"/>is null.</exception>
        /// <remarks>This is an O(k log n) operation, where k is the number of items to be added,
        /// and n is equal to <c>Count</c>.</remarks>
        public void InsertRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            int old = _items.Count;
            _items.AddRange(collection);
            // Simple optimization here.
            // If the number of items being added is more than (_items.Count / _ary),
            // then it's probably faster to re-heapify the entire thing rather than
            // call BubbleUp for each of the new items.
            int itemsAdded = _items.Count - old;
            if (itemsAdded > _items.Count / _order)
            {
                Heapify();
            }
            else
            {
                // bubble up each item 
                for (int i = old; i < _items.Count; ++i)
                {
                    if (ReferenceEquals(_items[i], null))
                    {
                        throw new InvalidOperationException("Cannot insert a null item into the heap.");
                    }
                    BubbleUp(i);
                }
            }
        }

        /// <summary>
        /// Returns the root item from the heap, without removing it.
        /// </summary>
        /// <returns>Returns the item at the root of the heap.</returns>
        /// <exception cref="System.InvalidOperationException">The heap is empty.</exception>
        /// <remarks>
        /// <para>This is an O(1) operation.</para>
        /// <para>The root element will be the smallest element in a min heap,
        /// and the largest element in a max heap.</para>
        /// </remarks>
        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }
            return _items[0];
        }

        /// <summary>
        /// Removes and returns the root item from the heap.
        /// </summary>
        /// <returns>Returns the item at the root of the heap.</returns>
        /// <exception cref="System.InvalidOperationException">The heap is empty.</exception>
        /// <remarks>
        /// 1.  Remove the item in the first position. this is the smallest item.
        /// 2.  Move the last item in the structure to the first position.
        /// 3.  Sift down. While the item is larger than the smallest of its' children, swap the smallest child.
        ///     If item has no children stop.
        /// </remarks>
        public T RemoveRoot()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }
            // Get the first item
            T smallest = _items[0];

            // Get the last item and insert it at the top
            _items[0] = _items[_items.Count - 1];

            //Remove the last item
            _items.RemoveAt(_items.Count - 1);

            if (_items.Count > 0)
            {
                SiftDown(0);
            }
            return smallest;
        }
        #endregion IHeap<T> Members

        #region IEnumerable<T> Members
        /// <summary>
        /// Returns an enumerator that iterates through the heap.
        /// </summary>
        /// <returns>An IEnumerator&lt;T&gt; that can be used to iterate through the collection.</returns>
        /// <remarks>The enumerator returns items in the order in which they are stored by
        /// the internal data structure. It is not guaranteed to be in sorted order.</remarks>
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the heap.
        /// </summary>
        /// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
        /// <remarks>The enumerator returns items in the order in which they are stored by
        /// the internal data structure. It is not guaranteed to be in sorted order.</remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion IEnumerable<T> Members

        private void Heapify()
        {
            for (int i = _items.Count / _order; i >= 0; --i)
            {
                SiftDown(i);
            }
        }

        private void SiftDown(int index)
        {
            while ((_order * index) + 1 < _items.Count)
            {
                // find the smallest child
                int child = (index * _order) + 1;
                int currentSmallestChild = child;

                int maxChild = child + _order;
                if (maxChild > _items.Count)
                {
                    maxChild = _items.Count;
                }
                ++child;
                while (child < maxChild)
                {
                    if (DoCompare(_items[currentSmallestChild], _items[child]))
                    {
                        currentSmallestChild = child;
                    }
                    ++child;
                }

                child = currentSmallestChild;
                // percolate one level
                if (DoCompare(_items[child], _items[index]))
                {
                    break;
                }
                //Swap
                var temp = _items[index];
                _items[index] = _items[child];
                _items[child] = temp;
                index = child;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool DoCompare(T x, T y)
        {
            return _resultComparer(comparer.Compare(x, y));
        }

        private void BubbleUp(int i)
        {
            T item = _items[i];
            while (i > 0 && DoCompare(_items[(i - 1) / _order], item))
            {
                _items[i] = _items[(i - 1) / _order];
                i = (i - 1) / _order;
            }
            _items[i] = item;
        }
    }
}
