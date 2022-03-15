using System;
using JetBrains.Annotations;

namespace Codetox.Pooling
{
    /// <summary>
    ///     Represents a first-in, first-out pool.
    /// </summary>
    /// <typeparam name="T">
    ///     <inheritdoc cref="IPool{T}" />
    /// </typeparam>
    public sealed class FifoPool<T> : Pool<T>
    {
        private readonly T[] _array;
        private int _firstIndex;
        private int _lastIndex;
        private int _count;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FifoPool{T}" /> class.
        /// </summary>
        /// <inheritdoc />
        public FifoPool([NotNull] Func<T> createObject, Action<T> onGetObject = null, Action<T> onReturnObject = null,
            Action<T> onRemoveObject = null, int capacity = 10) : base(createObject, onGetObject, onReturnObject,
            onRemoveObject, capacity)
        {
            _count = Capacity;
            _array = new T[_count];
            for (var i = 0; i < _count; i++) _array[i] = CreateObject();

            _firstIndex = _lastIndex = 0;
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
                if (IsFull) _lastIndex = _firstIndex;
                obj = _array[_firstIndex];
                _count--;
                _firstIndex++;
                if (_firstIndex >= Capacity) _firstIndex = 0;
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
            _array[_lastIndex] = obj;
            _count++;
            _lastIndex++;
            if (_lastIndex >= Capacity) _firstIndex = 0;
        }

        /// <inheritdoc />
        public override void Clear()
        {
            ForEach(obj => OnRemoveObject?.Invoke(obj));
            _count = _firstIndex = _lastIndex = 0;
        }

        /// <inheritdoc />
        public override void ForEach(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            var iteration = 0;
            var index = _firstIndex;
            var capacity = Capacity;
            while (iteration < _count)
            {
                if (index >= capacity) index = 0;
                action(_array[index]);
                iteration++;
                index++;
            }
        }

        /// <inheritdoc />
        public override bool Contains(T obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            var iteration = 0;
            var index = _firstIndex;
            var capacity = Capacity;
            while (iteration < _count)
            {
                if (index >= capacity) index = 0;
                if (_array[index].Equals(obj)) return true;
                iteration++;
                index++;
            }

            return false;
        }
    }
}