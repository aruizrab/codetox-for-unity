using System;
using System.Collections.Generic;
using System.Linq;

namespace Codetox.Pooling
{
    public class ListPool<T> : ObjectPool<T>
    {
        protected readonly List<T> Pool;

        public ListPool(int size, Func<T> onCreatePoolItem, Action<T> onGetPoolItem = null,
            Action<T> onReturnPoolItem = null) : base(size, onCreatePoolItem, onGetPoolItem, onReturnPoolItem)
        {
            Pool = new List<T>();
            for (var i = 0; i < Size; i++) Pool.Add(ONCreatePoolItem());
        }

        public override T Get()
        {
            if (Pool.Count == 0) throw new EmptyPoolException();
            var item = Pool.First();
            Pool.Remove(item);
            ONGetPoolItem?.Invoke(item);
            return item;
        }

        public override void Return(T item)
        {
            ONReturnPoolItem?.Invoke(item);
            Pool.Add(item);
        }
    }
}