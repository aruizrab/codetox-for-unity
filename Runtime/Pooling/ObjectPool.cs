using System;
using JetBrains.Annotations;

namespace Codetox.Pooling
{
    public abstract class ObjectPool<T> : IObjectPool<T>
    {
        protected readonly Func<T> ONCreatePoolItem;
        protected readonly Action<T> ONGetPoolItem;
        protected readonly Action<T> ONReturnPoolItem;
        protected readonly int Size;

        protected ObjectPool(int size, [NotNull] Func<T> onCreatePoolItem, [CanBeNull] Action<T> onGetPoolItem = null,
            [CanBeNull] Action<T> onReturnPoolItem = null)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size), "Pool size cannot be negative.");
            Size = size;
            ONCreatePoolItem = onCreatePoolItem ?? throw new ArgumentNullException(nameof(onCreatePoolItem));
            ONGetPoolItem = onGetPoolItem;
            ONReturnPoolItem = onReturnPoolItem;
        }

        public virtual T Get()
        {
            throw new NotImplementedException();
        }

        public virtual void Return(T item)
        {
            throw new NotImplementedException();
        }
    }
}