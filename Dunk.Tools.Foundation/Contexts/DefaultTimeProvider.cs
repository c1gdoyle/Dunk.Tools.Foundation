using System;

namespace Dunk.Tools.Foundation.Contexts
{
    /// <summary>
    /// Default implementation of <see cref="TimeProvider"/> for the
    /// application domain.
    /// </summary>
    public sealed class DefaultTimeProvider : TimeProvider
    {
        /// <summary>
        /// Gets the UTC time of the domain.
        /// </summary>
        /// <remarks>
        /// In this case the <see cref="DateTime.UtcNow"/>.
        /// </remarks>
        public override DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}
