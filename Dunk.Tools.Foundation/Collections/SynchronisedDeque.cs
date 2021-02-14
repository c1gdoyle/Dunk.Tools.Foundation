using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// A double-ended queue for which elements can be added or removed from either 
    /// the front(head) or back(tail) and provides thread-safe opeartions.
    /// </summary>
    /// <typeparam name="T">The type of items stored in the Deque.</typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public class SynchronisedDeque<T> : IDeque<T>, ICollection, IEnumerable<T>
    {
        private readonly object _sync = new object();
        private readonly Deque<T> _deque;

        /// <summary>
        /// Initialises a new default instance of <see cref="SynchronisedDeque{T}"/>.
        /// </summary>
        public SynchronisedDeque()
        {
            _deque = new Deque<T>();
        }

        /// <summary>
        /// Initialises a new instance of <see cref="Deque{T}"/> that contains 
        /// elements copied from the specified.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the Dequeue.</param>
        public SynchronisedDeque(IEnumerable<T> collection)
        {
            _deque = new Deque<T>(collection);
        }

        /// <summary>
        /// Tries to return an object from the front of the <see cref="SynchronisedDeque{T}"/>.
        /// </summary>
        /// <param name="result">When this method returns if the opeartion was successful the result contains the object from the front of the dequeue; otherwise value is unspecified.</param>
        /// <returns>
        /// <c>true</c> if an element was returned from the front of the Deque; otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method provides an atomic and thread-safe version of <see cref="IDeque{T}.PeekAtItemFromFront"/>.
        /// </remarks>
        public bool TryPeekAtItemFromFront(out T result)
        {
            lock (_sync)
            {
                if (!_deque.IsEmpty)
                {
                    result = _deque.PeekAtItemFromFront();
                    return true;
                }
                result = default(T);
                return false;
            }
        }

        /// <summary>
        /// Tries to return an object from the back of the <see cref="SynchronisedDeque{T}"/>.
        /// </summary>
        /// <param name="result">When this method returns if the opeartion was successful the result contains the object from the back of the dequeue; otherwise value is unspecified.</param>
        /// <returns>
        /// <c>true</c> if an element was returned from the back of the Deque; otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method provides an atomic and thread-safe version of <see cref="IDeque{T}.PeekAtItemFromBack"/>.
        /// </remarks>
        public bool TryPeekAtItemFromBack(out T result)
        {
            lock (_sync)
            {
                if (!_deque.IsEmpty)
                {
                    result = _deque.PeekAtItemFromBack();
                    return true;
                }
                result = default(T);
                return false;
            }
        }

        /// <summary>
        /// Tries to remove and return an object from the front of the <see cref="SynchronisedDeque{T}"/>.
        /// </summary>
        /// <param name="result">When this method returns if the opeartion was successful the result contains the object from the front of the dequeue; otherwise value is unspecified.</param>
        /// <returns>
        /// <c>true</c> if an element was returned from the front of the Deque; otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method provides an atomic and thread-safe version of <see cref="IDeque{T}.DequeueItemFromFront"/>.
        /// </remarks>
        public bool TryDequeueAtItemFromFront(out T result)
        {
            lock (_sync)
            {
                if (!_deque.IsEmpty)
                {
                    result = _deque.DequeueItemFromFront();
                    return true;
                }
                result = default(T);
                return false;
            }
        }

        /// <summary>
        /// Tries to remove and return an object from the back of the <see cref="SynchronisedDeque{T}"/>.
        /// </summary>
        /// <param name="result">When this method returns if the opeartion was successful the result contains the object from the back of the dequeue; otherwise value is unspecified.</param>
        /// <returns>
        /// <c>true</c> if an element was returned from the back of the Deque; otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method provides an atomic and thread-safe version of <see cref="IDeque{T}.DequeueItemFromBack"/>.
        /// </remarks>
        public bool TryDequeueAtItemFromBack(out T result)
        {
            lock (_sync)
            {
                if (!_deque.IsEmpty)
                {
                    result = _deque.DequeueItemFromBack();
                    return true;
                }
                result = default(T);
                return false;
            }
        }

        #region IDeque<T> Members
        /// <inheritdoc />
        public void EnqueueItemToFront(T item)
        {
            lock (_sync)
            {
                _deque.EnqueueItemToFront(item);
            }
        }

        /// <inheritdoc />
        public void EnqueueItemToBack(T item)
        {
            lock (_sync)
            {
                _deque.EnqueueItemToBack(item);
            }
        }

        /// <inheritdoc />
        public T DequeueItemFromFront()
        {
            lock (_sync)
            {
                return _deque.DequeueItemFromFront();
            }
        }

        /// <inheritdoc />
        public T DequeueItemFromBack()
        {
            lock (_sync)
            {
                return _deque.DequeueItemFromBack();
            }
        }

        /// <inheritdoc />
        public T PeekAtItemFromFront()
        {
            lock (_sync)
            {
                return _deque.PeekAtItemFromFront();
            }
        }

        /// <inheritdoc />
        public T PeekAtItemFromBack()
        {
            lock (_sync)
            {
                return _deque.PeekAtItemFromBack();
            }
        }
        #endregion IDeque<T> Members

        #region ICollection Members
        /// <summary>
        /// Gets the number of elements contained in the <see cref="Deque{T}"/>.
        /// </summary>
        public int Count
        {
            get
            {
                lock (_sync)
                {
                    return _deque.Count;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="Deque{T}"/> 
        /// is synchronised (thread safe).
        /// </summary>
        bool ICollection.IsSynchronized
        {
            get { return true; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronise access to the <see cref="Deque{T}"/>.
        /// </summary>
        object ICollection.SyncRoot
        {
            get { return _sync; }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            CopyTo((T[])array, index);
        }
        #endregion ICollection Members

        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            lock (_sync)
            {
                return _deque.GetEnumerator();
            }
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
            get
            {
                lock (_sync)
                {
                    return _deque.IsEmpty;
                }
            }
        }

        /// <summary>
        /// Removes all items from the <see cref="Deque{T}"/>.
        /// </summary>
        public void Clear()
        {
            lock (_sync)
            {
                _deque.Clear();
            }
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
            lock (_sync)
            {
                return _deque.Contains(item);
            }
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
            lock (_sync)
            {
                _deque.CopyTo(array, arrayIndex);
            }
        }
    }
}
