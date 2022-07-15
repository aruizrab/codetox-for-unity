using Codetox.Core;
using Codetox.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace Codetox.Sensors
{
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private ValueReference<LayerMask> targetLayers;
        [SerializeField] private CollisionDetectionStrategy detectionStrategy;
        
        public UnityEvent<GameObject> onCollisionEnter;
        public UnityEvent<GameObject> onCollisionExit;
        
        private void OnCollisionEnter(Collision other)
        {
            if (!detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) return;
            OnEnter(other.gameObject);
        }

        private void OnCollisionExit(Collision other)
        {
            if (!detectionStrategy.HasFlag(CollisionDetectionStrategy.Colliders)) return;
            OnExit(other.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!detectionStrategy.HasFlag(CollisionDetectionStrategy.TriggerColliders)) return;
            OnEnter(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
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