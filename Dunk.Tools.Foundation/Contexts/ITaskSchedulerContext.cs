using System.Threading.Tasks;

namespace Dunk.Tools.Foundation.Contexts
{
    /// <summary>
    /// Defines a context pattern for accessing a <see cref="TaskScheduler"/>.
    /// </summary>
    public interface ITaskSchedulerContext
    {
        /// <summary>
        /// Gets the <see cref="TaskScheduler"/> associated with the currently executing 
        /// task.
        /// </summary>
        TaskScheduler Current { get; }

        /// <summary>
        /// Gets the default <see cref="TaskScheduler"/> instance that is provided 
        /// by the .NET Framework.
        /// </summary>
        TaskScheduler Default { get; }
    }
}
