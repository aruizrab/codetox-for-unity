using System;

namespace Codetox.Pooling
{
    public class ArrayPool<T> : ObjectPool<T>
    {
        private readonly PoolItem[] _pool;

        public ArrayPool(int size, Func<T> onCreatePoolItem, Action<T> onGetPoolItem = null,
            Action<T> onReturnPoolItem = null) : base(size, onCreatePoolItem, onGetPoolItem, onReturnPoolItem)
        {
            _pool = new PoolItem[Size];
            for (var i = 0; i < Size; i++) _pool[i] = new PoolItem(ONCreatePoolItem(), true);
        }


        public override T Get()
        {
            foreach (var poolItem in _pool)
            {
                if (!poolItem.InPool) continue;
                var item = poolItem.Item;
                ONGetPoolItem?.Invoke(item);
                poolItem.InPool = false;
                return item;
            }

            throw new EmptyPoolException();
        }

        public override void Return(T item)
        {
            foreach (var poolItem in _pool)
            {
                if (!poolItem.Item.Equals(item)) continue;
                ONReturnPoolItem?.Invoke(item);
                poolItem.InPool = true;
                break;
            }
        }

        private class PoolItem
        {
            public readonly T Item;
            public bool InPool;

            public PoolItem(T item, bool inPool)
            {
                Item = item;
                InPool = inPool;
            }
        }
    }
}