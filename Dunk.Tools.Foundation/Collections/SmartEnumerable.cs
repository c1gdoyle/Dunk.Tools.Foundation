using System;
using System.Collections.Generic;
using System.Collections;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// A type of <see cref="IEnumerable{T}"/> that allows the 
    /// iterating code to detect the first and last entries simply.
    /// </summary>
    /// <remarks>
    /// Based on Jon Skeet post https://codeblog.jonskeet.uk/2007/07/27/smart-enumerations/
    /// </remarks>
    public class SmartEnumerable<T> : IEnumerable<SmartEnumerable<T>.Entry>
    {
        private readonly IEnumerable<T> _innerEnumerable;

        /// <summary>
        /// Initialises a new instance of <see cref="SmartEnumerable{T}"/> using a specified
        /// inner collection.
        /// </summary>
        /// <param name="enumerable">The collection to enumerate.</param>
        /// <exception cref="ArgumentNullException"><paramref name="enumerable"/> parameter cannot be null.</exception> 
        public SmartEnumerable(IEnumerable<T> enumerable)
        {
            if(enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable), 
                    $"Unable to initialise Smart-Enumerable, {nameof(enumerable)} parameter cannot be null");
            }
            _innerEnumerable = enumerable;
        }

        #region IEnumerable<SmartEnumerable<T>.Entry> Members
        /// <summary>
        /// Returns an enumeration of <see cref="Entry"/> objects.
        /// </summary>
        /// <returns>
        /// A <see cref="IEnumerator{T}"/> of <see cref="Entry"/> objects, each of which
        /// knows whether it is the first or last entry of the enumerable.
        /// </returns>
        public IEnumerator<Entry> GetEnumerator()
        {
            using (IEnumerator<T> e = _innerEnumerable.GetEnumerator())
            {
                if (!e.MoveNext())
                {
                    yield break;
                }

                bool isFirst = true;
                bool isLast = false;
                int index = 0;
                while (!isLast)
                {
                    T current = e.Current;
                    isLast = !e.MoveNext();
                    yield return new Entry(isFirst, isLast, current, index++);
                    isFirst = false;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion IEnumerable<SmartEnumerable<T>.Entry> Members

        /// <summary>
        /// Represents each entry returned within a collection,
        /// containing the value, whether it is the first and/or last
        /// entry in the collection.
        /// </summary>
        public class Entry
        {
            private readonly bool _isFirst;
            private readonly bool _isLast;
            private readonly T _value;
            private readonly int _index;

            internal Entry(bool isFirst, bool isLast, T value, int index)
            {
                _isFirst = isFirst;
                _isLast = isLast;
                _value = value;
                _index = index;
            }

            /// <summary>
            /// Gets the value of this entry
            /// </summary>
            public T Value { get { return _value; } }

            /// <summary>
            /// Gets whether or not this entry is first in the collection.
            /// </summary>
            public bool IsFirst { get { return _isFirst; } }

            /// <summary>
            /// Gets whether or not this entry is last in the collection.
            /// </summary>
            public bool IsLast { get { return _isLast; } }

            /// <summary>
            /// Gets the 0 based index of this entry.
            /// </summary>
            /// <remarks>
            /// How many entries have been returned before this one.
            /// </remarks>
            public int Index { get { return _index; } }
        }
    }
}
