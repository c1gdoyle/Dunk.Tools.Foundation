using System.Threading;

namespace Dunk.Tools.Foundation.Threading
{
    /// <summary>
    /// Provides a lock free atomic wrapper over a <see cref="long"/> value.
    /// </summary>
    /// <remarks>
    /// Equivalent of Java https://docs.oracle.com/javase/8/docs/api/java/util/concurrent/atomic/AtomicLong.html
    /// </remarks>
    public class AtomicInt64
    {
        private long _value;

        /// <summary>
        /// Initialises a new default instance of <see cref="AtomicInt64"/> with 
        /// an underlying value of 0.
        /// </summary>
        public AtomicInt64()
            : this(0)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="AtomicInt64"/> with a
        /// specified long.
        /// </summary>
        /// <param name="value">The underlying long value.</param>
        public AtomicInt64(long value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the underlying long value.
        /// </summary>
        /// <returns>
        /// The underlying value.
        /// </returns>
        public long Get()
        {
            return _value;
        }

        /// <summary>
        /// Atomically sets the underlying long to a new 
        /// specified value.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void Set(long value)
        {
            Interlocked.Exchange(ref _value, value);
        }

        /// <summary>
        /// Atomically sets the underlying long to a new 
        /// specified value and returns original value.
        /// </summary>
        /// <param name="value">The new value.</param>
        /// <returns>
        /// The original value.
        /// </returns>
        public long GetAndSet(long value)
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
        public bool CompareAndSet(long expected, long result)
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
        public long PostIncrement()
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
        public long PostDecrement()
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
        public long PreIncrement()
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
        public long PreDecrement()
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
        public long GetAndAdd(long delta)
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
        public long AddAndGet(int delta)
        {
            while (true)
            {
                long current = Get();
                long next = current + delta;
                if (CompareAndSet(current, next))
                {
                    return current;
                }
            }
        }

        /// <summary>
        /// Implicitly converts a <see cref="AtomicInt64"/> instance into a 
        /// <see cref="long"/> value.
        /// </summary>
        /// <param name="atomicInt64">The Atomic-Int64 instance.</param>
        public static implicit operator long(AtomicInt64 atomicInt64)
        {
            return atomicInt64.Get();
        }
    }
}
