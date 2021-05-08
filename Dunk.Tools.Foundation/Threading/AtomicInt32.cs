using System.Threading;

namespace Dunk.Tools.Foundation.Threading
{
    /// <summary>
    /// Provides a lock free atomic wrapper over a <see cref="int"/> value.
    /// </summary>
    /// <remarks>
    /// Equivalent of Java https://docs.oracle.com/javase/8/docs/api/java/util/concurrent/atomic/AtomicInteger.html.
    /// Based on https://github.com/mbolt35/CSharp.Atomic.
    /// </remarks>
    public class AtomicInt32 
    {
        private int _value;

        /// <summary>
        /// Initialises a new default instance of <see cref="AtomicInt32"/> with 
        /// an underlying value of 0.
        /// </summary>
        public AtomicInt32()
            : this(0)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="AtomicInt32"/> with a
        /// specified int.
        /// </summary>
        /// <param name="value">The underlying int value.</param>
        public AtomicInt32(int value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets or atomically sets the underlying int value.
        /// </summary>
        public int Value
        {
            get { return _value; }
            set
            {
                Interlocked.Exchange(ref _value, value);
            }
        }

        /// <summary>
        /// Atomically sets the underlying integer to a new 
        /// specified value and returns original value.
        /// </summary>
        /// <param name="value">The new value.</param>
        /// <returns>
        /// The original value.
        /// </returns>
        public int GetAndSet(int value)
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
        public bool CompareAndSet(int expected, int result)
        {
            return Interlocked.CompareExchange(ref _value, result, expected) == expected;
        }

        /// <summary>
        /// Atomically increments the underlying value 
        /// and returns the previous value.
        /// </summary>
        /// <returns>
        /// The new value after incrementing.
        /// </returns>
        public int PostIncrement()
        {
            return AddAndGet(1);
        }

        /// <summary>
        /// Atomically decrements the underlying value 
        /// and returns the previous value.
        /// </summary>
        /// <returns>
        /// The new value after decrementing.
        /// </returns>
        public int PostDecrement()
        {
            return AddAndGet(-1);
        }

        /// <summary>
        /// Atomically increments the underlying value 
        /// and returns the new value.
        /// </summary>
        /// <returns>
        /// The new value after incrementing.
        /// </returns>
        public int PreIncrement()
        {
            return Interlocked.Increment(ref _value);
        }

        /// <summary>
        /// Atomically decrements the underlying value 
        /// and returns the new value.
        /// </summary>
        /// <returns>
        /// The new value after decrementing.
        /// </returns>
        public int PreDecrement()
        {
            return Interlocked.Decrement(ref _value);
        }

        /// <summary>
        /// Atomically adds a specified delta to the underlying value 
        /// and returns the new value.
        /// </summary>
        /// <param name="delta">The delta.</param>
        /// <returns>
        /// The new value.
        /// </returns>
        public int GetAndAdd(int delta)
        {
            return Interlocked.Add(ref _value, delta);
        }

        /// <summary>
        /// Atomically adds a specified delta to the underlying value 
        /// and returns the original value.
        /// </summary>
        /// <param name="delta">The delta.</param>
        /// <returns>
        /// The new value.
        /// </returns>
        public int AddAndGet(int delta)
        {
            while (true)
            {
                int current = _value;
                int next = current + delta;
                if (CompareAndSet(current, next))
                {
                    return current;
                }
            }
        }

        #region Object Overrides
        /// <inheritdoc />
        public override string ToString()
        {
            return _value.ToString();
        }
        #endregion Object Overrides

        /// <summary>
        /// Implicitly converts a <see cref="AtomicInt32"/> instance into a 
        /// <see cref="int"/> value.
        /// </summary>
        /// <param name="atomicInt32">The Atomic-Int32 instance.</param>
        public static implicit operator int(AtomicInt32 atomicInt32)
        {
            return atomicInt32.Value;
        }
    }
}
