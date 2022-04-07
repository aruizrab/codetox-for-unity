using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Codetox.Core
{
    public static class GameObjectExtensions
    {
        public static Vector3 VectorTo(this GameObject gameObject, Vector3 point)
        {
            return point - gameObject.transform.position;
        }

        public static Vector3 VectorTo(this GameObject gameObject, [NotNull] Transform transform)
        {
            if (transform == null) throw new ArgumentNullException(nameof(transform));
            return gameObject.VectorTo(transform.position);
        }

        public static Vector3 VectorTo(this GameObject gameObject, [NotNull] GameObject other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return gameObject.VectorTo(other.transform);
        }

        public static Vector3 VectorFrom(this GameObject gameObject, Vector3 point)
        {
            return gameObject.transform.position - point;
        }

        public static Vector3 VectorFrom(this GameObject gameObject, [NotNull] Transform transform)
        {
            if (transform == null) throw new ArgumentNullException(nameof(transform));
            return gameObject.VectorFrom(transform.position);
        }

        public static Vector3 VectorFrom(this GameObject gameObject, [NotNull] GameObject other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return gameObject.VectorFrom(other.transform);
        }

        public static Vector3 DirectionTo(this GameObject gameObject, Vector3 point)
        {
            return gameObject.VectorTo(point).normalized;
        }

        public static Vector3 DirectionTo(this GameObject gameObject, [NotNull] Transform transform)
        {
            if (transform == null) throw new ArgumentNullException(nameof(transform));
            return gameObject.DirectionTo(transform.position);
        }

        public static Vector3 DirectionTo(this GameObject gameObject, [NotNull] GameObject other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return gameObject.DirectionTo(other.transform);
        }

        public static Vector3 DirectionFrom(this GameObject gameObject, Vector3 point)
        {
            return gameObject.VectorFrom(point).normalized;
        }

        public static Vector3 DirectionFrom(this GameObject gameObject, [NotNull] Transform transform)
        {
            if (transform == null) throw new ArgumentNullException(nameof(transform));
            return gameObject.DirectionFrom(transform.position);
        }

        public static Vector3 DirectionFrom(this GameObject gameObject, [NotNull] GameObject other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return gameObject.DirectionFrom(other.transform);
        }

        public static float DistanceTo(this GameObject gameObject, Vector3 point)
        {
            return gameObject.VectorTo(point).magnitude;
        }

        public static float DistanceTo(this GameObject gameObject, [NotNull] Transform transform)
        {
            if (transform == null) throw new ArgumentNullException(nameof(transform));
            return gameObject.DistanceTo(transform.position);
        }

        public static float DistanceTo(this GameObject gameObject, [NotNull] GameObject other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return gameObject.DistanceTo(other.transform);
        }

        public static bool IsInLayerMask(this GameObject gameObject, LayerMask layerMask)
        {
            return layerMask == (layerMask | (1 << gameObject.layer));
        }

        public static CoroutineBuilder Coroutine(this GameObject gameObject, bool destroyOnFinish = true,
            bool cancelOnDisable = true)
        {
            var coroutineBuilder = gameObject.AddComponent<CoroutineBuilder>()
                .DestroyOnFinish(destroyOnFinish)
                .CancelOnDisable(cancelOnDisable);
            coroutineBuilder.hideFlags = HideFlags.HideInInspector;
            return coroutineBuilder;
        }
    }
}