using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Codetox.Core
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _instance;
        private static readonly object Lock = new object();
        protected static bool IsApplicationQuitting;

        public static bool TryGetInstance(out T instance)
        {
            if (IsApplicationQuitting)
            {
                instance = null;
                return false;
            }
            lock (Lock)
            {
                if (!_instance)
                {
                    var instances = FindObjectsOfType<T>();
                    _instance = instances.Length switch
                    {
                        0 => new GameObject(typeof(T).Name).AddComponent<T>(),
                        1 => instances[0],
                        _ => DestroyDuplicates(instances)
                    };
                    _instance.Init();
                }
                instance = _instance;
                return true;
            }
        }

        private void OnApplicationQuit()
        {
            IsApplicationQuitting = true;
        }

        protected virtual void Init()
        {
        }

        private static T DestroyDuplicates(T[] instances)
        {
            var length = instances.Length;
#if UNITY_EDITOR
            Debug.LogWarning(
                $"{length} singleton instances of type {typeof(T)} have been found in the scene. The first instance will be used, the rest will be destroyed.");
#endif
            for (var i = length - 1; i >= 1; i--) Destroy(instances[i]);
            return instances[0];
        }
    }
}