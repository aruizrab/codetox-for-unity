using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Codetox.Pooling
{
    public abstract class ObjectPool<T> : MonoBehaviour, IPool<T> where T : Object
    {
        [SerializeField] private T poolObject;
        [SerializeField] [Min(1)] private int capacity = 1;
        [SerializeField] private PoolingStrategy strategy;

        private IPool<T> _pool;

        private void OnEnable()
        {
            _pool = Pool<T>.Create(strategy, CreateObject, OnGetObject, OnReturnObject, OnRemoveObject, capacity);
        }

        private void OnDisable()
        {
            Clear();
        }

        public int Capacity => _pool.Capacity;
        public int Count => _pool.Count;
        public bool IsEmpty => _pool.IsEmpty;
        public bool IsFull => _pool.IsFull;

        public T Get()
        {
            return _pool.Get();
        }

        public void Return(T obj)
        {
            _pool.Return(obj);
        }

        public void Clear()
        {
            _pool.Clear();
        }

        public bool Contains(T obj)
        {
            return _pool.Contains(obj);
        }

        public void ForEach(Action<T> action)
        {
            _pool.ForEach(action);
        }

        protected virtual T CreateObject()
        {
            return Instantiate(poolObject);
        }

        protected virtual void OnGetObject(T obj)
        {
        }

        protected virtual void OnReturnObject(T obj)
        {
        }

        protected virtual void OnRemoveObject(T obj)
        {
            Destroy(obj);
        }
    }
}