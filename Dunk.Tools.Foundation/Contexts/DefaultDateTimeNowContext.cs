using System;

namespace Dunk.Tools.Foundation.Contexts
{
    /// <summary>
    /// Default implementation of <see cref="IDateTimeNowContext"/>.
    /// </summary>
    public sealed class DefaultDateTimeNowContext : IDateTimeNowContext
    {
        #region IDateTimeNowContext Members
        /// <inheritdoc />
        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        /// <inheritdoc />
        public DateTime Today
        {
            get { return DateTime.Today; }
        }

        /// <inheritdoc />
        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
        #endregion IDateTimeNowContext Members
    }
}
