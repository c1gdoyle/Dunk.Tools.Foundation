using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// A double-ended queue for which elements can be added or removed from either 
    /// the front(head) or back(tail)
    /// </summary>
    /// <typeparam name="T">The type of items stored in the Deque.</typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public class Deque<T> : IDeque<T>, ICollection, IEnumerable<T>
    {
        private DequeNode _head;
        private DequeNode _tail;

        private int _count = 0;
        private long _version = 0;

        /// <summary>
        /// Initialises a new default instance of <see cref="Deque{T}"/>.
        /// </summary>
        public Deque()
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="Deque{T}"/> that contains 
        /// elements copied from the specified.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the Dequeue.</param>
        public Deque(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection),
                    $"Unable to initialise Deque. {nameof(collection)} parameter cannot be null");
            }
            foreach (T item in collection)
            {
                EnqueueItemToBack(item);
            }
        }

        #region IDeque<T> Members
        /// <inheritdoc />
        public void EnqueueItemToFront(T item)
        {
            /*
             * 1) Create a node to store the item
             * 2) Set the node's Next to point at the current head
             * 3) If there are items in queue set the current head's Previous to node
             * 4) Set the new node as the head
             * 5) Finally check if there is only one item, if so head and tail are the same
             * */
            DequeNode node = new DequeNode(item);
            node.Next = _head;
            if (Count != 0)
            {
                _head.Previous = node;
            }
            _head = node;

            _count++;
            if (Count == 1)
            {
                _tail = _head;
            }
            _version++;
        }

        /// <inheritdoc />
        public void EnqueueItemToBack(T item)
        {
            /*
             * 1) Create a node to store the item
             * 2) Set the node's Previous to point at the current tail
             * 3) If there are items in queue set the current tail's Next to the node
             * 4) Set the new node as the tail
             * 5) Finally check if there is only one item, if so head and tail are the same
             * */
            DequeNode node = new DequeNode(item);
            node.Previous = _tail;
            if (Count != 0)
            {
                _tail.Next = node;
            }
            _tail = node;

            _count++;
            if (Count == 1)
            {
                _head = _tail;
            }
            _version++;
        }

        /// <inheritdoc />
        public T DequeueItemFromFront()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Unable to Dequeue item from front. Deque is empty");
            }

            /*
             * 1) Get the value from the current head node
             * 2) Set the head to the current head's Next node.
             * 3) Decrement the count
             * 4) Check if the queue contains items, if it does set the new head's
             * Previous to null; otherwise both tail and head are nul
             * 
             * */
            T item = _head.Value;
            _head = _head.Next;

            _count--;

            if (Count != 0)
            {
                _head.Previous = null;
            }
            else
            {
                _tail = null;
            }
            _version++;

            return item;
        }

        /// <inheritdoc />
        public T DequeueItemFromBack()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Unable to Dequeue item from back. Deque is empty");
            }

            /*
             * 1) Get the value from the current tail node
             * 2) Set the tail to the current tail's Previous node.
             * 3) Decrement the count
             * 4) Check if the queue contains items, if it does set the new tail's
             * Next to null; otherwise both tail and head are nul
             * 
             * */
            T item = _tail.Value;
            _tail = _tail.Previous;

            _count--;

            if (Count != 0)
            {
                _tail.Next = null;
            }
            else
            {
                _head = null;
            }
            _version++;

            return item;
        }

        /// <inheritdoc />
        public T PeekAtItemFromFront()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Unable to Peek item from front. Deque is empty");
            }
            return _head.Value;
        }

        /// <inheritdoc />
        public T PeekAtItemFromBack()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Unable to Peek item from back. Deque is empty");
            }
            return _tail.Value;
        }
        #endregion IDeque<T> Members

        #region ICollection Members
        /// <summary>
        /// Gets the number of elements contained in the <see cref="Deque{T}"/>.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="Deque{T}"/> 
        /// is synchronised (thread safe).
        /// </summary>
        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronise access to the <see cref="Deque{T}"/>.
        /// </summary>
        object ICollection.SyncRoot
        {
            get { return this; }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            CopyTo((T[])array, index);
        }
        #endregion ICollection Members

        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return new DequeEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion IEnumerable<T> Members

        /// <summary>
        /// Gets value indicating whether or not the <see cref="Deque{T}"/> is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        /// <summary>
        /// Removes all items from the <see cref="Deque{T}"/>.
        /// </summary>
        public void Clear()
        {
            _count = 0;
            _version++;

            _head = null;
            _tail = null;
        }

        /// <summary>
        /// Determines whether the <see cref="Deque{T}"/> contains a 
        /// specified value.
        /// </summary>
        /// <param name="item">The item to locate.</param>
        /// <returns>
        /// <c>true</c> if the item is found in the <see cref="Deque{T}"/>; otherwise returns <c>false</c>.
        /// </returns>
        public bool Contains(T item)
        {
            return this.Any(i => EqualityComparer<T>.Default.Equals(i, item));
        }

        /// <summary>
        /// Copies the elements of <see cref="Deque{T}"/> to a <see cref="Array"/> 
        /// starting at a particular array index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        /// <exception cref="ArgumentNullException"><paramref name="array"/> was null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than zero.</exception>
        /// <exception cref="ArgumentException">The number of elements in the queue is greater than the available space from the <paramref name="arrayIndex"/> to the end of the destination array.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, $"{arrayIndex} is less than zero");
            }
            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException(
                    $"Number of elements in the {typeof(Deque<T>)} is greater than available space from index to end of destination array");
            }
            int i = arrayIndex;
            foreach (T item in this)
            {
                array[i] = item;
                i++;
            }
        }

        private sealed class DequeNode
        {
            private readonly T _value;

            public DequeNode(T value)
            {
                _value = value;
            }

            public T Value
            {
                get { return _value; }
            }

            public DequeNode Previous
            {
                get;
                set;
            }

            public DequeNode Next
            {
                get;
                set;
            }
        }

        /// <summary>
        /// An implementation of <see cref="IEnumerator{T}"/> that supports 
        /// enumerating a parent <see cref="Deque{T}"/>.
        /// </summary>
        private sealed class DequeEnumerator : IEnumerator<T>
        {
            private readonly Deque<T> _parent;
            private DequeNode _currentNode;
            private T _current = default(T);
            private bool _moveResult = false;

            private readonly long _version;

            private bool _disposed;

            public DequeEnumerator(Deque<T> parent)
            {
                _parent = parent;
                _currentNode = _parent._head;
                _version = _parent._version;
            }

            #region IEnumerator<T> Members
            public T Current
            {
                get
                {
                    if (_disposed)
                    {
                        throw new ObjectDisposedException(GetType().Name);
                    }
                    if (!_moveResult)
                    {
                        throw new InvalidOperationException(
                            "Unable to enumerate Deque. Enumerator is positioned before first item or after last item");
                    }
                    return _current;
                }
            }
            #endregion IEnumerator<T> Members

            #region IEnumerator Members
            public bool MoveNext()
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(GetType().Name);
                }
                if (_version != _parent._version)
                {
                    throw new InvalidOperationException(
                        "The Deque was modified after the enumerator was created");
                }

                if (_currentNode != null)
                {
                    _current = _currentNode.Value;
                    _currentNode = _currentNode.Next;

                    _moveResult = true;
                }
                else
                {
                    _moveResult = false;
                }
                return _moveResult;
            }

            public void Reset()
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(GetType().Name);
                }
                if (_version != _parent._version)
                {
                    throw new InvalidOperationException(
                        "The Deque was modified after the enumerator was created");
                }
                _currentNode = _parent._head;
                _moveResult = false;
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
            #endregion IEnumerator Members

            #region IDisposable Members
            public void Dispose()
            {
                _disposed = true;
            }
            #endregion IDisposable Members
        }
    }
}
