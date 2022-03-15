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
        private int _count;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LifoPool{T}" /> class.
        /// </summary>
        /// <inheritdoc />
        public LifoPool([NotNull] Func<T> createObject, Action<T> onGetObject = null, Action<T> onReturnObject = null,
            Action<T> onRemoveObject = null, int capacity = 10) : base(createObject, onGetObject, onReturnObject,
            onRemoveObject, capacity)
        {
            _count = Capacity;
            _array = new T[_count];
            for (var i = 0; i < _count; i++) _array[i] = CreateObject();
        }

        /// <inheritdoc />
        public override int Count => _count;

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
                _count--;
                obj = _array[_count];
            }

            OnGetObject?.Invoke(obj);
            return obj;
        }

        /// <inheritdoc />
        public override void Return(T obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (IsFull)
            {
                OnRemoveObject?.Invoke(obj);
                return;
            }

            OnReturnObject?.Invoke(obj);
            _array[_count] = obj;
            _count++;
        }

        /// <inheritdoc />
        public override void Clear()
        {
            ForEach(obj => OnRemoveObject?.Invoke(obj));
            _count = 0;
        }

        /// <inheritdoc />
        public override void ForEach(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            for (var i = 0; i < _count; i++) action(_array[i]);
        }

        /// <inheritdoc />
        public override bool Contains(T obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            for (var i = 0; i < _count; i++)
                if (_array[i].Equals(obj))
                    return true;
            return false;
        }
    }
}