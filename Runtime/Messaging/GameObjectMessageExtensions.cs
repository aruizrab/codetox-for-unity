using System;
using UnityEngine;

namespace Codetox.Messaging
{
    public static class GameObjectMessageExtensions
    {
        public static void Send<T>(this GameObject gameObject, Action<T> action,
            MessageScope scope = MessageScope.GameObject)
        {
            T t;
            switch (scope)
            {
                case MessageScope.GameObject:
                    if (!gameObject.TryGetComponent(out t)) return;
                    action?.Invoke(t);
                    break;
                case MessageScope.Children:
                    t = gameObject.GetComponentInChildren<T>();
                    if (t == null) return;
                    action?.Invoke(t);
                    break;
                case MessageScope.Parents:
                    t = gameObject.GetComponentInParent<T>();
                    if (t == null) return;
                    action?.Invoke(t);
                    break;
                case MessageScope.Hierarchy:
                    t = gameObject.transform.root.GetComponentInChildren<T>();
                    if (t == null) return;
                    action?.Invoke(t);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(scope), scope, null);
            }
        }

        public static void SendAll<T>(this GameObject gameObject, Action<T> action,
            MessageScope scope = MessageScope.GameObject)
        {
            var t = scope switch
            {
                MessageScope.GameObject => gameObject.GetComponents<T>(),
                MessageScope.Children => gameObject.GetComponentsInChildren<T>(),
                MessageScope.Parents => gameObject.GetComponentsInParent<T>(),
                MessageScope.Hierarchy => gameObject.transform.root.GetComponentsInChildren<T>(),
                _ => throw new ArgumentOutOfRangeException(nameof(scope), scope, null)
            };
            var length = t.Length;
            for (var i = 0; i < length; i++) action?.Invoke(t[i]);
        }
    }
}