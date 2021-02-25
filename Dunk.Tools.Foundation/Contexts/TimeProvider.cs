using System;

namespace Dunk.Tools.Foundation.Contexts
{
    /// <summary>
    /// An Ambient Context pattern that stores the current
    /// Co-ordinated Universal Time (UTC) of the domain.
    /// </summary>
    public abstract class TimeProvider
    {
        private static TimeProvider _current = new DefaultTimeProvider();

        /// <summary>
        /// Gets or sets the current <see cref="TimeProvider"/> of the domain.
        /// </summary>
        public static TimeProvider Current
        {
            get { return _current; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), $"{typeof(TimeProvider).Name} Current cannot be null");
                }
                _current = value;
            }
        }

        /// <summary>
        /// Gets the UTC time of the domain.
        /// </summary>
        public abstract DateTime UtcNow { get; }

        /// <summary>
        /// Resets the domain <see cref="TimeProvider"/> to the default.
        /// </summary>
        public static void ResetToDefault()
        {
            _current = new DefaultTimeProvider();
        }
    }
}
