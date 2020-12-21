using System;
using Dunk.Tools.Foundation.Monads;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Monads
{
    [TestFixture]
    public class TryTests
    {
        [Test]
        public void TrySuccessfulInitialises()
        {
            int successfulValue = 1;

            var trySuccessful = TryUtility.CreateTrySuccessful<int>(successfulValue);

            Assert.IsNotNull(trySuccessful);
        }

        [Test]
        public void TryFailureInitialises()
        {
            Exception error = new Exception();

            var tryFailure = TryUtility.CreateTryFailure<int>(error);

            Assert.IsNotNull(tryFailure);
        }

        [Test]
        public void TrySuccessfulInvokesSuccessAction()
        {
            int count = 10;
            int successfulValue = 1;

            var trySuccessful = TryUtility.CreateTrySuccessful<int>(successfulValue);

            Action<int> successHandler = i => count = count + i;
            Action<Exception> failureHandler = i => count = count - 1;

            trySuccessful.Check(successHandler, failureHandler);
            Assert.AreEqual(11, count);
        }

        [Test]
        public void TryFailureInvokesFailedAction()
        {
            int count = 10;
            Exception error = new Exception();

            var tryFailure = TryUtility.CreateTryFailure<int>(error);

            Action<int> successHandler = i => count = count + i;
            Action<Exception> failureHandler = i => count = count - 1;

            tryFailure.Check(successHandler, failureHandler);
            Assert.AreEqual(9, count);
        }

        [Test]
        public void TrySuccessInvokesSuccessFunc()
        {
            int successfulValue = 1;

            var trySuccessful = TryUtility.CreateTrySuccessful<int>(successfulValue);

            Func<int, string> successHandler = i => i.ToString();
            Func<Exception, string> failureHandler = e => e.Message;

            var output = trySuccessful.Check(successHandler, failureHandler);
            Assert.AreEqual("1", output);
        }

        [Test]
        public void TryFailureInvokesFailedFunc()
        {
            const string errorMessage = "foo";
            Exception error = new Exception(errorMessage);

            var tryFailure = TryUtility.CreateTryFailure<int>(error);

            Func<int, string> successHandler = i => i.ToString();
            Func<Exception, string> failureHandler = e => e.Message;

            var output = tryFailure.Check(successHandler, failureHandler);
            Assert.AreEqual("foo", output);
        }

        [Test]
        public void TrySuccessfulMonadSupportsChaining()
        {
            int originalValue = 10;
            var trySuccessful = TryUtility.CreateTrySuccessful(originalValue);

            var try1 = TryUtility.Chain<int, double>(trySuccessful, i => (double)i / 4); // 2.5
            var try2 = TryUtility.Chain<double, int>(try1, d => (int)(d * 2)); // 5
            var try3 = TryUtility.Chain<int, string>(try2, i => i.ToString()); //"5"

            Func<string, string> successHandler = s => s;
            Func<Exception, string> errorHandler = e => e.Message;

            var output = try3.Check(successHandler, errorHandler);

            Assert.AreEqual("5", output);
        }

        [Test]
        public void TryFailureMonadSupportChaining()
        {
            const string errorMessage = "Something went wrong";
            Exception error = new Exception(errorMessage);

            var tryFailure = TryUtility.CreateTryFailure<int>(error);

            var try1 = TryUtility.Chain<int, double>(tryFailure, i => (double)i / 4);
            var try2 = TryUtility.Chain<double, int>(try1, d => (int)(d * 2));
            var try3 = TryUtility.Chain<int, string>(try2, i => i.ToString());

            Func<string, string> successHandler = s => s;
            Func<Exception, string> errorHandler = e => e.Message;

            var output = try3.Check(successHandler, errorHandler);

            Assert.AreEqual(errorMessage, output);
        }

        [Test]
        public void TrySuccessfulWithNoOutputInitialises()
        {
            var trySuccessful = TryUtility.CreateTrySuccessful();

            Assert.IsNotNull(trySuccessful);
        }

        [Test]
        public void TryFailureWithNotOutputInitialises()
        {
            var tryFailure = TryUtility.CreateTryFailure(new Exception());

            Assert.IsNotNull(tryFailure);
        }

        [Test]
        public void TrySuccessfulWithNotOutputInvokesSuccessAction()
        {
            int count = 10;

            var trySuccessful = TryUtility.CreateTrySuccessful();

            Action successHandler = () => count = count + 1;
            Action<Exception> failureHandler = e => count = count - 1;

            trySuccessful.Check(successHandler, failureHandler);

            Assert.AreEqual(11, count);
        }

        [Test]
        public void TryFailureWithNoOutputInvokesFailedAction()
        {
            int count = 10;

            var tryFailure = TryUtility.CreateTryFailure(new Exception());

            Action successHandler = () => count = count + 1;
            Action<Exception> failureHandler = e => count = count - 1;

            tryFailure.Check(successHandler, failureHandler);

            Assert.AreEqual(9, count);
        }

        [Test]
        public void TrySuccessfulWithNotOutputInvokesSuccessFunc()
        {
            const string expectedOutput = "Success";

            var trySuccessful = TryUtility.CreateTrySuccessful();

            Func<string> successHandler = () => expectedOutput;
            Func<Exception, string> failureHandler = e => e.Message;

            var output = trySuccessful.Check(successHandler, failureHandler);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void TryFailureWithNoOutputInvokesFailedFunc()
        {
            const string expectedOutput = "foo";
            Exception error = new Exception(expectedOutput);

            var tryFailure = TryUtility.CreateTryFailure(error);

            Func<string> successHandler = () => expectedOutput;
            Func<Exception, string> failureHandler = e => e.Message;

            var output = tryFailure.Check(successHandler, failureHandler);

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void TrySuccessfulWithNoOutputSupportsChaining()
        {
            double value = 10;
            var trySuccessful = TryUtility.CreateTrySuccessful();

            var try1 = TryUtility.Chain(trySuccessful, () =>
            {
                value = value / 4;
                return TryUtility.CreateTrySuccessful();
            });
            var try2 = TryUtility.Chain(try1, () =>
            {
                value = value * 2;
                return TryUtility.CreateTrySuccessful();
            });
            var try3 = TryUtility.Chain(try2, () =>
            {
                value = value + 15;
                return TryUtility.CreateTrySuccessful();
            });

            Func<string> successHandler = () => value.ToString();
            Func<Exception, string> failureHandler = ex => ex.Message;

            var output = try3.Check(successHandler, failureHandler);

            Assert.AreEqual("20", output);
        }

        [Test]
        public void TryFailureWithNotOutputSupportsChaining()
        {
            const string errorMessage = "Something went wrong";
            double value = 10;
            var tryFailure = TryUtility.CreateTryFailure(new Exception(errorMessage));

            var try1 = TryUtility.Chain(tryFailure, () =>
            {
                value = value / 4;
                return TryUtility.CreateTrySuccessful();
            });
            var try2 = TryUtility.Chain(try1, () =>
            {
                value = value * 2;
                return TryUtility.CreateTrySuccessful();
            });
            var try3 = TryUtility.Chain(try2, () =>
            {
                value = value + 15;
                return TryUtility.CreateTrySuccessful();
            });

            Func<string> successHandler = () => value.ToString();
            Func<Exception, string> failureHandler = ex => ex.Message;

            var output = try3.Check(successHandler, failureHandler);

            Assert.AreEqual(errorMessage, output);
        }
    }
}
