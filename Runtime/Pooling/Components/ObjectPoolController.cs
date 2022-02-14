using System;
using Codetox.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Codetox.Pooling.Components
{
    public abstract class ObjectPoolController<T> : MonoBehaviour, IObjectPool<T> where T : Object
    {
        [SerializeField] protected T objectToPool;
        [SerializeField] private int poolSize;
        [SerializeField] private bool isPoolExpandable;

        private IObjectPool<T> _pool;

        private void Awake()
        {
            if (isPoolExpandable)
                _pool = new ExpandablePool<T>(poolSize, OnCreatePoolItem, OnGetPoolItem, OnReturnPoolItem);
            else
                _pool = new ArrayPool<T>(poolSize, OnCreatePoolItem, OnGetPoolItem, OnReturnPoolItem);
        }

        public T Get()
        {
            return _pool.Get();
        }

        public void Return(T item)
        {
            _pool.Return(item);
        }

        public void Return(T item, float secondsDelay)
        {
            this.Coroutine().WaitForSeconds(secondsDelay).Invoke(() => _pool.Return(item)).Run();
        }

        public void Return(T item, Func<bool> predicate)
        {
            this.Coroutine().WaitUntil(predicate).Invoke(() => _pool.Return(item)).Run();
        }

        protected abstract T OnCreatePoolItem();

        protected abstract void OnGetPoolItem(T item);

        protected abstract void OnReturnPoolItem(T item);
    }
}