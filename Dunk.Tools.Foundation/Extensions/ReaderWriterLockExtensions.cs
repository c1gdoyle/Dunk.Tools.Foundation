using System;
using System.Threading;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for a <see cref="ReaderWriterLockSlim"/> instance.
    /// </summary>
    public static class ReaderWriterLockExtensions
    {
        /// <summary>
        /// Enters the lock in read mode and returns an <see cref="IDisposable"/> wrapper.
        /// </summary>
        /// <param name="sync">The lock.</param>
        /// <returns>
        /// An <see cref="IDisposable"/> wrapper over the lock, when dispposed the underlying lock will
        /// exit read mode.
        /// </returns>
        internal static IDisposable ReadLock(this ReaderWriterLockSlim sync)
        {
            sync.ThrowIfNull(nameof(sync));
            return new ReadLockToken(sync);
        }

        /// <summary>
        /// Enters the lock in write mode and returns an <see cref="IDisposable"/> wrapper.
        /// </summary>
        /// <param name="sync">The lock.</param>
        /// <returns>
        /// An <see cref="IDisposable"/> wrapper over the lock, when dispposed the underlying lock will
        /// exit write mode.
        /// </returns>
        internal static IDisposable WriteLock(this ReaderWriterLockSlim sync)
        {
            sync.ThrowIfNull(nameof(sync));
            return new WriteLockToken(sync);
        }

        /// <summary>
        /// Enters the lock in upgradeable mode and returns an <see cref="IDisposable"/> wrapper.
        /// </summary>
        /// <param name="sync">The lock.</param>
        /// <returns>
        /// An <see cref="IDisposable"/> wrapper over the lock, when dispposed the underlying lock will
        /// exit upgradeable mode.
        /// </returns>
        internal static IDisposable UpgradeReadLock(this ReaderWriterLockSlim sync)
        {
            sync.ThrowIfNull(nameof(sync));
            return new UpgradeableReadLockToken(sync);
        }

        private sealed class ReadLockToken : IDisposable
        {
            private readonly ReaderWriterLockSlim _sync;

            public ReadLockToken(ReaderWriterLockSlim sync)
            {
                _sync = sync;
                sync.EnterReadLock();
            }

            public void Dispose()
            {
                if (_sync != null)
                {
                    _sync.ExitReadLock();
                }
            }
        }

        private sealed class WriteLockToken : IDisposable
        {
            private readonly ReaderWriterLockSlim _sync;

            public WriteLockToken(ReaderWriterLockSlim sync)
            {
                _sync = sync;
                sync.EnterWriteLock();
            }

            public void Dispose()
            {
                if (_sync != null)
                {
                    _sync.ExitWriteLock();
                }
            }
        }

        private sealed class UpgradeableReadLockToken : IDisposable
        {
            private readonly ReaderWriterLockSlim _sync;

            public UpgradeableReadLockToken(ReaderWriterLockSlim sync)
            {
                _sync = sync;
                sync.EnterUpgradeableReadLock();
            }

            public void Dispose()
            {
                if (_sync != null)
                {
                    _sync.ExitUpgradeableReadLock();
                }
            }
        }
    }
}
