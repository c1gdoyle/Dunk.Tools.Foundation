using System;
using System.Text;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods of common <see cref="Exception"/> super classes.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Flattens an <see cref="AggregateException"/> error and logs the inner exceptions that 
        /// caused the original exception.
        /// </summary>
        /// <param name="aEx">The original exception.</param>
        /// <param name="logger">The delegate that logs the inner exception.</param>
        /// <exception cref="ArgumentNullException"><paramref name="aEx"/> or <paramref name="logger"/> parameter was null.</exception>
        public static void LogAllInnerExceptions(this AggregateException aEx, Action<Exception> logger)
        {
            aEx.ThrowIfNull(nameof(aEx), $"Unable to log inner exception. {nameof(aEx)} parameter cannot be null");
            logger.ThrowIfNull(nameof(logger), $"Unable to log inner exception. {nameof(logger)} parameter cannot be null");

            foreach (var ex in aEx.Flatten().InnerExceptions)
            {
                logger(ex);
            }
        }

        /// <summary>
        /// Logs the inner exceptions of the original exception.
        /// </summary>
        /// <param name="ex">The original exception.</param>
        /// <param name="logger">The delegate that logs the inner exception.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ex"/> or <paramref name="logger"/> parameter was null.</exception>
        public static void LogInnerExpcetionRecurrent(this Exception ex, Action<Exception> logger)
        {
            ex.ThrowIfNull(nameof(ex), $"Unable to log inner exception. {nameof(ex)} parameter cannot be null");
            logger.ThrowIfNull(nameof(logger), $"Unable to log inner exception. {nameof(logger)} parameter cannot be null");

            Exception currentException = ex;
            bool isComplete = false;
            while (!isComplete)
            {
                if (currentException != null)
                {
                    logger(currentException);
                }
                if (currentException?.InnerException != null)
                {
                    currentException = currentException.InnerException;
                }
                else
                {
                    isComplete = true;
                }
            }
        }

        /// <summary>
        /// Recurrently converts the inner exceptions of the original exception 
        /// to a <see cref="string"/>.
        /// </summary>
        /// <param name="ex">The original exception.</param>
        /// <returns>
        /// An <see cref="string"/> containing the details of the original exception and 
        /// any inner-exceptions. If the original exception was null just returns an empty string.
        /// </returns>
        /// <remarks>
        /// The format for each exception will be "Exception: {exception.GetType()}\nMessage: {exception.Message}, \nStack Trace:{exception.StackTrace}\n"
        /// </remarks>
        public static string ToStringInnerExceptionRecurrent(this Exception ex)
        {
            if (ex == null)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();

            Exception currentException = ex;
            bool isComplete = false;

            while (!isComplete)
            {
                if (currentException != null)
                {
                    sb.Append(
                        $"Exception: {currentException.GetType()}\nMessage: {currentException.Message}, \nStack Trace:{currentException.StackTrace}\n");
                }

                if (currentException?.InnerException != null)
                {
                    currentException = currentException.InnerException;
                }
                else
                {
                    isComplete = true;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns the inner most exception of the original exception.
        /// </summary>
        /// <param name="ex">The original exception.</param>
        /// <returns>
        /// The inner most exception of the original exception, if the original exception had no Inner-Exception 
        /// just returns the original exception.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="ex"/> parameter was null.</exception>
        public static Exception GetInnerMostInnerException(this Exception ex)
        {
            ex.ThrowIfNull(nameof(ex), $"Unable to get inner-most exception. {nameof(ex)} parameter cannot be null");

            Exception currentException = ex;
            bool isComplete = false;

            while (!isComplete)
            {
                if (currentException.InnerException != null)
                {
                    currentException = currentException.InnerException;
                }
                else
                {
                    isComplete = true;
                }
            }
            return currentException;
        }
    }
}
