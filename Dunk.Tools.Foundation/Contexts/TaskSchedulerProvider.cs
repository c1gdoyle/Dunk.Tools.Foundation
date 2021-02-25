using System;
using System.Threading.Tasks;

namespace Dunk.Tools.Foundation.Contexts
{
    /// <summary>
    /// An Ambient Context pattern that stores the current default
    /// <see cref="TaskScheduler"/> instance of the domain.
    /// </summary>
    public abstract class TaskSchedulerProvider
    {
        private static TaskSchedulerProvider _current = new DefaultTaskSchedulerProvider();

        /// <summary>
        /// Gets or sets the current <see cref="TaskSchedulerProvider"/> of the domain.
        /// </summary>
        public static TaskSchedulerProvider Current
        {
            get { return _current; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), $"{typeof(TaskSchedulerProvider).Name} Current cannot be null");
                }
                _current = value;
            }
        }

        /// <summary>
        /// Gets the default <see cref="TaskScheduler"/> for the domain.
        /// </summary>
        public abstract TaskScheduler TaskScheduler { get; }

        /// <summary>
        /// Resets the domain <see cref="TaskSchedulerProvider"/> to the default.
        /// </summary>
        public static void ResetToDefault()
        {
            _current = new DefaultTaskSchedulerProvider();
        }
    }
}
