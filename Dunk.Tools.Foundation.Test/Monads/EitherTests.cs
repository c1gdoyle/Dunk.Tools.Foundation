using System;
using Dunk.Tools.Foundation.Monads;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Monads
{
    [TestFixture]
    public class EitherTests
    {
        [Test]
        public void LeftEitherInitialises()
        {
            int left = 1;

            var leftEither = EitherUtility.CreateLeft<int, string>(left);

            Assert.IsNotNull(leftEither);
        }

        [Test]
        public void RightEitherInitialises()
        {
            double right = 1.1;

            var rightEither = EitherUtility.CreateRight<string, double>(right);

            Assert.IsNotNull(rightEither);
        }

        [Test]
        public void LeftEitherInvokesLeftAction()
        {
            int count = 10;
            int left = 1;

            var leftEither = EitherUtility.CreateLeft<int, int>(left);

            Action<int> leftHandler = i => count = count + 1;
            Action<int> rightHandler = i => count = count - 1;

            leftEither.Check(leftHandler, rightHandler);

            Assert.AreEqual(11, count);
        }

        [Test]
        public void RightEitherInvokesRightAction()
        {
            int count = 10;
            int right = 1;

            var leftEither = EitherUtility.CreateRight<int, int>(right);

            Action<int> leftHandler = i => count = count + 1;
            Action<int> rightHandler = i => count = count - 1;

            leftEither.Check(leftHandler, rightHandler);

            Assert.AreEqual(9, count);
        }

        [Test]
        public void LeftEitherInvokesLeftFunc()
        {
            int count = 10;
            int left = 1;

            var leftEither = EitherUtility.CreateLeft<int, int>(left);

            Func<int, string> leftHandler = i => (count + 1).ToString();
            Func<int, string> rightHandler = i => (count - 1).ToString();

            string result = leftEither.Check(leftHandler, rightHandler);

            Assert.AreEqual("11", result);
        }

        [Test]
        public void RightEitherInvokesRightFunc()
        {
            int count = 10;
            int right = 1;

            var rightEither = EitherUtility.CreateRight<int, int>(right);

            Func<int, string> leftHandler = i => (count + 1).ToString();
            Func<int, string> rightHandler = i => (count - 1).ToString();

            string result = rightEither.Check(leftHandler, rightHandler);

            Assert.AreEqual("9", result);
        }
    }
}
