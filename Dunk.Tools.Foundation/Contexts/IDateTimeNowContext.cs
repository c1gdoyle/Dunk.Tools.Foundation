using System;

namespace Dunk.Tools.Foundation.Contexts
{
    /// <summary>
    /// Defines a context pattern for accessing DateTime now.
    /// </summary>
    public interface IDateTimeNowContext
    {
        /// <summary>
        /// Gets a <see cref="DateTime"/> object that is set to the current date and time on this 
        /// computer, expressed as the local time.
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        DateTime Today { get; }

        /// <summary>
        /// Gets a <see cref="DateTime"/> object that is set to the current date and time on this 
        /// computer, expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        DateTime UtcNow { get; }
    }
}
