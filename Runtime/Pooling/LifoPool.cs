using System;
using JetBrains.Annotations;

namespace Codetox.Pooling
{
    /// <summary>
    ///     Represents a last-in, first-out pool.
    /// </summary>
    /// <typeparam name="T">
    ///     <inheritdoc cref="IPool{T}" />
    /// </typeparam>
    public class LifoPool<T> : Pool<T>
    {
        private readonly T[] _array;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LifoPool{T}" /> class.
        /// </summary>
        /// <inheritdoc />
        public LifoPool([NotNull] Func<T> createObject, Action<T> onGetObject = null, Action<T> onReturnObject = null,
            Action<T> onRemoveObject = null, int capacity = 10) : base(createObject, onGetObject, onReturnObject,
            onRemoveObject, capacity)
        {
            _array = new T[Capacity];
            for (var i = 0; i < Capacity; i++) _array[i] = CreateObject();
        }

        /// <inheritdoc />
        public override T Get()
        {
            T obj;
            if (IsEmpty)
            {
                obj = CreateObject();
            }
            else
            {
                Count--;
                obj = _array[Count];
            }

            OnGetObject?.Invoke(obj);
            return obj;
        }

        /// <inheritdoc />
        public override void Return(T obj)
        {
            if (IsFull)
            {
                OnRemoveObject?.Invoke(obj);
                return;
            }

            OnReturnObject?.Invoke(obj);
            _array[Count] = obj;
            Count++;
        }

        /// <inheritdoc />
        public override void Clear()
        {
            ForEach(obj => OnRemoveObject?.Invoke(obj));
            Count = 0;
        }

        /// <inheritdoc />
        public override void ForEach(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            for (var i = 0; i < Count; i++) action(_array[i]);
        }

        /// <inheritdoc />
        public override bool Contains(T obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            for (var i = 0; i < Count; i++)
                if (_array[i].Equals(obj))
                    return true;
            return false;
        }
    }
}