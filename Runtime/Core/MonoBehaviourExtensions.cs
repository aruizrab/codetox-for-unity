using UnityEngine;

namespace Codetox.Core
{
    /// <summary>
    ///     Extends MonoBehaviour class adding utility methods.
    /// </summary>
    /// <footer>
    ///     <a href="https://github.com/aruizrab/codetox-for-unity/wiki/MonoBehaviour-extended-functionalities">
    ///         Check the
    ///         documentation for more
    ///     </a>
    /// </footer>
    public static class MonoBehaviourExtensions
    {
        /// <summary>
        ///     Returns a vector representing the direction and distance from this game object to a point in space.
        /// </summary>
        /// <footer>
        ///     <a href="https://github.com/aruizrab/codetox-for-unity/wiki/MonoBehaviour-extended-functionalities#vectorto">
        ///         Check the
        ///         documentation for more
        ///     </a>
        /// </footer>
        public static Vector3 VectorTo(this MonoBehaviour mono, Vector3 point)
        {
            return point - mono.transform.position;
        }

        /// <summary>
        ///     Returns a vector representing the direction and distance from this game object to a transform.
        /// </summary>
        /// <footer>
        ///     <a href="https://github.com/aruizrab/codetox-for-unity/wiki/MonoBehaviour-extended-functionalities#vectorto">
        ///         Check the
        ///         documentation for more
        ///     </a>
        /// </footer>
        public static Vector3 VectorTo(this MonoBehaviour mono, Transform transform)
        {
            return mono.VectorTo(transform.position);
        }

        /// <summary>
        ///     Returns a vector representing the direction and distance from this game object to other game object.
        /// </summary>
        /// <footer>
        ///     <a href="https://github.com/aruizrab/codetox-for-unity/wiki/MonoBehaviour-extended-functionalities#vectorto">
        ///         Check the
        ///         documentation for more
        ///     </a>
        /// </footer>
        public static Vector3 VectorTo(this MonoBehaviour mono, GameObject gameObject)
        {
            return mono.VectorTo(gameObject.transform);
        }

        /// <summary>
        ///     Returns a vector representing the direction and distance from a point in space to this game object.
        /// </summary>
        public static Vector3 VectorFrom(this MonoBehaviour mono, Vector3 point)
        {
            return mono.transform.position - point;
        }

        /// <summary>
        ///     Returns a vector representing the direction and distance from a transform to this game object.
        /// </summary>
        public static Vector3 VectorFrom(this MonoBehaviour mono, Transform transform)
        {
            return mono.VectorFrom(transform.position);
        }

        /// <summary>
        ///     Returns a vector representing the direction and distance from a game object to this game object.
        /// </summary>
        public static Vector3 VectorFrom(this MonoBehaviour mono, GameObject gameObject)
        {
            return mono.VectorFrom(gameObject.transform);
        }

        /// <summary>
        ///     Returns a float representing the distance between this game object and a point in space.
        /// </summary>
        public static float DistanceTo(this MonoBehaviour mono, Vector3 point)
        {
            return mono.VectorTo(point).magnitude;
        }

        /// <summary>
        ///     Returns a normalized vector representing the direction from this game object to a transform.
        /// </summary>
        public static Vector3 DirectionTo(this MonoBehaviour mono, Transform transform)
        {
            return mono.DirectionTo(transform.position);
        }

        /// <summary>
        ///     Returns a normalized vector representing the direction from this game object to another game object.
        /// </summary>
        public static Vector3 DirectionTo(this MonoBehaviour mono, GameObject gameObject)
        {
            return mono.DirectionTo(gameObject.transform);
        }

        /// <summary>
        ///     Returns a normalized vector representing the direction from a point in space to this game object.
        /// </summary>
        public static Vector3 DirectionFrom(this MonoBehaviour mono, Vector3 point)
        {
            return mono.VectorFrom(point).normalized;
        }

        /// <summary>
        ///     Returns a normalized vector representing the direction from a transform to this game object.
        /// </summary>
        public static Vector3 DirectionFrom(this MonoBehaviour mono, Transform transform)
        {
            return mono.DirectionFrom(transform.position);
        }

        /// <summary>
        ///     Returns a normalized vector representing the direction from a game object to this game object.
        /// </summary>
        public static Vector3 DirectionFrom(this MonoBehaviour mono, GameObject gameObject)
        {
            return mono.DirectionFrom(gameObject.transform);
        }
        
        /// <summary>
        ///     Returns a float representing the distance between this game object and a transform.
        /// </summary>
        public static float DistanceTo(this MonoBehaviour mono, Transform transform)
        {
            return mono.DistanceTo(transform.position);
        }

        /// <summary>
        ///     Returns a float representing the distance between this game object and another game object.
        /// </summary>
        public static float DistanceTo(this MonoBehaviour mono, GameObject gameObject)
        {
            return mono.DistanceTo(gameObject.transform);
        }

        /// <summary>
        ///     Returns a normalized vector representing the direction from this game object to a point in space.
        /// </summary>
        public static Vector3 DirectionTo(this MonoBehaviour mono, Vector3 point)
        {
            return mono.VectorTo(point).normalized;
        }

        /// <summary>
        ///     Returns <c>true</c> if the specified <c>layer</c> is included in the specified <c>layerMask</c>, <c>false</c>
        ///     otherwise.
        /// </summary>
        public static bool IsLayerInLayerMask(this MonoBehaviour mono, int layer, LayerMask layerMask)
        {
            return layerMask == (layerMask | (1 << layer));
        }

        /// <summary>
        ///     Adds a new <c>CoroutineBuilder</c> component to this game object, configures the <c>CoroutineBuilder</c> component
        ///     with the specified parameters, and returns a reference to the component.
        /// </summary>
        /// <param name="destroyOnFinish">
        ///     Configures the <c>CoroutineBuilder</c> component to destroyed itself once the coroutine
        ///     execution is finished. Default value is <c>true</c>.
        /// </param>
        /// <param name="cancelOnDisable">
        ///     Configures the <c>CoroutineBuilder</c> component to cancel the coroutine execution if the
        ///     script or game object is disabled. Default value is <c>true</c>.
        /// </param>
        /// <returns>A reference to the created <c>CoroutineBuilder</c> component.</returns>
        public static CoroutineBuilder Coroutine(this MonoBehaviour mono, bool destroyOnFinish = true,
            bool cancelOnDisable = true)
        {
            return mono.gameObject.AddComponent<CoroutineBuilder>().DestroyOnFinish(destroyOnFinish)
                .CancelOnDisable(cancelOnDisable);
        }
    }
}