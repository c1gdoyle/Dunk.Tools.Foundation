using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Comparers
{
    /// <summary>
    /// An implementation of <see cref="IComparer{T}"/> that compares the
    /// current item of 2 <see cref="IEnumerator{T}"/>'s.
    /// </summary>
    /// <typeparam name="T">The type of items being compared.</typeparam>
    internal sealed class EnumeratorComparer<T> : IComparer<IEnumerator<T>>
    {
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// Initialises a new instance of <see cref="EnumeratorComparer{T}"/> with a specified
        /// comparer.
        /// </summary>
        /// <param name="comparer">The comparer, if null the default is used.</param>
        public EnumeratorComparer(IComparer<T> comparer)
        {
            _comparer = comparer ?? Comparer<T>.Default;
        }

        #region Comparer<T> Members
        /// <inheritdoc />
        public int Compare(IEnumerator<T> x, IEnumerator<T> y)
        {
            var result = _comparer.Compare(x.Current, y.Current);
            return result;
        }
        #endregion Comparer<T> Members
    }
}
