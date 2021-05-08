using System.Threading;

namespace Dunk.Tools.Foundation.Threading
{
    /// <summary>
    /// Provides a lock free atomic wrapper over a <typeparamref name="T"/> reference.
    /// </summary>
    /// <remarks>
    /// Equivalent of Java https://docs.oracle.com/javase/8/docs/api/java/util/concurrent/atomic/AtomicReference.html
    /// </remarks>
    public class AtomicObject<T>
        where T : class
    {
        private T _value;

        /// <summary>
        /// Initialises a new default instance of <see cref="AtomicObject{T}"/> with 
        /// an underlying value of <c>null</c>.
        /// </summary>
        public AtomicObject()
            : this(null)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="AtomicObject{T}"/> with a 
        /// specified refermce.
        /// </summary>
        /// <param name="value">The underlying reference object.</param>
        public AtomicObject(T value)
        {
            _value = value;
        }


        /// <summary>
        /// Gets the underlying reference object.
        /// </summary>
        /// <returns>
        /// The underlying reference object.
        /// </returns>
        public T Get()
        {
            return _value;
        }

        /// <summary>
        /// Atomically sets the underlying reference to a new 
        /// specified value.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void Set(T value)
        {
            Interlocked.Exchange(ref _value, value);
        }

        /// <summary>
        /// Atomically sets the underlying reference to a new 
        /// specified value and returns original value.
        /// </summary>
        /// <param name="value">The new value.</param>
        /// <returns>
        /// The original value.
        /// </returns>
        public T GetAndSet(T value)
        {
            return Interlocked.Exchange(ref _value, value);
        }

        /// <summary>
        /// Atomically sets the value to the given updated value if the current value equals the expected value.
        /// </summary>
        /// <param name="expected">The value to compare against.</param>
        /// <param name="result">The value to set if the value is equal to the <paramref name="expected"/>.</param>
        /// <returns>
        /// <c>true</c> if the comparison and set was successful. A <c>false</c> indicates the comparison failed.
        /// </returns>
        public bool CompareAndSet(T expected, T result)
        {
            return Interlocked.CompareExchange(ref _value, result, expected) == expected;
        }

        #region Object Overrides
        /// <inheritdoc />
        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
        #endregion Object Overrides

        /// <summary>
        /// Implicitly converts a <see cref="AtomicObject{T}"/> instance into a 
        /// <typeparamref name="T"/> value.
        /// </summary>
        /// <param name="atomicObject">The Atomic-Object instance.</param>
        public static implicit operator T(AtomicObject<T> atomicObject)
        {
            return atomicObject.Get();
        }
    }
}
