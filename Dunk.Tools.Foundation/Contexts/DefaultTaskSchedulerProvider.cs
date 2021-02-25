using System.Threading.Tasks;

namespace Dunk.Tools.Foundation.Contexts
{
    /// <summary>
    /// Default implementation of <see cref="TaskSchedulerProvider"/> for the 
    /// application domain
    /// </summary>
    public sealed class DefaultTaskSchedulerProvider : TaskSchedulerProvider
    {
        /// <summary>
        /// Gets the <see cref="TaskScheduler"/> for the domain.
        /// </summary>
        /// <remarks>
        /// In this case the default <see cref="TaskScheduler"/> instance that is provided
        /// by the .NET framework.
        /// </remarks>
        public override TaskScheduler TaskScheduler
        {
            get { return TaskScheduler.Default; }
        }
    }
}
