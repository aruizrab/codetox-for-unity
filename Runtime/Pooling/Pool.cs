using System;
using JetBrains.Annotations;

namespace Codetox.Pooling
{
    /// <summary>
    ///     Base class for pools.
    /// </summary>
    /// <typeparam name="T">
    ///     <inheritdoc cref="IPool{T}" />
    /// </typeparam>
    public abstract class Pool<T> : IPool<T>
    {
        public static Pool<T> Create(PoolingStrategy strategy, [NotNull] Func<T> createObject, Action<T> onGetObject = null, Action<T> onReturnObject = null,
            Action<T> onRemoveObject = null, int capacity = 10)
        {
            return strategy switch
            {
                PoolingStrategy.FirstInFirstOut => new FifoPool<T>(createObject, onGetObject, onReturnObject,
                    onRemoveObject, capacity),
                PoolingStrategy.LastInFirstOut => new LifoPool<T>(createObject, onGetObject, onReturnObject,
                    onRemoveObject, capacity),
                _ => throw new ArgumentOutOfRangeException(nameof(strategy), strategy, null)
            };
        }

        /// <summary>
        ///     The <see cref="Func{TResult}" /> delegate that creates pool objects.
        /// </summary>
        protected readonly Func<T> CreateObject;

        /// <summary>
        ///     The <see cref="Action{T}" /> delegate that gets called on pool objects when they are retrieved from the pool.
        /// </summary>
        protected readonly Action<T> OnGetObject;

        /// <summary>
        ///     The <see cref="Action{T}" /> delegate that gets called on pool objects when they are returned to the pool.
        /// </summary>
        protected readonly Action<T> OnRemoveObject;

        /// <summary>
        ///     The <see cref="Action{T}" /> delegate that gets called on pool objects when they are removed from the pool.
        /// </summary>
        protected readonly Action<T> OnReturnObject;

        /// <param name="createObject">The <see cref="Func{TResult}" /> delegate that creates pool objects.</param>
        /// <param name="onGetObject">
        ///     The <see cref="Action{T}" /> delegate that gets called on pool objects when they are
        ///     retrieved from the pool.
        /// </param>
        /// <param name="onReturnObject">
        ///     The <see cref="Action{T}" /> delegate that gets called on pool objects when they are
        ///     returned to the pool.
        /// </param>
        /// <param name="onRemoveObject">
        ///     The <see cref="Action{T}" /> delegate that gets called on pool objects when they are
        ///     removed from the pool.
        /// </param>
        /// <param name="capacity">The number of elements that the pool can store.</param>
        /// <exception cref="ArgumentNullException"><c>createObject</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><c>capacity</c> is less than 0.</exception>
        protected Pool([NotNull] Func<T> createObject, Action<T> onGetObject = null, Action<T> onReturnObject = null,
            Action<T> onRemoveObject = null, int capacity = 10)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
            CreateObject = createObject ?? throw new ArgumentNullException(nameof(createObject));
            OnGetObject = onGetObject;
            OnReturnObject = onReturnObject;
            OnRemoveObject = onRemoveObject;
            Capacity = capacity;
        }

        /// <inheritdoc />
        public int Capacity { get; protected set; }

        /// <inheritdoc />
        public abstract int Count { get; }

        /// <inheritdoc />
        public bool IsEmpty => Count == 0;

        /// <inheritdoc />
        public bool IsFull => Count == Capacity;

        /// <inheritdoc />
        public abstract T Get();

        /// <inheritdoc />
        public abstract void Return(T obj);

        /// <inheritdoc />
        public abstract void Clear();

        /// <inheritdoc />
        public abstract bool Contains(T obj);

        /// <inheritdoc />
        public abstract void ForEach(Action<T> action);
    }
}