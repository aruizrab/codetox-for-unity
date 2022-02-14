using System;

namespace Codetox.Pooling
{
    public class ExpandablePool<T> : ListPool<T>
    {
        public ExpandablePool(int size, Func<T> onCreatePoolItem, Action<T> onGetPoolItem = null,
            Action<T> onReturnPoolItem = null) : base(size, onCreatePoolItem, onGetPoolItem, onReturnPoolItem)
        {
        }

        public override T Get()
        {
            try
            {
                return base.Get();
            }
            catch (EmptyPoolException e)
            {
                Pool.Add(ONCreatePoolItem());
                return base.Get();
            }
        }
    }
}