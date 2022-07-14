using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codetox.RuntimeSets
{
    public abstract class RuntimeSet<T> : CustomScriptableObject, IList<T>
    {
        [SerializeField] private List<T> items;

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (items.Contains(item)) return;
            items.Add(item);
            OnItemAdded?.Invoke(item);
        }

        public void Clear()
        {
            items.ForEach(item => OnItemRemoved?.Invoke(item));
            items.Clear();
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if (!items.Remove(item)) return false;
            OnItemRemoved?.Invoke(item);
            return true;
        }

        public int Count => items.Count;
        public bool IsReadOnly => false;

        public int IndexOf(T item)
        {
            return items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            var item = items[index];
            items.RemoveAt(index);
            OnItemRemoved?.Invoke(item);
        }

        public T this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }

        public event Action<T> OnItemAdded, OnItemRemoved;
    }
}