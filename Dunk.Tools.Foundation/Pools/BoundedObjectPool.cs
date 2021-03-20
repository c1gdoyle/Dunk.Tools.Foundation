using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Dunk.Tools.Foundation.Pools
{
    /// <summary>
    /// An implementation of <see cref="IBoundedObjectPool{T}"/> that supports an 
    /// upper and lower limit for the number of items supported in the pool.
    /// </summary>
    /// <typeparam name="T">The type of object that will be managed by the pool.</typeparam>
    public class BoundedObjectPool<T> : IBoundedObjectPool<T>
        where T : class, IObjectPoolItem
    {
        private const int DefaultMinimumPoolSize = 5;
        private const int DefaultMaximumPoolSize = 25;

        private readonly int _minimumPoolSize;
        private readonly int _maximumPoolSize;

        private readonly ConcurrentQueue<T> _objects;
        private readonly Func<T> _objectGenerator;

        /// <summary>
        /// An indication flag that states whether an adjusting operation is currently in progress.
        /// This is done as an Interlocked CAS (Compare-And-Swap) operation.
        /// 
        /// See Ofir Makmal's article at
        /// https://www.codeproject.com/Articles/535735/Implementing-a-Generic-Object-Pool-in-NET
        /// </summary>
        private int _adjustPoolSizeIsInProcessCASFlag = 0; // 0 indicates state is false

        /// <summary>
        /// Initialises a new instance of <see cref="BoundedObjectPool{T}"/> with a specified 
        /// delegate for generating new objects and default minimum and maximum pool size.
        /// </summary>
        /// <param name="objectGenerator">The delegate used to generate new objects.</param>
        public BoundedObjectPool(Func<T> objectGenerator)
            : this(objectGenerator, DefaultMinimumPoolSize, DefaultMaximumPoolSize)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="BoundedObjectPool{T}"/> with a specified 
        /// delegate for generating new objects and minimum and maximum pool size.
        /// </summary>
        /// <param name="objectGenerator">The delegate used to generate new objects.</param>
        /// <param name="minimumPoolSize">The minimum pool size.</param>
        /// <param name="maximumPoolSize">The maximum pool size.</param>
        public BoundedObjectPool(Func<T> objectGenerator, int minimumPoolSize, int maximumPoolSize)
        {
            if (objectGenerator == null)
            {
                throw new ArgumentNullException(nameof(objectGenerator), $"{nameof(objectGenerator)} parameter cannot be null.");
            }
            _objectGenerator = objectGenerator;
            ValidatePoolSizes(minimumPoolSize, maximumPoolSize);
            _minimumPoolSize = minimumPoolSize;
            _maximumPoolSize = maximumPoolSize;

            _objects = new ConcurrentQueue<T>();

            AdjustPoolSizeToBounds();
        }

        #region IBoundedObjectPool<T> Members
        /// <inheritdoc />
        public int MaximumPoolSize
        {
            get { return _maximumPoolSize; }
        }

        /// <inheritdoc />
        public int MinimumPoolSize
        {
            get { return _minimumPoolSize; }
        }

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
                //Invoke AdjustPoolSize on another thread
                ThreadPool.QueueUserWorkItem(new WaitCallback(o => AdjustPoolSizeToBounds()));

                return item;
            }
            return _objectGenerator();
        }

        /// <inheritdoc />
        public void ReturnObjectToPool(T obj)
        {
            // Checking that the pool is not full
            if (PoolCount < MaximumPoolSize)
            {
                //Adding object back to pool
                obj.ResetState();
                _objects.Enqueue(obj);
            }
            else
            {
                //The Pool's upper limit has been exceeded. So dump the obj
                DestroyPoolObject(obj);
            }

            ThreadPool.QueueUserWorkItem(new WaitCallback(o => AdjustPoolSizeToBounds()));
        }
        #endregion IBoundedObjectPool<T> Members

        private void AdjustPoolSizeToBounds()
        {
            //If there is an adjusting operation in progress just skip and return
            if (Interlocked.CompareExchange(ref _adjustPoolSizeIsInProcessCASFlag, 1, 0) == 0)
            {
                //If we have reached this point we have set _adjustPoolSizeIsInProcessCASFlag to 1 (true) using CAS function
                //We can now safely adjsut the pool size without interference

                //Adjusting
                while (PoolCount < MinimumPoolSize)
                {
                    _objects.Enqueue(_objectGenerator());
                }
                while (PoolCount > MaximumPoolSize)
                {
                    T dequeuedObj;
                    if (_objects.TryDequeue(out dequeuedObj))
                    {
                        DestroyPoolObject(dequeuedObj);
                    }
                }
                //Finished adjusting, allowing additional callers to enter when needed
                _adjustPoolSizeIsInProcessCASFlag = 0;
            }
        }

        private void DestroyPoolObject(T objectToDestroy)
        {
            objectToDestroy.ReleaseResources();
        }

        private void ValidatePoolSizes(int minimumPoolSize, int maximumPoolSize)
        {
            if (minimumPoolSize < 0)
            {
                throw new ArgumentException("Minimum pool size must be greater than or equal to zero", nameof(minimumPoolSize));
            }
            if (maximumPoolSize < 1)
            {
                throw new ArgumentException("Maximum pool size must be greater than or equal to one", nameof(maximumPoolSize));
            }
            if (minimumPoolSize > maximumPoolSize)
            {
                throw new ArgumentException("Minimum pool size cannot be greater than Maximum pool size");
            }
        }

    }
}
