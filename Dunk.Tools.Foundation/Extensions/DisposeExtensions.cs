using System;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for a <see cref="IDisposable"/>
    /// </summary>
    public static class DisposeExtensions
    {
        /// <summary>
        /// Attempts to dispose unmanaged resources without rethrowing any error.
        /// </summary>
        /// <param name="disposable">The object to dispose unmanaged resources from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="disposable"/> was null.</exception>
        public static void TryDispose(this IDisposable disposable)
        {
            TryDispose(disposable, false);
        }

        /// <summary>
        /// Attempts to dispose unmanaged resources with a <see cref="bool"/> flag indicating whether or 
        /// not to rethrow any error.
        /// </summary>
        /// <param name="disposable">The object to dispose unmanaged resources from.</param>
        /// <param name="throwException">The flag indicating whether or not to rethrow any error.</param>
        /// <exception cref="ArgumentNullException"><paramref name="disposable"/> was null.</exception>
        public static void TryDispose(this IDisposable disposable, bool throwException)
        {
            if(disposable == null)
            {
                throw new ArgumentNullException(nameof(disposable),
                    $"Unable to run Try-Dispose. {nameof(disposable)} parameter was null");
            }

            try
            {
                disposable.Dispose();
            }
            catch
            {
                if (throwException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Attempts to dispose unmanaged resources with a specified error handler delegate for processing 
        /// any exception thrown.
        /// </summary>
        /// <param name="disposable">The object to dispose unmanaged resources from.</param>
        /// <param name="errorHandler">A delegate for processing any exception thrown.</param>
        /// <exception cref="ArgumentNullException"><paramref name="disposable"/> or <paramref name="errorHandler"/> was null.</exception>
        public static void TryDispose(this IDisposable disposable, Action<Exception> errorHandler)
        {
            TryDispose(disposable, errorHandler, false);
        }

        /// <summary>
        /// Attempts to dispose unmanaged resources with a specified error handler delegate for processing 
        /// any exception thrown and a <see cref="bool"/> flag indicating whether or not to rethrow any error.
        /// </summary>
        /// <param name="disposable">The object to dispose unmanaged resources from.</param>
        /// <param name="errorHandler">A delegate for processing any exception thrown.</param>
        /// <param name="throwException">The flag indicating whether or not to rethrow any error.</param>
        /// <exception cref="ArgumentNullException"><paramref name="disposable"/> or <paramref name="errorHandler"/> was null.</exception>
        public static void TryDispose(this IDisposable disposable, Action<Exception> errorHandler, bool throwException)
        {
            if (disposable == null)
            {
                throw new ArgumentNullException(nameof(disposable),
                    $"Unable to run Try-Dispose. {nameof(disposable)} parameter was null");
            }
            if (errorHandler == null)
            {
                throw new ArgumentNullException(nameof(errorHandler),
                    $"Unable to run Try-Dispose. {nameof(errorHandler)} parameter was null");
            }

            try
            {
                disposable.Dispose();
            }
            catch(Exception ex)
            {
                errorHandler(ex);
                if (throwException)
                {
                    throw;
                }
            }
        }
    }
}
