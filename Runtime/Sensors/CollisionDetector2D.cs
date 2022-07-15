using Codetox.Core;
using Codetox.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace Codetox.Sensors
{
    public class CollisionDetector2D : MonoBehaviour
    {
        [SerializeField] private ValueReference<LayerMask> targetLayers;
        [SerializeField] private CollisionDetectionStrategy detectionStrategy;
        
        public UnityEvent<GameObject> onCollisionEnter;
        public UnityEvent<GameObject> onCollisionExit;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) return;
            OnEnter(other.gameObject);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) return;
            OnExit(other.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!detectionStrategy.HasFlag(CollisionDetectionStrategy.TriggerColliders)) return;
            OnEnter(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!detectionStrategy.HasFlag(CollisionDetectionStrategy.TriggerColliders)) return;
            OnExit(other.gameObject);
        }

        private void OnEnter(GameObject obj)
        {
            if (!obj.IsInLayerMask(targetLayers.Value)) return;
            onCollisionEnter?.Invoke(obj);
        }

        private void OnExit(GameObject obj)
        {
            if (!obj.IsInLayerMask(targetLayers.Value)) return;
            onCollisionExit?.Invoke(obj);
        }
    }
}