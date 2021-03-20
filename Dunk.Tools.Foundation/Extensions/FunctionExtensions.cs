using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for a Func or Action delegate.
    /// </summary>
    public static class FunctionExtensions
    {
        /// <summary>
        /// Tries to invoke an unsafe action and handles any exception raised with a 
        /// specified error handler.
        /// </summary>
        /// <param name="unsafeAction">The unsafe action to attempt to invoke</param>
        /// <param name="errorHandler">The error handler that will be invoked if an exception is thrown invoking the delegate.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unsafeAction"/> or <paramref name="errorHandler"/> was null.</exception>
        public static void Try(this Action unsafeAction, Action<Exception> errorHandler)
        {
            unsafeAction.ThrowIfNull(nameof(unsafeAction));
            errorHandler.ThrowIfNull(nameof(errorHandler));

            try
            {
                unsafeAction();
            }
            catch (Exception ex)
            {
                errorHandler(ex);
            }
        }

        /// <summary>
        /// Tries to invoke an unsafe function and handles any exception raised with a 
        /// specified error handler.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="unsafeFunc">The unsafe function to attempt to invoke</param>
        /// <param name="errorHandler">The error handler that will be invoked if an exception is thrown invoking the delegate.</param>
        /// <returns>
        /// If <paramref name="unsafeFunc"/> was invoked successfully returns the result; otherwise returns the result of <paramref name="errorHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="unsafeFunc"/> or <paramref name="errorHandler"/> was null.</exception>
        public static T Try<T>(this Func<T> unsafeFunc, Func<Exception, T> errorHandler)
        {
            unsafeFunc.ThrowIfNull(nameof(unsafeFunc));
            errorHandler.ThrowIfNull(nameof(errorHandler));

            try
            {
                return unsafeFunc();
            }
            catch (Exception ex)
            {
                return errorHandler(ex);
            }
        }

        /// <summary>
        /// Reties an unsafe function with a specified maximum allowed attempts until 
        /// the function succeeds or the retries are exhausted.
        /// </summary>
        /// <typeparam name="T">The type of return value.</typeparam>
        /// <param name="unsafeFunc">The unsafe function to attempt to invoke.</param>
        /// <param name="maxAttempts">The maximum allowed attempts.</param>
        /// <returns>
        /// The result of a successful invocation of <paramref name="unsafeFunc"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="unsafeFunc"/> was null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxAttempts"/> was zero or negative.</exception>
        /// <exception cref="AggregateException"><paramref name="unsafeFunc"/> retries exceeded maximum allowed attempts.</exception>
        public static T Retry<T>(this Func<T> unsafeFunc, int maxAttempts)
        {
            unsafeFunc.ThrowIfNull(nameof(unsafeFunc));

            if (maxAttempts <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(maxAttempts)}",
                    $"{nameof(maxAttempts)} parameter must be greater than zero.");
            }
            List<Exception> errors = new List<Exception>(maxAttempts);

            int attempt = 1;
            while (attempt <= maxAttempts)
            {
                try
                {
                    return unsafeFunc();
                }
                catch (Exception ex)
                {
                    errors.Add(ex);
                    attempt++;
                }
            }
            throw new AggregateException($"Unable to execution function, exceeded maximum attempts {maxAttempts}",
                errors);
        }

        /// <summary>
        /// Reties an unsafe action with a specified maximum allowed attempts until 
        /// the function succeeds or the retries are exhausted.
        /// </summary>
        /// <param name="unsafeAction">The unsafe action to attempt to invoke.</param>
        /// <param name="maxAttempts">The maximum allowed attempts.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unsafeAction"/> was null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxAttempts"/> was zero or negative.</exception>
        /// <exception cref="AggregateException"><paramref name="unsafeAction"/> retries exceeded maximum allowed attempts.</exception>
        public static void Retry(this Action unsafeAction, int maxAttempts)
        {
            unsafeAction.ThrowIfNull(nameof(unsafeAction));

            if (maxAttempts <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(maxAttempts)}", 
                    $"{nameof(maxAttempts)} parameter must be greater than zero.");
            }
            List<Exception> errors = new List<Exception>(maxAttempts);

            int attempt = 1;
            while (attempt <= maxAttempts)
            {
                try
                {
                    unsafeAction();
                    return;
                }
                catch (Exception ex)
                {
                    errors.Add(ex);
                    attempt++;
                }
            }
            throw new AggregateException($"Unable to execution action, exceeded maximum attempts {maxAttempts}",
                errors);
        }

        /// <summary>
        /// Retries an operation every 1000 milli-seconds until the operation completes or exceeds a specified time-out.
        /// </summary>
        /// <param name="func">The operation to attempt, <c>true</c> indicates the operation completed successfully; otherwise <c>false</c>.</param>
        /// <param name="timeout">The maximum time-out to wait for <paramref name="func"/> to complete.</param>
        /// <returns>
        /// <c>true</c> if the operation completed successfully; otherwise returns <c>false</c> if operation timed out.
        /// </returns>
        public static bool RetryUntilCompleteOrTimeout(this Func<bool> func, TimeSpan timeout)
        {
            return RetryUntilCompleteOrTimeout(func, timeout, 1000);
        }

        /// <summary>
        /// Retries an operation every interval in milli-seconds until the operation completes or exceeds a specified time-out.
        /// </summary>
        /// <param name="func">The operation to attempt, <c>true</c> indicates the operation completed successfully; otherwise <c>false</c>.</param>
        /// <param name="timeout">The maximum time-out to wait for <paramref name="func"/> to complete.</param>
        /// <param name="retryInterval">The retry interval in milli-seconds for attempting to complete the operation.</param>
        /// <returns>
        /// <c>true</c> if the operation completed successfully; otherwise returns <c>false</c> if operation timed out.
        /// </returns>
        public static bool RetryUntilCompleteOrTimeout(this Func<bool> func, TimeSpan timeout, int retryInterval)
        {
            if (retryInterval <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(retryInterval),
                    $"{nameof(retryInterval)} must be greater than zero milli-seconds");
            }

            bool complete = func();
            int elapsed = 0;

            while (!complete && elapsed < timeout.TotalMilliseconds)
            {
                System.Threading.Thread.Sleep(retryInterval);
                elapsed += retryInterval;
                complete = func();
            }
            return complete;
        }

        #region Partial Application Extensions
        /// <summary>
        /// Takes a function with 2 parameters and a value for the first parameter and returns a function of 1 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original function.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original function.</typeparam>
        /// <typeparam name="TResult">The return type of the original function.</typeparam>
        /// <param name="function">The original function.</param>
        /// <param name="arg1">The value of the first argument.</param>
        /// <returns>
        /// A function with 1 parameters such that calling the function will assemble the result based on the supplied parameters 
        /// and the value of <paramref name="arg1"/>.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg2, TResult> Partial<TArg1, TArg2, TResult>(this Func<TArg1, TArg2, TResult> function, TArg1 arg1)
        {
            return arg2 => function(arg1, arg2);
        }

        /// <summary>
        /// Takes a function with 3 parameters and a value for the first parameter and returns a function of 2 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original function.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original function.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original function.</typeparam>
        /// <typeparam name="TResult">The return type of the original function.</typeparam>
        /// <param name="function">The original function.</param>
        /// <param name="arg1">The value of the first argument.</param>
        /// <returns>
        /// A function with 2 parameters such that calling the function will assemble the result based on the supplied parameters 
        /// and the value of <paramref name="arg1"/>.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg2, TArg3, TResult> Partial<TArg1, TArg2, TArg3, TResult>(this Func<TArg1, TArg2, TArg3, TResult> function, TArg1 arg1)
        {
            return (arg2, arg3) => function(arg1, arg2, arg3);
        }

        /// <summary>
        /// Takes a function with 4 parameters and a value for the first parameter and returns a function of 3 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original function.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original function.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original function.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth argument of the original function.</typeparam>
        /// <typeparam name="TResult">The return type of the original function.</typeparam>
        /// <param name="function">The original function.</param>
        /// <param name="arg1">The value of the first argument.</param>
        /// <returns>
        /// A function with 3 parameters such that calling the function will assemble the result based on the supplied parameters 
        /// and the value of <paramref name="arg1"/>.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg2, TArg3, TArg4, TResult> Partial<TArg1, TArg2, TArg3, TArg4, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TResult> function, TArg1 arg1)
        {
            return (arg2, arg3, arg4) => function(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// Takes a action with 2 parameters and a value for the first parameter and returns a action of 1 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original action.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original action.</typeparam>
        /// <param name="action">The original action.</param>
        /// <param name="arg1">The value of the first argument.</param>
        /// <returns>
        /// A action with 1 parameters such that calling the action will assemble the result based on the supplied parameters 
        /// and the value of <paramref name="arg1"/>.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Action<TArg2> Partial<TArg1, TArg2>(this Action<TArg1, TArg2> action, TArg1 arg1)
        {
            return arg2 => action(arg1, arg2);
        }

        /// <summary>
        /// Takes a action with 3 parameters and a value for the first parameter and returns a action of 2 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original action.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original action.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original action.</typeparam>
        /// <param name="action">The original action.</param>
        /// <param name="arg1">The value of the first argument.</param>
        /// <returns>
        /// A action with 2 parameters such that calling the action will assemble the result based on the supplied parameters 
        /// and the value of <paramref name="arg1"/>.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Action<TArg2, TArg3> Partial<TArg1, TArg2, TArg3>(this Action<TArg1, TArg2, TArg3> action, TArg1 arg1)
        {
            return (arg2, arg3) => action(arg1, arg2, arg3);
        }

        /// <summary>
        /// Takes a action with 4 parameters and a value for the first parameter and returns a action of 3 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original action.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original action.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original action.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth argument of the original action.</typeparam>
        /// <param name="action">The original action.</param>
        /// <param name="arg1">The value of the first argument.</param>
        /// <returns>
        /// A action with 3 parameters such that calling the action will assemble the result based on the supplied parameters 
        /// and the value of <paramref name="arg1"/>.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Action<TArg2, TArg3, TArg4> Partial<TArg1, TArg2, TArg3, TArg4>(this Action<TArg1, TArg2, TArg3, TArg4> action, TArg1 arg1)
        {
            return (arg2, arg3, arg4) => action(arg1, arg2, arg3, arg4);
        }
        #endregion Partial Application Extensions

        #region Curry Extensions

        /// <summary>
        /// Decomposes a function taking 2 parameters into a sequence of functions taking a single parameter.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original function.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original function.</typeparam>
        /// <typeparam name="TResult">The return type of the original function.</typeparam>
        /// <param name="function">The original function.</param>
        /// <returns>
        /// A decomposed sequence of functions that each take a single parameter.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg1, Func<TArg2, TResult>> Curry<TArg1, TArg2, TResult>(this Func<TArg1, TArg2, TResult> function)
        {
            return a => b => function(a, b);
        }

        /// <summary>
        /// Decomposes a function taking 3 parameters into a sequence of functions taking a single parameter.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original function.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original function.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original function.</typeparam>
        /// <typeparam name="TResult">The return type of the original function.</typeparam>
        /// <param name="function">The original function.</param>
        /// <returns>
        /// A decomposed sequence of functions that each take a single parameter.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg1, Func<TArg2, Func<TArg3, TResult>>> Curry<TArg1, TArg2, TArg3, TResult>(this Func<TArg1, TArg2, TArg3, TResult> function)
        {
            return a => b => c => function(a, b, c);
        }

        /// <summary>
        /// Decomposes a function taking 4 parameters into a sequence of functions taking a single parameter.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original function.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original function.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original function.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth argument of the original function.</typeparam>
        /// <typeparam name="TResult">The return type of the original function.</typeparam>
        /// <param name="function">The original function.</param>
        /// <returns>
        /// A decomposed sequence of functions that each take a single parameter.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg1, Func<TArg2, Func<TArg3, Func<TArg4, TResult>>>> Curry<TArg1, TArg2, TArg3, TArg4, TResult>(this Func<TArg1, TArg2, TArg3, TArg4, TResult> function)
        {
            return a => b => c => d => function(a, b, c, d);
        }

        /// <summary>
        /// Decomposes an action taking 2 parameters into a sequence of functions taking a single parameter.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original function.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original function.</typeparam>
        /// <param name="action">The original action.</param>
        /// <returns>
        /// A decomposed sequence of functions that each take a single parameter.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg1, Action<TArg2>> Curry<TArg1, TArg2>(this Action<TArg1, TArg2> action)
        {
            return a => b => action(a, b);
        }

        /// <summary>
        /// Decomposes an action taking 3 parameters into a sequence of functions taking a single parameter.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original function.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original function.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original function.</typeparam>
        /// <param name="action">The original action.</param>
        /// <returns>
        /// A decomposed sequence of functions that each take a single parameter.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg1, Func<TArg2, Action<TArg3>>> Curry<TArg1, TArg2, TArg3>(this Action<TArg1, TArg2, TArg3> action)
        {
            return a => b => c => action(a, b, c);
        }

        /// <summary>
        /// Decomposes an action taking 4 parameters into a sequence of functions taking a single parameter.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original function.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original function.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original function.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth argument of the original function.</typeparam>
        /// <param name="action">The original action.</param>
        /// <returns>
        /// A decomposed sequence of functions that each take a single parameter.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg1, Func<TArg2, Func<TArg3, Action<TArg4>>>> Curry<TArg1, TArg2, TArg3, TArg4>(this Action<TArg1, TArg2, TArg3, TArg4> action)
        {
            return a => b => c => d => action(a, b, c, d);
        }
        #endregion Curry Extensions

        #region UnCurry Extensions
        /// <summary>
        /// Composes a sequence of 2 functions (each taking a single parameter) into a single function that takes 2 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TResult">The return type of the original sequence of functions.</typeparam>
        /// <param name="function">The original sequence of functions.</param>
        /// <returns>
        /// A single function that takes 2 parameters.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg1, TArg2, TResult> Uncurry<TArg1, TArg2, TResult>(this Func<TArg1, Func<TArg2, TResult>> function)
        {
            return (a, b) => function(a)(b);
        }

        /// <summary>
        /// Composes a sequence of 4 functions (each taking a single parameter) into a single function that takes 3 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TResult">The return type of the original sequence of functions.</typeparam>
        /// <param name="function">The original sequence of functions.</param>
        /// <returns>
        /// A single function that takes 3 parameters.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg1, TArg2, TArg3, TResult> Uncurry<TArg1, TArg2, TArg3, TResult>(this Func<TArg1, Func<TArg2, Func<TArg3, TResult>>> function)
        {
            return (a, b, c) => function(a)(b)(c);
        }

        /// <summary>
        /// Composes a sequence of 4 functions (each taking a single parameter) into a single function that takes 4 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TResult">The return type of the original sequence of functions.</typeparam>
        /// <param name="function">The original sequence of functions.</param>
        /// <returns>
        /// A single function that takes 4 parameters.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Func<TArg1, TArg2, TArg3, TArg4, TResult> Uncurry<TArg1, TArg2, TArg3, TArg4, TResult>(this Func<TArg1, Func<TArg2, Func<TArg3, Func<TArg4, TResult>>>> function)
        {
            return (a, b, c, d) => function(a)(b)(c)(d);
        }

        /// <summary>
        /// Composes a sequence of 2 functions (each taking a single parameter) into a single action that takes 2 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original sequence of functions.</typeparam>
        /// <param name="action">The original sequence of functions.</param>
        /// <returns>
        /// A single action that takes 2 parameters.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Action<TArg1, TArg2> Uncurry<TArg1, TArg2>(this Func<TArg1, Action<TArg2>> action)
        {
            return (a, b) => action(a)(b);
        }

        /// <summary>
        /// Composes a sequence of 3 functions (each taking a single parameter) into a single action that takes 3 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original sequence of functions.</typeparam>
        /// <param name="action">The original sequence of functions.</param>
        /// <returns>
        /// A single action that takes 3 parameters.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Action<TArg1, TArg2, TArg3> Uncurry<TArg1, TArg2, TArg3>(this Func<TArg1, Func<TArg2, Action<TArg3>>> action)
        {
            return (a, b, c) => action(a)(b)(c);
        }

        /// <summary>
        /// Composes a sequence of 4 functions (each taking a single parameter) into a single action that takes 4 parameters.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument of the original sequence of functions.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth argument of the original sequence of functions.</typeparam>
        /// <param name="action">The original sequence of functions.</param>
        /// <returns>
        /// A single action that takes 4 parameters.
        /// </returns>
        /// <remarks>
        /// See Jon Skeet's post
        /// https://codeblog.jonskeet.uk/2012/01/30/currying-vs-partial-function-application
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        public static Action<TArg1, TArg2, TArg3, TArg4> Uncurry<TArg1, TArg2, TArg3, TArg4>(this Func<TArg1, Func<TArg2, Func<TArg3, Action<TArg4>>>> action)
        {
            return (a, b, c, d) => action(a)(b)(c)(d);
        }
        #endregion UnCurry Extensions
    }
}
