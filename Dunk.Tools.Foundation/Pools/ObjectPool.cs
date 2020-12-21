using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Pools
{
    /// <summary>
    /// An implementation of <see cref="IObjectPool{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of object that will be managed by the pool.</typeparam>
    public class ObjectPool<T> : IObjectPool<T>
    {
        private readonly ConcurrentQueue<T> _objects;
        private readonly Func<T> _objectGenerator;

        /// <summary>
        /// Intialises a new instance of <see cref="ObjectPool{T}"/> with a 
        /// specified delegate for generating new objects.
        /// </summary>
        /// <param name="objectGenerator">The delegate used to generate new objects.</param>
        public ObjectPool(Func<T> objectGenerator)
            : this(objectGenerator, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="ObjectPool{T}"/> with a specified
        /// delegate for generating new objects and an initial size for the pool.
        /// </summary>
        /// <param name="objectGenerator">The delegate used to generate new objects.</param>
        /// <param name="initialSize">The initial number of instance of <typeparamref name="T"/> stored in this pool.</param>
        public ObjectPool(Func<T> objectGenerator, int initialSize)
        {
            if (objectGenerator == null)
            {
                throw new ArgumentNullException(nameof(objectGenerator), $"{nameof(objectGenerator)} parameter cannot be null");
            }
            if (initialSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialSize), $"{nameof(initialSize)} cannot be less than zero");
            }
            _objectGenerator = objectGenerator;

            IList<T> items = new List<T>();
            for (int i = 0; i < initialSize; i++)
            {
                items.Add(_objectGenerator());
            }
            _objects = new ConcurrentQueue<T>(items);
        }

        #region IObjectPool<T> Members
        /// <inheritdoc />
        public int PoolCount
        {
            get { return _objects.Count; }
        }

        /// <inheritdoc />
        public T GetObject()
        {
            T item;

            if (_objects.TryDequeue(out item))
            {
                return item;
            }
            return _objectGenerator();
        }

        /// <inheritdoc />
        public void ReturnObjectToPool(T obj)
        {
            _objects.Enqueue(obj);
        }
        #endregion IObjectPool<T> Members
    }
}
