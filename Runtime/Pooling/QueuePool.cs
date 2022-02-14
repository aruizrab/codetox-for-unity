using System;
using System.Collections.Generic;

namespace Codetox.Pooling
{
    public class QueuePool<T> : ObjectPool<T>
    {
        private readonly Queue<T> _pool;

        public QueuePool(int size, Func<T> onCreatePoolItem, Action<T> onGetPoolItem = null,
            Action<T> onReturnPoolItem = null) : base(size, onCreatePoolItem, onGetPoolItem, onReturnPoolItem)
        {
            _pool = new Queue<T>();
            for (var i = 0; i < Size; i++) _pool.Enqueue(ONCreatePoolItem());
        }


        public override T Get()
        {
            try
            {
                var item = _pool.Dequeue();
                ONGetPoolItem?.Invoke(item);
                return item;
            }
            catch (InvalidOperationException e)
            {
                throw new EmptyPoolException();
            }
        }

        public override void Return(T item)
        {
            ONReturnPoolItem?.Invoke(item);
            _pool.Enqueue(item);
        }
    }
}