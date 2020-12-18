using System;
using Dunk.Tools.Foundation.Extensions;
using Moq;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class DisposeExtensionsTests
    {
        [Test]
        public void TryDisposeThrowsIfDisposableIsNull()
        {
            IDisposable disposable = null;

            Assert.Throws<ArgumentNullException>(() => disposable.TryDispose());
        }

        [Test]
        public void TryDisposeInvokesDisposeOnSafeObject()
        {
            bool disposed = false;

            Mock<IDisposable> disposable = new Mock<IDisposable>();
            disposable.Setup(d => d.Dispose())
                .Callback(() => disposed = true);

            Assert.DoesNotThrow(() => disposable.Object.TryDispose());
            Assert.IsTrue(disposed);
        }

        [Test]
        public void TryDisposeInvokesDisposeOnUnsafeObjectAndDoesNotRethrowException()
        {
            bool disposed = false;

            Mock<IDisposable> disposable = new Mock<IDisposable>();
            disposable.Setup(d => d.Dispose())
                .Callback(() => disposed = true)
                .Throws(new InvalidOperationException());

            Assert.DoesNotThrow(() => disposable.Object.TryDispose(false));
            Assert.IsTrue(disposed);
        }

        [Test]
        public void TryDisposeInvokesDisposeOnUnsafeObjectAndDoesRethrowException()
        {
            bool disposed = false;

            Mock<IDisposable> disposable = new Mock<IDisposable>();
            disposable.Setup(d => d.Dispose())
                .Callback(() => disposed = true)
                .Throws(new InvalidOperationException());

            Assert.Throws<InvalidOperationException>(() => disposable.Object.TryDispose(true));
            Assert.IsTrue(disposed);
        }

        [Test]
        public void TryDisposeWithErrorHandlerThrowsIfDisposableIsNull()
        {
            IDisposable disposable = null;

            Assert.Throws<ArgumentNullException>(() => disposable.TryDispose(errorHandler => { }));
        }

        [Test]
        public void TryDisposeWithErrorHandlerThrowsIfErrorHandlerIsNull()
        {
            Mock<IDisposable> disposable = new Mock<IDisposable>();

            Assert.Throws<ArgumentNullException>(() => disposable.Object.TryDispose(null as Action<Exception>));
        }

        [Test]
        public void TryDisposeWithErrorHandlerInvokesDisposeOnSafeObject()
        {
            bool disposed = false;

            Mock<IDisposable> disposable = new Mock<IDisposable>();
            disposable.Setup(d => d.Dispose())
                .Callback(() => disposed = true);

            disposable.Object.TryDispose(e => { });
            
            Assert.IsTrue(disposed);
        }

        [Test]
        public void TryDisposeWithErrorHandlerDoesNotInvokeErrorHandlerForSafeObject()
        {
            bool disposed = false;
            bool errorHandled = false;

            Mock<IDisposable> disposable = new Mock<IDisposable>();
            disposable.Setup(d => d.Dispose())
                .Callback(() => disposed = true);

            disposable.Object.TryDispose(e => { errorHandled = true; });

            Assert.IsFalse(errorHandled);
            Assert.IsTrue(disposed);
        }

        [Test]
        public void TryDisposeWithErrorHandlerDoesInvokeErrorHandlerIfExceptionIsThrownForUnsafeObject()
        {
            bool disposed = false;
            bool errorHandled = false;

            Mock<IDisposable> disposable = new Mock<IDisposable>();
            disposable.Setup(d => d.Dispose())
                .Callback(() => disposed = true)
                .Throws(new InvalidOperationException());

            disposable.Object.TryDispose(e => { errorHandled = true; });

            Assert.IsTrue(errorHandled);
            Assert.IsTrue(disposed);
        }

        [Test]
        public void TryDisposeWithErrorHandlerDoesInvokeErrorHandlerIfExceptionIsThrownForUnsafeObjectAndDoesNotRethrowException()
        {
            bool errorHandled = false;

            Mock<IDisposable> disposable = new Mock<IDisposable>();
            disposable.Setup(d => d.Dispose())
                .Throws(new InvalidOperationException());

            Assert.DoesNotThrow(() => disposable.Object.TryDispose(e => { errorHandled = true; }, false));
            Assert.IsTrue(errorHandled);
        }

        [Test]
        public void TryDisposeWithErrorHandlerDoesInvokeErrorHandlerIfExceptionIsThrownForUnsafeObjectAndDoesRethrowException()
        {
            bool errorHandled = false;

            Mock<IDisposable> disposable = new Mock<IDisposable>();
            disposable.Setup(d => d.Dispose())
                .Throws(new InvalidOperationException());

            Assert.Throws<InvalidOperationException>(() => disposable.Object.TryDispose(e => { errorHandled = true; }, true));
            Assert.IsTrue(errorHandled);
        }
    }
}
