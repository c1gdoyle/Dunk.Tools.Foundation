using System;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class FunctionExtensionsTests
    {
        [Test]
        public void TryActionThrowsIfActionIsNull()
        {
            Action action = null;
            Action<Exception> errorHandler = ex => { };

            Assert.Throws<ArgumentNullException>(() => action.Try(errorHandler));
        }

        [Test]
        public void TryActionThrowsIfErrorHandlerIsNull()
        {
            Action action = () => { };
            Action<Exception> errorHandler = null;

            Assert.Throws<ArgumentNullException>(() => action.Try(errorHandler));
        }

        [Test]
        public void TryActionInvokesUnsafeActionIfSuccessful()
        {
            const int expected = 5;

            int result = 0;

            Action action = () => result = 5;
            Action<Exception> errorHandler = ex => result = 1;

            action.Try(errorHandler);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TryActionInvokesErrorHandlerIfUnSuccessful()
        {
            const int expected = 1;

            int result = 0;

            Action action = () => { throw new Exception(); };
            Action<Exception> errorHandler = ex => result = 1;

            action.Try(errorHandler);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TryFuncThrowsIfActionIsNull()
        {
            Func<string> function = null;
            Func<Exception, string> errorHandler = ex => ex.Message;

            Assert.Throws<ArgumentNullException>(() => function.Try(errorHandler));
        }

        [Test]
        public void TryFuncThrowsIfErrorHandlerIsNull()
        {
            Func<string> function = () => "foo";
            Func<Exception, string> errorHandler = null;

            Assert.Throws<ArgumentNullException>(() => function.Try(errorHandler));
        }

        [Test]
        public void TryFuncInvokesUnsafeFuncIfSuccessful()
        {
            const string expected = "foo";

            Func<string> function = () => "foo";
            Func<Exception, string> errorHandler = ex => "bar";

            string result = function.Try(errorHandler);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TryFuncInvokesErrorHandlerIfUnSuccessful()
        {
            const string expected = "bar";

            Func<string> function = () => { throw new Exception(); };
            Func<Exception, string> errorHandler = ex => "bar";

            string result = function.Try(errorHandler);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RetryFuncThrowsIfMaxAttemptsIsZero()
        {
            Func<int> func = () => 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => func.Retry(0));
        }

        [Test]
        public void RetryFuncThrowsIfMaxAttemptsIsNegative()
        {
            Func<int> func = () => 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => func.Retry(-1));
        }

        [Test]
        public void RetryFuncReturnsIfRetrySucceeds()
        {
            int currentAttempts = 0;
            int maxAttempts = 4;

            Func<int> func = () =>
            {
                if (currentAttempts == 3)
                {
                    return 1;
                }
                currentAttempts++;
                throw new Exception();
            };

            int result = func.Retry(maxAttempts);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void RetryFuncThrowsAggregateExceptionIfRetriesExhausted()
        {
            int maxAttempts = 4;

            Func<int> func = () =>
            {
                throw new Exception("Unsafe func failed");
            };

            Assert.Throws<AggregateException>(() => func.Retry(maxAttempts));
        }

        [Test]
        public void RetryFuncThrowsAggregateExceptionContainingAllErrorsIfRetriesExhausted()
        {
            const string errorMessage = "Unsafe func failed";
            const int maxAttempts = 4;

            Func<int> func = () =>
            {
                throw new Exception("Unsafe func failed");
            };

            AggregateException errors = null;
            try
            {
                func.Retry(maxAttempts);
            }
            catch (AggregateException ex)
            {
                errors = ex;
            }
            Assert.AreEqual(4, errors.InnerExceptions.Count);
            Assert.AreEqual(errorMessage, errors.InnerExceptions[0].Message);
        }

        [Test]
        public void RetryActionThrowsIfMaxAttemptsIsZero()
        {
            Action action = () => { };

            Assert.Throws<ArgumentOutOfRangeException>(() => action.Retry(0));
        }

        [Test]
        public void RetryActionThrowsIfMaxAttemptsIsNegative()
        {
            Action action = () => { };

            Assert.Throws<ArgumentOutOfRangeException>(() => action.Retry(-1));
        }

        [Test]
        public void RetryActionReturnsIfRetrySucceeds()
        {
            int currentAttempts = 0;
            int maxAttempts = 4;

            bool operationCompleted = false;

            Action action = () =>
            {
                if (currentAttempts == 3)
                {
                    operationCompleted = true;
                    return;
                }
                currentAttempts++;
                throw new Exception();
            };

            action.Retry(maxAttempts);

            Assert.IsTrue(operationCompleted);
        }

        [Test]
        public void RetryActionThrowsAggregateExceptionIfRetriesExhausted()
        {
            int maxAttempts = 4;

            Action action = () =>
            {
                throw new Exception("Unsafe func failed");
            };

            Assert.Throws<AggregateException>(() => action.Retry(maxAttempts));
        }

        [Test]
        public void RetryActionThrowsAggregateExceptionContainingAllErrorsIfRetriesExhausted()
        {
            const string errorMessage = "Unsafe func failed";
            const int maxAttempts = 4;

            Action action = () =>
            {
                throw new Exception("Unsafe func failed");
            };

            AggregateException errors = null;
            try
            {
                action.Retry(maxAttempts);
            }
            catch (AggregateException ex)
            {
                errors = ex;
            }
            Assert.AreEqual(4, errors.InnerExceptions.Count);
            Assert.AreEqual(errorMessage, errors.InnerExceptions[0].Message);
        }

        [Test]
        public void RetryUntilCompleteReturnsTrueIfOperationCompletes()
        {
            Func<bool> operation = () => true;

            Assert.IsTrue(operation.RetryUntilCompleteOrTimeout(TimeSpan.FromSeconds(10)));
        }

        [Test]
        public void RetryUntilCompleteThrowsIfIntervalIsZero()
        {
            Func<bool> operation = () => true;

            Assert.Throws<ArgumentOutOfRangeException>(() => operation.RetryUntilCompleteOrTimeout(TimeSpan.FromSeconds(10), 0));
        }

        [Test]
        public void RetryUntilCompleteThrowsIfIntervalIsNegative()
        {
            Func<bool> operation = () => true;

            Assert.Throws<ArgumentOutOfRangeException>(() => operation.RetryUntilCompleteOrTimeout(TimeSpan.FromSeconds(10), -1));
        }

        [Test]
        public void RetryUntilCompleteReturnsTrueIfOperationCompletesWithinTimeout()
        {
            int i = 0;
            Func<bool> operation = () =>
            {
                if (i == 5)
                {
                    return true;
                }
                i++;
                return false;
            };
            Assert.IsTrue(operation.RetryUntilCompleteOrTimeout(TimeSpan.FromSeconds(10), 10));
        }

        [Test]
        public void RetryUntilCompleteReturnsFalseIfOperationExceedsTimeout()
        {
            Func<bool> operation = () => false;

            Assert.IsFalse(operation.RetryUntilCompleteOrTimeout(TimeSpan.FromMilliseconds(50), 10));
        }

        [Test]
        public void FuncPartialApplicationAssemblesExpectedResult()
        {
            Func<int, int, int, int, string> originalFunc = (a, b, c, d) =>
            {
                int x = (a + b);
                int y = (c - d);
                int z = x * y;
                return z.ToString();
            };

            Func<int, int, int, string> partialFunc1 = originalFunc.Partial(1);
            Func<int, int, string> partialFunc2 = partialFunc1.Partial(2);
            Func<int, string> partialFunc3 = partialFunc2.Partial(6);

            string result = partialFunc3(3);

            Assert.AreEqual("9", result);
        }

        [Test]
        public void ActionPartialApplicationAssemblesExpectedResult()
        {
            string result = null;

            Action<int, int, int, int> originalAction = (a, b, c, d) =>
            {
                int x = (a + b);
                int y = (c - d);
                int z = x * y;
                result = z.ToString();
            };

            Action<int, int, int> partialAction1 = originalAction.Partial(1);
            Action<int, int> partialAction2 = partialAction1.Partial(2);
            Action<int> partialAction3 = partialAction2.Partial(6);

            partialAction3(3);

            Assert.AreEqual("9", result);
        }

        [Test]
        public void FuncCurryAssemblesExpectedResult()
        {
            Func<int, int, int, int, string> originalFunc = (a, b, c, d) =>
            {
                int x = (a + b);
                int y = (c - d);
                int z = x * y;
                return z.ToString();
            };

            var curryFunc = originalFunc.Curry();

            string result = curryFunc(1)(2)(6)(3);

            Assert.AreEqual("9", result);
        }

        [Test]
        public void FuncUncurryAssemblesExpectedResultForTwoParameters()
        {
            Func<int, int, string> originalFunc = (a, b) =>
            {
                int x = (a + b);
                return x.ToString();
            };

            var curryFunc = originalFunc.Curry();
            var uncurryFunc = curryFunc.Uncurry();

            string result = uncurryFunc(1, 2);

            Assert.AreEqual("3", result);
        }

        [Test]
        public void FuncUncurryAssemblesExpectedResultForThreeParameters()
        {
            Func<int, int, int, string> originalFunc = (a, b, c) =>
            {
                int x = (a + b);
                int y = x * c;
                return y.ToString();
            };

            var curryFunc = originalFunc.Curry();
            var uncurryFunc = curryFunc.Uncurry();

            string result = uncurryFunc(1, 2, 3);

            Assert.AreEqual("9", result);
        }

        [Test]
        public void FuncUncurryAssemblesExpectedResultForFourParameters()
        {
            Func<int, int, int, int, string> originalFunc = (a, b, c, d) =>
            {
                int x = (a + b);
                int y = c - d;
                int z = x * y;
                return z.ToString();
            };

            var curryFunc = originalFunc.Curry();
            var uncurryFunc = curryFunc.Uncurry();

            string result = uncurryFunc(1, 2, 6, 3);

            Assert.AreEqual("9", result);
        }

        [Test]
        public void ActionCurryAssemblesExpectedResult()
        {
            string result = null;

            Action<int, int, int, int> originalAction = (a, b, c, d) =>
            {
                int x = (a + b);
                int y = (c - d);
                int z = x * y;
                result = z.ToString();
            };

            var curryAction = originalAction.Curry();

            curryAction(1)(2)(6)(3);

            Assert.AreEqual("9", result);
        }

        [Test]
        public void ActionUncurryAssemblesExpectedResultForTwoParameters()
        {
            string result = null;

            Action<int, int> originalAction = (a, b) =>
            {
                int x = (a + b);
                result = x.ToString();
            };

            var curryAction = originalAction.Curry();
            var uncurryAction = curryAction.Uncurry();

            uncurryAction(1, 2);

            Assert.AreEqual("3", result);
        }

        [Test]
        public void ActionUncurryAssemblesExpectedResultForThreeParameters()
        {
            string result = null;

            Action<int, int, int> originalAction = (a, b, c) =>
            {
                int x = (a + b);
                int y = x * c;
                result = y.ToString();
            };

            var curryAction = originalAction.Curry();
            var uncurryAction = curryAction.Uncurry();

            uncurryAction(1, 2, 3);

            Assert.AreEqual("9", result);
        }

        [Test]
        public void ActionUncurryAssemblesExpectedResultForFourParameters()
        {
            string result = null;

            Action<int, int, int, int> originalAction = (a, b, c, d) =>
            {
                int x = (a + b);
                int y = c - d;
                int z = x * y;
                result = z.ToString();
            };

            var curryAction = originalAction.Curry();
            var uncurryAction = curryAction.Uncurry();

            uncurryAction(1, 2, 6, 3);

            Assert.AreEqual("9", result);
        }
    }
}
