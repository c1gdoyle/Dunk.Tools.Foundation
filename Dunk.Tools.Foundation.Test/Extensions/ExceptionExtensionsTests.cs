using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class ExceptionExtensionsTests
    {
        [Test]
        public void LogInnerExceptionRecurrentLogsOriginalException()
        {
            const string exceptedMessage = "Top Exception error";
            string actualMessage = null;

            Exception testEx = new Exception(exceptedMessage);

            Action<Exception> logger = ex => actualMessage = ex.Message;

            testEx.LogInnerExpcetionRecurrent(logger);

            Assert.AreEqual(actualMessage, exceptedMessage);
        }

        [Test]
        public void LogInnerExceptionRecurrentLogsInnerExceptionAfterOriginal()
        {
            const string exceptedMessage = "Top Exception error";
            const string expectedInnerMessage = "Inner Exception error";

            string actualMessage = null;
            string actualInnerMessage = null;

            Exception innerEx = new Exception(expectedInnerMessage);
            Exception testEx = new Exception(exceptedMessage, innerEx);

            Action<Exception> logger = ex =>
            {
                if (actualMessage == null)
                {
                    actualMessage = ex.Message;
                }
                else
                {
                    actualInnerMessage = ex.Message;
                }
            };

            testEx.LogInnerExpcetionRecurrent(logger);

            Assert.AreEqual(exceptedMessage, actualMessage);
            Assert.AreEqual(expectedInnerMessage, actualInnerMessage);
        }

        [Test]
        public void ToStringInnerExceptionRecurrentReturnsEmptyStringIfOriginalExceptionIsNull()
        {
            Exception testEx = null;

            string result = testEx.ToStringInnerExceptionRecurrent();

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void ToStringInnerExceptionRecurrentReturnsOriginalExceptionDetails()
        {
            Exception testEx = new Exception("Top Exception error");

            string result = testEx.ToStringInnerExceptionRecurrent();

            Assert.AreEqual("Exception: System.Exception\nMessage: Top Exception error, \nStack Trace:\n", result);
        }

        [Test]
        public void ToStringInnerExceptionRecurrentReturnsInnerExceptionDetails()
        {
            const string expectedResult =
#if NET472
                "Exception: System.Exception\nMessage: Top Exception error, \nStack Trace:\n" +
                "Exception: System.InvalidOperationException\nMessage: Middle Exception error, \nStack Trace:\n" +
                "Exception: System.ArgumentNullException\nMessage: Inner Exception error\r\nParameter name: param, \nStack Trace:\n";
#elif NETCOREAPP3_1
                "Exception: System.Exception\nMessage: Top Exception error, \nStack Trace:\n" +
                "Exception: System.InvalidOperationException\nMessage: Middle Exception error, \nStack Trace:\n" +
                "Exception: System.ArgumentNullException\nMessage: Inner Exception error (Parameter 'param'), \nStack Trace:\n";
#endif

#pragma warning disable S3928
            ArgumentNullException ex1 = new ArgumentNullException("param", "Inner Exception error");
#pragma warning restore S3928
            InvalidOperationException ex2 = new InvalidOperationException("Middle Exception error", ex1);
            Exception ex3 = new Exception("Top Exception error", ex2);

            string result = ex3.ToStringInnerExceptionRecurrent();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void LogAggregateInnerExceptionsLogsAllInnerExceptions()
        {
            const int expectedCount = 5;

            AggregateException testEx = new AggregateException(new List<Exception>
            {
                new Exception(),
                new Exception(),
                new Exception(),
                new Exception(),
                new Exception()
            });
            int count = 0;

            Action<Exception> logger = ex => count++;

            testEx.LogAllInnerExceptions(logger);

            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void LogAggregateInnerExceptionsFlattensAndLogsAllInnerExceptions()
        {
            const int expectedCount = 5;

            AggregateException testEx = new AggregateException(new List<Exception>
            {
                new AggregateException(new List<Exception>
                {
                    new Exception(),
                    new Exception(),
                    new Exception(),
                    new Exception(),
                    new Exception()
                })
            });
            int count = 0;

            Action<Exception> logger = ex => count++;

            testEx.LogAllInnerExceptions(logger);

            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void GetInnerMostExceptionReturnsInnerException()
        {
            const string expectedMessage = "Inner Exception depth 10";

            Exception innerTestEx = null;
            for (int i = 10; i > 0; i--)
            {
                innerTestEx = innerTestEx != null
                    ? new Exception($"Inner Exception depth {i}", innerTestEx)
                    : new Exception($"Inner Exception depth {i}");
            }

            Exception testEx = new Exception("Top Exception", innerTestEx);

            Exception innerMost = testEx.GetInnerMostInnerException();

            Assert.AreEqual(expectedMessage, innerMost.Message);
        }

        [Test]
        public void GetInnerMostExceptionReturnsOriginalExceptionIfNoInnerException()
        {
            const string expectedMessage = "Top Exception";

            Exception testEx = new Exception(expectedMessage);

            Exception innerMostEx = testEx.GetInnerMostInnerException();

            Assert.AreEqual(expectedMessage, innerMostEx.Message);
        }
    }
}
