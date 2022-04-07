using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Codetox.Core
{
    public static class TransformExtensions
    {
        public static Vector3 VectorTo(this Transform transform, Vector3 point)
        {
            return point - transform.position;
        }

        public static Vector3 VectorTo(this Transform transform, [NotNull] Transform other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return transform.VectorTo(other.position);
        }

        public static Vector3 VectorTo(this Transform transform, [NotNull] GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            return transform.VectorTo(gameObject.transform);
        }

        public static Vector3 VectorFrom(this Transform transform, Vector3 point)
        {
            return transform.position - point;
        }

        public static Vector3 VectorFrom(this Transform transform, [NotNull] Transform other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return transform.VectorFrom(other.position);
        }

        public static Vector3 VectorFrom(this Transform transform, [NotNull] GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            return transform.VectorFrom(gameObject.transform);
        }

        public static Vector3 DirectionTo(this Transform transform, Vector3 point)
        {
            return transform.VectorTo(point).normalized;
        }

        public static Vector3 DirectionTo(this Transform transform, [NotNull] Transform other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return transform.DirectionTo(other.position);
        }

        public static Vector3 DirectionTo(this Transform transform, [NotNull] GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            return transform.DirectionTo(gameObject.transform);
        }

        public static Vector3 DirectionFrom(this Transform transform, Vector3 point)
        {
            return transform.VectorFrom(point).normalized;
        }

        public static Vector3 DirectionFrom(this Transform transform, [NotNull] Transform other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return transform.DirectionFrom(other.position);
        }

        public static Vector3 DirectionFrom(this Transform transform, [NotNull] GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            return transform.DirectionFrom(gameObject.transform);
        }

        public static float DistanceTo(this Transform transform, Vector3 point)
        {
            return transform.VectorTo(point).magnitude;
        }

        public static float DistanceTo(this Transform transform, [NotNull] Transform other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return transform.DistanceTo(other.position);
        }

        public static float DistanceTo(this Transform transform, [NotNull] GameObject gameObject)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            return transform.DistanceTo(gameObject.transform);
        }

        public static bool IsInLayerMask(this Transform transform, LayerMask layerMask)
        {
            return layerMask == (layerMask | (1 << transform.gameObject.layer));
        }

        public static CoroutineBuilder Coroutine(this Transform transform, bool destroyOnFinish = true,
            bool cancelOnDisable = true)
        {
            var coroutineBuilder = transform.gameObject.AddComponent<CoroutineBuilder>()
                .DestroyOnFinish(destroyOnFinish)
                .CancelOnDisable(cancelOnDisable);
            coroutineBuilder.hideFlags = HideFlags.HideInInspector;
            return coroutineBuilder;
        }
    }
}