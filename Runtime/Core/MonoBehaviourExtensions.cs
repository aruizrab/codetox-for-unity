using UnityEngine;

namespace Codetox.Core
{
    public static class MonoBehaviourExtensions
    {
        public static float DistanceTo(this MonoBehaviour mono, Vector3 point)
        {
            return (point - mono.transform.position).magnitude;
        }

        public static float DistanceTo(this MonoBehaviour mono, Transform transform)
        {
            return mono.DistanceTo(transform.position);
        }

        public static float DistanceTo(this MonoBehaviour mono, GameObject gameObject)
        {
            return mono.DistanceTo(gameObject.transform);
        }

        public static Vector3 VectorTo(this MonoBehaviour mono, Vector3 point)
        {
            return point - mono.transform.position;
        }

        public static Vector3 VectorTo(this MonoBehaviour mono, Transform transform)
        {
            return mono.VectorTo(transform.position);
        }

        public static Vector3 VectorTo(this MonoBehaviour mono, GameObject gameObject)
        {
            return mono.VectorTo(gameObject.transform);
        }

        public static Vector3 VectorFrom(this MonoBehaviour mono, Vector3 point)
        {
            return mono.transform.position - point;
        }

        public static Vector3 VectorFrom(this MonoBehaviour mono, Transform transform)
        {
            return mono.VectorFrom(transform.position);
        }

        public static Vector3 VectorFrom(this MonoBehaviour mono, GameObject gameObject)
        {
            return mono.VectorFrom(gameObject.transform);
        }

        public static Vector3 DirectionTo(this MonoBehaviour mono, Vector3 point)
        {
            return mono.VectorTo(point).normalized;
        }

        public static Vector3 DirectionTo(this MonoBehaviour mono, Transform transform)
        {
            return mono.DirectionTo(transform.position);
        }

        public static Vector3 DirectionTo(this MonoBehaviour mono, GameObject gameObject)
        {
            return mono.DirectionTo(gameObject.transform);
        }

        public static Vector3 DirectionFrom(this MonoBehaviour mono, Vector3 point)
        {
            return mono.VectorFrom(point).normalized;
        }

        public static Vector3 DirectionFrom(this MonoBehaviour mono, Transform transform)
        {
            return mono.DirectionFrom(transform.position);
        }

        public static Vector3 DirectionFrom(this MonoBehaviour mono, GameObject gameObject)
        {
            return mono.DirectionFrom(gameObject.transform);
        }

        public static bool IsLayerInLayerMask(int layer, LayerMask layerMask)
        {
            return layerMask == (layerMask | (1 << layer));
        }

        public static CoroutineBuilder Coroutine(this MonoBehaviour mono, bool destroyOnFinish = true,
            bool cancelOnDisable = true)
        {
            return mono.gameObject.AddComponent<CoroutineBuilder>().DestroyOnFinish(destroyOnFinish)
                .CancelOnDisable(cancelOnDisable);
        }
    }
}