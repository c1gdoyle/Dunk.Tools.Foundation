using System.Threading;

namespace Dunk.Tools.Foundation.Threading
{
    /// <summary>
    /// Provides a lock free atomic wrapper over a <see cref="bool"/> value.
    /// </summary>
    /// <remarks>
    /// Equivalent of Java https://docs.oracle.com/javase/8/docs/api/java/util/concurrent/atomic/AtomicBoolean.html
    /// </remarks>
    public class AtomicBoolean
    {
        private int _value;

        /// <summary>
        /// Initialises a new default instance of <see cref="AtomicBoolean"/> with 
        /// an underlying value of <c>false</c>.
        /// </summary>
        public AtomicBoolean()
            : this(false)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="AtomicBoolean"/> with a 
        /// specified bool.
        /// </summary>
        /// <param name="value">The underlying bool value.</param>
        public AtomicBoolean(bool value)
        {
            _value = value ? 1 : 0;
        }

        /// <summary>
        /// Gets the underlying bool value.
        /// </summary>
        /// <returns>
        /// The underlying value.
        /// </returns>
        public bool Get()
        {
            return _value != 0;
        }

        /// <summary>
        /// Atomically sets the underlying bool to a new 
        /// specified value.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void Set(bool value)
        {
            Interlocked.Exchange(ref _value, value ? 1 : 0);
        }

        /// <summary>
        /// Atomically sets the underlying bool to a new 
        /// specified value and returns original value.
        /// </summary>
        /// <param name="value">The new value.</param>
        /// <returns>
        /// The original value.
        /// </returns>
        public bool GetAndSet(bool value)
        {
            return Interlocked.Exchange(ref _value, value ? 1 : 0) != 0;
        }

        /// <summary>
        /// Atomically sets the value to the given updated value if the current value equals the expected value.
        /// </summary>
        /// <param name="expected">The value to compare against.</param>
        /// <param name="result">The value to set if the value is equal to the <paramref name="expected"/>.</param>
        /// <returns>
        /// <c>true</c> if the comparison and set was successful. A <c>false</c> indicates the comparison failed.
        /// </returns>
        public bool CompareAndSet(bool expected, bool result)
        {
            int e = expected ? 1 : 0;
            int r = result ? 1 : 0;
            return Interlocked.CompareExchange(ref _value, r, e) == e;
        }

        #region Object Overrides
        /// <inheritdoc />
        public override string ToString()
        {
            return (_value == 1)
                .ToString();
        }
        #endregion Object Overrides

        /// <summary>
        /// Implicitly converts a <see cref="AtomicBoolean"/> instance into a 
        /// <see cref="bool"/> value.
        /// </summary>
        /// <param name="atomicBoolean">The Atomic-Boolean instance.</param>
        public static implicit operator bool(AtomicBoolean atomicBoolean)
        {
            return atomicBoolean.Get();
        }
    }
}
